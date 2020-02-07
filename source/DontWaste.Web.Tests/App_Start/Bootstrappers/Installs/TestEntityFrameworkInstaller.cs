﻿using System.Linq;
using Castle.Core;
using Castle.Core.Internal;
using Castle.Windsor;
using DontWaste.DB;
using DontWaste.Tests.Common.Helpers;
using DontWaste.Web.Bootstrappers.Installers;
using NUnit.Framework;

namespace DontWaste.Web.Tests.Bootstrappers.Installs
{
    [TestFixture]
    public class TestEntityFrameworkInstaller
    {
        private IWindsorContainer _container;
        private readonly WindsorTestHelpers _windsorTestHelpers = new WindsorTestHelpers();

        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            _container = _windsorTestHelpers.CreateContainerWith(new EntityFrameworkInstaller());
        }

        [TestFixtureTearDown]
        public void FixtureTearDown()
        {
            _container?.Dispose();
        }

        [Test]
        public void Install_Given_IDontWasteDbContext_ShouldHaveImpelemtationForAll()
        {
            //---------------Set up test pack-------------------
            var allHandlers = _windsorTestHelpers.GetAllHandlers(_container);
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var controllerHandlers = _windsorTestHelpers.GetHandlersFor<IDontWasteDbContext>(_container);
            //---------------Test Result -----------------------
            Assert.That(allHandlers, Is.Not.Empty);
            Assert.That(allHandlers, Is.EqualTo(controllerHandlers));
        }

        [Test]
        public void Install_ShouldRegisterAllControllers()
        {
            //---------------Set up test pack-------------------
            // Is<TType> is an helper, extension method from Windsor in the Castle.Core.Internal namespace
            // which behaves like 'is' keyword in C# but at a Type, not instance level
            var allControllers = _windsorTestHelpers.GetPublicClassesFromApplicationAssembly(typeof(DontWasteDbContext), c => c.Is<IDontWasteDbContext>());

            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var registeredControllers = _windsorTestHelpers.GetImplementationTypesFor(typeof(IDontWasteDbContext), _container);
            //---------------Test Result -----------------------
            Assert.That(allControllers, Is.EqualTo(registeredControllers));
        }

        [Test]
        public void Install_ShouldRegisterAllEntityFrameworkAsPerWebRequest()
        {
            //---------------Set up test pack-------------------

            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var nonTransientControllers = _windsorTestHelpers.GetHandlersFor(typeof(IDontWasteDbContext), _container)
                .Where(controller => controller.ComponentModel.LifestyleType != LifestyleType.PerWebRequest)
                .ToArray();
            //---------------Test Result -----------------------

            Assert.That(nonTransientControllers, Is.Empty);
        }
    }
}