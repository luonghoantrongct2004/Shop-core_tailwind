﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BLL.Service.IServices
{
        public interface ISendMailService
        {
            Task SendEmailAsync(string email, string subject, string message);
            Task SendSmsAsync(string number, string message);
        }
    
}
