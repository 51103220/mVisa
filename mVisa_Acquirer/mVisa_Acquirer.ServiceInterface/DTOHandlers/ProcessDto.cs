using mVisa_Acquirer.ServiceModel;
using System.Threading.Tasks;
using Common.DTOs.Receive.Base;
using static Common.Constants;
using Utils;

namespace mVisa_Acquirer.ServiceInterface.DTOHandlers {
    public static class ProcessDto {

        public static async Task<T> GetResponse<T>(this BaseRequest request, string apiUrl) where T : BaseResponse {
            if (request == null) {
                return default(T);
            }
            // TODO: Call other service to get response
            // await something
            return (T)DummyResponse<T>(request, apiUrl);
        }

        /// <summary>
        /// Delete after integration
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="message"></param>
        /// <param name="errorCode"></param>
        /// <returns></returns>
        public static object GetErrorResponse(string uri, string message, string errorCode) {
            // TODO: wont need after integration
            return new BaseResponse {
                ReceiverTransactionId = Helper.RandomReceiverTransactionId(),
                ResponseCode = errorCode,
                ResponseMessage = message
            };
        }

        /// <summary>
        /// Delete after integration
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <param name="apiUrl"></param>
        /// <returns></returns>
        private static BaseResponse DummyResponse<T>(BaseRequest request, string apiUrl) where T : BaseResponse {
            if (apiUrl.Equals(PROCESS_REQUEST_URL.PROCESS_POST_MERCHANT_PAYMENT)) {
                return new MerchantPaymentResponse() {
                    ReceiverTransactionId = Helper.RandomReceiverTransactionId(),
                    MerchantCategoryCode = DUMMY_RESPONSE.MERCHANT_CATEGORY_CODE,
                    AuthIdResponse = DUMMY_RESPONSE.AUTH_RESPONSE_CODE,
                    ResponseCode = RESPONSE_CODE.APPROVED_COMPLETED_SUCCESSFULLY,
                    MerchantName = DUMMY_RESPONSE.MERCHANT_NAME,
                    MerchantCity = DUMMY_RESPONSE.MERCHANT_CITY,
                    MerchantCountryCode = DUMMY_RESPONSE.MERCHANT_COUNTRY_CODE,
                    MerchantTerminalID = DUMMY_RESPONSE.MERCHANT_TERMINAL_ID,
                    MerchantID = DUMMY_RESPONSE.MERCHANT_ID,
                };
            } else if (apiUrl.Equals(PROCESS_REQUEST_URL.PROCESS_POST_CASH_IN)) {
                return new CashInResponse() {
                    ReceiverTransactionId = Helper.RandomReceiverTransactionId(),
                    AuthIdResponse = DUMMY_RESPONSE.AUTH_RESPONSE_CODE,
                    ResponseCode = RESPONSE_CODE.APPROVED_COMPLETED_SUCCESSFULLY,
                };
            } else if (apiUrl.Equals(PROCESS_REQUEST_URL.PROCESS_POST_CASH_OUT)) {
                return new CashOutResponse() {
                    ReceiverTransactionId = Helper.RandomReceiverTransactionId(),
                    AuthIdResponse = DUMMY_RESPONSE.AUTH_RESPONSE_CODE,
                    ResponseCode = RESPONSE_CODE.APPROVED_COMPLETED_SUCCESSFULLY,
                    AgentName = DUMMY_RESPONSE.AGENT_NAME,
                    AgentCity = DUMMY_RESPONSE.AGENT_CITY,
                    AgentCountryCode = DUMMY_RESPONSE.AGENT_COUNTRY_CODE
                };
            }
            return default(T);
        }
    }
}
