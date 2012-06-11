#region XD World Recipe V 2.8
// FileName: addupdatedeletearticlecategory.cs
// Author: Dexter Zafra
// Date Created: 7/4/2008
// Website: www.ex-designz.net
#endregion
using System;
using BLL;

namespace XDRecipe.Model.AddUpdateDeleteArticleCategory
{
    /// <summary>
    /// Objects in this class manages Add, Update and Delete Recipe Category
    /// </summary>
    public class ArticleCategory : Article
    {
        //Instantiate Action Stored Procedure object
        Blogic ActionSP = new Blogic();

        /// <summary>
        /// Default Constructor
        /// </summary>
        public ArticleCategory()
        {
        }

        /// <summary>
        /// Perform Insert to Database
        /// </summary>
        /// <returns></returns>
        public override int Add()
        {
            return ActionSP.AdminAddNewArticleCategory(Category);
            ActionSP = null;
        }

        /// <summary>
        /// Perform Update
        /// </summary>
        /// <returns></returns>
        public override int Update()
        {
            return ActionSP.UpdateArticleCategory(CatID, Category);
            ActionSP = null;
        }

        /// <summary>
        /// Perform Delete
        /// </summary>
        /// <returns></returns>
        public override int Delete()
        {
            return ActionSP.AdminDeleteArticleCategory(CatID);
            ActionSP = null;
        }
    }
}
