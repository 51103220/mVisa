using ServiceStack;
using mVisa_Acquirer.ServiceModel;
using System.Threading.Tasks;
using mVisa_Acquirer.ServiceInterface.DTOHandlers;
using Common;
using System.Net;
using ServiceStack.Logging;
using mVisa_Acquirer.ServiceInterface.Exceptions;

namespace mVisa_Acquirer.ServiceInterface
{
    public class AcquirerAdviceServices : Service
    {
        private static ILog Log = LogManager.GetLogger(typeof(AcquirerAdviceServices));

        public async Task<HttpResult> Post(MerchantPaymentAdvice request)
        {
            Log.Info(nameof(MerchantPaymentAdvice));
            Log.Info(request?.ToJson());

            request.Decrypt();
            if(!Constants.AVAILABLE_PAN_NUMBERS.Contains(request?.EncMerchantPAN)){
                throw new PANNotExistException();
            }

            var response = await request.GetResponse<MerchantPaymentResponse>
                (Constants.PROCESS_REQUEST_URL.PROCESS_POST_MERCHANT_PAYMENT);

            return new HttpResult() {
                StatusCode = HttpStatusCode.OK
            };
        }

        public async Task<HttpResult> Post(CashInAdvice request)
        {
            Log.Info(nameof(CashInAdvice));
            Log.Info(request?.ToJson());

            request.Decrypt();
            if (!Constants.AVAILABLE_PAN_NUMBERS.Contains(request?.EncConsumerPAN))
            {
                throw new PANNotExistException();
            }
            var response = await request.GetResponse<CashInResponse>
                (Constants.PROCESS_REQUEST_URL.PROCESS_POST_CASH_IN);

            return new HttpResult(){
                StatusCode = HttpStatusCode.OK
            };
        }

        public async Task<HttpResult> Post(CashOutAdvice request)
        {
            Log.Info(nameof(CashOutAdvice));
            Log.Info(request?.ToJson());

            request.Decrypt();
            if (!Constants.AVAILABLE_PAN_NUMBERS.Contains(request?.EncAgentPAN)
                || !Constants.AVAILABLE_PAN_NUMBERS.Contains(request?.EncConsumerPAN)){
                throw new PANNotExistException();
            }

            var response = await request.GetResponse<CashOutResponse>
                (Constants.PROCESS_REQUEST_URL.PROCESS_POST_CASH_OUT);

            return new HttpResult(){
                StatusCode = HttpStatusCode.OK
            };
        }
    }
}