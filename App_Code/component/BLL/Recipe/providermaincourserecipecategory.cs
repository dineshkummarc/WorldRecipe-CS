#region XD World Recipe V 2.8
// FileName: providermaincourserecipecategory.cs
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

namespace GetMainCourseRecipeCategory
{
    /// <summary>
    /// object in this class manages main course recipe category object List collection
    /// </summary>
    public class MainCourseRecipeCategoryProvider
    {
        /// <summary>
        /// Return Recipe Main Course Category
        /// </summary>
        /// <returns></returns>
        public static ExtendedCollection<Recipe> GetMainCourseCategory()
        {
            //Instantiate Action Stored Procedure object
            Blogic FetchData = new Blogic();

            ExtendedCollection<Recipe> GetRecipe = new ExtendedCollection<Recipe>();

            string Key = "MainCourse_RecipeCategory";
         
            if (Caching.Cache[Key] != null)
            {
                GetRecipe = (ExtendedCollection<Recipe>)Caching.Cache[Key];
            }
            else
            {
                IDataReader dr = FetchData.GetHomepageMainCourseCategory;

                while (dr.Read())
                {
                    Recipe item = new Recipe();

                    item.CatID = (int)dr["CAT_ID"];

                    if (dr["CAT_TYPE"] != DBNull.Value)
                    {
                        item.Category = (string)dr["CAT_TYPE"];
                    }
                    if (dr["REC_COUNT"] != DBNull.Value)
                    {
                        item.RecordCount = (int)(dr["REC_COUNT"]);
                    }

                    GetRecipe.Add(item);

                    Caching.CahceData(Key, GetRecipe);
                }

                dr.Close();
            }

            return GetRecipe;

            FetchData = null;
        }
    }
}