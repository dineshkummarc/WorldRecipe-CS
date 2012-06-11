#region XD World Recipe V 2.8
// FileName: providerrelatedrecipe.cs
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

namespace GetRelatedRecipe
{
    /// <summary>
    /// object in this class manages related recipe object List collection
    /// </summary>
    public sealed class RelatedRecipeProvider : Recipe
    {
        /// <summary>
        /// Return GetData
        /// </summary>
        /// <returns></returns>
        private static IDataReader GetData(int CatId)
        {
            //Instantiate Action Stored Procedure object
            Blogic FetchData = new Blogic();

            //Get data
            IDataReader dr = FetchData.GetRelatedRecipe(CatId);

            return dr;

            FetchData = null;
        }

        public static ExtendedCollection<Recipe> GetRelatedRecipes(int CatId)
        {
            ExtendedCollection<Recipe> GetRecipe = new ExtendedCollection<Recipe>();

            IDataReader dr = GetData(CatId);

            while (dr.Read())
            {
                Recipe item = new Recipe();

                item.ID = (int)dr["ID"];

                if (dr["Name"] != DBNull.Value)
                {
                    item.RecipeName = (string)dr["Name"];
                }
                if (dr["Category"] != DBNull.Value)
                {
                    item.Category = (string)dr["Category"];
                }
                if (dr["Hits"] != DBNull.Value)
                {
                    item.Hits = (int)(dr["Hits"]);
                }

                GetRecipe.Add(item);
            }

            dr.Close();

            return GetRecipe;
        }
    }
}