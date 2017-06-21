using mVisa_Acquirer.ServiceModel;
using ServiceStack.FluentValidation;

namespace mVisa_Acquirer.ServiceInterface.Validators
{
    public class CashInValidator : BaseValidator<CashIn>
    {
        public CashInValidator()
        {
            RuleFor(x => x.EncConsumerPAN)
                .NotNull()
                .NotEmpty()
                .Length(1, 500);
            RuleFor(x => x.EncAgentName)
                .NotNull()
                .NotEmpty()
                .Length(1, 500);
        }
    }
}
