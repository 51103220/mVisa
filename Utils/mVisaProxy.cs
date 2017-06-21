using System;
using System.Net;

namespace Utils
{
    public class mVisaProxy : IWebProxy
    {
        public ICredentials Credentials
        {
            get { return new NetworkCredential("thanhnt27254", "P#ssw0rd", "SACOMBANK"); }
            set { }
        }

        public Uri GetProxy(Uri destination)
        {
            return new Uri("http://proxy.sacombank.corp.vn:3128");
        }

        public bool IsBypassed(Uri host)
        {
            return false;
        }
    }
}
