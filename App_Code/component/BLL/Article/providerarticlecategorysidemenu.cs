#region XD World Recipe V 2.8
// FileName: providerarticlecategorysidemenu.cs
// Author: Dexter Zafra
// Date Created: 8/26/2008
// Website: www.ex-designz.net
#endregion
using System;
using System.Web;
using System.Data;
using XDRecipe.ExtendedCollections;
using XDRecipe.Model;
using CacheData;
using BLL;

namespace GetArticleCategorySideMenu
{
    /// <summary>
    /// object in this class manages article category side menu object List collection
    /// </summary>
    public class ArticleCategoryMenuProvider
    {
        /// <summary>
        /// Return Article Category
        /// </summary>
        public static ExtendedCollection<Article> GetArticle()
        {
            //Instantiate Action Stored Procedure object
            Blogic FetchData = new Blogic();

            ExtendedCollection<Article> GetArticles = new ExtendedCollection<Article>();

            string Key = "ArticleCategory_SideMenu";

            if (Caching.Cache[Key] != null)
            {
                GetArticles = (ExtendedCollection<Article>)Caching.Cache[Key];
            }
            else
            {
                IDataReader dr = FetchData.GetArticleCategoryList;

                while (dr.Read())
                {
                    Article item = new Article();

                    item.CatID = (int)dr["CAT_ID"];

                    if (dr["CAT_NAME"] != DBNull.Value)
                    {
                        item.Category = (string)dr["CAT_NAME"];
                    }
                    if (dr["REC_COUNT"] != DBNull.Value)
                    {
                        item.RecordCount = (int)(dr["REC_COUNT"]);
                    }

                    GetArticles.Add(item);

                    Caching.CahceData(Key, GetArticles);
                }

                dr.Close();
            }

            return GetArticles;

            FetchData = null;
        }
    }
}
