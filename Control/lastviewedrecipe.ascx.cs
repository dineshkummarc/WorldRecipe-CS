#region XD World Recipe V 2.8
// FileName: lastviewedrecipe.ascx.cs
// Author: Dexter Zafra
// Date Created: 7/16/2008
// Website: www.ex-designz.net
#endregion
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using LastViewedRecipe;
using Util;

public partial class Controllastviewedrecipe : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lbgethour.Text = LastViewedRecipeProvider.GetMinuteSpan.ToString();

        lastview.DataSource = LastViewedRecipeProvider.GetLastViewedRecipe();
        lastview.DataBind();
    }

    public void lastview_ItemDataBound(Object s, RepeaterItemEventArgs e)
    {
        //Get sequential number counter
        Utility.GetSeqCounter(lastview, e);
    }
}
