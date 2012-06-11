#region XD World Recipe V 2.8
// FileName: addupdatedeleterecipecategory.cs
// Author: Dexter Zafra
// Date Created: 6/30/2008
// Website: www.ex-designz.net
#endregion
using System;
using BLL;

namespace XDRecipe.Model.AddUpdateDeleteRecipeCategory
{
    /// <summary>
    /// Objects in this class manages Add, Update and Delete Recipe Category
    /// </summary>
    public class RecipeCategory : Recipe
    {
        //Instantiate Action Stored Procedure object
        Blogic ActionSP = new Blogic();

        /// <summary>
        /// Default Constructor
        /// </summary>
        public RecipeCategory()
        {
        }

        /// <summary>
        /// Perform Insert to Database
        /// </summary>
        /// <returns></returns>
        public override int Add()
        {
            return ActionSP.AdminAddNewRecipeCategory(Category, CatGroupID);
            ActionSP = null;
        }

        /// <summary>
        /// Perform Update
        /// </summary>
        /// <returns></returns>
        public override int Update()
        {
            return ActionSP.UpdateRecipeCategory(CatID, Category);
            ActionSP = null;
        }

        /// <summary>
        /// Perform Delete
        /// </summary>
        /// <returns></returns>
        public override int Delete()
        {
            return ActionSP.AdminDeleteRecipeCategory(CatID);
            ActionSP = null;
        }
    }
}