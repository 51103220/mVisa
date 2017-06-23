using Common;
using ServiceStack;
using ServiceStack.Configuration;
using ServiceStack.Logging;
using System;
using System.IO;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace mVisa_Issuer.ServiceInterface
{
    public static class ApiUtils
    {
        private static IAppSettings appSettings;
        private static string endPoint;
        private static string authorization;
        private static string transaction_timeout;
        private static X509CertificateCollection clientCertificates;
        private static ILog Log = LogManager.GetLogger(typeof(ApiUtils));
       
        static ApiUtils() {
            appSettings = new AppSettings();
            endPoint = appSettings.Get<string>(Constants.M_VISA.ENDPOINT);
            authorization = appSettings.Get<string>(Constants.AUTHORIZATION);
            transaction_timeout = appSettings.Get<string>(Constants.HTTP_HEADER.X_TRANSACTION_TIMEOUT_MS);
            clientCertificates = new X509CertificateCollection {
                GetCurrentClientCertificate()
            };
        }

        public static async Task<T> Post<T>(this string resource, object content) {
            var url = $"{endPoint}{resource}";
            Log.Info($"posting : {url}");
            Log.Info($"content : {content.ToJson()}");
            return await url.Process<T>(true, content);
        }

        public static async Task<T> Get<T>(this string resource) {
            var url = $"{endPoint}{resource}";
            Log.Info($"get : {url}");
            return await url.Process<T>();
        }

        private static async Task<T> Process<T>(this string url, bool isPost = false, object content = null) {
            try {
                var task = isPost
                    ? url.PostJsonToUrlAsync(content, requestFilter: webReq => webReq.DoAuth())
                    : url.GetJsonFromUrlAsync(requestFilter: webReq => webReq.DoAuth());
                    return (await task).FromJson<T>();
            } catch (Exception ex) {
                Log.Error(ex.ToString());
                var innerException = ex.InnerException;
                if (innerException is WebException) {
                    return await ((WebException)innerException).ProcessErrorResponse<T>(url, isPost);
                }
            }
            return default(T);
        }

        private static X509Certificate GetCurrentClientCertificate() {
            var certificatePath = appSettings.Get<string>(Constants.CERTIFICATE_PATH);
            var certificatePassword = appSettings.Get<string>(Constants.CERTIFICATE_PASSWORD);
            return new X509Certificate(certificatePath, certificatePassword, 
                X509KeyStorageFlags.MachineKeySet | X509KeyStorageFlags.PersistKeySet);
        }

        private static void DoAuth(this HttpWebRequest webReq) {
            webReq.Headers[Constants.AUTHORIZATION] = authorization;
            webReq.Headers[Constants.HTTP_HEADER.X_TRANSACTION_TIMEOUT_MS] = transaction_timeout;
            webReq.Accept = Constants.JSON_ACCEPT_HEADER;
            webReq.ClientCertificates = clientCertificates;
            Log.Info($"web request : {webReq.ToJson()}");
        }
    }
}