using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ex4.Models
{
    public class PasswordResetHelper
    {
        //private IEmailSender emailSender;

        //public PasswordResetHelper(IEmailSender emailSenderParam) {
        public PasswordResetHelper()
        {
            //emailSender = emailSenderParam;
        }

        public void ResetPassword() {
            // ...call interface methods to configure e-mail details...
            //emailSender.SendEmail();
        }
    }
}