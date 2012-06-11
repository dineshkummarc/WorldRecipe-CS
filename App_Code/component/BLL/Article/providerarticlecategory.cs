#region XD World Recipe V 2.8
// FileName: providerarticlecategory.cs
// Author: Dexter Zafra
// Date Created: 8/19/2008
// Website: www.ex-designz.net
#endregion
using System;
using System.Data;
using XDRecipe.Model.ArticleProviderEntity;
using XDRecipe.ExtendedCollections;
using BLL;

namespace GetArticleCategory
{
    /// <summary>
    /// object in this class manages recipe category object List collection
    /// </summary>
    public class ArticleCategoryProvider : articleproviderentity
    {
        //Constructor
        public ArticleCategoryProvider(int CatId, int OrderBy, int SortBy, int PageIndex, int PageSize)
        {
            this._CatID = CatId;
            this._OrderBy = OrderBy;
            this._SortBy = SortBy;
            this._Index = PageIndex;
            this._PageSize = PageSize;

            IDataReader dr = GetData;

            dr.Read();

            //Get the category name and record count
            this._Category = (string)dr["CAT_NAME"];
            this._RecordCount = (int)dr["RCount"];

            dr.Close();
        }

        /// <summary>
        /// Return Recipe Category Data
        /// </summary>
        private IDataReader GetData
        {
            get
            {
                //Instantiate Action Stored Procedure object
                Blogic FetchData = new Blogic();

                //Get data
                IDataReader dr = FetchData.GetArticlesInCategory(CatID, OrderBy, SortBy, Index, PageSize);

                return dr;

                FetchData = null;
            }
        }

        public ExtendedCollection<articleproviderentity> GetCategories()
        {
            ExtendedCollection<articleproviderentity> GetCategory = new ExtendedCollection<articleproviderentity>();

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

                GetCategory.Add(item);
            }

            dr.Close();

            return GetCategory;
        }
    }
}
