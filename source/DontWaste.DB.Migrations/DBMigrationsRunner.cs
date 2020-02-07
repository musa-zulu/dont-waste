﻿using System.Diagnostics;
using System.Reflection;
using FluentMigrator;
using FluentMigrator.Runner;
using FluentMigrator.Runner.Announcers;
using FluentMigrator.Runner.Initialization;
using FluentMigrator.Runner.Processors.SqlServer;

namespace DontWaste.DB.Migrations
{
    public class DBMigrationsRunner
    {
        private class MigrationOptions : IMigrationProcessorOptions
        {
            public bool PreviewOnly { get; private set; }
            public int Timeout { get; private set; }
            public string ProviderSwitches { get; private set; }
            public MigrationOptions(bool previewOnly = false, string providerSwitches = null, int timeout = 60)
            {
                this.PreviewOnly = previewOnly;
                this.ProviderSwitches = providerSwitches;
                this.Timeout = timeout;
            }
        }
        private string _connectionString;

        public DBMigrationsRunner(string connectionString)
        {
            this._connectionString = connectionString;
        }

        public void MigrateToLatest()
        {
            var asm = Assembly.GetExecutingAssembly();
            var announcer = new TextWriterAnnouncer((str) =>
            {
                Debug.WriteLine(str);
            });
            var context = new RunnerContext(announcer);
            var options = new MigrationOptions();
            var factory = new SqlServer2012ProcessorFactory();
            var processor = factory.Create(this._connectionString, announcer, options);
            var runner = new MigrationRunner(asm, context, processor);

            runner.MigrateUp(true);
        }
    }
}
