using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using BLL;
using EmailTemplates;

namespace XDRecipe.UI
{
    /// <summary>
    /// Base Page
    /// </summary>
    public class BasePage : System.Web.UI.Page
    {
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        void Page_Error(object sender, EventArgs e)
        {
            //Get current URL
            string GetCurrentURL = Request.Url.ToString();

            //Get the Exception error
            string GetExceptionError = Server.GetLastError().ToString();

            //Log Exception Error
            Blogic.LogExceptionError(GetCurrentURL, GetExceptionError);

            //Instantiate email temple object
            EmailTemplate SendEmailNotification = new EmailTemplate();

            SendEmailNotification.SendExceptionErrorNotification(GetCurrentURL, GetExceptionError);

            SendEmailNotification = null;

            //Redirect to the error page.
            Server.Transfer("error.aspx");
        }
    }
}
