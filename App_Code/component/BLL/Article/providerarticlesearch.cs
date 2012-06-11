#region XD World Recipe V 2.8
// FileName: providerarticlesearch.cs
// Author: Dexter Zafra
// Date Created: 8/22/2008
// Website: www.ex-designz.net
#endregion
using System;
using System.Data;
using XDRecipe.ExtendedCollections;
using XDRecipe.Model.ArticleProviderEntity;
using BLL;

namespace ArticleSearchResult
{
    /// <summary>
    /// object in this class manages recipe category object List collection
    /// </summary>
    public class ArticleSearchProvider : articleproviderentity
    {
        //Constructor
        public ArticleSearchProvider(string Keyword, int CatId, int OrderBy, int SortBy, int PageIndex, int PageSize)
        {
            this._CatID = CatId;
            this._Keyword = Keyword;
            this._OrderBy = OrderBy;
            this._SortBy = SortBy;
            this._Index = PageIndex;
            this._PageSize = PageSize;

            IDataReader dr = GetData;

            dr.Read();

            //Get category name and record count
            this._RecordCount = (int)dr["RCount"];
            this._Category = (string)dr["CAT_NAME"];

            dr.Close();
        }

        /// <summary>
        /// Return Data
        /// </summary>
        /// <returns></returns>
        private IDataReader GetData
        {
            get
            {
                //Instantiate Action Stored Procedure object
                Blogic FetchData = new Blogic();

                //Get data
                IDataReader dr = FetchData.GetArticleSearchResult(Keyword, CatID, OrderBy, SortBy, Index, PageSize);

                return dr;

                FetchData = null;
            }
        }

        public ExtendedCollection<articleproviderentity> GetArticleSearchResult()
        {
            ExtendedCollection<articleproviderentity> GetSearchArticle = new ExtendedCollection<articleproviderentity>();

            IDataReader dr = GetData;

            while (dr.Read())
            {
                articleproviderentity item = new articleproviderentity();

                item.ID = (int)dr["ID"];

                if (dr["Title"] != DBNull.Value)
                {
                    item.Title = (string)dr["Title"];
                }
                if (dr["CAT_NAME"] != DBNull.Value)
                {
                    item.Category = (string)dr["CAT_NAME"];
                }
                if (dr["Author"] != DBNull.Value)
                {
                    item.Author = (string)dr["Author"];
                }
                if (dr["Summary"] != DBNull.Value)
                {
                    item.Summary = (string)dr["Summary"];
                }
                if (dr["Rates"] != DBNull.Value)
                {
                    item.Rating = dr["Rates"].ToString();
                }
                if (dr["No_Rates"] != DBNull.Value)
                {
                    item.NoRates = dr["No_Rates"].ToString();
                }
                if (dr["Post_Date"] != DBNull.Value)
                {
                    item.Date = (DateTime)(dr["Post_Date"]);
                }
                if (dr["HITS"] != DBNull.Value)
                {
                    item.Hits = (int)dr["HITS"];
                }

                GetSearchArticle.Add(item);
            }

            dr.Close();

            return GetSearchArticle;
        }
    }
}
