#region XD World Recipe V 2.8
// FileName: sort.cs
// Author: Dexter Zafra
// Date Created: 5/22/2008
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
using GetRecipeSorted;
using XDRecipe.UI;
using GetPageTitle;
using PagerLink;
using Util;
using GetDynamicKeywords;
using ConstantVar;

public partial class recipesorting : BasePage
{
    //Instantiate utility/common object
    Utility Util = new Utility();

    //Declare variables
    private string strPageTtitle;
    private string strKeywords;
    private int SortBy;
    private int Sort_By;
    private int iPage;

    //Variable for the pagesize dropdown menu
    public int psOrderBy;
    public int psSortBy;
    public int psPageSize;
    public int psPageIndex;

    //Variable for layout switcher
    public int pLayout;
    public string SelectedValuePrefLayout;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(this.Request.QueryString["sid"]) || !string.IsNullOrEmpty(this.Request.QueryString["sb"]))
        {
            SortBy = (int)Util.Val(Request.QueryString["sid"]);
            Sort_By = (int)Util.Val(Request.QueryString["sb"]);
            lblsortname.Text = Util.GetSortOptionName(SortBy) + Util.GetSortOptionOrderBy(Sort_By);
        }

        //Display recipe count
        lblcount.Text = "(100) <b>Recipes</b> - ";

        //Repeater databind
        BindList();

        //Get Page title and keywords
        GetMetaTitleTagKeywords();

        //Release allocated memory
        Util = null;
    }

    //Return databind
    private void BindList()
    {
        SortBy = (int)Util.Val(Request.QueryString["sid"]);
        Sort_By = (int)Util.Val(Request.QueryString["sb"]);

        iPage = 1;
        psPageSize = 10;
        lbps.Text = " - Displaying <b>10</b> records per page";

        //Get the current file path
        string ParamURL = Request.CurrentExecutionFilePath + "?sid=" + SortBy;

        int GetPage = (int)Util.Val(Request.QueryString["page"]);

        if (!string.IsNullOrEmpty(this.Request.QueryString["page"]))
        {
            iPage = (int)Util.Val(Request.QueryString["page"]); //Grab the querystring pageindex value
        }

        if (!string.IsNullOrEmpty(this.Request.QueryString["ps"]))
        {
            psPageSize = (int)Util.Val(Request.QueryString["ps"]); //Grab the querystring pagesize value
            lbps.Text = " - Displaying <b>" + psPageSize + "</b> records per page";
        }

        if (psPageSize > 50)
        {
            psPageSize = 10;
        }

        int Layout = (int)Util.Val(Request.QueryString["layout"]);

        //Initialize variable for preferred layout dropdown menu
        SelectedValuePrefLayout = Utility.PreferredLayoutSelectedValue(Layout);
        pLayout = Utility.PreferredLayout(Layout);

        RecipeSort.RepeatColumns = Utility.PreferredLayout(Layout);

        //Initialize variable use for dynamic pagesize dropdown menu.
        psOrderBy = SortBy;
        psSortBy = Sort_By;
        psPageIndex = iPage;

        //Initialize pagesize and pageindex
        int PageSize = psPageSize;
        int PageIndex = iPage;

        try
        {
            //We only display top 100 recipes for the sort.aspx page
            int TotalRecords = 100;

            //Sort.aspx goes up to 5 pages only 100/5 = 5 pages
            int MaxSortPageSize = 5;

            //Get category datasource object
            RecipeSortProvider GetRecipe = new RecipeSortProvider(SortBy, Sort_By, PageIndex, PageSize);

            //Instantiate pager link object
            pagerlinks Pager = new pagerlinks(PageIndex, PageSize, TotalRecords, MaxSortPageSize, PlaceHolder1);

            //Dsiplay pager links
            lbPagerLink.Text = Pager.DisplayNumericPagerLink(ParamURL, SortBy, Sort_By, GetPage, pLayout);

            //Display the top right corner pager counter
            lblRecpagetop.Text = Pager.GetTopRightPagerCounterCustomPaging;

            //Display the bottom pager counter
            lblRecpage.Text = Pager.GetBottomPagerCounterCustomPaging;

            //Bind Generic List to a repeater
            RecipeSort.DataSource = GetRecipe.GetRecipeSort();
            RecipeSort.DataBind();

            //Release allocated memory
            GetRecipe = null;

            //Release allocated memory
            Pager = null;
        }
        catch
        {

        }
    }

    private void GetMetaTitleTagKeywords()
    {
        //Get Page title and keywords
        SortBy = (int)Util.Val(Request.QueryString["sid"]);

        string strPageTitleAndKeywords = DynamicKeywords.Keywords(constant.intRecipeDynamicKeywordSortPage, SortBy);
        string[] arrayPagetitleAndKeywords = strPageTitleAndKeywords.Split(',');

        GetMetaTitleTagKeyword(arrayPagetitleAndKeywords[0], arrayPagetitleAndKeywords[1]);
    }

    //Handle dynamic page title and keywords
    private void GetMetaTitleTagKeyword(string strPageTitle, string strKeywords)
    {
        iPage = (int)Util.Val(Request.QueryString["page"]);

        //Assign page title and meta keywords
        Page.Header.Title = PageTitle.Title(strPageTitle, iPage);
        HtmlMeta metaTag = new HtmlMeta();
        metaTag.Name = "Keywords";
        //You can add more keywords if you want.
        metaTag.Content = strKeywords;
        this.Header.Controls.Add(metaTag);
    }

    public void RecipeSortItemDataBound(Object s, DataListItemEventArgs e)
    {
        Utility.GetIdentifyItemNewPopular(Convert.ToDateTime(DataBinder.Eval(e.Item.DataItem, "Date")), e,
                                            (int)DataBinder.Eval(e.Item.DataItem, "Hits"));
    }
}
