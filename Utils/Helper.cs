using Common.DTOs.Receive.Base;
using System;
using System.Globalization;
using System.Linq;
using static Common.Constants;

namespace Utils
{
    public static class Helper
    {
        private const string DIGITS = "0123456789";
        
        /// <summary>
        /// YYYY-MM-DDThh:mm:ss
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string ToMVisaDateString(this DateTime dateTime)
        {
            return dateTime == null ? string.Empty : dateTime.ToString(M_VISA.DATE_TIME_FORMAT);
        }

        /// <summary>
        /// Check if a string matches date time format
        /// </summary>
        /// <param name="str"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public static bool MatchDateTimeFormat(this string str, string format)
        {
            DateTime expectedDate;
            return DateTime.TryParseExact(str, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out expectedDate);
        }
        
        /// <summary>
        /// Pattern of positive integer number string has length from min to max
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static string NumberPattern(int min, int max)
        {
            return $"^[0-9]{{{min},{max}}}$";
        }

        /// <summary>
        /// Pattern of positive real number string has length from min to max
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static string RealNumberPattern()
        {
            return "^[0-9]+(\\.[0-9]+)*$";
        }

        /// <summary>
        /// Pattern of retrieval reference number
        /// </summary>
        /// <returns></returns>
        public static string RetrievalReferenceNumberPattern()
        {
            return $"^({LAST_DIGIT_IN_CURRENT_YEAR})({CURRENT_DAY_IN_YEAR})({HOUR_2_DIGITS})([0-9]{{6}})$";
        }

        /// <summary>
        /// Decrypted Property should be started with 'enc'
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public static bool IsEncryptedProperty(this string propertyName)
        {
            return propertyName != null 
                && propertyName.ToLower().StartsWith(M_VISA.ENCRYPTED_PROPERTY_START_STR);
        }
        
        /// <summary>
        /// Randomize Receiver Transaction Id
        /// </summary>
        /// <returns></returns>
        public static string RandomReceiverTransactionId()
        {
            Random rnd = new Random();
            int idLength = rnd.Next(8, 16);
            return new string(Enumerable.Repeat(DIGITS, idLength)
                .Select(s => s[rnd.Next(s.Length)]).ToArray());
        }

        public static bool IsNullOrEmpty(this string str)
        {
            return str == null || str.Equals(string.Empty);
        }
    }
}
