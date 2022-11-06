using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirBnb.BL.Validations
{
    public class CheckReservationDate:ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value is DateTime date && date >= DateTime.Now)
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
