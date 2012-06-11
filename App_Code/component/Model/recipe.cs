#region XD World Recipe V 2.8
// FileName: recipe.cs
// Author: Dexter Zafra
// Date Created: 6/30/2008
// Website: www.ex-designz.net
#endregion
using System;

namespace XDRecipe.Model
{
    /// <summary>
    /// Objects in this class manages recipe properties and fields
    /// </summary>
    // This class a generic recipe properties and fields use in recipedetail, admin update and admin review page
    public class Recipe : DBObj
    {
        ///<summary>Default Constructor</summary>
        public Recipe()
        {
        }

#region Class Variables
        /// <summary>What Page We are dealing</summary>
        protected int _WhatPageID;

        /// <summary>Recipe ID</summary>
        protected int _ID;

        /// <summary>Recipe Name</summary>
        protected string _RecipeName;

        /// <summary>Author</summary>
        protected string _Author;

        /// <summary>Category ID</summary>
        protected int _CatID;

        /// <summary>No of Votes</summary>
        protected string _NoRates;

        /// <summary>No of Hits</summary>
        protected int _Hits;

        /// <summary>Rating</summary>
        protected string _Rating;

        /// <summary>Category</summary>
        protected string _Category;

        /// <summary>Ingredients</summary>
        protected string _Ingredients;

        /// <summary>Instruction</summary>
        protected string _Instructions;

        /// <summary>Date of Submission</summary>
        protected DateTime _Date;

        ///<summary>Comment Count</summary>
        protected int _CountComments;

        ///<summary>Approved Flag</summary>
        protected int _Approved;

        /// <summary>Category Group ID</summary>
        protected int _CatGroupID;

        /// <summary>Record Count</summary>
        protected int _RecordCount;

        /// <summary>Category Type</summary>
        protected string _Group;

        protected int _Hours;

        protected int _Minutes;

        protected string _RecipeImage;

        protected DateTime _HitDate;

        protected int _Top;

        #endregion

#region Properties - Get and Set Accessor
        public int WhatPageID
        {
            get { return _WhatPageID; }
            set { _WhatPageID = value; }
        }
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        public string RecipeName
        {
            get { return _RecipeName; }
            set { _RecipeName = value; }
        }
        public string Author
        {
            get { return _Author; }
            set { _Author = value; }
        }
        public int CatID
        {
            get { return _CatID; }
            set { _CatID = value; }
        }

        public string NoRates
        {
            get { return _NoRates; }
            set { _NoRates = value; }
        }
        public int Hits
        {
            get { return _Hits; }
            set { _Hits = value; }
        }
        public string Rating
        {
            get { return _Rating; }
            set { _Rating = value; }
        }

        public string Category
        {
            get { return _Category; }
            set { _Category = value; }
        }
        public string Ingredients
        {
            get { return _Ingredients; }
            set { _Ingredients = value; }
        }
        public string Instructions
        {
            get { return _Instructions; }
            set { _Instructions = value; }
        }
        public DateTime Date
        {
            get { return _Date; }
            set { _Date = value; }
        }
        public int CountComments
        {
            get { return _CountComments; }
            set { _CountComments = value; }
        }
        public int Approved
        {
            get { return _Approved; }
            set { _Approved = value; }
        }
        public string RecipeImage
        {
            get { return _RecipeImage; }
            set { _RecipeImage = value; }
        }
        public DateTime HitDate
        {
            get { return _HitDate; }
            set { _HitDate = value; }
        }
        public int CatGroupID
        {
            get { return _CatGroupID; }
            set { _CatGroupID = value; }
        }
        public int RecordCount
        {
            get { return _RecordCount; }
            set { _RecordCount = value; }
        }
        public string Group
        {
            get { return _Group; }
            set { _Group = value; }
        }
        public int Hours
        {
            get { return _Hours; }
            set { _Hours = value; }
        }
        public int Minutes
        {
            get { return _Minutes; }
            set { _Minutes = value; }
        }
        public int Top
        {
            get { return _Top; }
            set { _Top = value; }
        }
        #endregion
    }
}
