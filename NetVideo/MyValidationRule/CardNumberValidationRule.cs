using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace NetVideo.MyValidationRule
{
    public class CardNumberValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            string s = value.ToString();
            int cardNumber;
            if (String.IsNullOrEmpty(s))
            {
                return new ValidationResult(false, "Card Number is required!");
            }

            if(!int.TryParse(s, out cardNumber) || s.Contains('+') || s.Contains('-'))
            {
                return new ValidationResult(false, "Please enter a valid card number.");
            }

            return new ValidationResult(true, null);
        }
    }
}
