using System.Collections.Generic;

namespace Common
{
    public static class Constants
    {
        public const string PORT = "port";
        public const string ADDRESS = "address";
        public const string AUTHORIZATION = "Authorization";
        public const string ACCEPT = "Accept";
        public const string CONTENT_TYPE = "Content-Type";
        public const string JSON_CONTENT_TYPE = "application/json";
        public const string CERTIFICATE_PATH = "certificatePath";
        public const string CERTIFICATE_PASSWORD = "certificatePassword";
        public const string JSON_ACCEPT_HEADER = "application/json,application/octet-stream";
        public const string MQ_SERVER_ADDRESS = "localhost:6379";
        public const string PUSH_TO_MQ_URL = "/pushToMQ";
        public const string PULL_FROM_MQ_URL = "/pullFromMQ";
        public const string TRANMISSION_DATE_TIME_FORMAT = "MMddHHmmss";
        public const string LOCAL_TRANSACTION_TIME_FORMAT = "hhmmss";
        public const string LOCAL_TRANSACTION_DATE_FORMAT = "mmdd";
        public const string COUNTRY_CODE_FORMAT = "^[0-9]{3}$";
        public const string LAST_DIGIT_IN_CURRENT_YEAR = "[0-9]{1}";
        public const string CURRENT_DAY_IN_YEAR = "([0-2]{1}[0-9]{2})|(3[0-6]{2})";
        public const string HOUR_2_DIGITS = "([0-1]{1}[0-9]{1})|(2[0-3]{1})";
        public const string POST = "POST";
        public const string GET = "GET";
        public const string TIME_OUT = "timeOut";
        public const int DEFAULT_TIME_OUT = 10000; //in miliseconds
        /// <summary>
        /// Simulation purpose only
        ///     Pan numbers for testing: 
        ///         4110610000000005,4110610000000013,4110610000000021      
        /// </summary>
        public static IList<string> AVAILABLE_PAN_NUMBERS = new List<string>
        {
            "4110610000000005",
            "4110610000000013",
            "4110610000000021"
        };

        public  static class HTTP_HEADER
        {
            public const string ACCEPT = "Accept";
            public const string ACCEPT_ENCODING = "Accept-Encoding";
            public const string CONTENT_LENGTH = "Content-Length";
            public const string CONTENT_TYPE = "Content-Type";
            public const string HOST = "Host";
            public const string ORIGIN = "Origin";
            public const string USER_AGENT = "User-Agent";
            public const string VIA = "Via";
            public const string FORWARDED = "Forwarded";
        }

        public static class M_VISA
        {
            public const string ENDPOINT = "mVisaEndpoint";
            public const string ENCRYPTED_PROPERTY_START_STR = "enc";
            public const string CASH_IN_PUSH_PAYMENT_URL = "visadirect/mvisa/v1/cashinpushpayments";
            public const string CASH_OUT_PUSH_PAYMENT_URL = "visadirect/mvisa/v1/cashoutpushpayments";
            public const string MERCHANT_PUSH_PAYMENT_URL = "visadirect/mvisa/v1/merchantpushpayments";
            public const string DATE_TIME_FORMAT = "yyyy-MM-dd'T'HH:mm:ss";
            public const string ERROR_RESPONSE_MESSAGE = "Invalid Data";
            public const string HEADER_INFO_KEY_ID = "kid";
            public const string SHARED_SECRET_NOT_FOUND = "Shared secret not found";
            public const string KEY_ID_NOT_FOUND = "Shared secret not found";
            public const string KEY_ID_DECRYPT = "keyIdDecrypt";
            public const string KEY_ID_ENCRYPT = "keyIdEncrypt";
            public const string SHARED_SECRET_DECRYPT = "sharedSecretDecrypt";
            public const string SHARED_SECRET_ENCRYPT = "sharedSecretEncrypt";
        }

        public static class ACQUIRER
        {
            /// <summary>
            /// It should be Empty when deploy
            /// </summary>
            private const string LOCATION = "";
            public static class RECEIVE
            {
                public const string PERSON_TO_MERCHANT_URL = LOCATION + "/transactions/receive/p2m";
                public const string CASH_IN_URL = LOCATION + "/transactions/receive/ci";
                public const string CASH_OUT_URL = LOCATION + "/transactions/receive/co";
            }
            public static class ADVICE  
            {
                public const string PERSON_TO_MERCHANT_URL = LOCATION + "/advice/receive/p2m";
                public const string CASH_IN_URL = LOCATION + "/advice/receive/ci";
                public const string CASH_OUT_URL = LOCATION + "/advice/receive/co";
            }
        }
        public static class ISSUER
        {
            public const string CASH_IN_REQUEST_URL = "/cashinrequest";
            public const string CASH_IN_GET_REQUEST_URL = "/cashinrequest/{statusIdentifier}";
            public const string CASH_OUT_REQUEST_URL = "/cashoutrequest";
            public const string CASH_OUT_GET_REQUEST_URL = "/cashoutrequest/{statusIndentifier}";
            public const string MERCHANT_PAYMENT_REQUEST_URL = "/cashinrequest";
            public const string MERCHANT_PAYMENT_GET_REQUEST_URL = "/cashinrequest/{statusIndentifier}";
        }

