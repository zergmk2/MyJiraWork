using System;
using System.Net;

namespace MyJiraWork.Core.Utils
{
    public class JiraRequestProxy : IWebProxy
    {
        public JiraRequestProxy(string userName, string password, string proxySrvUrl)
        {
            Credentials = new NetworkCredential(userName, password);
            ProxySrvUri = new Uri(proxySrvUrl);
        }

        #region private member
        private Uri proxySrvUri;
        private NetworkCredential credentials;
        #endregion

        #region properties
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

        public Uri ProxySrvUri
        {
            get
            {
                return proxySrvUri;
            }

            set
            {
                proxySrvUri = value;
            }
        }
        #endregion

        public Uri GetProxy(Uri destination)
        {
            return ProxySrvUri;
        }

        public bool IsBypassed(Uri host)
        {
            return false;
        }
    }
}
