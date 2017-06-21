using mVisa_Acquirer.ServiceModel;
using ServiceStack.FluentValidation;
using Utils;

namespace mVisa_Acquirer.ServiceInterface.Validators
{
    public class MerchantPaymentValidator : BaseValidator<MerchantPayment>
    {
        public MerchantPaymentValidator()
        {
            RuleFor(x => x.EncMerchantPAN)
                .NotNull()
                .NotEmpty()
                .Length(1, 500);
            When(x => !x.TransactionFeeAmount.IsNullOrEmpty(), () =>{
                RuleFor(x => x.TransactionFeeAmount)
                       .Matches(Helper.RealNumberPattern());
            });
            RuleFor(x => x.BillIdFormat)
                .Length(0, 1);
            RuleFor(x => x.BillId)
                .Length(0, 25);
            RuleFor(x => x.RefId)
                .Length(0, 28);
            RuleFor(x => x.EncConsumerPAN)
                .NotNull()
                .NotEmpty()
                .Length(1, 500);
            RuleFor(x => x.EncConsumerName)
                .NotNull()
                .NotEmpty()
                .Length(1, 500);
        }
    }
}
