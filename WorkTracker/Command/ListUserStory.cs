using System;
using System.IO;
using WorkTracker.RestEngine;
using WorkTracker.Utils;

namespace WorkTracker.Command
{
    public static class ListUserStory
    {
        public static async void ListUserStories()
        {
            if (!File.Exists(Common.UserSettingFilePath))
            {
                SetUpUserSetting.SetUp();
            }

            JiraClient Client = JiraClient.Instance;
            Client.InitializeClient();
            var data = Client.GetAssignedUserStories();
            if (data.Status == RestSharp.ResponseStatus.Completed)
            {
                foreach (var item in data.issues)
                {
                    Console.WriteLine(item.ToString());
                }
            }
        }
    }
}
