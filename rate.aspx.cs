#region XD World Recipe V 2.8
// FileName: Rate.cs - handle rating for recipe and article
// Author: Dexter Zafra
// Date Created: 5/19/2008
// Website: www.ex-designz.net
#endregion
using System;
using AddUserRating;
using XDRecipe.UI;
using BLL;
using Util;

public partial class rate : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Instantiate object
        Utility Util = new Utility();

        //Initilaize rating variables
        int WhatPage = (int)Util.Val(Request.QueryString["wp"]); //Check what page to add the rating, either recipe or article.
        int ID = (int)Util.Val(Request.QueryString["id"]); //ID of the current item
        int RateValue = (int)Util.Val(Request.QueryString["rateval"]); //Rating value

        //Intantiate rating object
        Addrating Rating = new Addrating(WhatPage, ID, RateValue);

        Rating.Insert();

        //Release allocated memory
        Rating = null;
    }
}
