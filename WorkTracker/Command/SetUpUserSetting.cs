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
                ConsoleKeyInfo key;
                var sb = new StringBuilder();
                do
                {
                    key = Console.ReadKey(true);
                    if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                    {
                        sb.Append(key.KeyChar);
                        Console.Write("*");
                    }
                    else
                    {
                        if (key.Key == ConsoleKey.Backspace && sb.Length > 0)
                        {
                            sb.Remove(sb.Length - 1, 1);
                            Console.Write("\b \b");
                        }
                    }
                } while (key.Key != ConsoleKey.Enter);
                userSetting.JiraPassword = sb.ToString();
                sb.Clear();
                Console.Write(Environment.NewLine);

                Console.WriteLine(string.Format(@"Please input the Proxy server URL, for example : http://proxy.server.com:80 "));
                userSetting.ProxyServer = Console.ReadLine().Trim();
                Console.WriteLine(string.Format("Please input the user name of Proxy Server {0} : ", userSetting.ProxyServer));
                userSetting.ProxyUserName = Console.ReadLine().Trim();
                Console.WriteLine(string.Format("Please input the password of Proxy Server {0} : ", userSetting.ProxyServer));
                do
                {
                    key = Console.ReadKey(true);
                    if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                    {
                        sb.Append(key.KeyChar);
                        Console.Write("*");
                    }
                    else
                    {
                        if (key.Key == ConsoleKey.Backspace && sb.Length > 0)
                        {
                            sb.Remove(sb.Length - 1, 1);
                            Console.Write("\b \b");
                        }
                    }
                } while (key.Key != ConsoleKey.Enter);
                Console.WriteLine(Environment.NewLine);
                userSetting.ProxyPassword = sb.ToString();

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
