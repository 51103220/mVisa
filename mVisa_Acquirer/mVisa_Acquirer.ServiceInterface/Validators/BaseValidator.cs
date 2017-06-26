using Common.DTOs.Receive.Base;
using ServiceStack.FluentValidation;
using Utils;

namespace mVisa_Acquirer.ServiceInterface.Validators
{
    public class BaseValidator<T> : AbstractValidator<T> where T : BaseRequest
    {
        public BaseValidator()
        {
            #region receive message
            RuleFor(x => x.TransactionAmount)
                .NotNull()
                .NotEmpty()
                .Matches(Helper.RealNumberPattern());
            RuleFor(x => x.TransmissionDateTime)
                .NotNull()
                .NotEmpty()
                .Must(r => r.MatchDateTimeFormat(Common.Constants.TRANMISSION_DATE_TIME_FORMAT));
            RuleFor(x => x.SystemTraceAuditNumber)
                .NotNull()
                .NotEmpty()
                .Length(1, 6);
            RuleFor(x => x.LocalTransactionTime)
                .NotNull()
                .NotEmpty()
                .Must(r => r.MatchTimeSpanFormat(Common.Constants.LOCAL_TRANSACTION_TIME_FORMAT));
            RuleFor(x => x.LocalTransactionDate)
               .NotNull()
               .NotEmpty()
               .Must(r => r.MatchDateTimeFormat(Common.Constants.LOCAL_TRANSACTION_DATE_FORMAT));
            RuleFor(x => x.OriginatorCountryCode)
                .NotNull()
                .NotEmpty()
                .Matches(Helper.NumberPattern(3, 3));
            RuleFor(x => x.OriginatorBIN)
                .NotEmpty()
                .NotNull()
                .Matches(Helper.NumberPattern(1, 11));
            RuleFor(x => x.RetrievalReferenceNumber)
                .NotEmpty()
                .NotNull()
                .Matches(Helper.NumberPattern(1,12));
            RuleFor(x => x.VelocityLimitIndicator)
                .Matches(Helper.NumberPattern(0, 1));
            RuleFor(x => x.TransactionCurrencyCode)
                .NotEmpty()
                .NotNull()
                .Matches(Helper.NumberPattern(3, 3));
            RuleFor(x => x.VisaTransactionId)
                .NotEmpty()
                .NotNull()
                .Length(1, 15);
            RuleFor(x => x.DecimalPositionIndicator)
                .Matches(Helper.NumberPattern(0, 1));
            #endregion
        }
    }
}
