using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DailyHelper
{
    public class CheckDbNull
    {
       public static string Check(string value)
        {
            return string.IsNullOrEmpty(value) ? DBNull.Value.ToString() : value;
        }
    }
}
