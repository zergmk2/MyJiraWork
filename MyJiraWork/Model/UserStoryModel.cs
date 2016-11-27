using MyJiraWork.Common;
using MyJiraWork.Core.JsonClass;

namespace MyJiraWork.ViewModel
{
    public class UserStoryModel
    {
        private string id;
        private string key;
        private string summary;
        private string assignee;
        private string reporter;
        private int progressTime;
        private int totalTime;
        private UserStoryType userStoryType;
        private UserStoryPriority userStoryPriorty;

        public string Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Key
        {
            get
            {
                return key;
            }

            set
            {
                key = value;
            }
        }

        public UserStoryType UserStoryType
        {
            get
            {
                return userStoryType;
            }

            set
            {
                userStoryType = value;
            }
        }

        public UserStoryPriority UserStoryPriorty
        {
            get
            {
                return userStoryPriorty;
            }

            set
            {
                userStoryPriorty = value;
            }
        }

        public int TotalTime
        {
            get
            {
                return totalTime;
            }

            set
            {
                totalTime = value;
            }
        }

        public int ProgressTime
        {
            get
            {
                return progressTime;
            }

            set
            {
                progressTime = value;
            }
        }

        public string Reporter
        {
            get
            {
                return reporter;
            }

            set
            {
                reporter = value;
            }
        }

        public string Assignee
        {
            get
            {
                return assignee;
            }

            set
            {
                assignee = value;
            }
        }

        public string Summary
        {
            get
            {
                return summary;
            }

            set
            {
                summary = value;
            }
        }

        public UserStoryModel()
        {

        }
        public UserStoryModel(UserStory userStory)
        {
            Id = userStory.id;
            Key = userStory.key;
            Summary = userStory.fields.summary;
            Assignee = userStory.fields.assignee.name;
            Reporter = userStory.fields.reporter.name;
            ProgressTime = userStory.fields.progress.progress;
            TotalTime = userStory.fields.progress.total;
            UserStoryType = ConvertType(userStory.fields.issuetype.name);
            UserStoryPriorty = ConvertPriority(userStory.fields.priority.name);
        }

        private UserStoryType ConvertType(string typeName)
        {
            switch (typeName.ToUpper())
            {
                case "STORY":
                    return UserStoryType.USERSTORY;
                case "BUG":
                    return UserStoryType.BUG;

                default:
                    return UserStoryType.USERSTORY;
            }
        }

        private UserStoryPriority ConvertPriority(string priorityName)
        {
            switch (priorityName.ToUpper())
            {
                case "HIGH":
                    return UserStoryPriority.HIGH;
                case "LOW":
                    return UserStoryPriority.LOW;

                default:
                    return UserStoryPriority.HIGH;
            }
        }
    }

    public enum UserStoryPriority
    {
        HIGH,
        LOW,
    }
    public enum UserStoryStatus
    {
        RESOLVED,
        INPROGRESS,
    }
}