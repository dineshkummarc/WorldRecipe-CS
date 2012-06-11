#region XD World Recipe V 2.8
// FileName: articlesearchtab.ascx.cs
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
using System.Data.SqlClient;
using XDRecipe.DropdownHelper;
using ProviderDropdownList;
using Util;
using ConstantVar;

public partial class articlesearchtab : System.Web.UI.UserControl
{
    protected override void OnInit(EventArgs e)
    {
        //Populate article search category dropdownlist
        DropdownlistHelper.FillUpDropDown(SDropName, ProviderArticleCategoryDropdown.categoryListArticle, "All Category");
        base.OnInit(e);
    }

    //Handles dropdown list property
    public string SelectedValue
    {
        get
        {
            return SDropName.SelectedValue;
        }
        set
        {
            SDropName.SelectedValue = value;
        }
    }

    //Handles search button click
    public void SearchButton_Click(Object s, EventArgs e)
    {
        //Instantiate validation object
        Utility Util = new Utility();

        //Check for minimum keyword character
        int MinuiumSearchWordLength = 2;
        int SearchWordLength;
        SearchWordLength = find.Value.Length;
        if (SearchWordLength <= MinuiumSearchWordLength)
        {
            //Redirect to keyword too short page
            Util.PageRedirect(10);
        }

        if (this.SelectedValue != null)
        {
            SDropName.SelectedValue = this.SelectedValue;
        }

        string targetUrl = "searcharticle.aspx";

        targetUrl += "?find=" + Util.FormatTextForInput(find.Value) + "&catid=" + SDropName.SelectedValue;

        //Redirect to the search page
        Response.Redirect(targetUrl);

        Util = null;

    }
}