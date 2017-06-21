using NUnit.Framework;
using ServiceStack;
using ServiceStack.Testing;
using mVisa_Acquirer.ServiceInterface;
using Utils;

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
        public void Test_Local_Transaction_Time_Format() {
            var localTransactionTime = "141150";
            Assert.That(Helper.MatchDateTimeFormat
                (localTransactionTime, Common.Constants.LOCAL_TRANSACTION_TIME_FORMAT), Is.True);

        }
    }
}
