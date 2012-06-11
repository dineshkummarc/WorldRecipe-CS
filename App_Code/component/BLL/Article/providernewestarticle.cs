#region XD World Recipe V 2.8
// FileName: providernewestarticle.cs
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

namespace GetNewestArticle
{
    /// <summary>
    /// object in this class manages newst recipe side menu object List collection
    /// </summary>
    public class NewestArticleMenuProvider
    {
        /// <summary>
        /// Return Newest Recipe Side Panel
        /// </summary>
        public static ExtendedCollection<Article> GetArticle(int Top)
        {
            //Instantiate Action Stored Procedure object
            Blogic FetchData = new Blogic();

            ExtendedCollection<Article> GetArticles = new ExtendedCollection<Article>();

            string Key = "Newest_Articles";

            if (Caching.Cache[Key] != null)
            {
                GetArticles = (ExtendedCollection<Article>)Caching.Cache[Key];
            }
            else
            {
                IDataReader dr = FetchData.GetNewestArticleSidePanel(Top);

                while (dr.Read())
                {
                    Article item = new Article();

                    item.ID = (int)dr["ID"];

                    if (dr["Title"] != DBNull.Value)
                    {
                        item.Title = (string)dr["Title"];
                    }
                    if (dr["CAT_NAME"] != DBNull.Value)
                    {
                        item.Category = (string)dr["CAT_NAME"];
                    }
                    if (dr["Post_Date"] != DBNull.Value)
                    {
                        item.Date = (DateTime)(dr["Post_Date"]);
                    }
                    if (dr["HITS"] != DBNull.Value)
                    {
                        item.Hits = (int)dr["HITS"];
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
