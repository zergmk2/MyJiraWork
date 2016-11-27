using GalaSoft.MvvmLight;
using MyJiraWork.Backend;
using MyJiraWork.Core.JsonClass;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyJiraWork.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {

        #region Private Members
        private ObservableCollection<UserStoryModel> userStories;
        private string titleName;
        #endregion

        #region Properties
        public ObservableCollection<UserStoryModel> UserStories
        {
            get
            {
                return userStories;
            }

            set
            {
                userStories = value;
                RaisePropertyChanged("UserStories");
            }
        }

        public string TitleName
        {
            get
            {
                return titleName;
            }

            set
            {
                titleName = value;
                RaisePropertyChanged("TitleName");
            }
        }
        #endregion

        #region Constructor
        public MainWindowViewModel()
        {
            UserStories = new ObservableCollection<UserStoryModel>();
            TitleName = "Jira Story";
            for (int i = 0; i < 3; i++)
            {
                if (ViewModelBase.IsInDesignModeStatic)
                { 
                    UserStories.Add(new UserStoryModel
                    {
                        Id = "1",
                        Key = "aaaaa",
                    });
                    UserStories.Add(new UserStoryModel
                    {
                        Id = "2",
                        Key = "bbbbbb",
                    });
                    UserStories.Add(new UserStoryModel
                    {
                        Id = "3",
                        Key = "cccccc",
                    });
                }
            }
        }
        #endregion

        #region Public Methods
        public async Task LoadIssuesAsync()
        {
            AssignedUserStories stories = await JiraBackend.Instance.Client.GetAssignedUserStoriesAsync();
            foreach (var issue in stories.issues)
            {
                UserStories.Add(new UserStoryModel(issue));
            }
        }
        #endregion
    }
}