#region XD World Recipe V 2.8
// FileName: emailtemplates.cs
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
using XDRecipe.Model;
using Util;
using BaseURL;
using EmailSend;
using EmailNotificationSetting;

namespace EmailTemplates
{
    /// <summary>
    /// Object in this class generate the email template
    /// </summary>
    public class EmailTemplate : Email
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public EmailTemplate()
        {
        }

        /// <summary>
        /// Send exception error notification.
        /// </summary>
        public int SendExceptionErrorNotification(string strURL, string ExceptionError)
        {
            //Create string builder object
            StringBuilder mySB = new StringBuilder("");

            //Mail message subject property
            string Subject = "XD Recipe Exception Error Notification";

            //Build the email body in HTML format using stringbuilder
            mySB.Append("<table cellpadding=0 cellspacing=0 width=400 align=left>");
            mySB.Append("<tr>");
            mySB.Append("<td align=left>");
            mySB.Append("<font size=2 color=black face=verdana>");
            mySB.Append("Hi Webmaster:");
            mySB.Append("<br><br>");
            mySB.Append("This error has been logged to the database.");
            mySB.Append("<br><br>");
            mySB.Append("<b>Exception:</b>");
            mySB.Append("<br>");
            mySB.Append(ExceptionError);
            mySB.Append("</font>");
            mySB.Append("</td></tr>");
            mySB.Append("<tr>");
            mySB.Append("<td align=left><br>");
            mySB.Append("<font size=2 face=verdana>");
            mySB.Append("<a target=_new href=\"http://");
            mySB.Append(strURL);
            mySB.Append("\">");
            mySB.Append(strURL);
            mySB.Append("</a>");
            mySB.Append("</font>");
            mySB.Append("</td></tr>");
            mySB.Append("</table>");

            EmailNotificationSettings EmailSettings = new EmailNotificationSettings();

            EmailSettings.fillup();

            int Err = EmailHelper.SendEmail(EmailSettings.ToAdminEmail, EmailSettings.FromAdminEmail, Subject, mySB.ToString());

            EmailSettings = null;

            return Err;
        }

        /// <summary>
        /// Send comment posting email notification to the Webmaster
        /// </summary>
        public int SendEmailCommentNotify()
        {
            //Create string builder object
            StringBuilder mySB = new StringBuilder("");

            string strURL = BaseUrl.GetBaseUrl + "recipedetail.aspx?id=" + ItemID;

            //Mail message subject property
            string Subject = "Recipe Comment Posting";

            //Build the email body in HTML format using stringbuilder
            mySB.Append("<table cellpadding=0 cellspacing=0 width=400 align=left>");
            mySB.Append("<tr>");
            mySB.Append("<td align=left>");
            mySB.Append("<font size=2 color=black face=verdana>");
            mySB.Append("Hi Webmaster:");
            mySB.Append("<br><br>");
            mySB.Append("Someone has posted a recipe comment. Click the link below to view the comment.");
            mySB.Append("</font>");
            mySB.Append("</td></tr>");
            mySB.Append("<tr>");
            mySB.Append("<td align=left><br>");
            mySB.Append("<font size=2 face=verdana>");
            mySB.Append("<a target=_new href=\"http://");
            mySB.Append(strURL);
            mySB.Append("\">");
            mySB.Append(ItemName);
            mySB.Append("</a>");
            mySB.Append("</font>");
            mySB.Append("</td></tr>");
            mySB.Append("</table>");

            EmailNotificationSettings EmailSettings = new EmailNotificationSettings();

            EmailSettings.fillup();

            int Err = EmailHelper.SendEmail(EmailSettings.ToAdminEmail, EmailSettings.FromAdminEmail, Subject, mySB.ToString());

            EmailSettings = null;

            return Err;
        }

