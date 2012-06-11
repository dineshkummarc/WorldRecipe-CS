#region XD World Recipe V 2.8
// FileName: addupdatedeletearticle.cs
// Author: Dexter Zafra
// Date Created: 6/30/2008
// Website: www.ex-designz.net
#endregion
using System;
using BLL;

namespace XDRecipe.Model.AddUpdateDeleteArticle
{
    /// <summary>
    /// Objects in this class manages Add, Update and Delete Recipe
    /// </summary>
    public class ArticleInfo : Article
    {
        //Instantiate Action Stored Procedure object
        Blogic ActionSP = new Blogic();

        /// <summary>
        /// Default Constructor
        /// </summary>
        public ArticleInfo()
        {
        }

        /// <summary>
        /// Perform Insert to Database
        /// </summary>
        /// <returns></returns>
        public override int Add()
        {
            return ActionSP.AddArticle(Title, Content, Author, CatID, Keyword, Summary);
            ActionSP = null;
        }

        /// <summary>
        /// Perform Update
        /// </summary>
        /// <returns></returns>
        public override int Update()
        {
            return ActionSP.UpdateArticle(ID, Title, Content, Author, CatID, Keyword, Summary);
            ActionSP = null;
        }

        /// <summary>
        /// Perform Delete
        /// </summary>
        /// <returns></returns>
        public override int Delete()
        {
            return ActionSP.AdminDeleteArticle(ID);
            ActionSP = null;
        }
        
    }
}
