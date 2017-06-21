using ServiceStack;
using mVisa_Acquirer.ServiceModel;
using System.Threading.Tasks;
using mVisa_Acquirer.ServiceInterface.DTOHandlers;
using Common;
using ServiceStack.Logging;
using mVisa_Acquirer.ServiceInterface.Exceptions;

namespace mVisa_Acquirer.ServiceInterface {
    public class AcquirerReceiveServices : Service {
        private static ILog Log = LogManager.GetLogger(typeof(AcquirerReceiveServices));

        public async Task<MerchantPaymentResponse> Post(MerchantPayment request) {
            Log.Info(nameof(MerchantPayment));
            Log.Info(request?.ToJson());
            request.Decrypt();
            if (!Constants.AVAILABLE_PAN_NUMBERS.Contains(request?.EncMerchantPAN)) {
                throw new PANNotExistException();
            }

            var response = await request.GetResponse<MerchantPaymentResponse>
                (Constants.PROCESS_REQUEST_URL.PROCESS_POST_MERCHANT_PAYMENT);

            Log.Info(nameof(MerchantPaymentResponse));
            Log.Info(response?.ToJson());

            return response;
        }

        public async Task<CashInResponse> Post(CashIn request) {
            Log.Info(nameof(CashIn));
            Log.Info(request?.ToJson());
            request.Decrypt();
            if (!Constants.AVAILABLE_PAN_NUMBERS.Contains(request?.EncConsumerPAN)) {
                throw new PANNotExistException();
            }

            var response = await request.GetResponse<CashInResponse>
                (Constants.PROCESS_REQUEST_URL.PROCESS_POST_CASH_IN);

            Log.Info(nameof(CashInResponse));
            Log.Info(response?.ToJson());

            return response;
        }

        public async Task<CashOutResponse> Post(CashOut request) {
            Log.Info(nameof(CashOut));
            Log.Info(request?.ToJson());
            request.Decrypt();
            if (!Constants.AVAILABLE_PAN_NUMBERS.Contains(request?.EncAgentPAN)
                || !Constants.AVAILABLE_PAN_NUMBERS.Contains(request?.EncConsumerPAN)) {
                throw new PANNotExistException();
            }

            var response = await request.GetResponse<CashOutResponse>
                (Constants.PROCESS_REQUEST_URL.PROCESS_POST_CASH_OUT);

            Log.Info(nameof(CashOutResponse));
            Log.Info(response?.ToJson());

            return response;
        }
    }
}