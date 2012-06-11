#region XD World Recipe V 2.8
// FileName: providerlastviewedrecipe.cs
// Author: Dexter Zafra
// Date Created: 7/15/2008
// Website: www.ex-designz.net
#endregion
using System;
using System.Data;
using XDRecipe.ExtendedCollections;
using XDRecipe.Model;
using BLL;

namespace LastViewedRecipe
{
    /// <summary>
    /// Objects in this class manages last viewed recipe
    /// </summary>
    public sealed class LastViewedRecipeProvider
    {
        /// <summary>
        /// Returns the number of hours
        /// </summary>
        public static int GetMinuteSpan
        {
            get
            {
                int MinuteSpan = 0;

                try
                {
                    IDataReader dr = GetData;

                    dr.Read();

                    //Get the Minutes/hours span
                    MinuteSpan = (int)dr["MinuteSpan"];

                    dr.Close();
                }
                catch
                {
                }

                return MinuteSpan;
            }
        }

        /// <summary>
        /// Return Last Viewed Recipe Data
        /// </summary>
        /// <returns></returns>
        public static IDataReader GetData
        {
            get
            {
                //Instantiate Action Stored Procedure object
                Blogic FetchData = new Blogic();

                //Get data
                IDataReader dr = FetchData.GetLastViewedRecipe;

                return dr;

                FetchData = null;
            }
        }

        public static ExtendedCollection<Recipe> GetLastViewedRecipe()
        {
            ExtendedCollection<Recipe> GetRecipe = new ExtendedCollection<Recipe>();

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
                    if (dr["Hits"] != DBNull.Value)
                    {
                        item.Hits = (int)(dr["Hits"]);
                    }
                    if (dr["Hours"] != DBNull.Value)
                    {
                        item.Hours = (int)(dr["Hours"]);
                    }
                    if (dr["Minutes"] != DBNull.Value)
                    {
                        item.Minutes = (int)(dr["Minutes"]);
                    }

                    GetRecipe.Add(item);
                }

                dr.Close();

            return GetRecipe;
        }
    }
}
