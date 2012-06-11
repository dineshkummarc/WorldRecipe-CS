#region XD World Recipe V 2.8
// FileName: providerpopularrecipesidemenu.cs
// Author: Dexter Zafra
// Date Created: 8/26/2008
// Website: www.ex-designz.net
#endregion
using System;
using System.Data;
using XDRecipe.ExtendedCollections;
using XDRecipe.Model;
using CacheData;
using BLL;

namespace GetPopularRecipeSideMenu
{
    /// <summary>
    /// object in this class manages popular recipe sidemenu object List collection
    /// </summary>
    public class PopularRecipeSideMenuProvider : Recipe
    {
        //Constructor
        public PopularRecipeSideMenuProvider(int CatId, int Top)
        {
            if (CatId != null)
            {
                this._CatID = CatId;
            }

            this._Top = Top;
        }

        /// <summary>
        /// Returns Most Popular Recipes Side Menu
        /// </summary>
        public ExtendedCollection<Recipe> GetPopularRecipe()
        {
            //Instantiate Action Stored Procedure object
            Blogic FetchData = new Blogic();

            ExtendedCollection<Recipe> GetRecipe = new ExtendedCollection<Recipe>();

            string Key = "MostPopular_RecipesSideMenu_" + CatID.ToString();

            if (Caching.Cache[Key] != null)
            {
                GetRecipe = (ExtendedCollection<Recipe>)Caching.Cache[Key];
            }
            else
            {
                IDataReader dr = FetchData.GetMostpopularRecipesSideMenu(CatID, Top);

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
                    if (dr["HITS"] != DBNull.Value)
                    {
                        item.Hits = (int)dr["HITS"];
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
