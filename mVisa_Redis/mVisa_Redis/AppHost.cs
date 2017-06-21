using Funq;
using ServiceStack;
using mVisa_Redis.ServiceInterface;
using Common.Messages;
using ServiceStack.Redis;
using ServiceStack.Messaging.Redis;

namespace mVisa_Redis
{
    //VS.NET Template Info: https://servicestack.net/vs-templates/EmptySelfHost
    public class AppHost : AppHostHttpListenerBase
    {
        /// <summary>
        /// Base constructor requires a Name and Assembly where web service implementation is located
        /// </summary>
        public AppHost()
            : base("mVisa_Redis", typeof(RedisMQServices).Assembly)
        { }

        /// <summary>
        /// Application specific configuration
        /// This method should initialize any IoC resources utilized by your web service classes.
        /// </summary>
        public override void Configure(Container container)
        {
            //Config examples
            //this.Plugins.Add(new PostmanFeature());
            //this.Plugins.Add(new CorsFeature());
            Routes.Add<ISO8583>(Common.Constants.PUSH_TO_MQ_URL);

            var redisFactory = new PooledRedisClientManager(Common.Constants.MQ_SERVER_ADDRESS);
            container.Register<IRedisClientsManager>(redisFactory);
            var mqHost = new RedisMqServer(redisFactory, retryCount: 2);

            //Server - MQ Service Impl:

            //Listens for 'Hello' messages sent with: mqClient.Publish(new Hello { ... })
            mqHost.RegisterHandler<ISO8583>(base.ExecuteMessage);
            mqHost.Start(); //Starts listening for messages
        }
    }
}
