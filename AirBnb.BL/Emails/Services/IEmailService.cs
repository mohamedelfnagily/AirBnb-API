using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirBnb.BL.Emails.Services
{
    public interface IEmailService
    {
        Task SendEmailAsync(string mailTo, string subject, string body);
        Task ForgetPasswordEmailAsync(string mailTo, string subject);
    }
}
