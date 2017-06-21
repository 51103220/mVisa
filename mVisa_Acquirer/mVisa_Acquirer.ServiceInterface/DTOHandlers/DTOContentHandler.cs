using mVisa_Acquirer.ServiceInterface.Exceptions;
using ServiceStack.Logging;
using System;
using System.Reflection;
using Utils;

namespace mVisa_Acquirer.ServiceInterface.DTOHandlers
{
    public static class DTOContentHandler
    {
        private static ILog Log = LogManager.GetLogger(typeof(DTOContentHandler));

        private static T Process<T>(this object obj, bool isDecrypting = true)
        {   
            if(obj == null)
            {
                return default(T);
            }

            Type objType = obj.GetType();
            foreach(PropertyInfo propertyInfo in objType.GetProperties())
            {
                if (propertyInfo.CanRead && propertyInfo.Name.IsEncryptedProperty())
                {
                    var currentValue = (string) propertyInfo.GetValue(obj);
                    try
                    {
                        var newValue = isDecrypting
                            ? JWTHandler.Decrypt(currentValue)
                            : JWTHandler.CreateJWE(currentValue);

                        propertyInfo.SetValue(obj, newValue);
                    }
                    catch (Exception ex)
                    {
                        Log.Error(ex.ToString());
                        throw new DecryptionFailException(propertyInfo.Name);
                    }
                }
            }
            return (T) obj;
        }

        public static T Decrypt<T>(this T obj)
        {
            return obj.Process<T>();
        }

        public static T Encrypt<T>(this T obj)
        {
            return obj.Process<T>(false);
        }
    }
}
