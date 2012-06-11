#region XD World Recipe V 2.8
// FileName: providerrecipecategory.cs
// Author: Dexter Zafra
// Date Created: 8/19/2008
// Website: www.ex-designz.net
#endregion
using System;
using System.Data;
using XDRecipe.Model.RecipeProviderEntity;
using XDRecipe.ExtendedCollections;
using BLL;

namespace GetRecipeCategory
{
    /// <summary>
    /// object in this class manages recipe category object List collection
    /// </summary>
    public class RecipeCategoryProvider : recipeproviderentity
    {
        //Constructor
        public RecipeCategoryProvider(int CatId, int OrderBy, int SortBy, int PageIndex, int PageSize)
        {
            this._CatID = CatId;
            this._OrderBy = OrderBy;
            this._SortBy = SortBy;
            this._Index = PageIndex;
            this._PageSize = PageSize;

            IDataReader dr = GetData;

            dr.Read();

            //Get the category name and record count
            this._Category = (string)dr["Category"];
            this._RecordCount = (int)dr["RCount"];

            dr.Close();
        }

        /// <summary>
        /// Return Recipe Category Data
        /// </summary>
        /// <returns></returns>
        private IDataReader GetData
        {
            get
            {
                //Instantiate Action Stored Procedure object
                Blogic FetchData = new Blogic();

                //Get data
                IDataReader dr = FetchData.GetRecipeCategoryWithCustomPaging(CatID, OrderBy, SortBy, Index, PageSize);

                return dr;

                FetchData = null;
            }
        }

        public ExtendedCollection<recipeproviderentity> GetCategories()
        {
            ExtendedCollection<recipeproviderentity> GetCategory = new ExtendedCollection<recipeproviderentity>();

            IDataReader dr = GetData;

            while (dr.Read())
            {
                recipeproviderentity item = new recipeproviderentity();
                
                item.ID = (int)dr["ID"];

                if (dr["Name"] != DBNull.Value)
                {
                    item.RecipeName = (string)dr["Name"];
                }
                if (dr["Category"] != DBNull.Value)
                {
                    item.Category = (string)dr["Category"];
                }
                if (dr["Author"] != DBNull.Value)
                {
                    item.Author = (string)dr["Author"];
                }
                if (dr["Rates"] != DBNull.Value)
                {
                    item.Rating = dr["Rates"].ToString();
                }
                if (dr["NO_RATES"] != DBNull.Value)
                {
                    item.NoRates = dr["NO_RATES"].ToString();
                }
                if (dr["Date"] != DBNull.Value)
                {
                    item.Date = (DateTime)(dr["Date"]);
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
