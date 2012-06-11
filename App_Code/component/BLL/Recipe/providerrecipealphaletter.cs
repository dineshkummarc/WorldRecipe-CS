#region XD World Recipe V 2.8
// FileName: providerrecipealphaletter.cs
// Author: Dexter Zafra
// Date Created: 8/19/2008
// Website: www.ex-designz.net
#endregion
using System;
using System.Data;
using XDRecipe.ExtendedCollections;
using XDRecipe.Model.RecipeProviderEntity;
using BLL;

namespace GetRecipeAlphabetLetter
{
    /// <summary>
    /// object in this class manages recipe category object List collection
    /// </summary>
    public class RecipeAlphaLetterProvider : recipeproviderentity
    {
        //Constructor
        public RecipeAlphaLetterProvider(string letter, int OrderBy, int SortBy, int PageIndex, int PageSize)
        {
            this._Letter = letter;
            this._OrderBy = OrderBy;
            this._SortBy = SortBy;
            this._Index = PageIndex;
            this._PageSize = PageSize;

            IDataReader dr = GetData;

            dr.Read();

            this._RecordCount = (int)dr["RCount"];

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
                IDataReader dr = FetchData.GetRecipeAlphaLetterWithPaging(Letter, OrderBy, SortBy, Index, PageSize);

                return dr;

                FetchData = null;
            }
        }

        public ExtendedCollection<recipeproviderentity> GetRecipeAlphabetLetter()
        {
            ExtendedCollection<recipeproviderentity> GetAlphaRecipe = new ExtendedCollection<recipeproviderentity>();

            IDataReader dr = GetData;

            while (dr.Read())
            {
                recipeproviderentity item = new recipeproviderentity();
                
                item.ID = (int)dr["ID"];

                item.CatID = (int)dr["CAT_ID"];

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

                GetAlphaRecipe.Add(item);
            }

            dr.Close();

            return GetAlphaRecipe;
        }
    }
}
