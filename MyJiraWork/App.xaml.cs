using MaterialDesignThemes.Wpf;
using MyJiraWork.Core;
using MyJiraWork.Domain;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MyJiraWork
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        //override protected void OnStartup(StartupEventArgs e)
        //{
        //    //JiraClient client = new JiraClient();
        //    var view = new LoginViewDialog
        //    {
        //        DataContext = new LoginViewModel()
        //    };
        //    var result = view.();
        //    base.OnStartup(e);
        //}

        //private void ClosingEventHandler(object sender, DialogClosingEventArgs eventArgs)
        //{
        //    Console.WriteLine("You can intercept the closing event, and cancel here.");
        //}
    }
}
