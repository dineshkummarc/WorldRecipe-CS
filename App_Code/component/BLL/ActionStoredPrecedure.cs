#region XD World Recipe V 2.8
// FileName: ActionStoredPrecedure.cs
// Author: Dexter Zafra
// Date Created: 5/19/2008
// Website: www.ex-designz.net
#endregion
using System;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Win32;
using System.Collections;
using System.Diagnostics;
using XDRecipe.DAO;

namespace BLL
{
    /// <summary>
    /// Class which contains the logic to execute retrieval of stored procedures in the database.
    /// </summary>
    /// <returns></returns>
    public class Blogic
   {
      /// <summary>
      /// Returns category in the hompage.
      /// </summary>
      /// <returns></returns>
      public IDataReader GetCategoryHomePage
      {
          get { return DataAccess.GetFromReader("HomePage_GetCategory"); }
      }

      /// <summary>
      /// Returns recipe category dropdownlist.
      /// </summary>
      /// <returns></returns>
      public IDataReader GetRecipeCategoryDropdownlist
      {
          get { return DataAccess.GetFromReader("HomePage_GetCategory"); }
      }

      /// <summary>
      /// Returns homepage main course recipe category.
      /// </summary>
      /// <returns></returns>
        public IDataReader GetHomepageMainCourseCategory
        {
            get { return DataAccess.GetFromReader("GetHomePageCategoryMainCourseRecipe"); }
        }

      /// <summary>
      /// Returns homepage ethnic and regional recipe category.
      /// </summary>
      /// <returns></returns>
      public IDataReader GetHomepageEthnicRegionalCategory
      {
          get { return DataAccess.GetFromReader("GetHomepageEthnicRegionalCategory"); }
      }

      /// <summary>
      /// Returns homepage recipe of the day.
      /// </summary>
      /// <returns></returns>
      public IDataReader GetHomepageRecipeoftheDay
      {
          get { return DataAccess.GetFromReader("GetRecipeOfTheDay"); }
      }

      /// <summary>
      /// Returns homepage 15 last viewed recipe in the homepage.
      /// </summary>
      /// <returns></returns>
       public IDataReader GetLastViewedRecipe
        {
            get { return DataAccess.GetFromReader("GetLastViewedRecipe"); }
        }

      /// <summary>
      /// Returns category list with count in the sidemenu.
      /// </summary>
      /// <returns></returns>
       public IDataReader GetRecipeCategoryList_SideMenu
       {
           get { return DataAccess.GetFromReader("GetRecipeCategoryListSideMenu"); }
       }

       /// <summary>
       /// Returns show hide comment - default (value is 1 = show comment).
       /// </summary>
       /// <returns></returns>
       public IDataReader GetConfiguration
       {
           get { return DataAccess.GetFromReader("GetConfiguration"); }
       }

       /// <summary>
       /// Returns random recipe in the side menu.
       /// </summary>
       /// <returns></returns>
       public IDataReader GetRandomRecipeSideMenu(int CatId)
       {
           SqlParameter prmCatId = new SqlParameter("@CatId", SqlDbType.Int, 4);
           prmCatId.Value = CatId;

           return DataAccess.GetFromReader("GetRandomRecipe", prmCatId);
       }

       /// <summary>
       /// Returns recipe details.
       /// </summary>
       /// <returns></returns>
        public IDataReader GetRecipeDetail(int ID)
        {
            SqlParameter prmID = new SqlParameter("@ID", SqlDbType.Int, 4);
            prmID.Value = ID;

            return DataAccess.GetFromReader("GetRecipeDetail", prmID);
        }

       /// <summary>
       /// Returns article detail.
       /// </summary>
       /// <returns></returns>
        public IDataReader GetArticleDetail(int ID, int Show)
       {
           SqlParameter prmID = new SqlParameter("@AID", SqlDbType.Int, 4);
           prmID.Value = ID;

           SqlParameter prmShow = new SqlParameter("@Show", SqlDbType.Int, 4);
           prmShow.Value = Show;

           return DataAccess.GetFromReader("GetArticleDetails", prmID, prmShow);
       }

       /// <summary>
       /// Returns comments in the recipe detail.
       /// </summary>
       /// <returns></returns>
       public IDataReader GetCommentsRecipeDetail(int ID)
       {
           SqlParameter prmID = new SqlParameter("@ID", SqlDbType.Int, 4);
           prmID.Value = ID;

           return DataAccess.GetFromReader("GetCommentsRecipeDetail", prmID);
       }

       /// <summary>
       /// Returns related recipe in the recipe detail.
       /// </summary>
       /// <returns></returns>
       public IDataReader GetRelatedRecipe(int CatId)
       {
           SqlParameter prmCatId = new SqlParameter("@CatId", SqlDbType.Int, 4);
           prmCatId.Value = CatId;

           return DataAccess.GetFromReader("GetRelatedRecipe", prmCatId);
       }

