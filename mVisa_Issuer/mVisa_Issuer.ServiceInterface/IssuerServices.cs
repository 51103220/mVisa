﻿using ServiceStack;
using mVisa_Issuer.ServiceModel;
using ServiceStack.Logging;
using Common.DTOs.Response;
using static Common.Constants;
using System.Threading.Tasks;
//using ServiceStack.Redis;
//using ServiceStack.Messaging.Redis;

namespace mVisa_Issuer.ServiceInterface
{
    public class IssuerServices : Service
    {
        private static ILog Log = LogManager.GetLogger(typeof(IssuerServices));
        //private static PooledRedisClientManager redisFactory = new PooledRedisClientManager(MQ_SERVER_ADDRESS);
        //private static RedisMqServer mqServer = new RedisMqServer(redisFactory, retryCount: 2);

        public async Task<IssuerCashInResponse> Post(IssuerCashInRequest request)
        {
            var response = await M_VISA.CASH_IN_PUSH_PAYMENT_URL.Post<CashInResponseDto>(request);
            return new IssuerCashInResponse { Result = response?.ToJson() };
        }

        public async Task<IssuerCashInResponse> Get(IssuerCashInRequest request)
        {
            var resource = $"{M_VISA.CASH_IN_PUSH_PAYMENT_URL}/{request?.StatusIdentifier}";
            var response = await resource.Get<CashInResponseDto>();
            return new IssuerCashInResponse { Result = response?.ToJson() };
        }

        public async Task<IssuerCashOutResponse> Post(IssuerCashOutRequest request)
        {
            var cashOutRequest = DummyDtoServices.NewCashOutRequestDto();
            var response = await M_VISA.CASH_OUT_PUSH_PAYMENT_URL.Post<CashOutResponseDto>(cashOutRequest);                              
            return new IssuerCashOutResponse { Result = response?.ToJson() };
        }

        public async Task<IssuerCashOutResponse> Get(IssuerCashOutRequest request)
        {
            var resource = $"{M_VISA.CASH_OUT_PUSH_PAYMENT_URL}/{request?.StatusIdentifier}";
            var response = await resource.Get<CashOutResponseDto>();
            return new IssuerCashOutResponse { Result = response?.ToJson() };
        }

        public async Task<IssuerMerchantPaymentResponse> Post(IssuerMerchantPaymentRequest request)
        {
            var merchantPaymentRequest = DummyDtoServices.NewMerchantPaymentRequestDto();
            var response = await M_VISA.MERCHANT_PUSH_PAYMENT_URL.Post<MerchantPaymentResponseDto>(merchantPaymentRequest);
            return new IssuerMerchantPaymentResponse { Result = response?.ToJson() };
        }

        public async Task<IssuerMerchantPaymentResponse> Get(IssuerMerchantPaymentRequest request)
        {
            var resource = $"{M_VISA.MERCHANT_PUSH_PAYMENT_URL}/{request?.StatusIdentifier}";
            var response = await resource.Get<MerchantPaymentResponseDto>();
            return new IssuerMerchantPaymentResponse { Result = response?.ToJson() };
        }

        private void PublishToMQ(object response)
        {
            //var mqClient = mqServer.CreateMessageQueueClient();
            //mqClient.Publish(new ISO8583 { MsgContent = response?.ToJson() });  
        }
    }
}