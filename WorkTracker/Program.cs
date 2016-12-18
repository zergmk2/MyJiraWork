using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using CommandLine;
using CommandLine.Text;
using Google.Protobuf;
using MyJiraWork.Core.Utils.UserSetting;
using WorkTracker.Command;
using WorkTracker.Utils;

namespace WorkTracker
{
    class Program
    {
        static void Main(string[] args)
        {
            var options = new Options();
            if (args.Count<string>() != 0)
            {
                Console.WriteLine(options.GetUsage());
            }
            else
            {
                if (Parser.Default.ParseArguments(args, options))
                {
                    if (options.SetUpFlag)
                    {
                        UserSetting userSetting = SetUpUserSetting.SetUp();
                    
                    }

                    if (options.ListUserStories || true)
                    {
                        ListUserStory.ListUserStories();
                    }                   

                }
            }
            Console.Read();
        }
    }

    class Options
    {
        [Option('s', "setup", Required = false, HelpText = "Set up the configuration file.")]
        public bool SetUpFlag { get; set; }

        [Option('l', "List", Required = false, HelpText = "List all user stories assigned to you.")]
        public bool ListUserStories { get; set; }
        //[Option("length", DefaultValue = -1, HelpText = "The maximum number of bytes to process.")]
        //public int MaximumLength { get; set; }

        //[Option('v', null, HelpText = "Print details during execution.")]
        //public bool Verbose { get; set; }

        [HelpOption]
        public string GetUsage()
        {
            // this without using CommandLine.Text
            //  or using HelpText.AutoBuild
            var usage = new StringBuilder();
            usage.AppendLine("Work Tracker version : " + Assembly.GetExecutingAssembly().GetName().Version);
            usage.AppendLine("Read user manual for usage instructions...");
            usage.AppendLine(HelpText.AutoBuild(this));
            return usage.ToString();
        }
    }
}
