using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace JanitorSystem.Converters
{
    class IntConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if ((int)value == 0)
            {
                return String.Empty;
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (!String.IsNullOrEmpty((string)value))
            {
                int valueAsInt;
                bool canParse = Int32.TryParse((string)value, out valueAsInt);

                if (canParse)
                {
                    return valueAsInt;
                }
            }
            return 0;
        }
    }
}
