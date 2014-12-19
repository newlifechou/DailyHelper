using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace DailyHelper
{
    /// <summary>
    /// use the validate the null,empty value
    /// </summary>
    public class NotNullRule : ValidationRule
    {

        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            if (value == null || value.ToString() == "")
            {
                return new ValidationResult(false, "Should not be null or empty");
            }
            else
            {
                return new ValidationResult(true, null);
            }
        }
    }
}
