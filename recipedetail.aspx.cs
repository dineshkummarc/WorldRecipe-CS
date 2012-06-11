#region XD World Recipe V 2.8
// FileName: Recipedetail.cs
// Author: Dexter Zafra
// Date Created: 5/23/2008
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
using XDRecipe.Model.AddUpdateDeleteRecipeComment;
using EmailTemplates;
using RecipeComment;
using RatingCookie;
using BookmarkURL;
using GetRelatedRecipe;
using RecipeImage;
using XDRecipe.UI;
using Util;
using GetDynamicKeywords;
using ConstantVar;

public partial class recipedetail : BasePage
{
    //Instantiate utility/common object
    Utility Util = new Utility();

    //Instantiate recipe database field object
    RecipeDetails Recipe = new RecipeDetails();

    //Declare page level variables
    public string strRName;
    public string strCName;
    public int RecCatId;
    public string strBookmarkURL;
    public string strRecipeImage;
    public int RecipeSection;

    protected void Page_Load(object sender, EventArgs e)
    {
        Recipe.WhatPageID = constant.intRecipeDetails;
        Recipe.ID = (int)Util.Val(Request.QueryString["id"]);

        //Fill up database fields
        Recipe.fillup();

        //Initialize variables to use for aspx page.
        RecCatId = Recipe.CatID;
        strRName = Recipe.RecipeName;
        strCName = Recipe.Category;
        RecipeSection = constant.intRecipe;

        recipeimage.Visible = false;

        //Display recipe image if exist.
        if (!string.IsNullOrEmpty(Recipe.RecipeImage))
        {
            recipeimage.Visible = true;
            recipeimage.ImageUrl = GetRecipeImage.ImagePathDetail + Recipe.RecipeImage;
        }

        lbcountcomment.Text = Recipe.CountComments.ToString();
        lblname.Text = Recipe.RecipeName;
        lblauthor.Text = Recipe.Author;
        lblhits.Text = string.Format("{0:#,###}", Recipe.Hits);
        lblrating.Text = Recipe.Rating;
        lblvotescount.Text = Recipe.NoRates;
        lblcategorytop.Text = Recipe.Category;
        lbldate.Text = Recipe.Date.ToShortDateString();
        lblIngredients.Text = Util.FormatText(Recipe.Ingredients);
        lblInstructions.Text = Util.FormatText(Recipe.Instructions);
        starimage.ImageUrl = Utility.GetStarImage(Recipe.Rating);

        //Save to Favorite/Bookmark URL
        strBookmarkURL = Bookmark.URL;

        //Get dynamic page title and keywords
        GetMetaKeywords(DynamicKeywords.Keywords(constant.intRecipeDynamicKeywordDetails, Recipe.RecipeName.ToString() + " recipe, " + Recipe.Category.ToString() + " recipe"));

        //Display New and Popular image
        ShowNewPopularImage();

        //Get 15 related recipes datatable.
        GetRelatedrecipes();

        //Get user recipe cookie rating
        GetUserRecipeCookieRating();

        //Get Recipe Comment
        GetComments();

        //Release allocated memory
        Util = null;
        Recipe = null;
    }

    //Get recipe user cookie rating
    private void GetUserRecipeCookieRating()
    {
        //Instantiate user cookie rating object
        CookieRating GetCookie = new CookieRating(constant.intRecipe, Recipe.ID, PlaceHolder1);

        //Get the user rating cookie
        GetCookie.GetUserCookieRating();

        //Release allocated memory
        GetCookie = null;
    }

    //Handles show New and Popular image
    private void ShowNewPopularImage()
    {
        Utility.GetIdentifyItemNewPopular(Recipe.Date, PlaceHolder1, Recipe.Hits);
    }

    //Get 15 related recipes
    private void GetRelatedrecipes()
    {
        RelatedRecipes.DataSource = RelatedRecipeProvider.GetRelatedRecipes(Recipe.CatID);
        RelatedRecipes.DataBind();
    }

    //Handles recipe comment
    private void GetComments()
    {
        //Get Recipe Comment - show/hide comment
        RecipeComments Comment = new RecipeComments(Recipe.ID, RecComments, PlaceHolder1);
        Comment.fillup();

        Comment = null;
    }

