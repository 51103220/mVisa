using mVisa_Acquirer.ServiceModel;

namespace mVisa_Acquirer.ServiceInterface.Validators
{
    public class MerchantPaymentAdviceValidator : BaseValidator<MerchantPaymentAdvice>
    {      
        public MerchantPaymentAdviceValidator()
        {
            Include(new BaseAdviceValidator());
        }
    }
}
