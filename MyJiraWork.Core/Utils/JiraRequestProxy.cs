using RestSharp.Portable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace MyJiraWork.Core.Utils
{
    public class JiraRequestProxy : IRequestProxy
    {
        public JiraRequestProxy()
        {

        }

        private NetworkCredential credentials;
        public ICredentials Credentials
        {
            get
            {
                return credentials;
            }
            set
            {
                if (value is NetworkCredential)
                {
                    credentials = value as NetworkCredential;
                }
            }
        }

        public Uri GetProxy(Uri destination)
        {
            return new Uri("http://192.168.31.152:3128");
        }

        public bool IsBypassed(Uri host)
        {
            return false;
        }
    }
}
