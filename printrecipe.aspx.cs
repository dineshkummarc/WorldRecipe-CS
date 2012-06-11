#region XD World Recipe V 2.8
// FileName: printrecipe.cs
// Author: Dexter Zafra
// Date Created: 5/24/2008
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
using XDRecipe.UI;
using Util;
using ConstantVar;

public partial class printrecipe : BasePage
{
    public string strRName;

    protected void Page_Load(object sender, EventArgs e)
    {
        //Instantiate object
        Utility Util = new Utility();         

        //Instantiate database field
        RecipeDetails Recipe = new RecipeDetails();

        Recipe.WhatPageID = constant.intRecipeDetails; //1 = we are dealing with print.aspx use the same as recipedetails.
        Recipe.ID = (int)Util.Val(Request.QueryString["id"]);

        //Fill up database fields
        Recipe.fillup();

        lblingredientsdis.Text = "Ingredients:";
        lblinstructionsdis.Text = "Instructions:";
        lblname.Text = Recipe.RecipeName;
        lblIngredients.Text = Util.FormatText(Recipe.Ingredients);
        lblInstructions.Text = Util.FormatText(Recipe.Instructions);

        strRName = "Printing" + Recipe.RecipeName + " Recipe";

        //Release allocated memory
        Util = null;
        Recipe = null;
    }
}
