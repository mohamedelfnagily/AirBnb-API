using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirBnb.BL.Validations
{
    // a validator class to check on bdDate to not be a future date
    public class CheckBdDate : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value is DateTime date && date <= DateTime.Now)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
