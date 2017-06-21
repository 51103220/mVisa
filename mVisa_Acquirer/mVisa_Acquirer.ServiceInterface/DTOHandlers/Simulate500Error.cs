using ServiceStack.Redis;
using ServiceStack.Messaging.Redis;
using Common;
using Common.Messages;

namespace mVisa_Acquirer.ServiceInterface.DTOHandlers
{
    public static class Simulate500Error
    {
        private static PooledRedisClientManager redisFactory = new PooledRedisClientManager(Constants.MQ_SERVER_ADDRESS);
        private static RedisMqServer mqServer = new RedisMqServer(redisFactory, retryCount: 2);
        public static void CallMqServer()
        {
            var mqClient = mqServer.CreateMessageQueueClient();
            mqClient.Publish(new ISO8583 { MsgContent = string.Empty });  
        }
    }
}
