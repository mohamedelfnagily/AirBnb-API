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
    public class CheckImageExtensionValidator:ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if(value!=null)
            {
                if (!ImagesSettingsHelper.Extensions.Contains(Path.GetExtension(((IFormFile)value).FileName).ToLower()))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
