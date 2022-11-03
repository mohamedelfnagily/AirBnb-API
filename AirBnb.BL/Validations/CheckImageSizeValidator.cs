using AirBnb.BL.Helpers;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirBnb.BL.Validations
{
    public class CheckImageSizeValidator:ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if(value!=null)
            {
                if (((IFormFile)value).Length > ImagesSettingsHelper.MaximumLength)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
