using mVisa_Acquirer.ServiceModel;

namespace mVisa_Acquirer.ServiceInterface.Validators
{
    public class CashInAdviceValidator : BaseValidator<CashInAdvice>
    {
        public CashInAdviceValidator()
        {
            Include(new BaseAdviceValidator());
        }
    }
}
