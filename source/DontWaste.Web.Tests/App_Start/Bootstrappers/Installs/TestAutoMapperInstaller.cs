﻿using System.Linq;
using AutoMapper;
using Castle.Core.Internal;
using Castle.Windsor;
using DontWaste.Tests.Common.Helpers;
using DontWaste.Web.Bootstrappers.Installers;
using NUnit.Framework;

namespace DontWaste.Web.Tests.Bootstrappers.Installs
{
    [TestFixture]
    public class TestAutoMapperInstaller
    {
        private IWindsorContainer _container;
        private readonly WindsorTestHelpers _windsorTestHelpers = new WindsorTestHelpers();

        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            _container = _windsorTestHelpers.CreateContainerWith(new AutoMapperInstaller());
        }

        [TestFixtureTearDown]
        public void FixtureTearDown()
        {
            _container?.Dispose();
        }

        [Test]
        public void Install_GivenProfile_ShouldHaveImplementationForAll()
        {
            //---------------Set up test pack-------------------
            var allHandlers = _windsorTestHelpers.GetAllHandlers(_container);

            var profileHandlers = _windsorTestHelpers.GetHandlersFor(typeof(Profile), _container);
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var controllerHandlers = _windsorTestHelpers.GetHandlersFor<Profile>(_container);
            //---------------Test Result -----------------------
            Assert.That(allHandlers, Is.Not.Empty);
            Assert.That(controllerHandlers, Is.EqualTo(profileHandlers));
        }

        [Test]
        public void Install_GivenProfile_AllProfilesAreRegistered()
        {
            //---------------Set up test pack-------------------
            var allProfiles = _windsorTestHelpers.GetPublicClassesFromApplicationAssembly(typeof(AutoMapperInstaller), c => c.Is<Profile>());
            var registeredProfiles = _windsorTestHelpers.GetImplementationTypesFor(typeof(Profile), _container);
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------

            //---------------Test Result -----------------------
            Assert.AreEqual(allProfiles, registeredProfiles);
        }

        [Test]
        public void Install_AllProfilesExposeProfileExposeThemselvesAsService()
        {
            //---------------Set up test pack-------------------
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var profilesWithWrongService = _windsorTestHelpers.GetHandlersFor(typeof(Profile), _container)
                .Where(c => !c.ComponentModel.Services.SequenceEqual(new[] { typeof(Profile) }))
                .ToArray();
            //---------------Test Result -----------------------
            Assert.IsEmpty(profilesWithWrongService);
        }
    }
}