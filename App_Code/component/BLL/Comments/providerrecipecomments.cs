#region XD World Recipe V 2.8
// FileName: providerrecipecomments.cs
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

namespace GetRecipeComments
{
    /// <summary>
    /// object in this class manages recipe comments object List collection
    /// </summary>
    public sealed class RecipeCommentProvider
    {
        /// <summary>
        /// Return Recipe Comment
        /// </summary>
        public static ExtendedCollection<Comment> GetComments(int ID)
        {
            //Instantiate Action Stored Procedure object
            Blogic FetchData = new Blogic();

            ExtendedCollection<Comment> GetComment = new ExtendedCollection<Comment>();

            IDataReader dr = FetchData.GetCommentsRecipeDetail(ID);

            while (dr.Read())
            {
                Comment item = new Comment();

                if (dr["AUTHOR"] != DBNull.Value)
                {
                    item.Author = (string)dr["AUTHOR"];
                }
                if (dr["EMAIL"] != DBNull.Value)
                {
                    item.Email = (string)dr["EMAIL"];
                }
                if (dr["DATE"] != DBNull.Value)
                {
                    item.Date = (DateTime)(dr["DATE"]);
                }
                if (dr["COMMENTS"] != DBNull.Value)
                {
                    item.Comments = (string)dr["COMMENTS"];
                }

                GetComment.Add(item);
            }

            dr.Close();

            return GetComment;

            FetchData = null;
        }
    }
}