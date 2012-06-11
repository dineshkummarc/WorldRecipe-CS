#region XD World Recipe V 2.8
// FileName: providernewestrecipesidemenu.cs
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

namespace GetNewestRecipeSideMenu
{
    /// <summary>
    /// object in this class manages newest recipe sidemenu object List collection
    /// </summary>
    public class NewestRecipeSideMenuProvider : Recipe
    {

        //Constructor
        public NewestRecipeSideMenuProvider(int CatId, int Top)
        {
            if (CatId != null)
            {
                this._CatID = CatId;
            }

            this._Top = Top;

            IDataReader dr = GetData;

            dr.Read();

            //Get the category name
            this._Category = (string)dr["Category"];

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
                IDataReader dr = FetchData.GetNewestRecipesSideMenu(CatID, Top);

                return dr;

                FetchData = null;
            }
        }

        public ExtendedCollection<Recipe> GetNewestRecipe()
        {
            string Key = "Newest_RecipesSideMenu_" + CatID.ToString();

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

                    item.ID = (int)dr["ID"];

                    if (dr["Name"] != DBNull.Value)
                    {
                        item.RecipeName = (string)dr["Name"];
                    }
                    if (dr["Category"] != DBNull.Value)
                    {
                        item.Category = (string)dr["Category"];
                    }
                    if (dr["Date"] != DBNull.Value)
                    {
                        item.Date = (DateTime)(dr["Date"]);
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
        }
    }
}
