using Funq;
using ServiceStack;
using mVisa_Acquirer.ServiceInterface;
using ServiceStack.Logging;
using System.Collections.Generic;
using mVisa_Acquirer.ServiceInterface.Exceptions;
using System.Net;
using System.Runtime.Serialization;
using ServiceStack.Validation;
using mVisa_Acquirer.ServiceInterface.Validators;
using ServiceStack.Configuration;
using static Common.Constants;
using mVisa_Acquirer.ServiceInterface.DTOHandlers;

namespace mVisa_Acquirer
{
    public class AppHost : AppSelfHostBase
    {
        private static ILog Log = LogManager.GetLogger(typeof(AppHost));

        public AppHost()
            : base("mVisa_Acquirer", new[] { typeof(AcquirerReceiveServices).Assembly } )
        { }

        public override void Configure(Container container)
        {
            // Global Configurations
            SetConfig(new HostConfig
            {
                DefaultContentType = MimeTypes.Json,
                EnableFeatures = Feature.Json,
                PreferredContentTypes = new List<string> { MimeTypes.Json },
                MapExceptionToStatusCode = {
                    { typeof(InabilityToProcessPayloadException), (int) HttpStatusCode.BadRequest },
                }
            });

            // Exception Handlers
            ServiceExceptionHandlers.Add((httpReq, request, exception) => {
                var message = exception.Message;
                Log.Error(message);
                Log.Error(exception.GetResponseBody());
                Log.Info(httpReq.AbsoluteUri);
            return exception is DeclinePaymentException
                ? new HttpResult(
                    ProcessDto.GetErrorResponse(httpReq.AbsoluteUri, message, ((DeclinePaymentException)exception).ErrorCode),
                    HttpStatusCode.OK)
                : new HttpResult(null, HttpStatusCode.BadRequest);
            });

            UncaughtExceptionHandlers.Add((req, res, operationName, ex) => {
                Log.Error(ex.GetResponseBody());
                res.StatusCode = ex is SerializationException 
                    ? (int) HttpStatusCode.BadRequest
                    : (int) HttpStatusCode.InternalServerError;
                res.EndRequest(true);
            });

            // Global Filters
            PreRequestFilters.Add((req, res) => {
                Log.Info($"{HTTP_HEADER.HOST} : {req.UserHostAddress}");
                Log.Info($"{HTTP_HEADER.USER_AGENT} : {req.UserAgent}");
                Log.Info($"{HTTP_HEADER.CONTENT_LENGTH} : {req.ContentLength}");
                Log.Info($"{HTTP_HEADER.CONTENT_TYPE} : {req.ContentType}");
                Log.Info($"{HTTP_HEADER.ACCEPT} : {req.AcceptTypes}");
                Simulate500Error.CallMqServer();
            });

            // Validations
            Plugins.Add(new ValidationFeature());
            container.RegisterValidators(typeof(MerchantPaymentValidator).Assembly,
                typeof(MerchantPaymentAdviceValidator).Assembly,
                typeof(CashInValidator).Assembly, typeof(CashInAdviceValidator).Assembly,
                typeof(CashOutValidator).Assembly, typeof(CashOutAdviceValidator).Assembly);

            // IoC
            container.RegisterAutoWiredAs<AppSettings, IAppSettings>();
        }
    }
}
