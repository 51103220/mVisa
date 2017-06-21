using mVisa_Acquirer.ServiceModel;
using ServiceStack.FluentValidation;

namespace mVisa_Acquirer.ServiceInterface.Validators
{
    public class CashOutValidator : BaseValidator<CashOut>
    {
        public CashOutValidator()
        {
            RuleFor(x => x.EncConsumerPAN)
                .NotNull()
                .NotEmpty()
                .Length(1, 500);
            RuleFor(x => x.EncConsumerName)
                .NotNull()
                .NotEmpty()
                .Length(1, 500);
            RuleFor(x => x.EncAgentPAN)
                .NotNull()
                .NotEmpty()
                .Length(1, 500);
        }
    }
}
