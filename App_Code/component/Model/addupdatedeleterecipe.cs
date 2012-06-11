#region XD World Recipe V 2.8
// FileName: addupdatedeleterecipe.cs
// Author: Dexter Zafra
// Date Created: 6/30/2008
// Website: www.ex-designz.net
#endregion
using System;
using BLL;

namespace XDRecipe.Model.AddUpdateDelete
{
    /// <summary>
    /// Objects in this class manages Add, Update and Delete Recipe
    /// </summary>
    public class RecipeInfo : Recipe
    {
        //Instantiate Action Stored Procedure object
        Blogic ActionSP = new Blogic();

        /// <summary>
        /// Default Constructor
        /// </summary>
        public RecipeInfo()
        {
        }

        /// <summary>
        /// Perform Insert to Database
        /// </summary>
        /// <returns></returns>
        public override int Add()
        {
           return ActionSP.AddRecipe(RecipeName, Author, CatID, Category, Ingredients, Instructions, RecipeImage);
           ActionSP = null;
        }

        /// <summary>
        /// Perform Update
        /// </summary>
        /// <returns></returns>
        public override int Update()
        {
           return ActionSP.UpdateRecipe(ID, RecipeName, Author, CatID, Ingredients, Instructions, Hits, RecipeImage);
           ActionSP = null;
        }

        /// <summary>
        /// Perform Delete
        /// </summary>
        /// <returns></returns>
        public override int Delete()
        {
            return ActionSP.AdminRecipeManagerDelete(ID);
            ActionSP = null;
        }
    }
}

