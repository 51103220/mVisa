using System;
namespace mVisa_Acquirer.ServiceInterface.Exceptions
{
    public abstract class DeclinePaymentException : Exception
    {
        protected DeclinePaymentException(string message) : base(message){
        }

        public abstract string ErrorCode { get; }
    }
}
