using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkTracker.Model
{

    public class UserStory : JsonResponseBase
    {
        public UserStory()
        {

        }
        public string expand { get; set; }
        public string id { get; set; }
        public string self { get; set; }
        public string key { get; set; }
        public UserStoryFields fields { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format("{0,10} | {1, 15} | {2, 20}", id, key, fields.summary));
            return sb.ToString();
        }
    }

    public class UserStoryFields
    {
        public UserStoryFields()
        {

        }
        public object resolution { get; set; }
        public DateTime lastViewed { get; set; }
        public string[] labels { get; set; }
        public int? aggregatetimeoriginalestimate { get; set; }
        public object[] issuelinks { get; set; }
        public Assignee assignee { get; set; }
        public object[] components { get; set; }
        public object[] subtasks { get; set; }
        public Reporter reporter { get; set; }
        public Progress progress { get; set; }
        public Votes votes { get; set; }
        public Worklog worklog { get; set; }
        public Issuetype issuetype { get; set; }
        public Project project { get; set; }
        public object customfield_17901 { get; set; }
        public object resolutiondate { get; set; }
        public Watches watches { get; set; }
        public DateTime updated { get; set; }
        public int? timeoriginalestimate { get; set; }
        public string description { get; set; }
        public Timetracking timetracking { get; set; }
        public string summary { get; set; }
        public object environment { get; set; }
        public object duedate { get; set; }
        public Comment comment { get; set; }
        public Fixversion[] fixVersions { get; set; }
        public Priority priority { get; set; }
        public int? timeestimate { get; set; }
        public object[] versions { get; set; }
        public Status status { get; set; }
        public int? aggregatetimeestimate { get; set; }
        public Creator creator { get; set; }
        public Aggregateprogress aggregateprogress { get; set; }
        public int? timespent { get; set; }
        public int? aggregatetimespent { get; set; }
        public int? workratio { get; set; }
        public DateTime? created { get; set; }
        public object[] attachment { get; set; }
    }

    public class Worklog
    {
        public int startAt { get; set; }
        public int maxResults { get; set; }
        public int total { get; set; }
        public Worklog1[] worklogs { get; set; }
    }

    public class Worklog1
    {
        public string self { get; set; }
        public Author author { get; set; }
        public Updateauthor updateAuthor { get; set; }
        public string comment { get; set; }
        public DateTime created { get; set; }
        public DateTime updated { get; set; }
        public DateTime started { get; set; }
        public string timeSpent { get; set; }
        public int timeSpentSeconds { get; set; }
        public string id { get; set; }
        public string issueId { get; set; }
    }

    public class Author
    {
        public string self { get; set; }
        public string name { get; set; }
        public string key { get; set; }
        public string emailAddress { get; set; }
        public Avatarurls2 avatarUrls { get; set; }
        public string displayName { get; set; }
        public bool active { get; set; }
        public string timeZone { get; set; }
    }

    public class Updateauthor
    {
        public string self { get; set; }
        public string name { get; set; }
        public string key { get; set; }
        public string emailAddress { get; set; }
        public Avatarurls3 avatarUrls { get; set; }
        public string displayName { get; set; }
        public bool active { get; set; }
        public string timeZone { get; set; }
    }

    public class Timetracking
    {
        public string originalEstimate { get; set; }
        public string remainingEstimate { get; set; }
        public string timeSpent { get; set; }
        public int originalEstimateSeconds { get; set; }
        public int remainingEstimateSeconds { get; set; }
        public int timeSpentSeconds { get; set; }
    }

    public class Comment
    {
        public int startAt { get; set; }
        public int maxResults { get; set; }
        public int total { get; set; }
        public object[] comments { get; set; }
    }

      public class Avatarurls5
    {
        public string _48x48 { get; set; }
        public string _24x24 { get; set; }
        public string _16x16 { get; set; }
        public string _32x32 { get; set; }
    }

    public class Avatarurls6
    {
        public string _48x48 { get; set; }
        public string _24x24 { get; set; }
        public string _16x16 { get; set; }
        public string _32x32 { get; set; }
    }

}