      /// <summary>
      /// Returns newest recipes in the side menu.
      /// </summary>
      /// <returns></returns>
       public IDataReader GetNewestRecipesSideMenu(int CatId, int Top)
       {
          SqlParameter prmCatId = new SqlParameter("@CatId", SqlDbType.Int, 4);
          prmCatId.Value = CatId;

          SqlParameter prmTop = new SqlParameter("@Top", SqlDbType.Int, 4);
          prmTop.Value = Top;

          return DataAccess.GetFromReader("GetNewestRecipesSideMenu", prmCatId, prmTop);
      }

      /// <summary>
      /// Returns RSS most popular recipe
      /// </summary>
      /// <returns></returns>
      public IDataReader GetRSSMostPopularRecipe
      {
          get { return DataAccess.GetFromReader("GetXMLToprecipe"); }
      }

      /// <summary>
      /// Returns RSS newest recipe
      /// </summary>
      /// <returns></returns>
      public IDataReader GetRSSNewestRecipe
      {
          get { return DataAccess.GetFromReader("GetXMLNewestRecipe"); }
      }

      /// <summary>
      /// Returns Admin Get Recipe Comments
      /// </summary>
      /// <returns></returns>
       public DataTable AdminGetRecipeComments 
      {
          get { return DataAccess.GetFromDataTable("AdminGetRecipeComments"); }
      }

      /// <summary>
      /// Returns Admin Get Recipe Category Manager
      /// </summary>
      /// <returns></returns>
        public IDataReader AdminGetRecipeCategoryManager
      {
          get { return DataAccess.GetFromReader("AdminGetRecipeCategoryManager"); }
      }

      /// <summary>
      /// Returns category name
      /// </summary>
      /// <param name="CategoryID">Category ID</param>
      /// <returns></returns>
      public IDataReader GetCatName(int CatId)
      {
          SqlParameter prmCatId = new SqlParameter("@CatId", SqlDbType.Int, 4);
          prmCatId.Value = CatId;

          return DataAccess.GetFromReader("GetCategoryName", prmCatId);
      }

      /// <summary>
      /// Returns recipe image filename to use for update
      /// </summary>
      /// <returns></returns>
        public IDataReader GetRecipeImageFileNameForUpdate(int ID)
      {
          SqlParameter prmID = new SqlParameter("@ID", SqlDbType.Int, 4);
          prmID.Value = ID;

          return DataAccess.GetFromReader("GetRecipeImageFileNameForUpdate", prmID);
      }

      /// <summary>
      /// Log Exception Error
      /// </summary>
      public static int LogExceptionError(string URL, string ExceptionError)
      {
          SqlParameter prmURL = new SqlParameter("@URL", SqlDbType.VarChar, 100);
          prmURL.Value = URL;

          SqlParameter prmExceptionError = new SqlParameter("@Exception", SqlDbType.VarChar, 1000);
          prmExceptionError.Value = ExceptionError;

          return DataAccess.Execute("spInsertExceptionError", prmURL, prmExceptionError);

      }

#region Get category, A-Z recipename, sort and search with Custom Paging
      /// <summary>
      /// Returns Category with custom paging
      /// </summary>
      /// <param name="SectionName">Section Name</param>
      /// <param name="Category">Category</param>
      /// <returns></returns>
        public IDataReader GetRecipeCategoryWithCustomPaging(int CatId, int OrderBy, int SortBy, int PageIndex, int PageSize)
      {
          SqlParameter prmCatId = new SqlParameter("@CatId", SqlDbType.Int, 4);
          prmCatId.Value = CatId;

          SqlParameter prmOrderBy = new SqlParameter("@OrderBy", SqlDbType.Int, 4);
          prmOrderBy.Value = OrderBy;

          SqlParameter prmSortBy = new SqlParameter("@SortBy", SqlDbType.Int, 4);
          prmSortBy.Value = SortBy;

          SqlParameter prmPageIndex = new SqlParameter("@PageIndex", SqlDbType.Int, 4);
          prmPageIndex.Value = PageIndex;

          SqlParameter prmPageSize = new SqlParameter("@PageSize", SqlDbType.Int, 4);
          prmPageSize.Value = PageSize;

          return DataAccess.GetFromReader("GetRecipeCategory", prmCatId, prmOrderBy, prmSortBy, prmPageIndex, prmPageSize);
      }

      /// <summary>
      /// Returns A-Z recipe name with custom paging
      /// </summary>
      /// <param name="SectionName">Section Name</param>
      /// <param name="Category">A-Z recipe</param>
      /// <returns></returns>
        public IDataReader GetRecipeAlphaLetterWithPaging(string Letter, int OrderBy, int SortBy, int PageIndex, int PageSize)
      {
          SqlParameter prmLetter = new SqlParameter("@Letter", SqlDbType.Char, 1);
          prmLetter.Value = Letter;

          SqlParameter prmOrderBy = new SqlParameter("@OrderBy", SqlDbType.Int, 4);
          prmOrderBy.Value = OrderBy;

          SqlParameter prmSortBy = new SqlParameter("@SortBy", SqlDbType.Int, 4);
          prmSortBy.Value = SortBy;

          SqlParameter prmPageIndex = new SqlParameter("@PageIndex", SqlDbType.Int, 4);
          prmPageIndex.Value = PageIndex;

          SqlParameter prmPageSize = new SqlParameter("@PageSize", SqlDbType.Int, 4);
          prmPageSize.Value = PageSize;

          return DataAccess.GetFromReader("GetRecipeFirstAlphaLetterName", prmLetter, prmOrderBy, prmSortBy, prmPageIndex, prmPageSize);
      }

