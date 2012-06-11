#region XD World Recipe V 2.8
// FileName: Category.cs
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
using XDRecipe.UI;
using GetRecipeCategory;
using GetPageTitle;
using PagerLink;
using Util;
using GetDynamicKeywords;
using ConstantVar;

public partial class recipecategory : BasePage
{
    //Instantiate utility/common object
    Utility Util = new Utility();

    //Private variables
    private int CatId;
    private int OrderBy;
    private int SortBy;
    private int iPage;

    //Variable for the pagesize dropdown menu
    public int psCatId;
    public int psOrderBy;
    public int psSortBy;
    public int psPageSize;
    public int psPageIndex;

    //Variable for layout switcher
    public int pLayout;
    public string SelectedValuePrefLayout;

    protected void Page_Load(Object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(this.Request.QueryString["ob"]) || !string.IsNullOrEmpty(this.Request.QueryString["sb"]))
        {
            OrderBy = (int)Util.Val(Request.QueryString["ob"]);
            SortBy = (int)Util.Val(Request.QueryString["sb"]);
            lblsortname.Text = Util.GetSortOptionName(OrderBy) + Util.GetSortOptionOrderBy(SortBy);
        }
        else
        {
            lblsortname.Text = Util.GetSortOptionName(OrderBy);
        }

        //Repeater databind
        BindList();

        //Get Page title and keywords
        GetMetaTitleTagKeywords(lblcatname2.Text);

        //Release object allocated memory
        Util = null;
    }

    //Return databind
    private void BindList()
    {
        CatId = (int)Util.Val(Request.QueryString["catid"]);
        OrderBy = (int)Util.Val(Request.QueryString["ob"]);
        SortBy = (int)Util.Val(Request.QueryString["sb"]);

        iPage = 1;
        psPageSize = 10;
        lbps.Text = " - Displaying <b>10</b> records per page";

        //Get the current file path
        string ParamURL = Request.CurrentExecutionFilePath + "?catid=" + CatId;

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

        RecipeCat.RepeatColumns = Utility.PreferredLayout(Layout);

        //Initialize variable use for dynamic pagesize dropdown menu.
        psCatId = CatId;
        psOrderBy = OrderBy;
        psSortBy = SortBy;
        psPageIndex = iPage;

        //Initialize pagesize and pageindex
        int PageSize = psPageSize;
        int PageIndex = iPage;

        try
        {
            //Get category datasource object
            RecipeCategoryProvider GetCategory = new RecipeCategoryProvider(CatId, OrderBy, SortBy, PageIndex, PageSize);

            //Instantiate pager object
            pagerlinks Pager = new pagerlinks(PageIndex, PageSize, GetCategory.RecordCount, PlaceHolder1);

            lblcatname2.Text = GetCategory.Category;
            lblcount.Text = "(" + GetCategory.RecordCount.ToString() + ")";

            //Display pager links
            lbPagerLink.Text = Pager.DisplayNumericPagerLink(ParamURL, OrderBy, SortBy, GetPage, pLayout);

            //Display the top right corner pager counter
            lblRecpagetop.Text = Pager.GetTopRightPagerCounterCustomPaging;

            //Display the bottom pager counter
            lblRecpage.Text = Pager.GetBottomPagerCounterCustomPaging;

            //Bind Generic List to a repeater
            RecipeCat.DataSource = GetCategory.GetCategories();
            RecipeCat.DataBind();

            //Deallocate object memory
            GetCategory = null;

            //Release object allocated memory
            Pager = null;
        }
        catch
        {

        }
    }

    //Handle dynamic page title and keywords
    private void GetMetaTitleTagKeywords(string strPageTitle)
    {
        iPage = (int)Util.Val(Request.QueryString["page"]);

        string GetCategoryName;
        GetCategoryName = strPageTitle + " Recipes ";

        //Assign page title and meta keywords
        Page.Header.Title = PageTitle.Title(GetCategoryName, iPage);
        HtmlMeta metaTag = new HtmlMeta();
        metaTag.Name = "Keywords";
        //You can add more keywords if you want.
        metaTag.Content = strPageTitle + DynamicKeywords.Keywords(constant.intRecipeDynamicKeywordCategory);
        this.Header.Controls.Add(metaTag);
    }

    public void RecipeCatItemDataBound(Object s, DataListItemEventArgs e)
    {
        Utility.GetIdentifyItemNewPopular(Convert.ToDateTime(DataBinder.Eval(e.Item.DataItem, "Date")), e,
                                            (int)DataBinder.Eval(e.Item.DataItem, "Hits"));
    }
}
