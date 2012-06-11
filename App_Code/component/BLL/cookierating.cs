#region XD World Recipe V 2.8
// FileName: cookierating.cs
// Author: Dexter Zafra
// Date Created: 7/5/2008
// Website: www.ex-designz.net
#endregion
using System;
using System.Web;
using System.Web.UI.WebControls;
using UserRating;
using ConstantVar;

namespace RatingCookie
{
    /// <summary>
    /// Objects in this class manages user rating cookie
    /// </summary>
    public sealed class CookieRating : Rating
    {

        ///<summary>Constructor</summary>
        public CookieRating(int WhatPageID, int ID, PlaceHolder ph)
        {
            this._WhatPageID = WhatPageID;
            this._ID = ID;
            this._placeholder = ph;
        }

#region Check User Rating Cookie Method
        /// <summary>
        /// Return user cookie rating
        /// </summary>
        public void GetUserCookieRating()
        {
            switch (WhatPageID)
            {
                case constant.intRecipe:
                    //If the user has rated this recipe, then get the cookie value and compare it to the recipe ID.
                    if (HttpContext.Current.Request.Cookies["XDWorldRecipeRatingCookie"] != null)
                    {
                        this._cookieValue = Convert.ToInt32(HttpContext.Current.Request.Cookies["XDWorldRecipeRatingCookie"].Value);
                        this._cookieKey = ID;

                        //Show/hide star rating button
                        ShowHideStarRatingButton();
                    }
                    break;

                case constant.intArticle:
                    //If the user has rated this article, then get the cookie value and compare it to the article ID.
                    if (HttpContext.Current.Request.Cookies["XDArticleRatingCookie"] != null)
                    {
                        this._cookieValue = Convert.ToInt32(HttpContext.Current.Request.Cookies["XDArticleRatingCookie"].Value);
                        this._cookieKey = ID;

                        //Show/hide star rating button
                        ShowHideStarRatingButton();
                    }
                    break;
            }
       }
#endregion

#region Show/Hide Star Rating Button
       /// <summary>
        /// //Handles show/hide star rating button.
        /// </summary>
        private void ShowHideStarRatingButton()
        {
            //Find control
            Panel Panel2 = (Panel)(placeholder.FindControl("Panel2"));

            //Compare cookie value to an itemID.
            //If the user has rated this item , then hide the star rating button.
            if (IsCookieValueAndKeyIDMatch)
            {
                Panel2.Visible = false;
            }
            else
            {
                Panel2.Visible = true;
            }
        }
#endregion
    }
}
