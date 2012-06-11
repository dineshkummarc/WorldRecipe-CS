#region XD World Recipe V 2.8
// FileName: searchrecipe.cs
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
using GetRecipeSearchResult;
using XDRecipe.UI;
using PagerLink;
using Util;

public partial class searchrecipe : BasePage
{
    //Instantiate utility/common object
    Utility Util = new Utility();

    //Declare variables
    private string strKeyword;
    private int OrderBy;
    private int CatId;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(this.Request.QueryString["ob"]))
        {
            OrderBy = (int)Util.Val(Request.QueryString["ob"]);
            lblsortname.Text = Util.GetSortOptionName(OrderBy);
        }
        else
        {
            lblsortname.Text = "";
        }

        strKeyword = Request.QueryString["find"].ToString();
        string strmetaTag = "Search result for " + strKeyword;

        //Get Page title and keywords
        GetMetaTitleTagKeywords(strmetaTag);

        BindList();

        //Release allocated memory
        Util = null;
    }

    //Return databind
    private void BindList()
    {
        CatId = (int)Util.Val(Request.QueryString["catid"]);
        strKeyword = Request.QueryString["find"].ToString();
        OrderBy = (int)Util.Val(Request.QueryString["ob"]);

        //Get the current file path
        string ParamURL = Request.CurrentExecutionFilePath + "?find=" + strKeyword + "&catid=" + CatId;

        int GetPage = (int)Util.Val(Request.QueryString["page"]);

        int iPage;

        if (string.IsNullOrEmpty(this.Request.QueryString["page"]))
        {
            iPage = 1; //If request pageindex is empty, assign pageindex of 1 = 1st page
        }
        else
        {
            iPage = (int)Util.Val(Request.QueryString["page"]); //Grab the querystring pageindex value
        }

        //Initialize pagesize and pageindex
        int PageSize = pagerlinks.DefaultPageSize;
        int PageIndex = iPage;

        try
        {
            //Get category datasource object
            RecipeSearchProvider GetRecipe = new RecipeSearchProvider(strKeyword, CatId, OrderBy, 0, PageIndex, PageSize);

            //Instantiate pager link object
            pagerlinks Pager = new pagerlinks(PageIndex, PageSize, GetRecipe.RecordCount, PlaceHolder1);

            string strSearchIn;

            if (CatId == 0)
            {
                strSearchIn = "<b>in all category</b>.";
            }
            else
            {
                strSearchIn = "in <b>" + GetRecipe.Category + "</b> category.";
            }

            //Get recipe count in category and assign it to the labale
            lblcount.Text = "(" + GetRecipe.RecordCount.ToString() + ") recipes found for keyword (<b>" + strKeyword + "</b>) " + strSearchIn;

            //Get pageindex, pagesize and record count
            //Pager.GetPager(PageIndex, PageSize, GetRecipe.RecordCount, PlaceHolder1);

            //Display numeric pager link
            lbPagerLink.Text = Pager.DisplayNumericPagerLink(ParamURL, OrderBy, 0, GetPage);

            //Display the top right corner pager counter
            lblRecpagetop.Text = Pager.GetTopRightPagerCounterCustomPaging;

            //Display the bottom pager counter
            lblRecpage.Text = Pager.GetBottomPagerCounterCustomPaging;

            //Bind Generic List to a repeater
            RecipeCat.DataSource = GetRecipe.GetRecipeSearchResult();
            RecipeCat.DataBind();

            //Release allocated memory
            GetRecipe = null;

            //Release allocated memory
            Pager = null;
        }
        catch
        {
            lblNorecordFound.Visible = true;
            lblNorecordFound.Text = "No Recipe Found for the keyword (" + strKeyword + "). Please try again.";
        }
    }

    //Handle dynamic page title and keywords
    private void GetMetaTitleTagKeywords(string AlphaLetterName)
    {
        //Other option is to declare a public variable 

        //Assign page title and meta keywords
        Page.Header.Title = AlphaLetterName;
        HtmlMeta metaTag = new HtmlMeta();
        metaTag.Name = "Keywords";
        //You can add more keywords if you want.
        metaTag.Content = AlphaLetterName;
        this.Header.Controls.Add(metaTag);
    }

    public void RecipeCat_ItemDataBound(Object s, RepeaterItemEventArgs e)
    {
        Utility.GetIdentifyItemNewPopular(Convert.ToDateTime(DataBinder.Eval(e.Item.DataItem, "Date")), e,
                                            (int)DataBinder.Eval(e.Item.DataItem, "Hits"));
    }
}
