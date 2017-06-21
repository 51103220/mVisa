using Common;

namespace mVisa_Acquirer.ServiceInterface.Exceptions {

    public class PANNotExistException : DeclinePaymentException {

        public PANNotExistException() : base($"{Constants.EXCEPTIONS_MESSAGE.PAN_NOT_EXIST}") {
        }

        public override string ErrorCode => Constants.RESPONSE_CODE.INVALID_MERCHANT;
    }
}
