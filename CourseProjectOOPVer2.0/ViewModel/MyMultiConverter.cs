using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace CourseProjectOOPVer2._0.ViewModel
{
    public class Password
    {
        public object pass1;
        public object pass2;
    }
    public class MyMultiConverter : IMultiValueConverter
    {
        public object Convert(object[] values)
        {
            return values.Clone();
        }

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return new Password() { pass1 = values[0], pass2 = values[1] };
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
