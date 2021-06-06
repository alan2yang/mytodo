using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;

namespace MyTodo.Converters
{
    public class DisplayDateConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values!=null)
            {
                if (values.Length==2)
                {
                    bool dislayIcon = false;

                    if (values[0].ToString()=="Visible")
                    {
                        dislayIcon = true;
                    }

                    if (!dislayIcon&&values[1].ToString()=="我的一天")
                    {
                        string date= string.Format("{0:M}", DateTime.Now);
                        string[] weeks = { "星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六" };
                        string week = weeks[System.Convert.ToInt32(DateTime.Now.DayOfWeek)];

                        return $"{date}，{week}";
                    }
                    return string.Empty;

                }

            }


            return string.Empty;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
