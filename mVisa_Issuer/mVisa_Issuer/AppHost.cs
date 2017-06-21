using Funq;
using ServiceStack;
using mVisa_Issuer.ServiceInterface;
//using ServiceStack.Redis;
//using ServiceStack.Messaging.Redis;
//using Common.Messages;
//using System;
using System.Collections.Generic;

namespace mVisa_Issuer
{
    //VS.NET Template Info: https://servicestack.net/vs-templates/EmptySelfHost
    public class AppHost : AppSelfHostBase
    {
        /// <summary>
        /// Base constructor requires a Name and Assembly where web service implementation is located
        /// </summary>
        public AppHost()
            : base("mVisa_Issuer", typeof(IssuerServices).Assembly)
        { }

        /// <summary>
        /// Application specific configuration
        /// This method should initialize any IoC resources utilized by your web service classes.
        /// </summary>
        public override void Configure(Container container)
        {
            // Global Configurations
            SetConfig(new HostConfig
            {
                DefaultContentType = MimeTypes.Json,
                EnableFeatures = Feature.Json,
                PreferredContentTypes = new List<string> { MimeTypes.Json },
            });

            //var redisFactory = new PooledRedisClientManager(Common.Constants.MQ_SERVER_ADDRESS);
            //var mqServer = new RedisMqServer(redisFactory, retryCount: 2);

            //mqServer.RegisterHandler<ISO8583Response>(m => {
             //   Console.WriteLine("Received: " + m.GetBody()?.MsgResult);
              //  return null;
           // });
            //mqServer.Start();
        }
    }
}
