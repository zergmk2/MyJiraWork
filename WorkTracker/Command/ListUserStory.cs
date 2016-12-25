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
                Console.WriteLine(new String('-', 115));
                Console.WriteLine(string.Format("| {0,10} | {1, 15} | {2, -80} |", "id", "User Story Key", "User Story Summary"));
                Console.WriteLine(new String('-', 115));
                for(int i = 0; i < data.issues.Length; i++)
                {
                    var issue = data.issues[i];
                    string summary = issue.fields.summary;
                    if (summary.Length > 78)
                    {
                        summary = summary.Substring(0, 75) + "...";
                    }
                    Console.WriteLine(string.Format("| {0,10} | {1, 15} | {2, -80} |", i, issue.key, summary));
                }
                Console.WriteLine(new String('-', 115));
            }
        }
    }
}
