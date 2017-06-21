using Common.Messages;
using ServiceStack;
namespace mVisa_Redis.ServiceInterface
{
    public class RedisMQServices : Service
    {
        public object Post(ISO8583 request)
        {
            return new ISO8583Response { MsgResult = "Message returned from MQ" };
        }
    }
}