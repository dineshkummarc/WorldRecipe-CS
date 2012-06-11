#region XD World Recipe V 2.8
// FileName: articlepreview.cs
// Author: Dexter Zafra
// Date Created: 5/26/2008
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
using CacheData;
using BLL;
using Util;
using UserVal;
using ConstantVar;

public partial class admin_articlepreview : System.Web.UI.Page
{

    //Instantiate utility object
    Utility Util = new Utility();

    //Instantiate database field
    ArticleDetail Article = new ArticleDetail();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //Validate admin session username and password by comparing them to the admin user database record.
            UserNameVal.ValidateAdminUserNameandPass();

            //Get admin username from the session variable and place it in the label.
            lblusername.Text = "Welcome Admin:&nbsp;" + UserNameVal.AdminUsername;

            Article.WhatPageID = constant.intArticleAdminPreview;
            Article.ID = (int)Util.Val(Request.QueryString["aid"]);

            Article.fillup(); 

            lbtitle.Text = Article.Title;
            lbartdetail.Text = Article.Content;

            //Release allocated memory
            Util = null;
            Article = null;
        }
    }

    //Handles finalize insert article
    public void Finalize_ArticleSubmission(Object s, EventArgs e)
    {
        //Instantiate the SQL command object
        Blogic FinalizeAddArticle = new Blogic();

        int ID = (int)Util.Val(Request.QueryString["aid"]);

        Caching.PurgeCacheItems("Newest_Articles");
        Caching.PurgeCacheItems("ArticleCategory_SideMenu");

        //Add the parameters to the SQL command
        int Err = FinalizeAddArticle.FinalizeAddArticle(ID);

        // If error occured, stop further processing and notify user.
        if (Err != 0)
        {
            JSLiteral.Text = Util.JSProcessingErrorAlert;
            return;
        }

        //Release allocated memory
        FinalizeAddArticle = null;   

        //If success, redirect to article submission confirmation/thank you page.
        Util.PageRedirect(9);

        //Release allocated memory
        Util = null;
    }

    public void Edit_Article(Object s, EventArgs e)
    {
        int ID = (int)Util.Val(Request.QueryString["aid"]);

        Response.Redirect("updatearticle.aspx?aid=" + ID + "&show=2&prevedit=1");
    }
}