using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace NetVideo.MyValidationRule
{
    public class PasswordValidationRule : ValidationRule
    {
        public int minSize { get; set; }
        public int maxSize { get; set; }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var vr = new ValidationResult(true, null);
            int t = value.ToString().Count();
            if (t < minSize || t > maxSize)
            {
                vr = new ValidationResult(false, String.Format("Your password must contain between {0} and {1} characters.", minSize, maxSize));
            }
            return vr;
        }
    }
}
