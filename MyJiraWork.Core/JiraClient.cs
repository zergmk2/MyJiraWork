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
        public JiraClient(string ServerUrl, string userName, string password, int restVersion = 2)
        {
            restServerURL = GetRestApiUrl(ServerUrl, restVersion);
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
        private string GetRestApiUrl(string baseUrl, int restVersion)
        {
            var baseUri = new Uri(baseUrl);
            var jiraRestApiUri = new Uri(baseUri, "rest/api/" + restVersion.ToString());
            return jiraRestApiUri.ToString();
        }
        #endregion

        #region Public Methods
        public async Task<JiraUser> Myself()
        {
            try
            {
                var request = new RestRequest("myself", Method.GET);
                var a = client.BuildUri(request);
                var b = client.UserAgent;
                Task<IRestResponse<JiraUser>> response = client.Execute<JiraUser>(request);
                IRestResponse<JiraUser> r = await response;
                await Task.Delay(10000);
                if (r.IsSuccess)
                {
                    r.Data.Status = ResponseStatus.OK;
                    return r.Data;
                }
            }
            catch (Exception ex)
            {
                return new JiraUser
                {
                    Status = ResponseStatus.Failed,
                    FailureReason = ex.ToString()
                };
            }

            return null;
        }

        public async Task<AssignedUserStories> GetAssignedUserStoriesAsync()
        {
            try
            {
                var request = new RestRequest("search?jql=assignee=currentuser() AND resolution=unresolved", Method.GET);
                var a = client.BuildUri(request);
                var b = client.UserAgent;
                Task<IRestResponse<AssignedUserStories>> response = client.Execute<AssignedUserStories>(request);
                IRestResponse<AssignedUserStories> r = await response;
                await Task.Delay(10000);
                if (r.IsSuccess)
                {
                    r.Data.Status = ResponseStatus.OK;
                    return r.Data;
                }
            }
            catch (Exception ex)
            {
                return new AssignedUserStories
                {
                    Status = ResponseStatus.Failed,
                    FailureReason = ex.ToString()
                };
            }

            return null;
        }

        public async Task<UserStory> GetUserStoryAsync(string userStoryUrl)
        {
            try
            {
                var request = new RestRequest(userStoryUrl, Method.GET);
                var a = client.BuildUri(request);
                var b = client.UserAgent;
                Task<IRestResponse<UserStory>> response = client.Execute<UserStory>(request);
                IRestResponse<UserStory> r = await response;
                await Task.Delay(10000);
                if (r.IsSuccess)
                {
                    r.Data.Status = ResponseStatus.OK;
                    return r.Data;
                }
            }
            catch (Exception ex)
            {
                return new UserStory
                {
                    Status = ResponseStatus.Failed,
                    FailureReason = ex.ToString()
                };
            }

            return null;
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
