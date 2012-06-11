#region XD World Recipe V 2.8
// FileName: emailarticle.cs
// Author: Dexter Zafra
// Date Created: 7/24/2008
// Website: www.ex-designz.net
#endregion
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using XDRecipe.UI;
using EmailTemplates;
using Util;

public partial class emailarticle : BasePage
{

    //Instantiate validation object
    Utility Util = new Utility();

    protected void Page_Load(object sender, EventArgs e)
    {
        string ArticleTitle;
        ArticleTitle = Request.QueryString["n"].ToString();

        Util.SecureQueryString(ArticleTitle);
    }

    public void SendingArticle(Object s, EventArgs e)
    {
        //Instantiate email template object
        EmailTemplate SendeMail = new EmailTemplate();

        SendeMail.ItemID = (int)Util.Val(Request.QueryString["id"]);
        SendeMail.ItemName = Request.QueryString["n"].ToString();

        //Filters harmful scripts from input string.
        SendeMail.SenderName = Util.FormatTextForInput(Request.Form["txtFromName"]);
        SendeMail.SenderEmail = Util.FormatTextForInput(Request.Form["txtFromEmail"]);
        SendeMail.RecipientEmail = Util.FormatTextForInput(Request.Form["txtToEmail"]);
        SendeMail.RecipientName = Util.FormatTextForInput(Request.Form["toname"]);

        SendeMail.SendEmailRecipeToAFriend();

        Panel1.Visible = false;

        lblsentmsg.Text = "Your message has been sent to " + SendeMail.RecipientEmail + ".";

        //Release allocated memory
        SendeMail = null;
        Util = null;

    }
}