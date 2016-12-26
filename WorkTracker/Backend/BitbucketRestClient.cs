using MyJiraWork.Core.Utils;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.IO;
using WorkTracker.Contract;
using WorkTracker.Utils;

namespace WorkTracker.Backend
{
    public class BitbucketRestClient : SingletonBase<BitbucketRestClient>
    {
        #region Private Member
        private static object _lock = new object();
        private static bool isInitialized;
        private RestClient client;
        private Uri restServerURL;
        private UserSetting userSetting;
        #endregion

        #region Properties
        public bool IsInitialized
        {
            get { return isInitialized; }
            set
            {
                lock (_lock)
                {
                    isInitialized = value;
                }
            }
        }

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

        #region Constructor
        public BitbucketRestClient()
        {
            client = new RestClient();
        }
        #endregion
        
        #region Public Methods
        public bool InitializeClient(string ServerUrl, string userName, string password, int restVersion = 1)
        {
            lock (_lock)
            {
                if (!isInitialized && !string.IsNullOrEmpty(ServerUrl) &&
                    !string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(password))
                {
                    try
                    {
                        restServerURL = GetRestApiUrl(ServerUrl, restVersion);
                        client.BaseUrl = restServerURL;
                        client.Authenticator = new HttpBasicAuthenticator(userName, password);
                        client.UserAgent = "Safari/537.36";
                        return true;
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
            return false;
        }

        public bool InitializeClient(GitClient gitClient)
        {
            lock (_lock)
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
            return false;
        }
        #endregion

        #region Private Methods
        private Uri GetRestApiUrl(string baseUrl, int restVersion)
        {
            var baseUri = new Uri(baseUrl);
            var jiraRestApiUri = new Uri(baseUri, "rest/api/" + restVersion.ToString());
            return jiraRestApiUri;
        }
        #endregion
    }
}