      /// <summary>
      /// Returns Sorted recipe.
      /// </summary>
      /// <returns></returns>
        public IDataReader GetSortRecipePage(int Sid, int SortBy, int PageIndex, int PageSize)
      {
          SqlParameter prmSid = new SqlParameter("@Sid", SqlDbType.Int, 4);
          prmSid.Value = Sid;

          SqlParameter prmSortBy = new SqlParameter("@SortBy", SqlDbType.Int, 4);
          prmSortBy.Value = SortBy;

          SqlParameter prmPageIndex = new SqlParameter("@PageIndex", SqlDbType.Int, 4);
          prmPageIndex.Value = PageIndex;

          SqlParameter prmPageSize = new SqlParameter("@PageSize", SqlDbType.Int, 4);
          prmPageSize.Value = PageSize;

          return DataAccess.GetFromReader("GetSortingRecipe", prmSid, prmSortBy, prmPageIndex, prmPageSize);
      }

      /// <summary>
      /// Returns search result
      /// </summary>
        public IDataReader GetSearchResult(string Search, int CatId, int OrderBy, int PageIndex, int PageSize)
      {
          SqlParameter prmSearch = new SqlParameter("@Search", SqlDbType.VarChar, 20);
          prmSearch.Value = Search;

          SqlParameter prmCatId = new SqlParameter("@CAT_ID", SqlDbType.Int, 4);
          prmCatId.Value = CatId;

          SqlParameter prmOrderBy = new SqlParameter("@OrderBy", SqlDbType.Int, 4);
          prmOrderBy.Value = OrderBy;

          SqlParameter prmPageIndex = new SqlParameter("@PageIndex", SqlDbType.Int, 4);
          prmPageIndex.Value = PageIndex;

          SqlParameter prmPageSize = new SqlParameter("@PageSize", SqlDbType.Int, 4);
          prmPageSize.Value = PageSize;

          return DataAccess.GetFromReader("GetSearchResult", prmSearch, prmCatId, prmOrderBy, prmPageIndex, prmPageSize);
      }

      /// <summary>
      /// Returns top 15 most popular recipes in the side menu.
      /// </summary>
      /// <returns></returns>
      public IDataReader GetMostpopularRecipesSideMenu(int CatId, int Top)
      {
          SqlParameter prmCatId = new SqlParameter("@CatId", SqlDbType.Int, 4);
          prmCatId.Value = CatId;

          SqlParameter prmTop = new SqlParameter("@Top", SqlDbType.Int, 4);
          prmTop.Value = Top;

          return DataAccess.GetFromReader("GetTopRecipesSideMenu", prmCatId, prmTop);
      }

#endregion 

#region Return counter - int32 Scalar value
      /// <summary>
      /// Returns category recipe count
      /// </summary>
      /// <param name="CategoryID">Category ID</param>
      /// <returns></returns>
       public int CategoryCount(int CatId)
       {
           SqlParameter prmCatId = new SqlParameter("@CatId", SqlDbType.Int, 4);
           prmCatId.Value = CatId;

           return DataAccess.GetInt32("CategoryPage_GetRecipesCount", prmCatId);
       }

       /// <summary>
       /// Returns Article Count
       /// </summary>
       /// <returns></returns>
       public int ArticleCountAll
       {
           get { return DataAccess.GetIntScalarVal("ArticleCountAll"); }
       }

      /// <summary>
      /// Returns total category count
      /// </summary>
      /// <returns></returns>
       public int GetHomepageTotalCategoryCount
       {
           get { return DataAccess.GetIntScalarVal("GetHompageTotalCategoryCount"); }
       }

       /// <summary>
       /// Returns total recipe count
       /// </summary>
       /// <returns></returns>
       public int GetHomepageTotalRecipeCount
       {
           get { return DataAccess.GetIntScalarVal("GetCountTotalRecipes"); }
       }

       /// <summary>
       /// Returns total comments count
       /// </summary>
       /// <returns></returns>
       public int AdminRecipeManagerGetTotalComments
       {
           get { return DataAccess.GetIntScalarVal("GetTotalCommentsCount"); }
       }

       /// <summary>
       /// Returns admin recipe manager waiting for approval recipe count
       /// </summary>
       /// <returns></returns>
       public int AdminRecipeManagerGetWaitingforApprovalCount
       {
           get { return DataAccess.GetIntScalarVal("GetUnApprovedRecipeCount"); }
       }

       /// <summary>
       /// Returns last viewed set hours
       /// </summary>
       /// <returns></returns>
       public int GetLastViewedSetHours
       {
           get { return DataAccess.GetIntScalarVal("GetLastViewedSetHours"); }
       }

       /// <summary>
       /// Returns show hide comment value
       /// </summary>
       /// <returns></returns>
       public int GetShowHideComment
       {
           get { return DataAccess.GetIntScalarVal("GetShowHideComment"); }
       }
#endregion

#region Get article details, Update hit counter, Get Category list, Add, Update and Delete Article

