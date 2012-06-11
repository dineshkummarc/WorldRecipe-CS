#region XD World Recipe V 2.8
// FileName: articlemanager.cs
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
using XDRecipe.Model.AddUpdateDeleteArticleCategory;
using CacheData;
using UserVal;
using BLL;
using Util;
using ConstantVar;

public partial class admin_articlemanager : System.Web.UI.Page
{
    public int ArticleUpdateSection;

    protected void Page_Load(object sender, EventArgs e)
    {
        ArticleUpdateSection = constant.intArticleAdminUpdate;

        if (!IsPostBack)
        {
            //Validate admin session username and password by comparing them to the admin user database record.
            UserNameVal.ValidateAdminUserNameandPass();

            //Get admin username from the sessioan variable and place it in the label.
            lblusername.Text = "Welcome Admin:&nbsp;" + UserNameVal.AdminUsername;

            //Instantiate SQL params object
            Blogic myBL = new Blogic();

            lbCountArticle.Text = "Total Approved Article: " + myBL.ArticleCountAll;

            //Return Update Category List
            AdminUpdateArtCatList.DataSource = myBL.GetArticleCategoryList;
            AdminUpdateArtCatList.DataBind();

            //Return Add New Category List
            ArtCategoryList.DataSource = myBL.GetArticleCategoryList;
            ArtCategoryList.DataBind();

            ShowEditArticleListing();

            //Hide comment editing form
            Panel2.Visible = false;

            if (Request.QueryString["editcatid"] != null)
            {
                CategoryName.Text = Request.QueryString["catname"];
                CategoryID.Value = Request.QueryString["editcatid"];
                Panel2.Visible = true;
                Panel3.Visible = false;
                AddNewCat.Visible = false;
                lblheaderform.Text = "Updating Article Category ID# " + Request.QueryString["editcatid"];
            }

            //Release allocated memory
            myBL = null;
        }
        else
        {
            //Show comment editing form
            Panel2.Visible = true;
        }
    }

    //Handles show edit article listing
    private void ShowEditArticleListing()
    {
        //Instantiate sql params object
        Blogic myBL = new Blogic();

        //Instantiate validation
        Utility Util = new Utility();

        int CatId;
        CatId = (int)Util.Val(Request.QueryString["catid"]);

        if (string.IsNullOrEmpty(this.Request.QueryString["catid"]))
        {
            Panel1.Visible = false;
        }
        else
        {
            Panel1.Visible = true;

            try
            {
                IDataReader dr = myBL.GetArticleCategory(CatId, 3); //3 = Category OrderBy Name.

                dr.Read();
                lbcatname.Text = dr["CAT_NAME"].ToString();
                dr.Close();

                ArticleCat.DataSource = myBL.GetArticleCategory(CatId, 3); //3 = Category OrderBy Name.
                ArticleCat.DataBind();
            }
            catch
            {
                Error.Text = "No Record Found.";
                return;
            }

            //Release allocated memory
            myBL = null;
            Util = null;
        }
    }

