#region XD World Recipe V 2.8
// FileName: addarticle.cs
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
using XDRecipe.Model.AddUpdateDeleteArticle;
using UserVal;
using BLL;
using Util;

public partial class admin_addarticle : System.Web.UI.Page
{

    //Instantiate sql params object
    Blogic myBL = new Blogic();

    //Instantiate validation
    Utility Util = new Utility();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //Validate admin session username and password by comparing them to the admin user database record.
            UserNameVal.ValidateAdminUserNameandPass();

            //Get admin username from the sessioan variable and place it in the label.
            lblusername.Text = "Welcome Admin:&nbsp;" + UserNameVal.AdminUsername;

            GetArticleCategoryName();

            IDataReader dr = myBL.GetLastArticleID;

            dr.Read();

            Label1.Text = dr["Col"].ToString();

            dr.Close();

            //Release allocated memory
            myBL = null;
            Util = null;
        }
    }

    private void GetArticleCategoryName()
    {
        int Cat_ID = (int)Util.Val(Request.QueryString["catid"]);

        //Get article category name and assigned to the label.
        lbcatname.Text = myBL.GetArticleCategoryName(Cat_ID);
        lbcatname2.Text = myBL.GetArticleCategoryName(Cat_ID);
        CAT_ID.Value = Cat_ID.ToString();
    }

    //Handles insert article
    public void Add_Article(Object s, EventArgs e)
    {
        //Instantiate article information object.
        ArticleInfo AddArticle = new ArticleInfo();

        AddArticle.Title = Request.Form["Title"];
        AddArticle.Content = Request.Form["Content"];
        AddArticle.Author = Request.Form["Author"];
        AddArticle.CatID = (int)Util.Val(Request.QueryString["catid"]);
        AddArticle.Keyword = Request.Form["Keyword"];
        AddArticle.Summary = Request.Form["Summary"];

        //Notify user if error occured.
        if (AddArticle.Add() != 0)
        {
            JSLiteral.Text = "Error occured while processing your submit.";
            return;
        }

        //Release allocated memory
        AddArticle = null;
        Util = null;

        int getlastID;
        getlastID = int.Parse(Label1.Text) + 1;

        //If success, redirect to confirmation and thank you page.
        Response.Redirect("articlepreview.aspx?aid=" + getlastID);
    }
}
