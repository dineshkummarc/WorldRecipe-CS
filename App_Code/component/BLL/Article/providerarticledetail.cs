#region XD World Recipe V 2.8
// FileName: providerarticledetail.cs
// Author: Dexter Zafra
// Date Created: 5/29/2008
// Website: www.ex-designz.net
#endregion
using System;
using System.Data;
using Util;
using BLL;
using ConstantVar;

namespace XDRecipe.Model.ArticleDetail
{
    /// <summary>
    /// Objects in this class manages return the article details
    /// </summary>
    public sealed class ArticleDetail : Article
    {
        ///<summary>Default Constructor</summary>
        public ArticleDetail()
        {
        }

#region Initialize Database Field
        /// <summary>
        /// Get article title, author, date, hits, rating and content from the DB matching the Article ID provided.
        /// </summary>
        public override void fillup()
        {
            //Instantiate Action Stored Procedure object
            Blogic FetchData = new Blogic();

            //Instantiate object
            Utility Util = new Utility();

            //Parameter 1 = we are dealing with the articledetail.aspx not the admin article update  which is 2.
            IDataReader dr = FetchData.GetArticleDetail(ID, WhatPageID);

            dr.Read();

            if (WhatPageID == constant.intArticleDetails) //Populate articledetail.aspx
                {
                    try
                    {
                        if (dr["Title"] != DBNull.Value)
                        {
                            this._Title = (string)dr["Title"];
                        }
                        if (dr["Author"] != DBNull.Value)
                        {
                            this._Author = (string)dr["Author"];
                        }
                        if (dr["No_Rates"] != DBNull.Value)
                        {
                            this._NoRates = dr["No_Rates"].ToString();
                        }
                        if (dr["HITS"] != DBNull.Value)
                        {
                            this._Hits = (int)dr["HITS"];
                        }
                        if (dr["Rates"] != DBNull.Value)
                        {
                            this._Rating = dr["Rates"].ToString();
                        }
                        if (dr["Content"] != DBNull.Value)
                        {
                            this._Content = (string)dr["Content"];
                        }
                        if (dr["CAT_NAME"] != DBNull.Value)
                        {
                            this._Category = (string)dr["CAT_NAME"];
                        }
                        if (dr["CAT_ID"] != DBNull.Value)
                        {
                            this._CatID = (int)dr["CAT_ID"];
                        }
                        if (dr["Post_Date"] != DBNull.Value)
                        {
                            this._Date = (DateTime)(dr["Post_Date"]);
                        }
                    }
                    catch
                    {
                        //Redirect to page not found.
                        //1 = pagenotfound.aspx
                        Util.PageRedirect(1);
                    }

                    return;
                }
                else if (WhatPageID == constant.intArticleAdminUpdate) //Populate Admin/updatearticle.aspx
                {
                    try
                    {
                        if (dr["Title"] != DBNull.Value)
                        {
                            this._Title = (string)dr["Title"];
                        }
                        if (dr["Author"] != DBNull.Value)
                        {
                            this._Author = (string)dr["Author"];
                        }
                        if (dr["CAT_NAME"] != DBNull.Value)
                        {
                            this._Category = (string)dr["CAT_NAME"];
                        }
                        if (dr["Content"] != DBNull.Value)
                        {
                            this._Content = (string)dr["Content"];
                        }
                        if (dr["Summary"] != DBNull.Value)
                        {
                            this._Summary = (string)dr["Summary"];
                        }
                        if (dr["Keyword"] != DBNull.Value)
                        {
                            this._Keyword = (string)dr["Keyword"];
                        }
                        if (dr["CAT_ID"] != DBNull.Value)
                        {
                            this._CatID = (int)dr["CAT_ID"];
                        }
                        if (dr["Post_Date"] != DBNull.Value)
                        {
                            this._Date = (DateTime)(dr["Post_Date"]);
                        }
                    }

                    catch
                    {
                        //Redirect to page not found.
                        //1 = pagenotfound.aspx
                        Util.PageRedirect(1);
                    }

                    return;
                }
                else if (WhatPageID == constant.intArticleAdminPreview) //Populate Admin/articlepreview.aspx
                {
                    try
                    {
                        if (dr["Title"] != DBNull.Value)
                        {
                            this._Title = (string)dr["Title"];
                        }
                        if (dr["Content"] != DBNull.Value)
                        {
                            this._Content = (string)dr["Content"];
                        }
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
                dr.Close();
                dr = null;
                FetchData = null;
                Util = null;
        }

#endregion
    }
}