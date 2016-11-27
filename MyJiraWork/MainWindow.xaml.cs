using MaterialDesignThemes.Wpf;
using MyJiraWork.Backend;
using MyJiraWork.Contracts;
using MyJiraWork.Core.JsonClass;
using MyJiraWork.Domain;
using MyJiraWork.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyJiraWork
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ColorZoneMouseDownHandler(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        protected override async void OnContentRendered(EventArgs e)
        {
            base.OnContentRendered(e);
            string credFilePath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"cred.json");
            JiraServerCredential cred = null;
            if (File.Exists(credFilePath))
            {
                using (StreamReader file = File.OpenText(credFilePath))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    cred = (JiraServerCredential)serializer.Deserialize(file, typeof(JiraServerCredential));
                }
            }

            if (cred == null || !File.Exists(credFilePath))
            {
                var view = new LoginViewDialog
                {
                    DataContext = new LoginViewModel()
                };
                ((LoginViewModel)view.DataContext).ServerRestVersionList.Add("Version 1");
                ((LoginViewModel)view.DataContext).ServerRestVersionList.Add("Version 2");
                var result = await DialogHost.Show(view, "RootDialog");

                Console.WriteLine("======================");
                Console.WriteLine(((LoginViewModel)view.DataContext).UserName);
                Console.WriteLine(((LoginViewModel)view.DataContext).Password);
                Console.WriteLine(((LoginViewModel)view.DataContext).JiraServerUrl);
                Console.WriteLine(((LoginViewModel)view.DataContext).ServerRestVersion);
                Console.WriteLine("======================");

                cred = new JiraServerCredential
                {
                    Username = ((LoginViewModel)view.DataContext).UserName,
                    Password = ((LoginViewModel)view.DataContext).Password,
                    ServerUrl = ((LoginViewModel)view.DataContext).JiraServerUrl,
                    ServerVersion = ((LoginViewModel)view.DataContext).ServerRestVersion,
                };

                // serialize JSON to a string and then write string to a file
                File.WriteAllText(credFilePath, JsonConvert.SerializeObject(cred));
                // serialize JSON directly to a file
            }
            int version = cred.ServerVersion.Equals("Version 2") ? 2 : 1;
            JiraBackend.Instance.Client = new Core.JiraClient(cred.ServerUrl,
                                                              cred.Username,
                                                              cred.Password,
                                                              version);

            await  (DataContext as MainWindowViewModel).LoadIssuesAsync();

            Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!");
        }

        private static async Task LoadSelfDataAyncAsync()
        {
            //JiraUser ret = await /*JiraBackend.Instance.Client.*/Myself();
            //Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@");
            //AssignedUserStories stories = await JiraBackend.Instance.Client.GetAssignedUserStoriesAsync();
            //Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@");
            //UserStory issue = await JiraBackend.Instance.Client.GetUserStoryAsync(@"issue/493291");
            //JiraUser ret = await JiraBackend.Instance.Client.MyselfAsync();
            //Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@");
            //AssignedUserStories stories = await JiraBackend.Instance.Client.GetAssignedUserStoriesAsync();
            //Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@");
        }


        private void WindowsLoadedHandler(object sender, RoutedEventArgs e)
        {

        }
    }
}
