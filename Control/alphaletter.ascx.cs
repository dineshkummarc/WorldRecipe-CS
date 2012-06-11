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
using Util;
using ConstantVar;

public partial class alphaletter : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Display A-Z links
        lblletter.Text = "Recipe A-Z:";
        lblalphaletter.Text = Utility.DisplayAZAlphabetLink(constant.UserFrontEnd);
    }
}
