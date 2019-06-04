using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace NetVideo.MyValidationRule
{
    public class ExpirationDateValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            string s = value.ToString();

            if (String.IsNullOrEmpty(s))
            {
                return new ValidationResult(false, "Expiration Date is required!");
            }
            else
            {
                int month = 0;
                int year = 0;
                int currentYear = DateTime.Now.Year;
                int exDateYear = currentYear + 25;

                if (s.Contains('/'))
                {
                    string[] split = s.Split('/');
                    int.TryParse(split[0], out month);
                    int.TryParse(split[1], out year);
                }
                else
                {
                    int.TryParse(s, out month);
                }
                if (month != 0)
                {
                    if (month < 1 || month > 12)
                    {
                        return new ValidationResult(false, "Expiration Month must be between 1 and 12.");
                    }
                }
                if (month != 0 && year != 0)
                {
                    int inputYear = 2000 + year;
                    if (month < 1 || month > 12)
                    {
                        return new ValidationResult(false, "Expiration Month must be between 1 and 12.");
                    }
                    if (inputYear < currentYear || inputYear > exDateYear)
                    {
                        return new ValidationResult(false, String.Format("Expiration Year must be between {0} and {1}.", currentYear, exDateYear));
                    }
                }
                else
                {
                    return new ValidationResult(false, "Please enter a valid expiration date.");
                }
            }
            return new ValidationResult(true, null);;
        }
    }
}
