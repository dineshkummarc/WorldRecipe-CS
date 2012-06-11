#region XD World Recipe V 2.8
// FileName: articleproviderentity.cs
// Author: Dexter Zafra
// Date Created: 8/23/2008
// Website: www.ex-designz.net
#endregion
using System;
using Model.Pager;

namespace XDRecipe.Model.ArticleProviderEntity
{
    /// <summary>
    /// Objects in this class manages article provider properties and fields
    /// </summary>
    public class articleproviderentity : pager
    {
        ///<summary>Default Constructor</summary>
        public articleproviderentity()
        {
        }

        #region Class Variables
        /// <summary>Article Title</summary>
        protected int _ID;

        /// <summary>Article Title</summary>
        protected string _Title;

        /// <summary>Author</summary>
        protected string _Author;

        /// <summary>No of Votes</summary>
        protected string _NoRates;

        /// <summary>No of Hits</summary>
        protected int _Hits;

        /// <summary>Rating</summary>
        protected string _Rating;

        /// <summary>Category</summary>
        protected string _Category;

        /// <summary>Summary</summary>
        protected string _Summary;

        /// <summary>Summary</summary>
        protected string _Keyword;

        /// <summary>Category ID</summary>
        protected int _CatID;

        /// <summary>Date</summary>
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
        public string Keyword
        {
            get { return _Keyword; }
            set { _Keyword = value; }
        }
        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }
        public string Author
        {
            get { return _Author; }
            set { _Author = value; }
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
        public string Summary
        {
            get { return _Summary; }
            set { _Summary = value; }
        }
        public int CatID
        {
            get { return _CatID; }
            set { _CatID = value; }
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

