using MaterialDesignThemes.Wpf;
using MyJiraWork.Backend;
using MyJiraWork.Core.JsonClass;
using MyJiraWork.Domain;
using System;
using System.Collections.Generic;
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

            int version = ((LoginViewModel)view.DataContext).ServerRestVersion.Equals("Version 2") ? 2 : 1;

            JiraBackend.Instance.Client = new Core.JiraClient(((LoginViewModel)view.DataContext).JiraServerUrl,
                                                              ((LoginViewModel)view.DataContext).UserName,
                                                              ((LoginViewModel)view.DataContext).Password,
                                                              version);
            JiraUser ret = await JiraBackend.Instance.Client.Myself();

            Console.WriteLine("======================");
        }

        private async void WindowsLoadedHandler(object sender, RoutedEventArgs e)
        {

        }
    }
}