       /// <summary>
       /// Returns article category list.
       /// </summary>
       /// <returns></returns>
       public IDataReader GetArticleCategoryList
       {
           get { return DataAccess.GetFromReader("GetArticleCategoryList"); }
       }

       /// <summary>
       /// Returns 10 newest cooking articles in the right side panel.
       /// </summary>
       /// <returns></returns>
        public IDataReader GetNewestArticleSidePanel(int Top)
       {
           SqlParameter prmTop = new SqlParameter("@Top", SqlDbType.Int, 4);
           prmTop.Value = Top;

           return DataAccess.GetFromReader("GetNewestArticleSidePanel", prmTop); 
       }

       /// <summary>
       /// Returns DataTable Article Category
       /// </summary>
        public IDataReader GetArticlesInCategory(int CATID, int OrderBy, int SortBy, int PageIndex, int PageSize)
       {
           SqlParameter prmCatId = new SqlParameter("@CATID", SqlDbType.Int, 4);
           prmCatId.Value = CATID;

           SqlParameter prmOrderBy = new SqlParameter("@OrderBy", SqlDbType.Int, 4);
           prmOrderBy.Value = OrderBy;

           SqlParameter prmSortBy = new SqlParameter("@SortBy", SqlDbType.Int, 4);
           prmSortBy.Value = SortBy;

           SqlParameter prmPageIndex = new SqlParameter("@PageIndex", SqlDbType.Int, 4);
           prmPageIndex.Value = PageIndex;

           SqlParameter prmPageSize = new SqlParameter("@PageSize", SqlDbType.Int, 4);
           prmPageSize.Value = PageSize;

           return DataAccess.GetFromReader("GetCategoryArticle", prmCatId, prmOrderBy, prmSortBy, prmPageIndex, prmPageSize);
       }

       /// <summary>
       /// Returns IDataReader Article Category
       /// </summary>
       public IDataReader GetArticleCategory(int CATID, int OrderBy)
       {
           SqlParameter prmCatId = new SqlParameter("@CATID", SqlDbType.Int, 4);
           prmCatId.Value = CATID;

           SqlParameter prmOrderBy = new SqlParameter("@OrderBy", SqlDbType.Int, 4);
           prmOrderBy.Value = OrderBy;

           return DataAccess.GetFromReader("CategoryPage_Article", prmCatId, prmOrderBy);
       }

       /// <summary>
       /// Returns article category name
       /// </summary>
       /// <returns></returns>
       public string GetArticleCategoryName(int CAT_ID)
       {
           SqlParameter prmCatID = new SqlParameter("@CAT_ID", SqlDbType.Int, 4);
           prmCatID.Value = CAT_ID;

           return DataAccess.GetString("GetArticleCategoryName", prmCatID);
       }

       /// <summary>
       /// Update article rating
       /// </summary>
       /// <returns></returns>
       public int AddArticleRating(int ID, int Rating)
       {
           SqlParameter prmID = new SqlParameter("@ID", SqlDbType.Int, 4);
           prmID.Value = ID;

           SqlParameter prmRating = new SqlParameter("@Rating", SqlDbType.Int, 4);
           prmRating.Value = Rating;

           return DataAccess.Execute("AddArticleRating", prmID, prmRating);
       }

       /// <summary>
       /// Insert article
       /// </summary>
       /// <returns></returns>
       public int AddArticle(string Title, string Content, string Author, int CAT_ID, string Keyword, string Summary)
       {
           SqlParameter prmTitle = new SqlParameter("@Title", SqlDbType.VarChar, 200);
           prmTitle.Value = Title;

           SqlParameter prmContent = new SqlParameter("@Content", SqlDbType.NText);
           prmContent.Value = Content;

           SqlParameter prmAuthor = new SqlParameter("@Author", SqlDbType.VarChar, 50);
           prmAuthor.Value = Author;

           SqlParameter prmCatID = new SqlParameter("@CAT_ID", SqlDbType.Int, 4);
           prmCatID.Value = CAT_ID;

           SqlParameter prmKeyword = new SqlParameter("@Keyword", SqlDbType.VarChar, 255);
           prmKeyword.Value = Keyword;

           SqlParameter prmSummary = new SqlParameter("@Summary", SqlDbType.NText);
           prmSummary.Value = Summary;

           return DataAccess.Execute("AdminAddCookingArticle", prmTitle, prmContent, prmAuthor, prmCatID, prmKeyword, prmSummary);

       }

