using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace NetVideo.MyValidationRule
{
    public class EmptyValidationRule : ValidationRule
    {
        public string Name { get; set; }

        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            var vr = new ValidationResult(true, null);
            string s = value.ToString();
            if (String.IsNullOrEmpty(s))
            {
                vr = new ValidationResult(false, String.Format("{0}  is required!", Name));
            }
            return vr;
        }
    }
}