        /// <summary>
        /// Send comment posting email notification to the Webmaster
        /// </summary>
        public int SendEmailAddRecipeNotify()
        {
            //Create string builder object
            StringBuilder mySB = new StringBuilder("");

            //Mail message subject property
            //Change Mydomain to your own domain name.
            string Subject = "Recipe Submission at Mydomain.com";

            //Build the email body in HTML format using stringbuilder
            mySB.Append("<table cellpadding=0 cellspacing=0 width=400 align=left>");
            mySB.Append("<tr>");
            mySB.Append("<td align=left>");
            mySB.Append("<font size=2 color=black face=verdana>");
            mySB.Append("Hi Webmaster:");
            mySB.Append("<br><br>");
            mySB.Append("Someone submitted a recipe.");
            mySB.Append("<br>");
            mySB.Append("Recipe Name:");
            mySB.Append("&nbsp;");
            mySB.Append(ItemName);
            mySB.Append("</font>");
            mySB.Append("</td></tr>");
            mySB.Append("</table>");

            EmailNotificationSettings EmailSettings = new EmailNotificationSettings();

            EmailSettings.fillup();

            int Err = EmailHelper.SendEmail(EmailSettings.ToAdminEmail, EmailSettings.FromAdminEmail, Subject, mySB.ToString());

            EmailSettings = null;

            return Err;
        }

        /// <summary>
        /// Send email recipe to a friend
        /// </summary>
        public int SendEmailRecipeToAFriend()
        {
            //Create string builder object
            StringBuilder mySB = new StringBuilder("");

            //Mail message subject property
            string Subject = SenderName + " Has Sent You A Recipe";

            //Change the domain name into your website domain.
            string strURL = BaseUrl.GetBaseUrl + "recipedetail.aspx?id=" + ItemID;

            //Build the email body in HTML format using stringbuilder
            mySB.Append("<table cellpadding=0 cellspacing=0 width=400 align=left>");
            mySB.Append("<tr>");
            mySB.Append("<td align=left>");
            mySB.Append("<font size=2 color=black face=verdana>");
            mySB.Append("Hi");
            mySB.Append("&nbsp;");
            mySB.Append(RecipientEmail);
            mySB.Append(":");
            mySB.Append("<br><br>");
            mySB.Append(SenderName);
            mySB.Append(",&nbsp;");
            mySB.Append("has sent you a recipe. Please click the link below to view the recipe.");
            mySB.Append("</font>");
            mySB.Append("</td></tr>");
            mySB.Append("<tr>");
            mySB.Append("<td align=left><br>");
            mySB.Append("<font size=2 face=verdana>");
            mySB.Append("<a target=_new href=\"http://");
            mySB.Append(strURL);
            mySB.Append("\">");
            mySB.Append(ItemName);
            mySB.Append("</a>");
            mySB.Append("</font>");
            mySB.Append("</td></tr>");
            mySB.Append("</table>");

            //Send email - Take the message and recipient email, and pass it to the SendeMail method.
            int Err = EmailHelper.SendEmail(RecipientEmail, SenderEmail, Subject, mySB.ToString());

            return Err;
        }

        /// <summary>
        /// Send email article to a friend
        /// </summary>
        public int SendEmailArticleToAFriend()
        {
            //Create string builder object
            StringBuilder mySB = new StringBuilder("");

            //Mail message subject property
            string Subject = SenderName + " Has Sent You A Cooking Article";

            //Change the domain name into your website domain.
            string strURL = BaseUrl.GetBaseUrl + "articledetail.aspx?aid=" + ItemID;

            //Build the email body in HTML format using stringbuilder
            mySB.Append("<table cellpadding=0 cellspacing=0 width=400 align=left>");
            mySB.Append("<tr>");
            mySB.Append("<td align=left>");
            mySB.Append("<font size=2 color=black face=verdana>");
            mySB.Append("Hi");
            mySB.Append("&nbsp;");
            mySB.Append(RecipientEmail);
            mySB.Append(":");
            mySB.Append("<br><br>");
            mySB.Append(SenderName);
            mySB.Append(",&nbsp;");
            mySB.Append("has sent you a cooking article. Please click the link below to read the article.");
            mySB.Append("</font>");
            mySB.Append("</td></tr>");
            mySB.Append("<tr>");
            mySB.Append("<td align=left><br>");
            mySB.Append("<font size=2 face=verdana>");
            mySB.Append("<a target=_new href=\"http://");
            mySB.Append(strURL);
            mySB.Append("\">");
            mySB.Append(ItemName);
            mySB.Append("</a>");
            mySB.Append("</font>");
            mySB.Append("</td></tr>");
            mySB.Append("</table>");

            //Send email - Take the message and recipient email, and pass it to the SendeMail method.
            int Err = EmailHelper.SendEmail(RecipientEmail, SenderEmail, Subject, mySB.ToString());

            return Err;
        }
    }
}