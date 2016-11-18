using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace MyJiraWork.Domain
{
    internal class LoginViewModel : ViewModelBase
    {
        #region Private Members
        private string userName;
        private string password;
        private string jiraServerUrl;
        private string serverRestVersion;
        private ObservableCollection<string> serverRestVersionList = new ObservableCollection<string>();
        #endregion


        #region Properties
        public string UserName
        {
            get { return userName; }
            set
            {
                userName = value;
                RaisePropertyChanged("UserName");
            }
        }

        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
                RaisePropertyChanged("Password");
            }
        }

        public string JiraServerUrl
        {
            get
            {
                return jiraServerUrl;
            }

            set
            {
                jiraServerUrl = value;
                RaisePropertyChanged("JiraServerUrl");
            }
        }

        public string ServerRestVersion
        {
            get
            {
                return serverRestVersion;
            }

            set
            {
                serverRestVersion = value;
                RaisePropertyChanged("ServerRestVersion");
            }
        }

        public ObservableCollection<string> ServerRestVersionList
        {
            get
            {
                return serverRestVersionList;
            }

            set
            {
                serverRestVersionList = value;
                RaisePropertyChanged("ServerRestVersionList");
            }
        }
        #endregion
    }
}
