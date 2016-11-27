using MyJiraWork.Domain;
using MyJiraWork.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyJiraWork
{
    public class ViewModelLocator
    {
        private static MainWindowViewModel mainWindowViewModle = new MainWindowViewModel();

        public ViewModelLocator()
        {

        }

        public static MainWindowViewModel MainWindowViewModle
        {
            get
            {
                return mainWindowViewModle;
            }
        }
    }
}
