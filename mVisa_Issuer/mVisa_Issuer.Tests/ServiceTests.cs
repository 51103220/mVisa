using System;
using NUnit.Framework;
using ServiceStack;
using ServiceStack.Testing;
using mVisa_Issuer.ServiceModel;
using mVisa_Issuer.ServiceInterface;
using ServiceStack.Configuration;

namespace mVisa_Issuer.Tests
{
    [TestFixture]
    public class ServiceTests
    {
        private readonly ServiceStackHost appHost;
        private IAppSettings appSettings;

        public ServiceTests()
        {
            appHost = new BasicAppHost(typeof(IssuerServices).Assembly)
            {
                ConfigureContainer = container =>
                {
                    //Add your IoC dependencies here
                }
            }
            .Init();
        }

        [OneTimeTearDown]
        public void TestFixtureTearDown()
        {
            appHost.Dispose();
        }

        [Test]
        public void OCT_Timeout_260000()
        {
            var service = appHost.Container.Resolve<IssuerServices>();

            var response = "Hello";

            Assert.That(response, Is.EqualTo("Hello, World!"));
        }
    }
}
