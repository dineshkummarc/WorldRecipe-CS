#region XD World Recipe V 2.8
// FileName: articlecategory.cs
// Author: Dexter Zafra
// Date Created: 5/25/2008
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
using GetArticleCategory;
using PagerLink;
using Util;

public partial class articlecategory : BasePage
{

    //Instantiate utility/common object
    Utility Util = new Utility();

    private int CatId;
    private int OrderBy;
    private int SortBy;

    protected void Page_Load(object sender, EventArgs e)
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

        BindList();

        GetMetaTitleTagKeywords(lbcatname.Text.ToString());

        //Release allocated memory           
        Util = null;
    }

    private void BindList()
    {
        CatId = (int)Util.Val(Request.QueryString["catid"]);
        OrderBy = (int)Util.Val(Request.QueryString["ob"]);
        SortBy = (int)Util.Val(Request.QueryString["sb"]);

        //Get the current file path
        string ParamURL = Request.CurrentExecutionFilePath + "?&catid=" + CatId;

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
            ArticleCategoryProvider GetCategory = new ArticleCategoryProvider(CatId, OrderBy, SortBy, PageIndex, PageSize);

            //Instantiate pager link object
            pagerlinks Pager = new pagerlinks(PageIndex, PageSize, GetCategory.RecordCount, PlaceHolder1);

            string artcatname;
            artcatname = GetCategory.Category;
            lbcatname.Text = GetCategory.Category;
            lbcount.Text = "(" + GetCategory.RecordCount.ToString() + ")";

            //Display numeric pager link
            lbPagerLink.Text = Pager.DisplayNumericPagerLink(ParamURL, OrderBy, SortBy, GetPage);

            //Display the top right corner pager counter
            lblRecpagetop.Text = Pager.GetTopRightPagerCounterCustomPaging;

            //Display the bottom pager counter
            lblRecpage.Text = Pager.GetBottomPagerCounterCustomPaging;

            ArticleCat.DataSource = GetCategory.GetCategories();
            ArticleCat.DataBind();

            //Release allocated memory
            GetCategory = null;
            Pager = null;
        }
        catch
        {

        }
    }

    //Handle dynamic page title and keywords
    private void GetMetaTitleTagKeywords(string CategoryName)
    {
        //Assign page title and meta keywords
        Page.Header.Title = CategoryName + " article";
        HtmlMeta metaTag = new HtmlMeta();
        metaTag.Name = "Keywords";
        //You can add more keywords if you want.
        metaTag.Content = CategoryName + " article, cooking article";
        this.Header.Controls.Add(metaTag);
    }

    public void ArticleCat_ItemDataBound(Object s, RepeaterItemEventArgs e)
    {
        Utility.GetIdentifyItemNewPopular(Convert.ToDateTime(DataBinder.Eval(e.Item.DataItem, "Date")), e,
                                          (int)DataBinder.Eval(e.Item.DataItem, "Hits"));

    }
}
