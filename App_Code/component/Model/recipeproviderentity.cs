#region XD World Recipe V 2.8
// FileName: recipeproviderentity.cs
// Author: Dexter Zafra
// Date Created: 8/20/2008
// Website: www.ex-designz.net
#endregion
using System;
using Model.Pager;

namespace XDRecipe.Model.RecipeProviderEntity
{
    /// <summary>
    /// Objects in this class manages recipe provider properties and fields
    /// </summary>
    public class recipeproviderentity : pager
    {
        ///<summary>Default Constructor</summary>
        public recipeproviderentity()
        {
        }

        #region Class Variables
        /// <summary>Recipe ID</summary>
        protected int _ID;

        /// <summary>Letter</summary>
        protected string _Letter;

        /// <summary>Search Keyword</summary>
        protected string _Keyword;

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

        /// <summary>Date of Submission</summary>
        protected DateTime _Date;

        /// <summary>Record Count</summary>
        protected int _RecordCount;

        protected int _OrderBy;

        protected int _SortBy;

        #endregion

        #region Properties - Get and Set Accessor
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        public string Letter
        {
            get { return _Letter; }
            set { _Letter = value; }
        }
        public string Keyword
        {
            get { return _Keyword; }
            set { _Keyword = value; }
        }
        public string RecipeName
        {
            get { return _RecipeName; }
            set { _RecipeName = value; }
        }
        public string Category
        {
            get { return _Category; }
            set { _Category = value; }
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
        public DateTime Date
        {
            get { return _Date; }
            set { _Date = value; }
        }
        public int RecordCount
        {
            get { return _RecordCount; }
            set { _RecordCount = value; }
        }
        public int OrderBy
        {
            get { return _OrderBy; }
            set { _OrderBy = value; }
        }
        public int SortBy
        {
            get { return _SortBy; }
            set { _SortBy = value; }
        }
        #endregion
    }
}