       /// <summary>
       /// Update article
       /// </summary>
       /// <returns></returns>
       public int UpdateArticle(int ID, string Title, string Content, string Author, int CAT_ID, string Keyword, string Summary)
       {

           SqlParameter prmID = new SqlParameter("@AID", SqlDbType.Int, 4);
           prmID.Value = ID;

           SqlParameter prmTitle = new SqlParameter("@Title", SqlDbType.VarChar, 200);
           prmTitle.Value = Title;

           SqlParameter prmContent = new SqlParameter("@Content", SqlDbType.NText);
           prmContent.Value = Content;

           SqlParameter prmAuthor = new SqlParameter("@Author", SqlDbType.VarChar, 50);
           prmAuthor.Value = Author;

           SqlParameter prmCatID = new SqlParameter("@CAT_ID", SqlDbType.Int, 4);
           prmCatID.Value = CAT_ID;

           SqlParameter prmKeyword = new SqlParameter("@Keyword", SqlDbType.VarChar, 255);
           prmKeyword.Value = Keyword;

           SqlParameter prmSummary = new SqlParameter("@Summary", SqlDbType.NText);
           prmSummary.Value = Summary;

           return DataAccess.Execute("UpdateArticle", prmID, prmTitle, prmContent, prmAuthor, prmCatID, prmKeyword, prmSummary);

       }

       /// <summary>
       /// Finalize Insert article
       /// </summary>
       /// <returns></returns>
       public int FinalizeAddArticle(int ID)
       {
           SqlParameter prmID = new SqlParameter("@ID", SqlDbType.Int, 4);
           prmID.Value = ID;

           return DataAccess.Execute("FinalizeArticleSubmission", prmID);
       }

       /// <summary>
       /// Returns last submitted article ID
       /// </summary>
       /// <returns></returns>
       public IDataReader GetLastArticleID
       {
           get { return DataAccess.GetFromReader("GetLastArticleID"); }
       }

       /// <summary>
       /// Admin Recipe Manager Delete Recipe
       /// </summary>
       /// <returns></returns>
       public int AdminDeleteArticle(int ID)
       {
           SqlParameter prmID = new SqlParameter("@ID", SqlDbType.Int, 4);
           prmID.Value = ID;

           return DataAccess.Execute("ArticleDelete", prmID);
       }

       /// <summary>
       /// Returns article search result
       /// </summary>
        public IDataReader GetArticleSearchResult(string Search, int CatId, int OrderBy, int SortBy, int PageIndex, int PageSize)
       {
           SqlParameter prmSearch = new SqlParameter("@Search", SqlDbType.VarChar, 20);
           prmSearch.Value = Search;

           SqlParameter prmCatId = new SqlParameter("@CATID", SqlDbType.Int, 4);
           prmCatId.Value = CatId;

           SqlParameter prmOrderBy = new SqlParameter("@OrderBy", SqlDbType.Int, 4);
           prmOrderBy.Value = OrderBy;

           SqlParameter prmSortBy = new SqlParameter("@SortBy", SqlDbType.Int, 4);
           prmSortBy.Value = SortBy;

           SqlParameter prmPageIndex = new SqlParameter("@PageIndex", SqlDbType.Int, 4);
           prmPageIndex.Value = PageIndex;

           SqlParameter prmPageSize = new SqlParameter("@PageSize", SqlDbType.Int, 4);
           prmPageSize.Value = PageSize;

           return DataAccess.GetFromReader("GetArticleSearchResult", prmSearch, prmCatId, prmOrderBy, prmSortBy, prmPageIndex, prmPageSize);
       }

#endregion

#region Admin Recipe Manager return recipe, approve, update, delete and configuration
       /// <summary>
       /// Returns Admin Recipe Manager for Datagrid
       /// </summary>
       /// <returns></returns>
        public DataTable AdminRecipeManagerWithCustomPaging(int CAT_ID, string Letter, string Find, int Tab, int Top, int Year, int Month, int RecipeImage, int LastViewed, int PageIndex, int PageSize)
        {
            SqlParameter prmCatId = new SqlParameter("@CAT_ID", SqlDbType.Int, 4);
            prmCatId.Value = CAT_ID;

            SqlParameter prmLetter = new SqlParameter("@Letter", SqlDbType.VarChar, 10);
            prmLetter.Value = Letter;

            SqlParameter prmFind = new SqlParameter("@Find", SqlDbType.VarChar, 50);
            prmFind.Value = Find;

            SqlParameter prmTab = new SqlParameter("@Tab", SqlDbType.Int, 4);
            prmTab.Value = Tab;

            SqlParameter prmTop = new SqlParameter("@Top", SqlDbType.Int, 4);
            prmTop.Value = Top;

            SqlParameter prmYear = new SqlParameter("@Year", SqlDbType.Int, 4);
            prmYear.Value = Year;

            SqlParameter prmMonth = new SqlParameter("@Month", SqlDbType.Int, 4);
            prmMonth.Value = Month;

            SqlParameter prmRecipeImage = new SqlParameter("@RecipeImage", SqlDbType.Int, 4);
            prmRecipeImage.Value = RecipeImage;

            SqlParameter prmLastViewed = new SqlParameter("@LastViewed", SqlDbType.Int, 4);
            prmLastViewed.Value = LastViewed;

            SqlParameter prmPageIndex = new SqlParameter("@PageIndex", SqlDbType.Int, 4);
            prmPageIndex.Value = PageIndex;

            SqlParameter prmPageSize = new SqlParameter("@PageSize", SqlDbType.Int, 4);
            prmPageSize.Value = PageSize;

            return DataAccess.GetFromDataTable("AdminManagerGetRecipe", prmCatId, prmLetter, prmFind, prmTab, prmTop, prmYear, prmMonth, prmRecipeImage, prmLastViewed, prmPageIndex, prmPageSize);
        }

