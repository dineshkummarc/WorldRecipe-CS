#region XD World Recipe V 2.8
// FileName: emailHelper.cs
// Author: Dexter Zafra
// Date Created: 5/19/2008
// Website: www.ex-designz.net
#endregion
using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Text;
using System.Diagnostics;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Net.Mail;
using XDRecipe.Model;
using Util;
using BaseURL;

namespace EmailSend
{
    /// <summary>
    /// Object in this class send email using System.Net.Mail
    /// </summary>
    public class EmailHelper
    {
        /// <summary>
        /// Sends email using System.Net.Mail
        /// </summary>
        /// <param name="msg">Populated MailMessage object</param>
        /// <returns>Returns 0 if processed successfully. Any other values indicate failure.</returns>
        public static int SendEmail(string ToEmail, string FromEmail, string Subject, string emailbody)
        {
            int Err = 0;

            //Only deliver email if both fields are provided.
            if (!string.IsNullOrEmpty(ToEmail) && !string.IsNullOrEmpty(FromEmail))
            {
                try
                {
                    MailAddress from = new MailAddress(FromEmail);
                    MailAddress to = new MailAddress(ToEmail);
                    MailMessage msg = new MailMessage(from, to);

                    msg.Subject = Subject;
                    msg.Body = emailbody;
                    msg.IsBodyHtml = true;
                    msg.Priority = MailPriority.High;

                    SmtpClient smtp = new SmtpClient();
                    smtp.Send(msg);
                }
                catch (Exception x)
                {
                    Err = 1;
                    throw new SystemException();
                }
            }

            return Err;
        }

    }
}
