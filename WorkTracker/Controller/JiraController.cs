using System;
using MyJiraWork.Core.Utils.UserSetting;
using WorkTracker.RestEngine;
using System.IO;
using WorkTracker.Utils;

namespace WorkTracker.Controller
{
    public class JiraController
    {
       
        private JiraClient client;
        private UserSetting userSetting;
        public JiraController()
        {
            try
            {
                if (File.Exists(Common.UserSettingFilePath))
                {
                    using (var input = File.OpenRead(Common.UserSettingFilePath))
                    {
                        UserSetting = UserSetting.Parser.ParseFrom(input);
                        Client = JiraClient.Instance;
                        Client.InitializeClient(UserSetting.JiraServerAddress, UserSetting.JiraUserName, UserSetting.JiraPassword);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception occurred in JiraController constructor : " + ex.ToString());               
            }
        }

        public JiraController(UserSetting userSetting)
        {
            Client = JiraClient.Instance;
            Client.InitializeClient(userSetting.JiraServerAddress, userSetting.JiraUserName, userSetting.JiraPassword);
        }

        public JiraClient Client
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

        public UserSetting UserSetting
        {
            get
            {
                return userSetting;
            }

            set
            {
                userSetting = value;
            }
        }
    }
}
