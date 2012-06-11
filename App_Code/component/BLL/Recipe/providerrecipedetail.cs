#region XD World Recipe V 2.8
// FileName: providerrecipedetail.cs
// Author: Dexter Zafra
// Date Created: 5/29/2008
// Website: www.ex-designz.net
#endregion
using System;
using System.Data;
using BLL;
using Util;
using ConstantVar;

namespace XDRecipe.Model.RecipeDetail
{
    /// <summary>
    /// Objects in this class manages recipe detail, update and approval database field
    /// </summary>
    public sealed class RecipeDetails : Recipe
    {
        ///<summary>Default Constructor</summary>
        public RecipeDetails()
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

            //Instantiate object
            Utility Util = new Utility();

            /* The reason why we have to use a conditional statement is because we are dealing with 3 diffrent
             * stored procedures to return the data. Each sproc has its number of columns declared and diffrent where clauses.
             */

            if (WhatPageID == constant.intRecipeDetails) //Populate Recipedetail.aspx database fields
            {
                try
                {
                    IDataReader dr = FetchData.GetRecipeDetail(ID);

                    dr.Read();

                    if (dr["Name"] != DBNull.Value)
                    {
                        this._RecipeName = (string)dr["Name"];
                    }
                    if (dr["Author"] != DBNull.Value)
                    {
                        this._Author = (string)dr["Author"];
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
                    if (dr["Date"] != DBNull.Value)
                    {
                        this._Date = (DateTime)(dr["Date"]);
                    }
                    if (dr["TOTAL_COMMENTS"] != DBNull.Value)
                    {
                        this._CountComments = (int)dr["TOTAL_COMMENTS"];
                    }
                    if (dr["LINK_APPROVED"] != DBNull.Value)
                    {
                        this._Approved = (int)dr["LINK_APPROVED"];
                    }
                    if (dr["RecipeImage"] != DBNull.Value)
                    {
                        this._RecipeImage = (string)dr["RecipeImage"];
                    }

                    //Release allocated memory
                    dr.Close();
                    dr = null;
                }
                catch
                {
                    //Redirect to page not found.
                    //1 = pagenotfound.aspx
                    Util.PageRedirect(1);
                }

                return;
            }
            else if (WhatPageID == constant.intRecipeAdminViewing) //Populate Admin/viewing.aspx database fields
            {
                try
                {
                    IDataReader dr = FetchData.AdminRecipeApprovalReview(ID);

                    dr.Read();

                    if (dr["Name"] != DBNull.Value)
                    {
                        this._RecipeName = (string)dr["Name"];
                    }
                    if (dr["Author"] != DBNull.Value)
                    {
                        this._Author = (string)dr["Author"];
                    }
                    if (dr["HITS"] != DBNull.Value)
                    {
                        this._Hits = (int)dr["HITS"];
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
                    if (dr["Date"] != DBNull.Value)
                    {
                        this._Date = (DateTime)(dr["Date"]);
                    }
                    if (dr["LINK_APPROVED"] != DBNull.Value)
                    {
                        this._Approved = (int)dr["LINK_APPROVED"];
                    }
                    if (dr["HIT_DATE"] != DBNull.Value)
                    {
                        this._HitDate = (DateTime)dr["HIT_DATE"];
                    }

                    //Release allocated memory
                    dr.Close();
                    dr = null;
                }
                catch
                {
                    //Redirect to page not found.
                    //1 = pagenotfound.aspx
                    Util.PageRedirect(1);
                }

                return;
            }
            else if (WhatPageID == constant.intRecipeAdminEditing) //Populate Admin/editing.aspx database fields
            {
                try
                {
                    IDataReader dr = FetchData.GetRecipeDetailForUpdate(ID);

                    dr.Read();

                    if (dr["Name"] != DBNull.Value)
                    {
                        this._RecipeName = (string)dr["Name"];
                    }
                    if (dr["Author"] != DBNull.Value)
                    {
                        this._Author = (string)dr["Author"];
                    }
                    if (dr["HITS"] != DBNull.Value)
                    {
                        this._Hits = (int)dr["HITS"];
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
                catch
                {
                    //Redirect to page not found.
                    //1 = pagenotfound.aspx
                    Util.PageRedirect(1);
                }

                return;
            }

            //Release allocated memory
            FetchData = null;
            Util = null;
        }
        #endregion
    }
}