using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace NetVideo.MyValidationRule
{
    public class SecurityCodeValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            string s = value.ToString();

            int code = int.TryParse(s, out code) ? code : -1;

            if (String.IsNullOrEmpty(s))
            {
                return new ValidationResult(false, "Security Code is required!");
            }

            if (s.Count() < 3 || s.Count() > 4)
            {
                return new ValidationResult(false, "Security code (CVV) is the 3 or 4 digit number located on the back of most cards.");
            }
            if (code < 0 || code > 9999 || s.Contains('+'))
            {
                return new ValidationResult(false, "Please enter a valid CVV code.");
            }


            return new ValidationResult(true, null);
        }
    }
}