        public static class EXCEPTIONS_MESSAGE
        {
            public const string MISSING_FIELDS = "Missing required/mandatory field";
            public const string LENGTH_EXCEEDS = "The value exceeds the length specified for this field";
            public const string INVALID_FIELD_FORMAT = "Field formatting does not match the expected format";
            public const string TYPE_MISMATCH = "Type mismatch in field";
            public const string INVALID_JSON = "Invalid JSON request /The recipient API server could not understand the request";
            public const string BASE_64_DECODING_FAIL = "Base64 decoding failed";
            public const string DECRYPTION_FIELDS_FAIL = "Decryption of the encrypted fields failed";
            public const string PAN_NOT_EXIST = "The requested PAN number does not exist";
        }

        public static class PROCESS_REQUEST_URL
        {
            public const string PROCESS_POST_MERCHANT_PAYMENT = "/post/merchantpayment";
            public const string PROCESS_POST_CASH_IN = "/post/cashin";
            public const string PROCESS_POST_CASH_OUT = "/post/cashout";
        }

        public static class RESPONSE_CODE
        {
            public const string APPROVED_COMPLETED_SUCCESSFULLY = "00";
            public const string REFER_TO_CARD_ISSUER = "01";
            public const string REFER_TO_CARD_ISSUER_SPECIAL_CONDITION = "02";
            public const string INVALID_MERCHANT = "03";
            public const string PICK_UP_CARD = "04";
            public const string DO_NOT_HONOR = "05";
            public const string ERROR = "06";
            public const string PICK_UP_CARD_SPECIAL_CONDITION = "07";
            public const string PARTIAL_APPROVED = "10";
            public const string APPROVED_VIP = "11";
            public const string INVALID_TRANSACTION = "12";
            public const string INVALID_AMOUNT_OR_CURRENCY_CONVERSION_OVERFLOW = "13";
            public const string INVALID_ACCOUNT_NUMBER = "14";
            public const string NO_SUCH_ISSUER = "15";
            public const string RE_ENTER_TRANSACTION = "16";
            public const string NO_ACTION_TAKEN = "21";
            public const string UNABLE_TO_LOCATE_RECORD_IN_FILE = "25";
            public const string FILE_TEMPORILY_NOT_AVAILABLE = "28";
            public const string NO_CREDIT_ACCOUNT = "39";
            public const string LOST_CARD_PICK_UP = "41";
            public const string STOLEN_CARD_PICKUP = "43";
            public const string NOT_EFFICIENT_FUND = "51";
            public const string NOT_CHECKING_ACCOUNT = "52";
            public const string NO_SAVING_ACCOUNT = "53";
            public const string EXPIRED_CARD_OR_EXPIRATION_DATE_IS_MISSING = "54";
            public const string INCORRECT_OR_MISSING_PIN = "55";
            public const string TRANSACTION_NOT_PERMITTED_TO_CARDHOLDER = "57";
            public const string SUSPECTED_FRAUD = "59";
            public const string EXCEEDS_APPROVAL_AMOUNT_LIMIT = "61";
            public const string RESTRICTED_CARD = "62";
            public const string SECURITY_VIOLATION = "63";
            public const string REQUIREMENT_DOES_NOT_FULLFILL_AML = "64";
            public const string EXCEEDS_WITHDRAWAL_FREQUENCY_LIMIT = "65";
            public const string NUMBER_OF_PIN_TRIES_EXCEEDED = "75";
            public const string UNSOLICITED_REVERSAL = "76";
            public const string ALREADY_REVERSED = "79";
            public const string NO_FINANCIAL_IMPACT = "80";
            public const string CRYTOGRAPHICAL_ERROR_FOUND = "81";
            public const string NEGATIVE_CAM_DCCV_ICVV_CVV_RESULTS = "82";
            public const string NO_REASON_TO_DECLINE_REQUEST = "82";
            public const string CAN_NOT_VERIFY_PIN = "86";
            public const string INELIGIBLE_TO_RECEIVE_FINANCIAL_POSITION_INFO = "89";
            /// <summary>
            /// Issuer or switch inoperative and STIP not applicable or not available for this transaction; 
            /// Time-out when no stand-in; POS Check Service: Destination unavailable; 
            /// Credit Voucher and Merchandise Return Authorizations: V.I.P. sent the transaction to the issuer, 
            ///     but the issuer was unavailable.
            /// </summary>
            public const string CODE_91 = "91";
            /// <summary>
            /// Financial institution or 
            /// intermediate network facility cannot be found for routing (receiving institution ID is invalid)
            /// </summary>
            public const string CODE_92 = "92";
            public const string TRANSACTION_CANT_BE_COMPLETED = "93";
            public const string DUPLICATE_TRANMISSION = "94";
            public const string SYSTEM_MALFUNCTION = "96";
            /// <summary>
            /// Surcharge amount not permitted on Visa cards or EBT food stamps (U.S. acquirers only)
            /// </summary>
            public const string SURCHAGE_AMOUNT_NOT_PERMITTED = "B1";
            /// <summary>
            /// Surcharge amount not supported by debit network issuer.
            /// </summary>
            public const string SURCHAGE_AMOUNT_NOT_SUPPORTED = "B2";
            public const string FORCE_STIP = "N0";
            public const string CASH_SERVICE_NOT_AVAILABLE = "N3";
            /// <summary>
            /// Cash request exceeds issuer or approved limit
            /// </summary>
            public const string CASH_REQUEST_EXCEEDS = "N4";
            public const string INELIGIBLE_FOR_RESUBMISSION = "N5";
            public const string DECLINE_FOR_CVV2_FAILURE = "N7";
            /// <summary>
            /// Transaction amount exceeds preauthorized approval amount
            /// </summary>
            public const string TRANSACTION_AMOUNT_EXCEEDS = "N8";
            public const string CARD_AUTHENTICATION_FAILED = "Q1";
            public const string STOP_PAYMENT_ORDER = "R0";
            public const string REVOCATION_OF_AUTHORIZATION_ORDER = "R1";
            public const string TRANSACTION_DOES_NOT_QUALIFY_FOR_VISA_PIN = "R2";
            public const string REVOCATION_OF_ALL_AUTHORIZATIONS_ORDER = "R3";
            public const string FIRST_TIME_CHECK = "T0";
            public const string CHECK_IS_OK_BUT_CANT_BE_CONVERTED = "T1";
            /// <summary>
            /// Invalid Routing Transit Number or check belongs to a category that is not eligible for conversion; 
            /// Transaction failed ABA check digit validation
            /// </summary>
            public const string T2_CODE = "T2";
            public const string AMOUNT_GREATER_THAN_ESTABLISHED_SERVICE_LIMIT = "T3";
            public const string UNPAID_ITEMS_FAILED_NEGATIVE_FILE_CHECK = "T4";
            public const string DUPLICATE_CHECK_NUMBER = "T5";
            public const string MICR_ERROR = "T6";
            public const string TOO_MANY_CHECKS = "T7";
            public const string OFFLINE_APPROVED = "Y1";
            public const string OFFLINE_APPROVED_UNABLE_TO_GO_ONLINE = "Y3";
            public const string OFFLINE_DECLINED = "Z1";
            public const string OFFLINE_DECLINED_UNABLE_TO_GO_ONLINE = "Z3";
        }

        public static class DUMMY_RESPONSE
        {
            public const string AUTH_RESPONSE_CODE = "231043";
            public const string MERCHANT_CATEGORY_CODE = "5944";
            public const string MERCHANT_NAME = "SACOMBANK";
            public const string MERCHANT_CITY = "HO CHI MINH CITY";
            public const string MERCHANT_COUNTRY_CODE = "VN";
            public const string MERCHANT_TERMINAL_ID = "123";
            public const string MERCHANT_ID = "1011";
            public const string AGENT_NAME = "SACOMBANK AGENT";
            public const string AGENT_CITY = "HO CHI MINH CITY";
            public const string AGENT_COUNTRY_CODE = "VN";
        }

        public static class ADVICE_MESSAGE_TYPE
        {
            public const string RECIPIENT_TIMEOUT = "Recipient Timeout";
            public const string STIP_DECLINE_ADVICE = "Advice";
            public const string ORIGINATOR_UNAVAILABLE = "Originator Unavailable Advice";
            public const string REJECT = "Reject";
        }
    }
}