       /// <summary>
       /// Returns Datagrid Admin Recipe Manager
       /// </summary>
       /// <returns></returns>
       public IDataReader AdminRecipeManager(int CAT_ID, string Letter, string Find, int Tab, int Top, int Year, int Month)
       {
           SqlParameter prmCatId = new SqlParameter("@CAT_ID", SqlDbType.Int, 4);
           prmCatId.Value = CAT_ID;

           SqlParameter prmLetter = new SqlParameter("@Letter", SqlDbType.VarChar, 10);
           prmLetter.Value = Letter;

           SqlParameter prmFind = new SqlParameter("@Find", SqlDbType.VarChar, 50);
           prmFind.Value = Find;

           SqlParameter prmTab = new SqlParameter("@Tab", SqlDbType.Int, 4);
           prmTab.Value = Tab;

           SqlParameter prmTop = new SqlParameter("@Top", SqlDbType.Int, 4);
           prmTop.Value = Top;

           SqlParameter prmYear = new SqlParameter("@Year", SqlDbType.Int, 4);
           prmYear.Value = Year;

           SqlParameter prmMonth = new SqlParameter("@Month", SqlDbType.Int, 4);
           prmMonth.Value = Month;

           return DataAccess.GetFromReader("AdminManagerGetRecipe", prmCatId, prmLetter, prmFind, prmTab, prmTop, prmYear, prmMonth);
       }

       /// <summary>
       /// Returns admin recipe approval review.
       /// </summary>
       /// <returns></returns>
        public IDataReader AdminRecipeApprovalReview(int ID)
       {
           SqlParameter prmID = new SqlParameter("@ID", SqlDbType.Int, 4);
           prmID.Value = ID;

           return DataAccess.GetFromReader("AdminRecipeApprovalReview", prmID);
       }

       /// <summary>
       /// Returns admin recipe detail for update.
       /// </summary>
       /// <returns></returns>
        public IDataReader GetRecipeDetailForUpdate(int ID)
       {
           SqlParameter prmID = new SqlParameter("@ID", SqlDbType.Int, 4);
           prmID.Value = ID;

           return DataAccess.GetFromReader("GetRecipeDetailsForUpdate", prmID);
       }

       /// <summary>
       /// Returns admin username for session variable use
       /// </summary>
       /// <returns></returns>
       public string GetAdminUserNameSession(string Username)
       {
           SqlParameter prmUserName = new SqlParameter("@Username", SqlDbType.VarChar, 50);
           prmUserName.Value = Username;

           return DataAccess.GetString("GetAdminLoginCredential", prmUserName);
       }

       /// <summary>
       /// Admin Update Email Address and SMTP Server Address
       /// </summary>
       /// <returns></returns>
       public int AdminUpdateEmailAndSMTPAddress(string Email, string SMTP)
       {
           SqlParameter prmEmail = new SqlParameter("@Email", SqlDbType.VarChar, 100);
           prmEmail.Value = Email;

           SqlParameter prmSMTP = new SqlParameter("@SMTP", SqlDbType.VarChar, 50);
           prmSMTP.Value = SMTP;

           return DataAccess.Execute("AdminUpdateEmailAndSMTPAddress", prmEmail, prmSMTP);
       }

       /// <summary>
       /// Returns admin password for session variable use
       /// </summary>
       /// <returns></returns>
       public string GetAdminPasswordSession(string Password)
       {
           SqlParameter prmPass = new SqlParameter("@Password", SqlDbType.VarChar, 50);
           prmPass.Value = Password;

           return DataAccess.GetString("GetAdminPassword", prmPass);
       }

       /// <summary>
       /// Returns admin username for login session validation
       /// </summary>
       /// <returns></returns>
       public IDataReader AdminGetCredentialSessionValidation
       {
           get { return DataAccess.GetFromReader("AdminGetCredentialForsessionValidation"); }
       }

       /// <summary>
       /// Admin Recipe Manager Delete Recipe
       /// </summary>
       /// <returns></returns>
       public int AdminRecipeManagerDelete(int ID)
       {
           SqlParameter prmID = new SqlParameter("@ID", SqlDbType.Int, 4);
           prmID.Value = ID;

           return DataAccess.Execute("AdminManagerDeleteRecipe", prmID);
       }

       /// <summary>
       /// Approve Recipe
       /// </summary>
       /// <returns></returns>
       public int AdminApproveRecipe(int ID)
       {
           SqlParameter prmID = new SqlParameter("@ID", SqlDbType.Int, 4);
           prmID.Value = ID;

           return DataAccess.Execute("AdminApproveRecipe", prmID);
       }

       /// <summary>
       /// Update last viewed hour span
       /// </summary>
       /// <returns></returns>
       public int AdminUpdateLastViewedHours(int Minutes)
       {
           SqlParameter prmMinutes = new SqlParameter("@Minutes", SqlDbType.Int, 4);
           prmMinutes.Value = Minutes;

           return DataAccess.Execute("AdminUpdateLastViewedHours", prmMinutes);
       }

