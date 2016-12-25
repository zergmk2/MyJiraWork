using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibGit2Sharp;
using WorkTracker.Contract;

namespace WorkTracker.Backend
{
    public class GitClient : SingletonBase<GitClient>
    {
        #region private Members
        private static object _lock = new object();
        private Repository repo;
        private bool isInitialized;
        #endregion

        #region Properties
        public bool IsInitialized
        {
            get { return isInitialized; }
            set
            {
                lock (_lock)
                {
                    isInitialized = value;
                }
            }
        }

        public Repository Repo
        {
            get
            {
                return repo;
            }

            set
            {
                repo = value;
            }
        }
        #endregion

        #region Constructor
        public GitClient()
        {
            IsInitialized = false;
        }
        #endregion

        #region Public Methods
        public bool InitializeRepo(string repoPath)
        {
            lock (_lock)
            {
                if (!isInitialized && !string.IsNullOrEmpty(repoPath) &&
                    Directory.Exists(repoPath) && File.Exists(Path.Combine(repoPath, ".git\\config")))
                {
                    try
                    {
                        Repo = new Repository(repoPath);
                        IsInitialized = true;
                        return true;
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
            return false;
        }

        public string GetCurrentBranchName()
        {
            if (IsInitialized)
            {
                return repo.Head.CanonicalName;
            }
            else
            {
                return string.Empty;
            }
        }
        #endregion
    }
}
