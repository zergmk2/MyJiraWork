using MyJiraWork.Contracts;
using MyJiraWork.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyJiraWork.Backend
{
    internal class JiraBackend : SingletonBase<JiraBackend>
    {
        #region Private Members
        private JiraClient client;
        #endregion

        #region Properties
        public JiraClient Client
        {
            get
            {
                return client;
            }

            set
            {
                client = value;
            }
        }
        #endregion
    }
}
