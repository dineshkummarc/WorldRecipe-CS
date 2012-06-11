#region XD World Recipe V 2.8
// FileName: articledetail.cs
// Author: Dexter Zafra
// Date Created: 5/28/2008
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
using XDRecipe.Model.ArticleDetail;
using RatingCookie;
using BookmarkURL;
using Util;
using ConstantVar;

public partial class articledetail : BasePage
{
    //Instantiate database field
    ArticleDetail Article = new ArticleDetail();

    public int ArtCatId;
    public string strCatName;
    public string strArtTitle;
    public string strBookmarkURL;
    public int ArticleSection;

    protected void Page_Load(object sender, EventArgs e)
    {
        //Instantiate utility/common object
        Utility Util = new Utility();

        Article.WhatPageID = constant.intArticleDetails;
        Article.ID = (int)Util.Val(Request.QueryString["aid"]);

        //Fill up article database fields
        Article.fillup();

        lblwordcount.Text = Utility.WordCount(Article.Content).ToString();

        lbtitle.Text = Article.Title;
        lbcontent.Text = Article.Content;
        lbhits.Text = string.Format("{0:#,###}", Article.Hits);
        lbauthor.Text = Article.Author;
        lblrating.Text = Article.Rating;
        lblvotescount.Text = Article.NoRates;
        starimage.ImageUrl = Utility.GetStarImage(Article.Rating);
        lbldate.Text = string.Format("{0:MMMM dd, yyyy}", Article.Date);

        //Save to Favorite/Bookmark URL.
        strBookmarkURL = Bookmark.URL;

        strArtTitle = Article.Title;
        strCatName = Article.Category;
        ArtCatId = Article.CatID;
        ArticleSection = constant.intArticle;

        //Get page title and keyword
        GetMetaTitleTagKeywords(strArtTitle, strCatName);

        //Get cooking article user rating
        GetUserCookingArticleRating();

        //Release allocated memory         
        Util = null;
        Article = null;
    }

    //Get cooking article user rating
    private void GetUserCookingArticleRating()
    {
        //Instantiate user article cookie rating object
        CookieRating GetCookie = new CookieRating(constant.intArticle, Article.ID, PlaceHolder2);

        //Get the user rating cookie
        GetCookie.GetUserCookieRating();

        //Release allocated memory
        GetCookie = null;
    }

    //Handle dynamic page title and keywords
    private void GetMetaTitleTagKeywords(string Title, string CategoryName)
    {
        //Assign page title and meta keywords
        Page.Header.Title = Title + "," + CategoryName + " article";
        HtmlMeta metaTag = new HtmlMeta();
        metaTag.Name = "Keywords";
        //You can add more keywords if you want.
        metaTag.Content = Title + "," + CategoryName + ", cooking article";
        this.Header.Controls.Add(metaTag);
    }
}
