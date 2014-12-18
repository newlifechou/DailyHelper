using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace DailyHelper
{
    public class HaveInvoiceConverter:IValueConverter
    {
        public string HaveInvoiceMessage { get; set; }
        public string NotHaveInvoiceMessage { get; set; }
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool haveInvoice = System.Convert.ToBoolean(value);
            if (haveInvoice)
            {
                return HaveInvoiceMessage;
            }
            else
            {
                return NotHaveInvoiceMessage;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
