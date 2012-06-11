#region XD World Recipe V 2.8
// FileName: rating.cs
// Author: Dexter Zafra
// Date Created: 7/5/2008
// Website: www.ex-designz.net
#endregion
using System;
using System.Web.UI.WebControls;

namespace UserRating
{
    /// <summary>
    /// Objects in this class manages rating properties
    /// </summary>
    public class Rating
    {
        ///<summary>Default Constructor</summary>
        public Rating()
        {
        }
#region Class Variables
        /// <summary>What Page We are dealing</summary>
        protected int _WhatPageID;

        /// <summary>Item ID</summary>
        protected int _ID;

        /// <summary>Rating value</summary>
        protected int _RateVal;

        /// <summary>Cookie Value</summary>
        protected int _cookieValue;

        /// <summary>Cookie Compare Value</summary>
        protected int _cookieKey;

        protected PlaceHolder _placeholder;

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
        public int RateVal
        {
            get 
            {
                //Check whether the rating value is between 1 to 5, else assign a rating value of 5
                if (this._RateVal > 5 || this._RateVal == 0)
                    this._RateVal = 5;
                return _RateVal; 
            }
            set { _RateVal = value; }
        }
        public int cookieValue
        {
            get { return _cookieValue; }
            set { _cookieValue = value; }
        }
        public int cookieKey
        {
            get { return _cookieKey; }
            set { _cookieKey = value; }
        }
        public PlaceHolder placeholder
        {
            get { return _placeholder; }
            set { _placeholder = value; }
        }
#endregion

#region Boolean - Compare Cookie Value to the Item ID
        protected bool IsCookieValueAndKeyIDMatch
        {
            get
            {
                //Compare cookie value to an itemID. If it match, hide the rating star button
                if (cookieValue == cookieKey)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
#endregion
    }
}