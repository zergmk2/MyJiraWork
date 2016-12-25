using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkTracker.Backend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WorkTracker.Backend.Tests
{
    [TestClass()]
    public class GitClientTests
    {
        [TestMethod()]
        public void InitializeRepoTest()
        {
            string wanted_path = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
            string solutionPath = Directory.GetParent(wanted_path).FullName;
            GitClient gitClient = GitClient.Instance;
            Assert.IsTrue(gitClient.InitializeRepo(solutionPath));
        }

        [TestMethod()]
        public void GetCurrentBranchNameTest()
        {
            GitClient gitClient = GitClient.Instance;
            string wanted_path = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
            string solutionPath = Directory.GetParent(wanted_path).FullName;
            gitClient.InitializeRepo(solutionPath);
            if (gitClient.IsInitialized)
            {
                Assert.IsTrue(gitClient.GetCurrentBranchName().EndsWith("master", StringComparison.CurrentCultureIgnoreCase));
            }
        }
    }
}