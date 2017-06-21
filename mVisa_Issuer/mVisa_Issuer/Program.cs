using System;
using System.Diagnostics;
using ServiceStack.Logging;
using ServiceStack.Logging.Log4Net;
using ServiceStack.Configuration;

namespace mVisa_Issuer
{
    class Program
    {
        static void Main(string[] args)
        {
            log4net.Config.XmlConfigurator.Configure();
            LogManager.LogFactory = new Log4NetFactory(configureLog4Net: true);
            var appSettings = new AppSettings();
            var port = appSettings.Get<string>(Common.Constants.PORT);
            var address = appSettings.Get<string>(Common.Constants.ADDRESS);

            new AppHost().Init().Start($"{address}:{port}/");           
            Process.Start($"{address}:{port}/");

            Console.ReadLine();
        }
    }
}
