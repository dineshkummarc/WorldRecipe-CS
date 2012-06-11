#region XD World Recipe V 2.8
// FileName: recipecomment.cs
// Author: Dexter Zafra
// Date Created: 5/29/2008
// Website: www.ex-designz.net
#endregion
using System;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;
using XDRecipe.Model;
using GetRecipeComments;
using BLL;

namespace RecipeComment
{
    /// <summary>
    /// Objects in this class manages get and show/hide recipe comments
    /// </summary>
    public sealed class RecipeComments : Comment
    {
        //Constructor
        public RecipeComments(int ID, Repeater RepeaterName, PlaceHolder Ph)
        {
            this._ID = ID;
            this._RepeaterName = RepeaterName;
            this._placeholder = Ph;
        }

#region Show/Hide Comment Method
        /// <summary>
     /// Show or hide recipe comment
    /// </summary>
    public override void fillup()
    {
        //Find control
        Panel Panel1 = (Panel)(placeholder.FindControl("Panel1"));
        Image CommentImg = (Image)(placeholder.FindControl("CommentImg"));
        HyperLink CommentLink = (HyperLink)(placeholder.FindControl("CommentLink"));

        //Instantiate Action Stored Procedure object
        Blogic FetchData = new Blogic();

        try
        {
            IDataReader dr = FetchData.GetConfiguration;

            dr.Read();

            //Show hide comment 
            if (dr["HideShowComment"] != DBNull.Value)
            {
                this._ShowHideComment = (int)dr["HideShowComment"];
            }

            dr.Close();
            dr = null;

            if (IsShowHideComment)
            {
                //If true, display recipe comments, else hide.
                //Get datasourse
                RepeaterName.DataSource = RecipeCommentProvider.GetComments(ID);
                RepeaterName.DataBind();
                Panel1.Visible = true;
            }
            else
            {
                Panel1.Visible = false;
                CommentImg.Visible = false;
                CommentLink.Visible = false;
            }
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