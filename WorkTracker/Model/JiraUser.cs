using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkTracker.Model
{
    public class JiraUser : JsonResponseBase
    {
        public string self { get; set; }
        public string key { get; set; }
        public string name { get; set; }
        public string emailAddress { get; set; }
        public Avatarurls avatarUrls { get; set; }
        public string displayName { get; set; }
        public bool active { get; set; }
        public string timeZone { get; set; }
        public string locale { get; set; }
        public Groups groups { get; set; }
        public Applicationroles applicationRoles { get; set; }

    }
    public class Avatarurls
    {
        [JsonProperty(PropertyName = "16x16")]
        public string _16x16 { get; set; }
        [JsonProperty(PropertyName = "24x24")]
        public string _24x24 { get; set; }
        [JsonProperty(PropertyName = "32x32")]
        public string _32x32 { get; set; }
        [JsonProperty(PropertyName = "48x48")]
        public string _48x48 { get; set; }
    }

    public class Groups
    {
        public int size { get; set; }
        public object[] items { get; set; }
    }

    public class Applicationroles
    {
        public int size { get; set; }
        public object[] items { get; set; }
    }
}
