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
        private static IAppSettings AppSettings = new AppSettings();
        private static ILog Log = LogManager.GetLogger(typeof(ApiUtils));
        private static int timeOut;
        
        static ApiUtils() {
            timeOut = AppSettings.Get(Constants.TIME_OUT,Constants.DEFAULT_TIME_OUT);
        }

        public static async Task<T> Post<T>(this string resource, object content) {
            var url = $"{MVisaEndpoint()}{resource}";
            Log.Info($"posting : {url}");
            Log.Info($"content : {content.ToJson()}");
            return await url.Process<T>(true, content);
        }

        public static async Task<T> Get<T>(this string resource) {
            var url = $"{MVisaEndpoint()}{resource}";
            Log.Info($"get : {url}");
            return await url.Process<T>();
        }

        private static async Task<T> Process<T>(this string url, bool isPost = false, object content = null) {
            try {
                var task = isPost
                    ? url.PostJsonToUrlAsync(content, requestFilter: webReq => webReq.DoAuth())
                    : url.GetJsonFromUrlAsync(requestFilter: webReq => webReq.DoAuth());
                if (await Task.WhenAny(task, Task.Delay(timeOut)) == task) {
                    return (await task).FromJson<T>();
                }
                throw new TimeoutException();
            } catch (Exception ex) {
                Log.Error(ex.ToString());
                var innerException = ex.InnerException;
                if (innerException is WebException) {
                    var resp = new StreamReader(((WebException) innerException).Response.GetResponseStream()).ReadToEnd();
                    Log.Error(((WebException) innerException).Status);
                    Log.Error(resp);
                }
            }
            return default(T);
        }

        private static string MVisaEndpoint() {
            return AppSettings.Get<string>(Constants.M_VISA.ENDPOINT);
        }

        private static X509Certificate GetCurrentClientCertificate() {
            var certificatePath = AppSettings.Get<string>(Constants.CERTIFICATE_PATH);
            var certificatePassword = AppSettings.Get<string>(Constants.CERTIFICATE_PASSWORD);
            return new X509Certificate(certificatePath, certificatePassword, 
                X509KeyStorageFlags.MachineKeySet | X509KeyStorageFlags.PersistKeySet);
        }

        private static void DoAuth(this HttpWebRequest webReq) {
            var clientCertificates = new X509CertificateCollection {
                GetCurrentClientCertificate()
            };
            webReq.ClientCertificates = clientCertificates;

            webReq.Headers[Constants.AUTHORIZATION] = AppSettings.Get<string>(Constants.AUTHORIZATION);
            webReq.Accept = Constants.JSON_ACCEPT_HEADER;

            Log.Info($"web request : {webReq.ToJson()}");
        }
    }
}
