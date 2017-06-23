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
            
            var status = Helper.DetectHttpStatus(statusCode, null);
            switch (status)
            {
                case HTTP_STATUS_CODE.TIME_OUT :
                case HTTP_STATUS_CODE.DUPLICATE_TRANSACTION :
                    var baseResponseDto = JsonSerializer.DeserializeFromString<BaseResponseDto>(resp);
                    var statusIdentifier = baseResponseDto?.StatusIdentifier;
                    source = isPost 
                        ? $"{source}/{statusIdentifier}" 
                        : source;
                    var getResponse = await source.Get<T>();
                    return getResponse;
                case HTTP_STATUS_CODE.RESOURCE_NOT_FOUND:
                    throw new GETRequestHasBeenSentException(source);
                case HTTP_STATUS_CODE.INTERNAL_SERVER_ERROR:
                    throw new TransactionStatusIsNotKnownException(source);
                default:
                    throw new UnableToIdentifyErrorException(resp);
            }
        }
    }
}