    public void ArtCategoryList_ItemDataBound(Object s, RepeaterItemEventArgs e)
    {
        // This event is raised for the header, the footer, separators, and items.
        // Execute the following logic for Items and Alternating Items.
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            LinkButton delbutton2 = (LinkButton)(e.Item.FindControl("delbutton2"));
            HyperLink editbutton2 = (HyperLink)(e.Item.FindControl("editbutton2"));

            int showeditdellink;
            showeditdellink = Convert.ToInt32(Request.QueryString["showeditdellink"]);
            if (showeditdellink == 1)
            {
                delbutton2.Attributes["onclick"] = "javascript:return confirm('Are you sure you want to delete this category and all its associated articles. Note: you will loss all articles belong in this category. " + DataBinder.Eval(e.Item.DataItem, "CAT_NAME") + " Category, ID#  " + DataBinder.Eval(e.Item.DataItem, "CAT_ID") + "?')";
                delbutton2.Visible = true;
                editbutton2.Visible = true;
                Panel3.Visible = false;
            }
            else
            {
                if (Request.QueryString["editcatid"] != null)
                {
                    delbutton2.Visible = true;
                    editbutton2.Visible = true;
                }
                else
                {
                    delbutton2.Visible = false;
                    editbutton2.Visible = false;
                }
            }
        }
    }

    //Handles update comment
    public void Update_Category(Object s, EventArgs e)
    {
        //Instantiate article delete object
        ArticleCategory UpdateCat = new ArticleCategory();

        UpdateCat.CatID = int.Parse(Request.Form["CategoryID"]);
        UpdateCat.Category = Request.Form["CategoryName"];

        Caching.PurgeCacheItems("ArticleCategory_SideMenu");

        //Notify user if error occured.
        if (UpdateCat.Update() != 0)
        {
            JSLiteral.Text = "Error occured while processing your submit.";
            return;
        }

        Response.Redirect("confirmarticlecatedit.aspx?catname=" + UpdateCat.Category + "&mode=update");
    }

    //Handle the delete button click event
    public void Delete_Category(Object sender, RepeaterCommandEventArgs e)
    {
        if ((e.CommandName == "Delete"))
        {
            //Instantiate article delete object
            ArticleCategory DelCat = new ArticleCategory();

            DelCat.CatID = Convert.ToInt32(e.CommandArgument);

            Caching.PurgeCacheItems("ArticleCategory_SideMenu");

            //Perform delete
            DelCat.Delete();

            //Redirect to confirm delete page
            Response.Redirect("confirmarticlecatedit.aspx?catname=ArticleCategoryID" + DelCat.CatID + "&mode=del");
        }
    }

    //Handle add new category
    public void Add_Category(Object s, EventArgs e)
    {
        //Instantiate article delete object
        ArticleCategory AddCat = new ArticleCategory();

        AddCat.Category = Request.Form["CategoryName"];

        Caching.PurgeCacheItems("ArticleCategory_SideMenu");

        //Notify user if error occured.
        if (AddCat.Add() != 0)
        {
            JSLiteral.Text = "Error occured while processing your submit.";
            return;
        }

        Response.Redirect("confirmarticlecatedit.aspx?catname=" + AddCat.Category + "&mode=add");
    }

    public void ArticleCat_ItemDataBound(Object s, RepeaterItemEventArgs e)
    {
        // This event is raised for the header, the footer, separators, and items.
        // Execute the following logic for Items and Alternating Items.
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            LinkButton delbutton = (LinkButton)(e.Item.FindControl("delbutton"));
            delbutton.Attributes["onclick"] = "javascript:return confirm('Are you sure you want to delete " + DataBinder.Eval(e.Item.DataItem, "Title") + " Article, ID#  " + DataBinder.Eval(e.Item.DataItem, "ID") + "?')";
        }
    }

    //Handle the delete button click event
    public void Delete_Article(Object sender, RepeaterCommandEventArgs e)
    {
        if ((e.CommandName == "Delete"))
        {
            //Instantiate article delete object
            ArticleInfo DeleteArticle = new ArticleInfo();

            DeleteArticle.ID = Convert.ToInt32(e.CommandArgument);

            Caching.PurgeCacheItems("Newest_Articles");
            Caching.PurgeCacheItems("ArticleCategory_SideMenu");

            //Perform delete
            DeleteArticle.Delete();

            //Release allocated memory
            DeleteArticle = null;

            //Redirect to confirm delete page
            Response.Redirect("articlemanager.aspx");
        }
    }

    //Switch to Add Category mode
    public void ChangeToAddCat(object s, EventArgs e)
    {
        DelCategory.Visible = false;
        CategoryName.Text = "";
        CategoryID.Visible = false;
        Panel2.Visible = true;
        Panel3.Visible = false;
        AddNewCat.Visible = true;
        updatebutton.Visible = false;
        lblheaderform.Text = "Adding New Article Category";
        lblnamedis2.Text = "Category Name:";
    }
}
