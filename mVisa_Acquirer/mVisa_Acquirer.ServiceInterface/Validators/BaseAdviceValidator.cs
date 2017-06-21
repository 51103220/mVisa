using Common.DTOs.Receive.Base;
using ServiceStack.FluentValidation;
using static Common.Constants;

namespace mVisa_Acquirer.ServiceInterface.Validators
{
    public class BaseAdviceValidator : AbstractValidator<BaseRequest>
    {
        public BaseAdviceValidator()
        {
            #region Advice message
            RuleFor(x => x.MessageType)
                .NotEmpty()
                .NotNull();
            RuleFor(x => x.AuthIdResponse)
                .Length(0, 6);
            RuleFor(x => x.ResponseCode);
            When(x => x.MessageType.Equals(ADVICE_MESSAGE_TYPE.REJECT), () =>{
                RuleFor(x => x.RejectionCode)
                .NotEmpty()
                .NotNull();
            });
            #endregion
        }
    }
}
