#region XD World Recipe V 2.8
// FileName: provideradminrecipecategory.cs
// Author: Dexter Zafra
// Date Created: 8/19/2008
// Website: www.ex-designz.net
#endregion
using System;
using System.Data;
using System.Data.SqlClient;
using XDRecipe.ExtendedCollections;
using XDRecipe.Model;
using BLL;

namespace GetAdminRecipeCategory
{
    /// <summary>
    /// object in this class manages admin recipe category object List collection
    /// </summary>
    public class AdminRecipeCategoryProvider
    {

        /// <summary>
        /// Return Recipe Category Data
        /// </summary>
        public static ExtendedCollection<Recipe> GetCategories()
        {
            //Instantiate Action Stored Procedure object
            Blogic FetchData = new Blogic();

            ExtendedCollection<Recipe> GetCategory = new ExtendedCollection<Recipe>();

            IDataReader dr = FetchData.AdminGetRecipeCategoryManager;

            while (dr.Read())
            {
                Recipe item = new Recipe();

                item.CatID = (int)dr["CAT_ID"];

                if (dr["CAT_TYPE"] != DBNull.Value)
                {
                    item.Category = (string)dr["CAT_TYPE"];
                }
                if (dr["GROUPCAT"] != DBNull.Value)
                {
                    item.Group = (string)dr["GROUPCAT"];
                }
                if (dr["REC_COUNT"] != DBNull.Value)
                {
                    item.RecordCount = (int)(dr["REC_COUNT"]);
                }

                GetCategory.Add(item);
            }

            dr.Close();

            return GetCategory;

            FetchData = null;
        }
    }
}
