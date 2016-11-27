using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyJiraWork.Contracts
{
    public class JiraServerCredential
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string ServerUrl { get; set; }
        public string ServerVersion { get; set; }
    }
}
