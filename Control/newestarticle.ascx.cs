#region XD World Recipe V 2.8
// FileName: newestarticle.ascx.cs
// Author: Dexter Zafra
// Date Created: 5/19/2008
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
using System.Data.SqlClient;
using CacheData;
using GetNewestArticle;
using BLL;
using Util;

public partial class newestarticle : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int Top = 5; //Get the newest 5 articles. Change the value to 10 if you want to display 10 newest articles.

        lbTopCount.Text = Top.ToString();

        NewArticlesSidePanel.DataSource = NewestArticleMenuProvider.GetArticle(Top);
        NewArticlesSidePanel.DataBind();
    }

    public void NewArticlesSidePanel_ItemDataBound(Object s, RepeaterItemEventArgs e)
    {
        //Get the number of days
        //parameter 2 = we are dealing with the newest article.
        Utility.GetCounterDay(Convert.ToDateTime(DataBinder.Eval(e.Item.DataItem, "Date")), e, 2);
    }
}
