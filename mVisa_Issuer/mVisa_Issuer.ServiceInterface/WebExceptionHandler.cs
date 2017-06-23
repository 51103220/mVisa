using Common.DTOs.Response.Base;
using mVisa_Issuer.ServiceInterface.Exceptions;
using ServiceStack.Logging;
using ServiceStack.Text;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Utils;
using static Common.Constants.ISSUER;

namespace mVisa_Issuer.ServiceInterface
{
    public static class WebExceptionHandler
    {
        private static ILog Log = LogManager.GetLogger(typeof(WebExceptionHandler));

        public static async Task<T> ProcessErrorResponse<T>(this WebException exception, string source, bool isPost) {
            var resp = new StreamReader(exception
                        .Response
                        .GetResponseStream())
                        .ReadToEnd();
            var errorResponse = (HttpWebResponse)exception.Response;
            var statusCode = (int)errorResponse.StatusCode;
            Log.Error(statusCode);
            Log.Error(resp);
            
            var errorCode = exception.Response.DetectErrorCode();
            var status = Helper.DetectHttpStatus(statusCode, errorCode);
            switch (status)
            {
                case HTTP_STATUS.TIME_OUT :
                case HTTP_STATUS.DUPLICATE_TRANSACTION :
                    var baseResponseDto = JsonSerializer.DeserializeFromString<BaseResponseDto>(resp);
                    var statusIdentifier = baseResponseDto?.StatusIdentifier;
                    source = isPost 
                        ? $"{source}/{statusIdentifier}" 
                        : source;
                    var getResponse = await source.Get<T>();
                    return getResponse;
                case HTTP_STATUS.GET_REQUEST_HAS_BEEN_SENT:
                    throw new GETRequestHasBeenSentException(source);
                case HTTP_STATUS.RESOURCE_NOT_FOUND:
                    throw new UrlNotExistsException(source);
                case HTTP_STATUS.INTERNAL_SERVER_ERROR:
                    throw new TransactionStatusIsNotKnownException(source);
                case HTTP_STATUS.REJECTED_DUE_TO_VALIDATION:
                    throw new MessageValidationErrorException(resp);
                case HTTP_STATUS.WRONG_USER_CREDENTIALS:
                    throw new WrongUserCredentialsException(resp);
                case HTTP_STATUS.WRONG_CERTIFICATE:
                    throw new UnmatchedCertificateException(resp);
                case HTTP_STATUS.URL_NOT_PERMITTED:
                    throw new UrlAccessNotPermitedException(source);
                case HTTP_STATUS.INVALID_PAN:
                    throw new InvalidPrimaryAccountNumberException(resp);
                case HTTP_STATUS.DUE_TO_CONNECTIVITY:
                    throw new NetworkConnectivityException(resp);
                case HTTP_STATUS.TIME_OUT_DUE_TO_CONNECTIVITY:
                    throw new NetworkConnectivityTimeoutException(resp);
                default:
                    throw new UnableToIdentifyErrorException(resp);
            }
        }
    }
}