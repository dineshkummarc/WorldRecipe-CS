#region XD World Recipe V 2.8
// FileName: viewing.cs
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
using XDRecipe.Model.RecipeDetail;
using RecipeImage;
using CacheData;
using UserVal;
using BLL;
using Util;
using ConstantVar;

public partial class admin_viewing : System.Web.UI.Page
{

    //Instantiate sql params object
    Blogic myBL = new Blogic();

    //Instantiate validation
    Utility Util = new Utility();

    //Declare page level variable
    private int ID;
    public string strRecipename;
    public string strRecipeImage;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //Validate admin session username and password by comparing them to the admin user database record.
            UserNameVal.ValidateAdminUserNameandPass();

            //Instantiate database field
            RecipeDetails Recipe = new RecipeDetails();

            Recipe.ID = (int)Util.Val(Request.QueryString["id"]);

            strRecipeImage = GetRecipeImage.GetImage(Recipe.ID);

            Recipe.WhatPageID = constant.intRecipeAdminViewing; //Parameter 2 = we are pulling database field for Admin/viewing.aspx

            //Fill up database fields
            Recipe.fillup();

            if (Recipe.HitDate.ToString() == "1/1/0001 12:00:00 AM")
            {
                lblastviewed.Text = "This Recipe Has not been view by anyone";
            }
            else
            {
                lblastviewed.Text = Recipe.HitDate.ToString();
            }

            lblname.Text = Recipe.RecipeName;
            lblauthor.Text = Recipe.Author;
            lbldate.Text = Recipe.Date.ToShortDateString();
            lblCatName.Text = Recipe.Category;
            Ingredients.Text = Recipe.Ingredients;
            Instructions.Text = Recipe.Instructions;

            if (Recipe.Approved == 1)
            {
                approvebutton.Visible = false;
                lblapprovalstatus.Text = "Viewing Recipe";
            }
            else
            {
                lblapprovalstatus.Text = "Unapprove - This recipe is waiting for approval";
            }

            if (Recipe.Hits == 0)
            {
                lblhits.Text = "0";
            }
            else
            {
                lblhits.Text = string.Format("{0:#,###}", Recipe.Hits);
            }

            strRecipename = Recipe.RecipeName;

            //Release allocated memory.
            Util = null;
            Recipe = null;
        }
    }

    //Handles approve recipe
    public void Approve_Recipe(object sender, EventArgs e)
    {
        ID = (int)Util.Val(Request.QueryString["id"]);

        Caching.PurgeCacheItems("MainCourse_RecipeCategory");
        Caching.PurgeCacheItems("Ethnic_RecipeCategory");
        Caching.PurgeCacheItems("RecipeCategory_SideMenu");
        Caching.PurgeCacheItems("Newest_RecipesSideMenu_");

        // myBL.AdminApproveRecipe(ID);

        //Release allocated memory.
        myBL = null;

        //If success, redirect to recipe approval confirmation page.
        Util.PageRedirect(8);

        Util = null;
    }
}
