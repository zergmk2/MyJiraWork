using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyJiraWork.Core.Utils.UserSetting;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using WorkTracker.Contract;
using WorkTracker.Model;
using WorkTracker.Utils;
using System.Net;
using MyJiraWork.Core.Utils;

namespace WorkTracker.RestEngine
{
    public class JiraClient : SingletonBase<JiraClient>
    {
        #region Constructor
        public JiraClient()
        {
            client = new RestClient();
        }
        #endregion

        #region Private Members
        private RestClient client;
        private Uri restServerURL;
        private UserSetting userSetting;
        #endregion

        #region Private Methods
        private Uri GetRestApiUrl(string baseUrl, int restVersion)
        {
            var baseUri = new Uri(baseUrl);
            var jiraRestApiUri = new Uri(baseUri, "rest/api/" + restVersion.ToString());
            return jiraRestApiUri;
        }
        #endregion

        #region Public Methods
        public void InitializeClient(string ServerUrl, string userName, string password, int restVersion = 2)
        {
            restServerURL = GetRestApiUrl(ServerUrl, restVersion);
            client.BaseUrl = restServerURL;
            client.Authenticator = new HttpBasicAuthenticator(userName, password);
            client.UserAgent = "Safari/537.36";
        }

        public void InitializeClient()
        {
            try
            {
                if (File.Exists(Common.UserSettingFilePath))
                {
                    using (var stream = new MemoryStream())
                    {
                        CryptographyUtils.DecryptFiletoStream(Common.UserSettingFilePath, stream, Common.GetMachineGuid());
                        stream.Position = 0;
                        userSetting = UserSetting.Parser.ParseFrom(stream);
                        InitializeClient(userSetting.JiraServerAddress, userSetting.JiraUserName, userSetting.JiraPassword);
                        if (!string.IsNullOrEmpty(userSetting.ProxyServer))
                        {
                            JiraRequestProxy myProxy = new JiraRequestProxy(userSetting.ProxyUserName, userSetting.ProxyPassword, userSetting.ProxyServer);
                            client.Proxy = myProxy;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception occurred in JiraController constructor : " + ex.ToString());
            }
        }

        public async Task<JiraUser> MyselfAsync()
        {
            try
            {
                var data = await Task.Run<JiraUser>(() =>
                {
                    var request = new RestRequest("myself", Method.GET);
                    var a = client.BuildUri(request);
                    var b = client.UserAgent;
                    IRestResponse<JiraUser> response = client.Execute<JiraUser>(request);
                    if (response.ErrorException == null)
                    {
                        response.Data.Status = ResponseStatus.Completed;
                        return response.Data;
                    }
                    else
                    {
                        return new JiraUser
                        {
                            Status = ResponseStatus.Error,
                            FailureReason = response.ErrorException.ToString()
                        };
                    }
                });
                return data;
            }
            catch (Exception ex)
            {
                return new JiraUser
                {
                    Status = ResponseStatus.Error,
                    FailureReason = ex.ToString()
                };
            }
        }

        public AssignedUserStories GetAssignedUserStories()
        {
            try
            {
                var request = new RestRequest("search?jql=assignee=currentuser() AND resolution=unresolved", Method.GET);
                var a = client.BuildUri(request);
                var b = client.UserAgent;
                IRestResponse response = client.Execute(request);
                if (response.ErrorException == null)
                {
                    var keyResponse = JsonConvert.DeserializeObject<AssignedUserStories>(response.Content);
                    keyResponse.Status = ResponseStatus.Completed;
                    return keyResponse;
                }
                else
                {
                    return new AssignedUserStories
                    {
                        Status = ResponseStatus.Error,
                        FailureReason = response.ErrorException.ToString()
                    };
                }
            }
            catch (Exception ex)
            {
                return new AssignedUserStories
                {
                    Status = ResponseStatus.Error,
                    FailureReason = ex.ToString()
                };
            }
        }

        public async Task<AssignedUserStories> GetAssignedUserStoriesAsync()
        {
            try
            {
                var data = await Task.Run<AssignedUserStories>(() =>
                {
                    var request = new RestRequest("search?jql=assignee=currentuser() AND resolution=unresolved", Method.GET);
                    var a = client.BuildUri(request);
                    var b = client.UserAgent;
                    IRestResponse response = client.Execute(request);
                    if (response.ErrorException == null)
                    {
                        var keyResponse = JsonConvert.DeserializeObject<AssignedUserStories>(response.Content);
                        keyResponse.Status = ResponseStatus.Completed;
                        return keyResponse;
                    }
                    else
                    {
                        return new AssignedUserStories
                        {
                            Status = ResponseStatus.Error,
                            FailureReason = response.ErrorException.ToString()
                        };
                    }
                });
                return data;
            }
            catch (Exception ex)
            {
                return new AssignedUserStories
                {
                    Status = ResponseStatus.Error,
                    FailureReason = ex.ToString()
                };
            }
        }

        public async Task<UserStory> GetUserStoryAsync(string userStoryUrl)
        {
            try
            {
                var data = await Task.Run<UserStory>(() =>
                {
                    var request = new RestRequest(userStoryUrl, Method.GET);
                    var a = client.BuildUri(request);
                    var b = client.UserAgent;
                    IRestResponse response = client.Execute(request);
                    if (response.ErrorException == null)
                    {
                        var keyResponse = JsonConvert.DeserializeObject<UserStory>(response.Content);
                        keyResponse.Status = ResponseStatus.Completed;
                        return keyResponse;
                    }
                    else
                    {
                        return new UserStory
                        {
                            Status = ResponseStatus.Error,
                            FailureReason = response.ErrorException.ToString()
                        };
                    }
                });
                return data;
            }
            catch (Exception ex)
            {
                return new UserStory
                {
                    Status = ResponseStatus.Error,
                    FailureReason = ex.ToString()
                };
            }
        }

        public UserStory GetUserStory(string userStoryUrl)
        {
            try
            {
                var request = new RestRequest(userStoryUrl, Method.GET);
                var a = client.BuildUri(request);
                var b = client.UserAgent;
                var response = client.Execute(request);
                if (response.ErrorException == null)
                {
                    var keyResponse = JsonConvert.DeserializeObject<UserStory>(response.Content);
                    keyResponse.Status = ResponseStatus.Completed;
                    return keyResponse;
                }
                else
                {
                    return new UserStory
                    {
                        Status = ResponseStatus.Error,
                        FailureReason = response.ErrorException.ToString()
                    };
                }
            }
            catch (Exception ex)
            {
                return new UserStory
                {
                    Status = ResponseStatus.Error,
                    FailureReason = ex.ToString()
                };
            }
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
