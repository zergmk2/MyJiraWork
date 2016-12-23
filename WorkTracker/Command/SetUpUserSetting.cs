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
                Console.WriteLine(@"Please input the Jira Server Url, for example : https://jira.server.com/");
                userSetting.JiraServerAddress = Console.ReadLine().Trim();
                Console.WriteLine(string.Format("Please input the user name of Jira Server {0} : ", userSetting.JiraServerAddress));
                userSetting.JiraUserName = Console.ReadLine().Trim();
                Console.WriteLine(string.Format("Please input the password of Jira Server {0} : ", userSetting.JiraServerAddress));
                userSetting.JiraPassword = Console.ReadLine().Trim();
                Console.WriteLine(string.Format(@"Please input the Proxy server URL, for example : http://proxy.server.com:80 "));
                userSetting.ProxyServer = Console.ReadLine().Trim();
                Console.WriteLine(string.Format("Please input the user name of Proxy Server {0} : ", userSetting.ProxyServer));
                userSetting.ProxyUserName = Console.ReadLine().Trim();
                Console.WriteLine(string.Format("Please input the password of Proxy Server {0} : ", userSetting.ProxyServer));
                userSetting.ProxyPassword = Console.ReadLine().Trim();

                using (var memoryStream = new MemoryStream())
                {
                    userSetting.WriteTo(memoryStream);
                    memoryStream.Flush();
                    CryptographyUtils.EncryptStreamtoFile(memoryStream, Common.UserSettingFilePath, Common.GetMachineGuid());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return userSetting;
        }
    }
}
