using Common;
using Jose;
using ServiceStack.Configuration;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace mVisa_Acquirer.ServiceInterface.DTOHandlers
{
    public static class JWTHandler
    {
        private static IAppSettings AppSettings { get; set; }
        private static Dictionary<string, string> KEY_SHARED_SECRET_MAP;

        static JWTHandler()
        {
            AppSettings = new AppSettings();
            KEY_SHARED_SECRET_MAP = new Dictionary<string, string>();          
            KEY_SHARED_SECRET_MAP[AppSettings.Get<string>(Constants.M_VISA.KEY_ID_DECRYPT)] =
               AppSettings.Get<string>(Constants.M_VISA.SHARED_SECRET_DECRYPT);
            KEY_SHARED_SECRET_MAP[AppSettings.Get<string>(Constants.M_VISA.KEY_ID_ENCRYPT)] =
               AppSettings.Get <string> (Constants.M_VISA.SHARED_SECRET_ENCRYPT);
        }

        public static string Decrypt(string jweString)
        {
            var headers = JWT.Headers(jweString);
            var keyId = GetKeyID(headers);
            var sharedSecret = GetSharedSecret(keyId);
            return JWT.Decode(jweString, GetKeyBytes(sharedSecret));
        }

        public static string CreateJWE(string payload)
        {
            var keyId = AppSettings.Get<string>(Constants.M_VISA.KEY_ID_DECRYPT);
            var sharedSecret = GetSharedSecret(keyId);
            var keyBytes = GetKeyBytes(sharedSecret);
            return JWT.Encode(payload, keyBytes, JweAlgorithm.A256GCMKW, JweEncryption.A256GCM);
        }

        private static byte[] GetKeyBytes(string sharedSecret)
        {
            var sha256 = SHA256.Create();
            return sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(sharedSecret));
        }

        private static string GetKeyID(IDictionary<string, object> headers)
        {
            object keyId = null;
            if(headers != null && headers.TryGetValue(Constants.M_VISA.HEADER_INFO_KEY_ID, out keyId))
            {
                return (string)keyId;
            }
            throw new Exception(Constants.M_VISA.KEY_ID_NOT_FOUND);
        }

        private static string GetSharedSecret(string keyId)
        {
            string sharedSecret;
            if(KEY_SHARED_SECRET_MAP.TryGetValue(keyId, out sharedSecret))
            {
                return sharedSecret;
            }
            throw new Exception(Constants.M_VISA.SHARED_SECRET_NOT_FOUND);
        }
    }
}