       /// <summary>
       /// Configure show hide comment
       /// </summary>
       /// <returns></returns>
       public int AdminUpdateShowHideComment(int Showhide)
       {
           SqlParameter prmShowhide = new SqlParameter("@Showhide", SqlDbType.Int, 4);
           prmShowhide.Value = Showhide;

           return DataAccess.Execute("AdminUpdateShowHideComment", prmShowhide);
       }

       /// <summary>
       /// Update Recipe
       /// </summary>
       /// <returns></returns>
        public int UpdateRecipe(int ID, string Name, string Author, int Cat_Id, string Ingredients, string Instructions, int Hits, string RecipeImage)
       {
           SqlParameter prmID = new SqlParameter("@ID", SqlDbType.Int, 4);
           prmID.Value = ID;

           SqlParameter prmName = new SqlParameter("@Name", SqlDbType.VarChar, 200);
           prmName.Value = Name;

           SqlParameter prmAuthor = new SqlParameter("@Author", SqlDbType.VarChar, 50);
           prmAuthor.Value = Author;

           SqlParameter prmCatId = new SqlParameter("@Cat_Id", SqlDbType.Int, 4);
           prmCatId.Value = Cat_Id;

           SqlParameter prmIngred = new SqlParameter("@Ingredients", SqlDbType.VarChar, 1000);
           prmIngred.Value = Ingredients;

           SqlParameter prmInstruc = new SqlParameter("@Instructions", SqlDbType.VarChar, 1000);
           prmInstruc.Value = Instructions;

           SqlParameter prmHits = new SqlParameter("@Hits", SqlDbType.Int, 8);
           prmHits.Value = Hits;

           SqlParameter prmRecipeImage = new SqlParameter("@RecipeImage", SqlDbType.VarChar, 50);
           prmRecipeImage.Value = RecipeImage;

           return DataAccess.Execute("UpdateRecipe", prmID, prmName, prmAuthor, prmCatId, prmIngred, prmInstruc, prmHits, prmRecipeImage);

       }
#endregion

#region Admin Update, Delete Recipe Comment
       /// <summary>
       /// Update Recipe Comment
       /// </summary>
       /// <returns></returns>
       public int UpdateRecipeComments(int ID, string Author, string Email, string Comment)
       {
           SqlParameter prmID = new SqlParameter("@ID", SqlDbType.Int, 4);
           prmID.Value = ID;

           SqlParameter prmAuthor = new SqlParameter("@Author", SqlDbType.VarChar, 50);
           prmAuthor.Value = Author;

           SqlParameter prmEmail = new SqlParameter("@Email", SqlDbType.VarChar, 100);
           prmEmail.Value = Email;

           SqlParameter prmComment = new SqlParameter("@Comment", SqlDbType.VarChar, 255);
           prmComment.Value = Comment;

           return DataAccess.Execute("UpdateRecipeComments", prmID, prmAuthor, prmEmail, prmComment);
       }

       /// <summary>
       /// Delete Recipe Comment
       /// </summary>
       /// <returns></returns>
       public int AdminDeleteRecipeComments(int COMID, int RecipeID)
       {
           SqlParameter prmCOMID = new SqlParameter("@COMID", SqlDbType.Int, 4);
           prmCOMID.Value = COMID;

           SqlParameter prmRecipeID = new SqlParameter("@RecipeID", SqlDbType.Int, 4);
           prmRecipeID.Value = RecipeID;

           return DataAccess.Execute("AdminDeleteRecipeComments", prmCOMID, prmRecipeID);
       }

#endregion

#region Admin Update, Delete Recipe Category
       /// <summary>
       /// Update Recipe Category
       /// </summary>
       /// <returns></returns>
        public int UpdateRecipeCategory(int CatId, string CatName)
       {
           SqlParameter prmCatId = new SqlParameter("@Catid", SqlDbType.Int, 4);
           prmCatId.Value = CatId;

           SqlParameter prmCatName = new SqlParameter("@CatName", SqlDbType.VarChar, 100);
           prmCatName.Value = CatName;

           return DataAccess.Execute("UpdateRecipeCategory", prmCatId, prmCatName);
       }

       /// <summary>
       /// Delete Recipe Category
       /// </summary>
       /// <returns></returns>
        public int AdminDeleteRecipeCategory(int CatId)
       {
           SqlParameter prmCatId = new SqlParameter("@Catid", SqlDbType.Int, 4);
           prmCatId.Value = CatId;

           return DataAccess.Execute("AdminDeleteRecipeCategory", prmCatId);
       }

       /// <summary>
       /// Add New Recipe Category
       /// </summary>
       /// <returns></returns>
        public int AdminAddNewRecipeCategory(string CatName, int Group)
       {
           SqlParameter prmCatName = new SqlParameter("@CatName", SqlDbType.VarChar, 100);
           prmCatName.Value = CatName;

           SqlParameter prmGroup = new SqlParameter("@Group", SqlDbType.Int, 4);
           prmGroup.Value = Group;

           return DataAccess.Execute("AdminAddNewRecipeCategory", prmCatName, prmGroup);
       }
#endregion

#region Admin Update, Delete Article Category
       /// <summary>
       /// Update Recipe Comment
       /// </summary>
       /// <returns></returns>
       public int UpdateArticleCategory(int CatId, string CatName)
       {
           SqlParameter prmCatId = new SqlParameter("@Catid", SqlDbType.Int, 4);
           prmCatId.Value = CatId;

           SqlParameter prmCatName = new SqlParameter("@CatName", SqlDbType.VarChar, 100);
           prmCatName.Value = CatName;

           return DataAccess.Execute("UpdateArticleCategory", prmCatId, prmCatName);
       }

