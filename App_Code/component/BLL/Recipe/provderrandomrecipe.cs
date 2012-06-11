#region XD World Recipe V 2.8
// FileName: providerrandomrecipe.cs
// Author: Dexter Zafra
// Date Created: 5/29/2008
// Website: www.ex-designz.net
#endregion
using System;
using System.Data;
using BLL;
using Util;

namespace XDRecipe.Model.RandomRecipe
{
    /// <summary>
    /// Objects in this class manages top right panel random recipe
    /// </summary>
    public sealed class RandomRecipe : Recipe
    {
        ///<summary>Default Constructor</summary>
        public RandomRecipe()
        {
        }

        #region Initialize Database Field
        /// <summary>
        /// Get recipe name, author, date, hits, rating, ingredients, instructions and other field from the DB matching the Recipe ID provided.
        /// </summary>
        public override void fillup()
        {
            //Instantiate Action Stored Procedure object
            Blogic FetchData = new Blogic();

            try
            {
                IDataReader dr = FetchData.GetRandomRecipeSideMenu(CatID);

                dr.Read();

                if (dr["ID"] != DBNull.Value)
                {
                    this._ID = (int)dr["ID"];
                }
                if (dr["Name"] != DBNull.Value)
                {
                    this._RecipeName = (string)dr["Name"];
                }
                if (dr["CAT_ID"] != DBNull.Value)
                {
                    this._CatID = (int)dr["CAT_ID"];
                }
                if (dr["NO_RATES"] != DBNull.Value)
                {
                    this._NoRates = dr["NO_RATES"].ToString();
                }
                if (dr["HITS"] != DBNull.Value)
                {
                    this._Hits = (int)dr["HITS"];
                }
                if (dr["Rates"] != DBNull.Value)
                {
                    this._Rating = dr["Rates"].ToString();
                }
                if (dr["Category"] != DBNull.Value)
                {
                    this._Category = (string)dr["Category"];
                }

                //Release allocated memory
                dr.Close();
                dr = null;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            FetchData = null;
        }
        #endregion
    }
}