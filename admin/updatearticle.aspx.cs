#region XD World Recipe V 2.8
// FileName: updatearticle.cs
// Author: Dexter Zafra
// Date Created: 5/29/2008
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
using XDRecipe.Model.AddUpdateDeleteArticle;
using UserVal;
using CacheData;

public partial class admin_updatearticle : System.Web.UI.Page
{

    //Instantiate sql params object
    BLL.Blogic myBL = new BLL.Blogic();

    //Instantiate validation
    Util.Utility Util = new Util.Utility();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //Validate admin session username and password by comparing them to the admin user database record.
            UserNameVal.ValidateAdminUserNameandPass();

            //Get admin username from the sessioan variable and place it in the label.
            lblusername.Text = "Welcome Admin:&nbsp;" + UserNameVal.AdminUsername;

            if (Request.QueryString["prevedit"] != null)
            {
                btn1.Visible = false;
                btn2.Visible = true;
            }
            else
            {
                btn1.Visible = true;
                btn2.Visible = false;
            }

            //Instantiate database field
            ArticleDetail Article = new ArticleDetail();

            Article.WhatPageID = (int)Util.Val(Request.QueryString["show"]); //Parameter 2 = we are dealing with the admin/updatearticle.aspx.
            Article.ID = (int)Util.Val(Request.QueryString["aid"]);

            //Fill up database fields
            Article.fillup(); 

            string categoryname;
            categoryname = Article.Category;

            lbtitle.Text = Article.Title;
            lbcatname2.Text = Article.Category;
            Title.Value = Article.Title;
            Content.Value = Util.FormatText(Article.Content);
            Summary.Value = Util.FormatText(Article.Summary);
            Keyword.Value = Article.Keyword;
            Author.Value = Article.Author;
            CAT_ID.Value = Article.CatID.ToString();

            //Release allocated memory
            myBL = null;
            Util = null;
            Article = null;
        }
    }

    //Handles insert article
    public void Update_Article(Object s, EventArgs e)
    {
        //Instantiate database field
        ArticleInfo UpdateArticle = new ArticleInfo();

        UpdateArticle.ID = (int)Util.Val(Request.QueryString["aid"]);

        UpdateArticle.Title = Request.Form["Title"];
        UpdateArticle.Content = Request.Form["Content"];
        UpdateArticle.Author = Request.Form["Author"];
        UpdateArticle.CatID = int.Parse(Request.Form["CAT_ID"]);
        UpdateArticle.Keyword = Request.Form["Keyword"];
        UpdateArticle.Summary = Request.Form["Summary"];

        Caching.PurgeCacheItems("Newest_Articles");

        //Notify user if error occured.
        if (UpdateArticle.Update() != 0)
        {
            JSLiteral.Text = Util.JSProcessingErrorAlert;
            return;
        }

        //Release allocated memory
        UpdateArticle = null;

        //If success, redirect to article update confirmation page.
        Util.PageRedirect(7);

        Util = null;
    }

    public void Finalize_EditSubmission(Object s, EventArgs e)
    {

        //Instantiate database field
        ArticleInfo EditSubmission = new ArticleInfo();

        EditSubmission.ID = (int)Util.Val(Request.QueryString["aid"]);

        EditSubmission.Title = Request.Form["Title"];
        EditSubmission.Content = Request.Form["Content"];
        EditSubmission.Author = Request.Form["Author"];
        EditSubmission.CatID = int.Parse(Request.Form["CAT_ID"]);
        EditSubmission.Keyword = Request.Form["Keyword"];
        EditSubmission.Summary = Request.Form["Summary"];

        //Notify user if error occured.
        if (EditSubmission.Update() != 0)
        {
            JSLiteral.Text = Util.JSProcessingErrorAlert;
            return;
        }

        Response.Redirect("articlepreview.aspx?aid=" + EditSubmission.ID);

        //Release allocated memory
        EditSubmission = null;
        Util = null;
    }
}