       /// <summary>
       /// Delete Article Category
       /// </summary>
       /// <returns></returns>
       public int AdminDeleteArticleCategory(int CatId)
       {
           SqlParameter prmCatId = new SqlParameter("@Catid", SqlDbType.Int, 4);
           prmCatId.Value = CatId;

           return DataAccess.Execute("AdminDeleteArticleCategory", prmCatId);
       }

       /// <summary>
       /// Add New Article Category
       /// </summary>
       /// <returns></returns>
       public int AdminAddNewArticleCategory(string CatName)
       {
           SqlParameter prmCatName = new SqlParameter("@CatName", SqlDbType.VarChar, 100);
           prmCatName.Value = CatName;

           return DataAccess.Execute("AdminAddNewArticleCategory", prmCatName);
       }

#endregion

#region Admin Username and Password Validation
       /// <summary>
       /// Check whether admin user name exist in the admin user database.
       /// </summary>
       /// <param name="UserName">UserName</param>
       /// <returns></returns>
       public bool AdminUserNameExist(string UserName)
       {

           SqlParameter prmUserName = new SqlParameter("@Username", SqlDbType.VarChar, 50);
           prmUserName.Value = UserName;

           string UName = DataAccess.GetString("GetAdminuserName", prmUserName);

           if (UName != "")
               return true;
           else
               return false;
       }

       /// <summary>
       /// Check whether admin password exist in the admin user database.
       /// </summary>
       /// <returns></returns>
       public bool AdminPasswordExist(string Password)
       {

           SqlParameter prmPassword = new SqlParameter("@Password", SqlDbType.VarChar, 50);
           prmPassword.Value = Password;

           string UPass = DataAccess.GetString("GetAdminPassword", prmPassword);

           if (UPass != "")
               return true;
           else
               return false;
       }
#endregion

#region Front-end Add Recipe, Add Comment and Add Rating
       /// <summary>
       /// Insert recipe
       /// </summary>
       /// <returns></returns>
       public int AddRecipe(string Name, string Author, int CAT_ID, string Category, string Ingredients, string Instructions, string RecipeImage)
       {
           SqlParameter prmName = new SqlParameter("@Name", SqlDbType.VarChar, 50);
           prmName.Value = Name;

           SqlParameter prmAuthor = new SqlParameter("@Author", SqlDbType.VarChar, 50);
           prmAuthor.Value = Author;

           SqlParameter prmCatID = new SqlParameter("@Cat_Id", SqlDbType.Int, 4);
           prmCatID.Value = CAT_ID;

           SqlParameter prmCategory = new SqlParameter("@Category", SqlDbType.VarChar, 50);
           prmCategory.Value = Category;

           SqlParameter prmIngred = new SqlParameter("@Ingredients", SqlDbType.VarChar, 1000);
           prmIngred.Value = Ingredients;

           SqlParameter prmInstruct = new SqlParameter("@Instructions", SqlDbType.VarChar, 1000);
           prmInstruct.Value = Instructions;

           SqlParameter prmRecipeImage = new SqlParameter("@RecipeImage", SqlDbType.VarChar, 50);
           prmRecipeImage.Value = RecipeImage;

           return DataAccess.Execute("AddRecipe", prmName, prmAuthor, prmCatID, prmCategory, prmIngred, prmInstruct, prmRecipeImage);
       }

       /// <summary>
       /// Insert comments
       /// </summary>
       /// <returns></returns>
       public int AddComment(int ID, string Author, string Email, string Comments)
       {
           SqlParameter prmCommentID = new SqlParameter("@ID", SqlDbType.Int, 4);
           prmCommentID.Value = ID;

           SqlParameter prmAuthor = new SqlParameter("@Author", SqlDbType.VarChar, 50);
           prmAuthor.Value = Author;

           SqlParameter prmEmail = new SqlParameter("@Email", SqlDbType.VarChar, 50);
           prmEmail.Value = Email;

           SqlParameter prmComment = new SqlParameter("@Comments", SqlDbType.VarChar, 200);
           prmComment.Value = Comments;

           return DataAccess.Execute("AddComments", prmCommentID, prmAuthor, prmEmail, prmComment);

       }

       /// <summary>
       /// Insert rating
       /// </summary>
       /// <returns></returns>
       public int AddRating(int ID, int Rating)
       {
           SqlParameter prmID = new SqlParameter("@ID", SqlDbType.Int, 4);
           prmID.Value = ID;

           SqlParameter prmRating = new SqlParameter("@Rating", SqlDbType.VarChar, 50);
           prmRating.Value = Rating;

           return DataAccess.Execute("AddRating", prmID, prmRating);

       }
#endregion

   }
}