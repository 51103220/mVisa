using mVisa_Acquirer.ServiceModel;

namespace mVisa_Acquirer.ServiceInterface.Validators
{
    public class CashOutAdviceValidator : BaseValidator<CashOutAdvice>
    {
        public CashOutAdviceValidator()
        {
            Include(new BaseAdviceValidator());
        }
    }
}
