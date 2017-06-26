using NUnit.Framework;
using ServiceStack;
using ServiceStack.Testing;
using mVisa_Acquirer.ServiceInterface;
using Utils;
using System;
using System.Globalization;

namespace mVisa_Acquirer.Tests {
    [TestFixture]
    public class ValidatorTests {
        private readonly ServiceStackHost appHost;

        public ValidatorTests() {
            appHost = new BasicAppHost(typeof(AcquirerReceiveServices).Assembly) {
                ConfigureContainer = container => {
                }
            }
            .Init();
        }

        [OneTimeTearDown]
        public void TestFixtureTearDown() {
            appHost.Dispose();
        }

        [Test]
        public void Test_Time_Span_AM()
        {
            var localTransactionTime = "091150";
            TimeSpan val;
            Assert.That(TimeSpan.TryParseExact(localTransactionTime, "hhmmss", CultureInfo.InvariantCulture, out val), Is.True);

        }

        [Test]
        public void Test_Time_Span_PM() {
            var localTransactionTime = "141150";
            TimeSpan val;            
            Assert.That(TimeSpan.TryParseExact(localTransactionTime, "hhmmss", CultureInfo.InvariantCulture, out val), Is.True);

        }

        [Test]
        public void Test_Time_Span_Fails()
        {
            var localTransactionTime = "251150";
            TimeSpan val;
            Assert.That(TimeSpan.TryParseExact(localTransactionTime, "hhmmss", CultureInfo.InvariantCulture, out val), Is.False);

        }
    }
}