using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Protobuf;
using MyJiraWork.Core.Utils.UserSetting;
using WorkTracker.Utils;

namespace WorkTracker.Command
{
    public static class SetUpUserSetting
    {
        public static UserSetting SetUp()
        {
            UserSetting userSetting = new UserSetting();
            try
            {
                Console.WriteLine("Please input the Jira Server Url : ");
                userSetting.JiraServerAddress = Console.ReadLine().Trim();
                Console.WriteLine(string.Format("Please input the user name of Jira Server {0} : ", userSetting.JiraServerAddress));
                userSetting.JiraUserName = Console.ReadLine().Trim();
                Console.WriteLine(string.Format("Please input the password of Jira Server {0} : ", userSetting.JiraServerAddress));
                userSetting.JiraPassword = Console.ReadLine().Trim();
                using (var output = File.Create(Common.UserSettingFilePath))
                {
                    userSetting.WriteTo(output);
                }
            }
            catch (Exception)
            {
            }
            return userSetting;
        }
    }
}
