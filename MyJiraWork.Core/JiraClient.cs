using MyJiraWork.Core.JsonClass;
using RestSharp.Portable;
using RestSharp.Portable.Authenticators;
using RestSharp.Portable.HttpClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MyJiraWork.Core
{
    public class JiraClient
    {
        #region Constructor
        public JiraClient(string ServerUrl, string userName, string password)
        {
            restServerURL = GetRestApiUrl(ServerUrl);
            client = new RestClient(restServerURL);
            client.Authenticator = new HttpBasicAuthenticator(userName, password);
            client.UserAgent = "Safari/537.36";
        }
        #endregion

        #region Private Members
        private RestClient client;
        private string restServerURL;
        #endregion

        #region Private Methods
        private string GetRestApiUrl(string baseUrl)
        {
            var baseUri = new Uri(baseUrl);
            var jiraRestApiUri = new Uri(baseUri, "rest/api/2");
            return jiraRestApiUri.ToString();
        }
        #endregion

        #region Public Methods
        public async Task Test()
        {
            Debug.WriteLine("===========================================");
            Debug.WriteLine("===========================================");
            Debug.WriteLine("===========================================");
            Debug.WriteLine("===========================================");
            JiraUser re = await Myself();
            Debug.WriteLine("===========================================");
            Debug.WriteLine("===========================================");
        }
        public async Task<JiraUser> Myself()
        {
            var request = new RestRequest("myself", Method.GET);
            var a = client.BuildUri(request);
            var b = client.UserAgent;
            Task<IRestResponse<JiraUser>> response = client.Execute<JiraUser>(request);
            IRestResponse<JiraUser> r = await response;
            return r.Data as JiraUser;
        }
        #endregion

        #region Property
        public RestClient Client
        {
            get
            {
                return client;
            }

            set
            {
                client = value;
            }
        }
        #endregion
    }
}
