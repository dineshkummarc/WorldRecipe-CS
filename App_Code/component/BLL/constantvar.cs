#region XD World Recipe V 2.8
// FileName: constantvar.cs
// Author: Dexter Zafra
// Date Created: 12/29/2008
// Website: www.ex-designz.net
#endregion
using System;
using System.Web;

namespace ConstantVar
{
    /// <summary>
    /// Object in this class manage constant variables.
    /// </summary>
    public static class constant
    {
        //These constant variables are use to flag when fetching database,previewing/viewing,
        //inserting cookie, getting dynamic keywords based on the value passed. 

        #region AZ Alphabet Letter Links
        /// <summary>
        /// User page - int = 1
        /// </summary>
        public const int UserFrontEnd = 1;

        /// <summary>
        /// Admin Page int = 2
        /// </summary>
        public const int AdminBackEnd = 2;
        #endregion

        #region Categopry Dropdownlist
        /// <summary>
        /// Recipe Section - string = "Recipe"
        /// </summary>
        public const string Recipe = "Recipe";

        /// <summary>
        /// Article Section - string = "Article"
        /// </summary>
        public const string Article = "Article";
        #endregion

        #region Recipe Section int
        /// <summary>
        /// Recipe Section - int = 1
        /// </summary>
        public const int intRecipe = 1;

        /// <summary>
        /// Article Section - int = 2
        /// </summary>
        public const int intArticle = 2;
        #endregion

        #region Recipe Details, Admin Viewing and Editing Section int
        /// <summary>
        /// Recipe details int = 1
        /// </summary>
        public const int intRecipeDetails = 1;

        /// <summary>
        /// Recipe admin viewing - int = 2
        /// </summary>
        public const int intRecipeAdminViewing = 2;

        /// <summary>
        /// Recipe admin editing - int = 3
        /// </summary>
        public const int intRecipeAdminEditing = 3;
        #endregion

        #region Recipe Dynamic Keywords Section int
        /// <summary>
        /// Recipe dynamic keyword category page int = 1
        /// </summary>
        public const int intRecipeDynamicKeywordCategory = 1;

        /// <summary>
        /// Recipe dynamic keyword sort page - int = 2
        /// </summary>
        public const int intRecipeDynamicKeywordSortPage = 2;

        /// <summary>
        /// Recipe dynamic keywrod recipe details - int = 3
        /// </summary>
        public const int intRecipeDynamicKeywordDetails = 3;
        #endregion

        #region Article Details, Admin Preview and Editing Section int
        /// <summary>
        /// Article details int = 1
        /// </summary>
        public const int intArticleDetails = 1;

        /// <summary>
        /// Article admin editing - int = 2
        /// </summary>
        public const int intArticleAdminUpdate = 2;

        /// <summary>
        /// Article admin submission preview int = 3
        /// </summary>
        public const int intArticleAdminPreview = 3;
        #endregion
    }
}