using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyJiraWork.Contracts
{
    internal abstract class SingletonBase<SingletonClass> where SingletonClass : class
    {
        #region Singleton Implementation
        private static readonly Lazy<SingletonClass> sInstance = new Lazy<SingletonClass>(() => CreateInstanceOfT());
        public static SingletonClass Instance { get { return sInstance.Value; } }

        private static SingletonClass CreateInstanceOfT()
        {
            SingletonClass instance = Activator.CreateInstance(typeof(SingletonClass), true) as SingletonClass;
            return instance;
        }
        #endregion
    }
}
