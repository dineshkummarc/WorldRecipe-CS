#region XD World Recipe V 2.8
// FileName: providerrecipeoftheday.cs
// Author: Dexter Zafra
// Date Created: 5/29/2008
// Website: www.ex-designz.net
#endregion
using System;
using System.Data;
using System.Text;
using BLL;
using Util;

namespace XDRecipe.Model.RecipeDay
{
    /// <summary>
    /// Objects in this class manages recipe of the day
    /// </summary>
    public sealed class RecipeoftheDay : Recipe
    {
        ///<summary>Default Constructor</summary>
        public RecipeoftheDay()
        {
        }

#region Initialize Database Field
        /// <summary>
        /// Get recipe name, author, date, hits, rating, ingredients, instructions and other field from the DB matching the Recipe ID provided.
        /// </summary>
        /// <param name="ID">Recipe ID</param>
        public override void fillup()
          {
              //Instantiate Action Stored Procedure object
              Blogic FetchData = new Blogic();

              try
              {
                  IDataReader dr = FetchData.GetHomepageRecipeoftheDay;

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
                  if (dr["Ingredients"] != DBNull.Value)
                  {
                      this._Ingredients = (string)dr["Ingredients"];
                  }
                  if (dr["Instructions"] != DBNull.Value)
                  {
                      this._Instructions = (string)dr["Instructions"];
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