    //Handles dyanmic page title and meta keywords
    private void GetMetaKeywords(string strPageTitleAndKeywords)
    {
        //Assign page title and meta keywords
        Page.Header.Title = strPageTitleAndKeywords;
        HtmlMeta metaTag = new HtmlMeta();
        metaTag.Name = "Keywords";
        //You can add more keywords if you want.
        metaTag.Content = strPageTitleAndKeywords;
        this.Header.Controls.Add(metaTag);
    }

    //Handles comment posting
    public void Add_Comment(Object s, EventArgs e)
    {
        //Perform spam validation by matching the value of the textbox security code to the session variable
        //that store the random number.
        if (Page.IsValid && (txtsecfield.Text.ToString() == Session["randomStr"].ToString()))
        {
            //Instantiate object
            Utility Util = new Utility();

            //If all the fields are filled correctly, then process the comment post.
            //Instantiate the SQL command object
            CommentInfo AddComm = new CommentInfo();

            AddComm.ID = (int)Util.Val(Request.QueryString["id"]);

            //Filters harmful scripts from input string.
            AddComm.Author = Util.FormatTextForInput(Request.Form[AUTHOR.UniqueID]);
            AddComm.Email = Util.FormatTextForInput(Request.Form[EMAIL.UniqueID]);
            AddComm.Comments = Util.FormatTextForInput(Request.Form[COMMENTS.UniqueID]);

            #region Comment Form Input Validator
            //Validate for empty name
            if (AddComm.Author.Length == 0)
            {
                JSLiteral.Text = Util.JSAlert("Error: Name is empty, please enter your name.");
                lbvalenght.Text = "<br>Error: Name is empty, please enter your name.";
                lbvalenght.Visible = true;
                txtsecfield.Text = "";
                return;
            }
            //Validate for empty email
            if (AddComm.Email.Length == 0)
            {
                JSLiteral.Text = Util.JSAlert("Error: Email is empty, please enter your email.");
                lbvalenght.Text = "<br>Error: Email is empty, please enter your email.";
                lbvalenght.Visible = true;
                txtsecfield.Text = "";
                return;
            }
            //Validate for empty comments
            if (AddComm.Comments.Length == 0)
            {
                JSLiteral.Text = Util.JSAlert("Error: Comment is empty, please your comment.");
                lbvalenght.Text = "<br>Error: Comment is empty, please your comment.";
                lbvalenght.Visible = true;
                txtsecfield.Text = "";
                return;
            }

            //Name maximum of 50 char allowed
            if (AddComm.Author.Length > 50)
            {
                JSLiteral.Text = Util.JSAlert("Error: Name is too long. Max of 50 characters.");
                lbvalenght.Text = "<br>Error: Name is too long. Max of 50 characters.";
                lbvalenght.Visible = true;
                AUTHOR.Value = "";
                txtsecfield.Text = "";
                return;
            }
            //Email maximum of 50 char allowed
            if (AddComm.Email.Length > 50)
            {
                JSLiteral.Text = Util.JSAlert("Error: Email is too long. Max of 50 characters.");
                lbvalenght.Text = "<br>Error: Email is too long. Max of 50 characters.";
                lbvalenght.Visible = true;
                EMAIL.Value = "";
                txtsecfield.Text = "";
                return;
            }
            //Comments maximum of 200 char allowed
            if (AddComm.Comments.Length > 200)
            {
                JSLiteral.Text = Util.JSAlert("Error: Comments is too long. Max of 200 characters.");
                lbvalenght.Text = "<br>Error: Comments is too long. Max of 200 characters.";
                lbvalenght.Visible = true;
                txtsecfield.Text = "";
                return;
            }
            #endregion

            //Notify user if error occured.
            if (AddComm.Add() != 0)
            {
                JSLiteral.Text = Util.JSAlert("A database error occured while processing your request.");
                return;
            }

            //Instantiate email template object
            EmailTemplate SendEmail = new EmailTemplate();

            SendEmail.ItemID = AddComm.ID;
            SendEmail.ItemName = strRName;

            //Send an email notification to the webmaster in HTML format.
            SendEmail.SendEmailCommentNotify();

            //Release allocated memory
            SendEmail = null;
            AddComm = null;

            //If success, redirect to confirmation and thank you page.
            Util.PageRedirect(4);

            Util = null;
        }
        else
        {
            //Javascript validation
            JSLiteral.Text = Util.JSAlert("Invalid security code. Make sure you type it correctly.");
            return;

           // lblinvalidsecode.Text = "Invalid security code. Make sure you type it correctly.";
           // lblinvalidsecode.Visible = true;
        }
    }
}
