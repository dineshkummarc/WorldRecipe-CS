#region XD World Recipe V 2.8
// FileName: addrecipecomment.cs
// Author: Dexter Zafra
// Date Created: 6/30/2008
// Website: www.ex-designz.net
#endregion
using System;
using BLL;

namespace XDRecipe.Model.AddUpdateDeleteRecipeComment
{
    /// <summary>
    /// Objects in this class manage Add, update and delete recipe comment
    /// </summary>
    public class CommentInfo : Comment
    {
        //Instantiate Action Stored Procedure object
        Blogic ActionSP = new Blogic();

        /// <summary>
        /// Default Constructor
        /// </summary>
        public CommentInfo()
        {
        }

        /// <summary>
        /// Perform Insert to Database
        /// </summary>
        /// <returns></returns>
        public override int Add()
        {
            return ActionSP.AddComment(ID, Author, Email, Comments);
            ActionSP = null;
        }

        /// <summary>
        /// Perform Update
        /// </summary>
        /// <returns></returns>
        public override int Update()
        {
            return ActionSP.UpdateRecipeComments(ID, Author, Email, Comments);
            ActionSP = null;
        }

        /// <summary>
        /// Perform Delete
        /// </summary>
        /// <returns></returns>
        public override int Delete()
        {
            return ActionSP.AdminDeleteRecipeComments(ID, RECID);
            ActionSP = null;
        }
    }
}
