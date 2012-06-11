#region XD World Recipe V 2.8
// FileName: printarticle.cs
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
using XDRecipe.Model.ArticleDetail;
using XDRecipe.UI;
using RatingCookie;
using BLL;
using Util;
using ConstantVar;

public partial class printarticle : BasePage
{
    public string strArtTitle;

    protected void Page_Load(object sender, EventArgs e)
    {
        //Instantiate utility object
        Utility Util = new Utility();

        //Instantiate database field
        ArticleDetail Article = new ArticleDetail();

        Article.WhatPageID = constant.intArticleDetails; //Parameter 1 = we are dealing with the articledetail.aspx.
        Article.ID = (int)Util.Val(Request.QueryString["aid"]);

        //Fill up article database fields
        Article.fillup();

        lbtitle.Text = Article.Title;
        lbcontent.Text = Article.Content;
        strArtTitle = "Printing " + Article.Title + " article";

        //Release allocated memory         
        Util = null;
        Article = null;
    }
}