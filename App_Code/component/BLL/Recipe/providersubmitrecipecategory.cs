#region XD World Recipe V 2.8
// FileName: providersubmitrecipecategory.cs
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

namespace GetSubmitRecipeCategory
{
    /// <summary>
    /// object in this class manages submission recipe category object List collection
    /// </summary>
    public class submitrecipecategoryprovider : Recipe
    {
        public submitrecipecategoryprovider()
        {
        }

        /// <summary>
        /// Return GetData
        /// </summary>
        /// <returns></returns>
        private IDataReader GetData
        {
            get
            {
                //Instantiate Action Stored Procedure object
                Blogic FetchData = new Blogic();

                //Get data
                IDataReader dr = FetchData.GetCategoryHomePage;

                return dr;

                FetchData = null;
            }
        }

        public ExtendedCollection<Recipe> GetSubmitCategory()
        {
            string Key = "Submission_RecipeCategory";

            ExtendedCollection<Recipe> GetRecipe = new ExtendedCollection<Recipe>();

            if (Caching.Cache[Key] != null)
            {
                GetRecipe = (ExtendedCollection<Recipe>)Caching.Cache[Key];
            }
            else
            {
                IDataReader dr = GetData;

                while (dr.Read())
                {
                    Recipe item = new Recipe();

                    item.CatID = (int)dr["CAT_ID"];

                    if (dr["CAT_TYPE"] != DBNull.Value)
                    {
                        item.Category = (string)dr["CAT_TYPE"];
                    }

                    GetRecipe.Add(item);

                    Caching.CahceData(Key, GetRecipe);
                }

                dr.Close();
            }

            return GetRecipe;
        }
    }
}