#region XD World Recipe V 2.8
// FileName: searcharticle.cs
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
using ArticleSearchResult;
using PagerLink;
using Util;

public partial class searcharticle : BasePage
{
    //Instantiate utility/common object
    Utility Util = new Utility();

    private string strKeyword;
    private int CatId;
    private int OrderBy;
    private int SortBy;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(this.Request.QueryString["ob"]) || !string.IsNullOrEmpty(this.Request.QueryString["sb"]))
        {
            OrderBy = (int)Util.Val(Request.QueryString["ob"]);
            int SortBy = (int)Util.Val(Request.QueryString["sb"]);
            lblsortname.Text = Util.GetSortOptionName(OrderBy) + Util.GetSortOptionOrderBy(SortBy);
        }
        else
        {
            lblsortname.Text = Util.GetSortOptionName(OrderBy);
        }

        strKeyword = Request.QueryString["find"].ToString();
        string strmetaTag = "Search result for " + strKeyword;

        //Get Page title and keywords
        GetMetaTitleTagKeywords(strmetaTag);

        BindList();

        //Release allocated memory           
        Util = null;
    }

    private void BindList()
    {
        CatId = (int)Util.Val(Request.QueryString["catid"]);
        strKeyword = Request.QueryString["find"].ToString();
        OrderBy = (int)Util.Val(Request.QueryString["ob"]);
        SortBy = (int)Util.Val(Request.QueryString["sb"]);

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

        //Initialize pagesize and page index
        int PageSize = pagerlinks.DefaultPageSize;
        int PageIndex = iPage;

        try
        {
            //Get category datasource object
            ArticleSearchProvider GetArticle = new ArticleSearchProvider(strKeyword, CatId, OrderBy, SortBy, PageIndex, PageSize);

            //Instantiate pager link object
            pagerlinks Pager = new pagerlinks(PageIndex, PageSize, GetArticle.RecordCount, PlaceHolder1);

            string strSearchIn;

            if (CatId == 0)
            {
                strSearchIn = "in all category.";
            }
            else
            {
                strSearchIn = "in <b>" + GetArticle.Category + "</b> category.";
            }

            //Get recipe count in category and assign it to the labale
            lbcount.Text = "(" + GetArticle.RecordCount.ToString() + ") recipes found for keyword (<b>" + strKeyword + "</b>) " + strSearchIn;

            //Display numeric pager link
            lbPagerLink.Text = Pager.DisplayNumericPagerLink(ParamURL, OrderBy, SortBy, GetPage);

            //Display the top right corner pager counter
            lblRecpagetop.Text = Pager.GetTopRightPagerCounterCustomPaging;

            //Display the bottom pager counter
            lblRecpage.Text = Pager.GetBottomPagerCounterCustomPaging;

            //Bind Generic List to a repeater
            ArticleCat.DataSource = GetArticle.GetArticleSearchResult();
            ArticleCat.DataBind();

            //Release allocated memory
            GetArticle = null;
            Pager = null;
        }
        catch
        {
            lblNorecordFound.Visible = true;
            lblNorecordFound.Text = "&nbsp;&nbsp;&nbsp;No Article Found for the keyword (" + strKeyword + "). Please try again.";
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
