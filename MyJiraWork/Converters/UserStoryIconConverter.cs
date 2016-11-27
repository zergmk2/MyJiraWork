using GalaSoft.MvvmLight;
using MyJiraWork.Common;
using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace MyJiraWork.Converters
{
    public class UserStoryIconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            UserStoryType type = (UserStoryType)value;

            if (type.Equals(UserStoryType.BUG))
            {
                if (ViewModelBase.IsInDesignModeStatic)
                {
                    return "../Resources/Icons/BugIcon.png";
                }
                else
                {
                    return new BitmapImage(new Uri("pack://application:,,,/Resources/Icons/BugIcon.png"));
                }
            }
            else if (type.Equals(UserStoryType.USERSTORY))
            {
                if (ViewModelBase.IsInDesignModeStatic)
                {
                    return "../Resources/Icons/UserStoryIcon.png";
                }
                else
                {
                    return new BitmapImage(new Uri("pack://application:,,,/Resources/Icons/UserStoryIcon.png"));
                }
            }

            throw new ArgumentException("UserStoryIconConverter can't convert this property!");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
