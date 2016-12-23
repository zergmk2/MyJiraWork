using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkTracker.Model
{

    public class AssignedUserStories : JsonResponseBase
    {
        public AssignedUserStories()
        {

        }
        public string expand { get; set; }
        public int startAt { get; set; }
        public int maxResults { get; set; }
        public int total { get; set; }
        public Issue[] issues { get; set; }

    }

    public class Issue
    {
        public string expand { get; set; }
        public string id { get; set; }
        public string self { get; set; }
        public string key { get; set; }
        public Fields fields { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format("{0,10} | {1, 15} | {2, 20}", id, key, fields.summary));
            return sb.ToString();
        }
    }

    public class Fields
    {
        public object customfield_21400 { get; set; }
        public object customfield_21004 { get; set; }
        public object customfield_19201 { get; set; }
        public object customfield_21003 { get; set; }
        public object customfield_21002 { get; set; }
        public object customfield_21001 { get; set; }
        public object customfield_21000 { get; set; }
        public Customfield_18110 customfield_18110 { get; set; }
        public object customfield_15003 { get; set; }
        public object customfield_17301 { get; set; }
        public Fixversion[] fixVersions { get; set; }
        public object resolution { get; set; }
        public object customfield_11202 { get; set; }
        public object customfield_18904 { get; set; }
        public object customfield_19040 { get; set; }
        public object customfield_19041 { get; set; }
        public object customfield_18100 { get; set; }
        public object customfield_18101 { get; set; }
        public object customfield_19036 { get; set; }
        public DateTime? lastViewed { get; set; }
        public object customfield_19038 { get; set; }
        public object customfield_16200 { get; set; }
        public object customfield_19034 { get; set; }
        public object customfield_18108 { get; set; }
        public object customfield_18504 { get; set; }
        public Customfield_14300 customfield_14300 { get; set; }
        public Customfield_18109 customfield_18109 { get; set; }
        public Customfield_14301 customfield_14301 { get; set; }
        public object customfield_16201 { get; set; }
        public object customfield_14700 { get; set; }
        public string[] customfield_12004 { get; set; }
        public Priority priority { get; set; }
        public object customfield_10100 { get; set; }
        public object[] customfield_18500 { get; set; }
        public object customfield_14701 { get; set; }
        public object customfield_12003 { get; set; }
        public object customfield_18106 { get; set; }
        public Customfield_14302 customfield_14302 { get; set; }
        public string[] labels { get; set; }
        public Customfield_14303 customfield_14303 { get; set; }
        public string customfield_11700 { get; set; }
        public object customfield_17804 { get; set; }
        public int? aggregatetimeoriginalestimate { get; set; }
        public int? timeestimate { get; set; }
        public object[] versions { get; set; }
        public object[] issuelinks { get; set; }
        public object customfield_20019 { get; set; }
        public Customfield_21901[] customfield_21901 { get; set; }
        public object customfield_21900 { get; set; }
        public Assignee assignee { get; set; }
        public object customfield_20017 { get; set; }
        public object customfield_20018 { get; set; }
        public object customfield_21500 { get; set; }
        public Status status { get; set; }
        public object customfield_17120 { get; set; }
        public object customfield_19300 { get; set; }
        public object customfield_20014 { get; set; }
        public object[] components { get; set; }
        public Customfield_21100 customfield_21100 { get; set; }
        public object customfield_17124 { get; set; }
        public object customfield_17121 { get; set; }
        public object customfield_17126 { get; set; }
        public object customfield_17125 { get; set; }
        public object customfield_17803 { get; set; }
        public string customfield_19028 { get; set; }
        public object customfield_15900 { get; set; }
        public object customfield_11301 { get; set; }
        public object customfield_13600 { get; set; }
        public object customfield_14407 { get; set; }
        public object customfield_14408 { get; set; }
        public object customfield_14405 { get; set; }
        public object customfield_14406 { get; set; }
        public int? aggregatetimeestimate { get; set; }
        public object customfield_14409 { get; set; }
        public object customfield_20406 { get; set; }
        public object customfield_20803 { get; set; }
        public Creator creator { get; set; }
        public object customfield_14121 { get; set; }
        public string customfield_14000 { get; set; }
        public object[] subtasks { get; set; }
        public object customfield_14400 { get; set; }
        public Reporter reporter { get; set; }
        public object customfield_14001 { get; set; }
        public string customfield_15212 { get; set; }
        public object customfield_16300 { get; set; }
        public Aggregateprogress aggregateprogress { get; set; }
        public object customfield_14403 { get; set; }
        public object customfield_14404 { get; set; }
        public object customfield_14800 { get; set; }
        public Customfield_10200[] customfield_10200 { get; set; }
        public object customfield_14401 { get; set; }
        public object customfield_17119 { get; set; }
        public object customfield_14402 { get; set; }
        public object customfield_17910 { get; set; }
        public object customfield_17906 { get; set; }
        public object customfield_17905 { get; set; }
        public object customfield_14119 { get; set; }
        public object customfield_17903 { get; set; }
        public object customfield_17909 { get; set; }
        public object customfield_17908 { get; set; }
        public object customfield_17907 { get; set; }
        public Progress progress { get; set; }
        public Votes votes { get; set; }
        public Customfield_21600 customfield_21600 { get; set; }
        public object customfield_21203 { get; set; }
        public object customfield_19123 { get; set; }
        public Issuetype issuetype { get; set; }
        public object customfield_19124 { get; set; }
        public object customfield_21201 { get; set; }
        public object customfield_19125 { get; set; }
        public object customfield_20231 { get; set; }
        public object customfield_19126 { get; set; }
        public object customfield_19120 { get; set; }
        public object customfield_19121 { get; set; }
        public int? timespent { get; set; }
        public object customfield_19122 { get; set; }
        public object customfield_19802 { get; set; }
        public Customfield_17502 customfield_17502 { get; set; }
        public Project project { get; set; }
        public object customfield_13025 { get; set; }
        public object customfield_14117 { get; set; }
        public object customfield_19127 { get; set; }
        public int? aggregatetimespent { get; set; }
        public object customfield_14118 { get; set; }
        public object customfield_17901 { get; set; }
        public object customfield_13821 { get; set; }
        public object customfield_13820 { get; set; }
        public float? customfield_10303 { get; set; }
        public object customfield_12603 { get; set; }
        public object customfield_10305 { get; set; }
        public object customfield_13815 { get; set; }
        public object resolutiondate { get; set; }
        public int workratio { get; set; }
        public object customfield_20225 { get; set; }
        public Watches watches { get; set; }
        public object customfield_19114 { get; set; }
        public object customfield_22002 { get; set; }
        public object customfield_22001 { get; set; }
        public object customfield_22000 { get; set; }
        public object customfield_16000 { get; set; }
        public DateTime created { get; set; }
        public object customfield_14502 { get; set; }
        public object customfield_19116 { get; set; }
        public object customfield_19117 { get; set; }
        public object customfield_14500 { get; set; }
        public object customfield_19118 { get; set; }
        public object customfield_19119 { get; set; }
        public string customfield_11900 { get; set; }
        public Customfield_21708 customfield_21708 { get; set; }
        public Customfield_21707 customfield_21707 { get; set; }
        public Customfield_21706 customfield_21706 { get; set; }
        public object customfield_21705 { get; set; }
        public object customfield_21704 { get; set; }
        public object customfield_21703 { get; set; }
        public object customfield_21702 { get; set; }
        public object customfield_21701 { get; set; }
        public object customfield_21700 { get; set; }
        public DateTime updated { get; set; }
        public int? timeoriginalestimate { get; set; }
        public string description { get; set; }
        public object customfield_19506 { get; set; }
        public object customfield_10010 { get; set; }
        public object customfield_10012 { get; set; }
        public object customfield_17209 { get; set; }
        public object customfield_15700 { get; set; }
        public object customfield_10005 { get; set; }
        public object customfield_12706 { get; set; }
        public object customfield_20602 { get; set; }
        public object customfield_20603 { get; set; }
        public string summary { get; set; }
        public object customfield_16501 { get; set; }
        public object customfield_14200 { get; set; }
        public object customfield_14601 { get; set; }
        public object customfield_16505 { get; set; }
        public object customfield_10002 { get; set; }
        public string customfield_12300 { get; set; }
        public object customfield_16504 { get; set; }
        public Customfield_12302 customfield_12302 { get; set; }
        public object customfield_11204 { get; set; }
        public string environment { get; set; }
        public object duedate { get; set; }
        public object customfield_11606 { get; set; }
        public object customfield_21009 { get; set; }
        public object customfield_21801 { get; set; }
        public object customfield_21008 { get; set; }
        public object customfield_21800 { get; set; }
        public object customfield_21007 { get; set; }
        public object customfield_21006 { get; set; }
        public object customfield_21005 { get; set; }
        public object customfield_17904 { get; set; }
        public object customfield_18724 { get; set; }
        public object customfield_12501 { get; set; }
    }

    public class Customfield_18110
    {
        public string self { get; set; }
        public string value { get; set; }
        public string id { get; set; }
    }

    public class Customfield_14300
    {
        public string errorMessage { get; set; }
        public I18nerrormessage i18nErrorMessage { get; set; }
    }

    public class I18nerrormessage
    {
        public string i18nKey { get; set; }
        public object[] parameters { get; set; }
    }

    public class Customfield_18109
    {
        public string self { get; set; }
        public string value { get; set; }
        public string id { get; set; }
    }

    public class Customfield_14301
    {
        public string errorMessage { get; set; }
        public I18nerrormessage1 i18nErrorMessage { get; set; }
    }

    public class I18nerrormessage1
    {
        public string i18nKey { get; set; }
        public object[] parameters { get; set; }
    }

    public class Priority
    {
        public string self { get; set; }
        public string iconUrl { get; set; }
        public string name { get; set; }
        public string id { get; set; }
    }

    public class Customfield_14302
    {
        public string errorMessage { get; set; }
        public I18nerrormessage2 i18nErrorMessage { get; set; }
    }

    public class I18nerrormessage2
    {
        public string i18nKey { get; set; }
        public object[] parameters { get; set; }
    }

    public class Customfield_14303
    {
        public string errorMessage { get; set; }
        public I18nerrormessage3 i18nErrorMessage { get; set; }
    }

    public class I18nerrormessage3
    {
        public string i18nKey { get; set; }
        public object[] parameters { get; set; }
    }

    public class Assignee
    {
        public string self { get; set; }
        public string name { get; set; }
        public string key { get; set; }
        public string emailAddress { get; set; }
        public Avatarurls avatarUrls { get; set; }
        public string displayName { get; set; }
        public bool active { get; set; }
        public string timeZone { get; set; }
    }

    public class Status
    {
        public string self { get; set; }
        public string description { get; set; }
        public string iconUrl { get; set; }
        public string name { get; set; }
        public string id { get; set; }
        public Statuscategory statusCategory { get; set; }
    }

    public class Statuscategory
    {
        public string self { get; set; }
        public int id { get; set; }
        public string key { get; set; }
        public string colorName { get; set; }
        public string name { get; set; }
    }

    public class Customfield_21100
    {
        public string errorMessage { get; set; }
        public I18nerrormessage4 i18nErrorMessage { get; set; }
    }

    public class I18nerrormessage4
    {
        public string i18nKey { get; set; }
        public object[] parameters { get; set; }
    }

    public class Creator
    {
        public string self { get; set; }
        public string name { get; set; }
        public string key { get; set; }
        public string emailAddress { get; set; }
        public Avatarurls1 avatarUrls { get; set; }
        public string displayName { get; set; }
        public bool active { get; set; }
        public string timeZone { get; set; }
    }

    public class Avatarurls1
    {
        public string _48x48 { get; set; }
        public string _24x24 { get; set; }
        public string _16x16 { get; set; }
        public string _32x32 { get; set; }
    }

    public class Reporter
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

    public class Avatarurls2
    {
        public string _48x48 { get; set; }
        public string _24x24 { get; set; }
        public string _16x16 { get; set; }
        public string _32x32 { get; set; }
    }

    public class Aggregateprogress
    {
        public int progress { get; set; }
        public int total { get; set; }
        public int percent { get; set; }
    }

    public class Progress
    {
        public int progress { get; set; }
        public int total { get; set; }
        public int percent { get; set; }
    }

    public class Votes
    {
        public string self { get; set; }
        public int votes { get; set; }
        public bool hasVoted { get; set; }
    }

    public class Customfield_21600
    {
        public string errorMessage { get; set; }
        public I18nerrormessage5 i18nErrorMessage { get; set; }
    }

    public class I18nerrormessage5
    {
        public string i18nKey { get; set; }
        public object[] parameters { get; set; }
    }

    public class Issuetype
    {
        public string self { get; set; }
        public string id { get; set; }
        public string description { get; set; }
        public string iconUrl { get; set; }
        public string name { get; set; }
        public bool subtask { get; set; }
        public int avatarId { get; set; }
    }

    public class Customfield_17502
    {
        public string self { get; set; }
        public string value { get; set; }
        public string id { get; set; }
    }

    public class Project
    {
        public string self { get; set; }
        public string id { get; set; }
        public string key { get; set; }
        public string name { get; set; }
        public Avatarurls3 avatarUrls { get; set; }
        public Projectcategory projectCategory { get; set; }
    }

    public class Avatarurls3
    {
        public string _48x48 { get; set; }
        public string _24x24 { get; set; }
        public string _16x16 { get; set; }
        public string _32x32 { get; set; }
    }

    public class Projectcategory
    {
        public string self { get; set; }
        public string id { get; set; }
        public string description { get; set; }
        public string name { get; set; }
    }

    public class Watches
    {
        public string self { get; set; }
        public int watchCount { get; set; }
        public bool isWatching { get; set; }
    }

    public class Customfield_21708
    {
        public string errorMessage { get; set; }
        public I18nerrormessage6 i18nErrorMessage { get; set; }
    }

    public class I18nerrormessage6
    {
        public string i18nKey { get; set; }
        public object[] parameters { get; set; }
    }

    public class Customfield_21707
    {
        public string errorMessage { get; set; }
        public I18nerrormessage7 i18nErrorMessage { get; set; }
    }

    public class I18nerrormessage7
    {
        public string i18nKey { get; set; }
        public object[] parameters { get; set; }
    }

    public class Customfield_21706
    {
        public string errorMessage { get; set; }
        public I18nerrormessage8 i18nErrorMessage { get; set; }
    }

    public class I18nerrormessage8
    {
        public string i18nKey { get; set; }
        public object[] parameters { get; set; }
    }

    public class Customfield_12302
    {
        public string self { get; set; }
        public string value { get; set; }
        public string id { get; set; }
    }

    public class Fixversion
    {
        public string self { get; set; }
        public string id { get; set; }
        public string description { get; set; }
        public string name { get; set; }
        public bool archived { get; set; }
        public bool released { get; set; }
        public string releaseDate { get; set; }
    }

    public class Customfield_21901
    {
        public string self { get; set; }
        public string value { get; set; }
        public string id { get; set; }
    }

    public class Customfield_10200
    {
        public string self { get; set; }
        public string name { get; set; }
        public string key { get; set; }
        public string emailAddress { get; set; }
        public Avatarurls4 avatarUrls { get; set; }
        public string displayName { get; set; }
        public bool active { get; set; }
        public string timeZone { get; set; }
    }

    public class Avatarurls4
    {
        public string _48x48 { get; set; }
        public string _24x24 { get; set; }
        public string _16x16 { get; set; }
        public string _32x32 { get; set; }
    }
}
