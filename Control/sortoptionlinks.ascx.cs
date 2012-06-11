#region XD World Recipe V 2.8
// FileName: sortoptionlinks.ascx.cs
// Author: Dexter Zafra
// Date Created: 5/25/2008
// Website: www.ex-designz.net
#endregion
using System;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Util;

public partial class sortoptionlinks : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
            //Instantiate validation
            Utility Util = new Utility();

            int OrderBy, Sort_By, iPage, Layout;
            OrderBy = (int)Util.Val(Request.QueryString["ob"]);
            Sort_By = (int)Util.Val(Request.QueryString["sb"]);

            if (string.IsNullOrEmpty(this.Request.QueryString["page"]))
            {
                iPage = 1; //If request pageindex is empty, assign pageindex of 1 = 1st page
            }
            else
            {
                iPage = (int)Util.Val(Request.QueryString["page"]); //Grab the querystring pageindex value
            }

            if (string.IsNullOrEmpty(this.Request.QueryString["layout"]))
            {
                Layout = 1; 
            }
            else
            {
                Layout = (int)Util.Val(Request.QueryString["layout"]);
            }

         #region Sort option links for category.aspx
            //Handles the sort option links for the category.aspx
            if (!string.IsNullOrEmpty(Request.QueryString["catid"]))
            {            
                int CatId;              

                CatId = (int)Util.Val(Request.QueryString["catid"]);

                // Here we check what field are we going to sort, this depends on the sort value
                if (OrderBy == 1)
                {
                    LinkMostPopular.NavigateUrl = "~/category.aspx?catid=" + CatId + "&ob=" + OrderBy + "&sb=2&page=" + iPage + "&layout=" + Layout;
                    LinkMostPopular.Text = "Most Popular";
                    LinkMostPopular.ToolTip = "Sort category by Most Popular ASC Order";
                    ArrowImage1.ImageUrl = Util.SortOptionArrowImage;
                    ArrowImage1.Visible = true;

                    if (Sort_By == 2)
                    {
                        LinkMostPopular.NavigateUrl = "~/category.aspx?catid=" + CatId + "&ob=" + OrderBy + "&sb=1&page=" + iPage + "&layout=" + Layout;
                        LinkMostPopular.Text = "Most Popular";
                        LinkMostPopular.ToolTip = "Sort category by Most Popular DESC Order";
                        ArrowImage1.ImageUrl = Util.SortOptionArrowUpImage;
                        ArrowImage1.Visible = true;
                    }
                }
                else
                {
                    LinkMostPopular.NavigateUrl = "~/category.aspx?catid=" + CatId + "&ob=1" + "&sb=" + Sort_By + "&page=" + iPage + "&layout=" + Layout;
                    LinkMostPopular.Text = "Most Popular";
                    LinkMostPopular.ToolTip = "Sort category by Most Popular";
                    ArrowImage1.Visible = false;
                }

                if (OrderBy == 2)
                {
                    LinkHighestRated.NavigateUrl = "~/category.aspx?catid=" + CatId + "&ob=" + OrderBy + "&sb=2&page=" + iPage + "&layout=" + Layout;
                    LinkHighestRated.Text = "Highest Rated";
                    LinkHighestRated.ToolTip = "Sort category by highest rated ASC order";
                    ArrowImage2.ImageUrl = Util.SortOptionArrowImage;
                    ArrowImage2.Visible = true;

                    if (Sort_By == 2)
                    {
                        LinkHighestRated.NavigateUrl = "~/category.aspx?catid=" + CatId + "&ob=" + OrderBy + "&sb=1&page=" + iPage + "&layout=" + Layout;
                        LinkHighestRated.Text = "Highest Rated";
                        LinkHighestRated.ToolTip = "Sort category by highest rated DESC order";
                        ArrowImage2.ImageUrl = Util.SortOptionArrowUpImage;
                        ArrowImage2.Visible = true;
                    }
                }
                else
                {
                    LinkHighestRated.NavigateUrl = "~/category.aspx?catid=" + CatId + "&ob=2" + "&sb=" + Sort_By + "&page=" + iPage + "&layout=" + Layout;
                    LinkHighestRated.Text = "Highest Rated";
                    LinkHighestRated.ToolTip = "Sort category by highest rated";
                    ArrowImage2.Visible = false;
                }

                if (OrderBy == 3)
                {
                    LinkName.NavigateUrl = "~/category.aspx?catid=" + CatId + "&ob=" + OrderBy + "&sb=1&page=" + iPage + "&layout=" + Layout;
                    LinkName.Text = "Name";
                    LinkName.ToolTip = "Sort recipe by name DESC order";
                    ArrowImage3.ImageUrl = Util.SortOptionArrowImage;
                    ArrowImage3.Visible = true;

                    if (Sort_By == 1)
                    {
                        LinkName.NavigateUrl = "~/category.aspx?catid=" + CatId + "&ob=" + OrderBy + "&sb=2&page=" + iPage + "&layout=" + Layout;
                        LinkName.Text = "Name";
                        LinkName.ToolTip = "Sort recipe by name ASC order";
                        ArrowImage3.ImageUrl = Util.SortOptionArrowUpImage;
                        ArrowImage3.Visible = true;
                    }
                }
                else
                {
                    LinkName.NavigateUrl = "~/category.aspx?catid=" + CatId + "&ob=3" + "&sb=" + Sort_By + "&page=" + iPage + "&layout=" + Layout;
                    LinkName.Text = "Name";
                    LinkName.ToolTip = "Sort category by name";
                    ArrowImage3.Visible = false;
                }

                if (OrderBy == 4)
                {
                    LinkNewest.NavigateUrl = "~/category.aspx?catid=" + CatId + "&ob=" + OrderBy + "&sb=2&page=" + iPage + "&layout=" + Layout;
                    LinkNewest.Text = "Newest";
                    LinkNewest.ToolTip = "Sort category by newest recipes ASC order";
                    ArrowImage4.ImageUrl = Util.SortOptionArrowImage;
                    ArrowImage4.Visible = true;

                    if (Sort_By == 2)
                    {
                        LinkNewest.NavigateUrl = "~/category.aspx?catid=" + CatId + "&ob=" + OrderBy + "&sb=1&page=" + iPage + "&layout=" + Layout;
                        LinkNewest.Text = "Newest";
                        LinkNewest.ToolTip = "Sort category by newest recipes DESC order";
                        ArrowImage4.ImageUrl = Util.SortOptionArrowUpImage;
                        ArrowImage4.Visible = true;
                    }
                }
                else
                {
                    LinkNewest.NavigateUrl = "~/category.aspx?catid=" + CatId + "&ob=4&sb=" + Sort_By + "&page=" + iPage + "&layout=" + Layout;
                    LinkNewest.Text = "Newest";
                    LinkNewest.ToolTip = "Sort category by newest recipes";
                    ArrowImage4.Visible = false;

                }
            }
          #endregion

         #region Sort option links for sort.aspx - most popular
            //Handles the sort option links for the sort.aspx
            if (!string.IsNullOrEmpty(Request.QueryString["sid"]))
            {
                int SortBy, SBy;

                SortBy = (int)Util.Val(Request.QueryString["sid"]);
                SBy = (int)Util.Val(Request.QueryString["sb"]);

                // Here we check what field are we going to sort, this depends the sort value
                if (SortBy == 1)
                {
                    LinkMostPopular.NavigateUrl = "~/sort.aspx?sid=" + SortBy + "&sb=2&page=" + iPage + "&layout=" + Layout;
                    LinkMostPopular.Text = "Most Popular";
                    LinkMostPopular.ToolTip = "Sort by 60 Most Popular ASC order";
                    ArrowImage1.ImageUrl = Util.SortOptionArrowImage;
                    ArrowImage1.Visible = true;

                    if (SBy == 2)
                    {
                        LinkMostPopular.NavigateUrl = "~/sort.aspx?sid=" + SortBy + "&sb=1&page=" + iPage + "&layout=" + Layout;
                        LinkMostPopular.Text = "Most Popular";
                        LinkMostPopular.ToolTip = "Sort by 60 Most Popular DESC order";
                        ArrowImage1.ImageUrl = Util.SortOptionArrowUpImage;
                        ArrowImage1.Visible = true;
                    }
                }
                else
                {
                    LinkMostPopular.NavigateUrl = "~/sort.aspx?sid=1&sb=" + SBy + "&page=" + iPage + "&layout=" + Layout;
                    LinkMostPopular.Text = "Most Popular";
                    LinkMostPopular.ToolTip = "Sort by 60 Most Popular";
                    ArrowImage1.Visible = false;
                }

                if (SortBy == 2)
                {
                    LinkHighestRated.NavigateUrl = "~/sort.aspx?sid=" + SortBy + "&sb=2&page=" + iPage + "&layout=" + Layout;
                    LinkHighestRated.Text = "Highest Rated";
                    LinkHighestRated.ToolTip = "Sort by 60 Highest Rated Recipes ASC order";
                    ArrowImage2.ImageUrl = Util.SortOptionArrowImage;
                    ArrowImage2.Visible = true;

                    if (SBy == 2)
                    {
                        LinkHighestRated.NavigateUrl = "~/sort.aspx?sid=" + SortBy + "&sb=1&page=" + iPage + "&layout=" + Layout;
                        LinkHighestRated.Text = "Highest Rated";
                        LinkHighestRated.ToolTip = "Sort by 60 Highest Rated Recipes DESC order";
                        ArrowImage2.ImageUrl = Util.SortOptionArrowUpImage;
                        ArrowImage2.Visible = true;
                    }
                }
                else
                {
                    LinkHighestRated.NavigateUrl = "~/sort.aspx?sid=2&sb=" + SBy + "&page=" + iPage + "&layout=" + Layout;
                    LinkHighestRated.Text = "Highest Rated";
                    LinkHighestRated.ToolTip = "Sort by 60 Highest Rated";
                    ArrowImage2.Visible = false;
                }
                if (SortBy == 3)
                {
                    LinkName.NavigateUrl = "~/sort.aspx?sid=" + SortBy + "&sb=1&page=" + iPage + "&layout=" + Layout;
                    LinkName.Text = "Name";
                    LinkName.ToolTip = "Sort by name DESC order";
                    ArrowImage3.ImageUrl = Util.SortOptionArrowImage;
                    ArrowImage3.Visible = true;

                    if (SBy == 1)
                    {
                        LinkName.NavigateUrl = "~/sort.aspx?sid=" + SortBy + "&sb=2&page=" + iPage + "&layout=" + Layout;
                        LinkName.Text = "Name";
                        LinkName.ToolTip = "Sort by name ASC order";
                        ArrowImage3.ImageUrl = Util.SortOptionArrowUpImage;
                        ArrowImage3.Visible = true;
                    }
                }
                else
                {
                    LinkName.NavigateUrl = "~/sort.aspx?sid=3&sb=" + SBy + "&page=" + iPage + "&layout=" + Layout;
                    LinkName.Text = "Name";
                    LinkName.ToolTip = "Sort by name";
                    ArrowImage3.Visible = false;
                }
                if (SortBy == 4)
                {
                    LinkNewest.NavigateUrl = "~/sort.aspx?sid=" + SortBy + "&sb=2&page=" + iPage + "&layout=" + Layout;
                    LinkNewest.Text = "Newest";
                    LinkNewest.ToolTip = "Sort by 60 Newest Recipes ASC order";
                    ArrowImage4.ImageUrl = Util.SortOptionArrowImage;
                    ArrowImage4.Visible = true;

                    if (SBy == 2)
                    {
                        LinkNewest.NavigateUrl = "~/sort.aspx?sid=" + SortBy + "&sb=1&page=" + iPage + "&layout=" + Layout;
                        LinkNewest.Text = "Newest";
                        LinkNewest.ToolTip = "Sort by 60 Newest Recipes DESC order";
                        ArrowImage4.ImageUrl = Util.SortOptionArrowUpImage;
                        ArrowImage4.Visible = true;
                    }
                }
                else
                {
                    LinkNewest.NavigateUrl = "~/sort.aspx?sid=4&sb=" + SBy + "&page=" + iPage + "&layout=" + Layout;
                    LinkNewest.Text = "Newest";
                    LinkNewest.ToolTip = "Sort by 60 Newest Recipes";
                    ArrowImage4.Visible = false;

                }
            }
            #endregion

         #region Sort option links for recipename.aspx
            //Handles the sort option links for the recipename.aspx
            if (!string.IsNullOrEmpty(Request.QueryString["letter"]))
            {
                string letter;
                int Sby = (int)Util.Val(Request.QueryString["sb"]);

                letter = Request.QueryString["letter"].ToString();

                // Here we check what field are we going to sort, this depends the sort value
                if (OrderBy == 1)
                {
                    LinkMostPopular.NavigateUrl = "~/recipename.aspx?letter=" + letter + "&ob=" + OrderBy + "&sb=2&page=" + iPage + "&layout=" + Layout;
                    LinkMostPopular.Text = "Most Popular";
                    LinkMostPopular.ToolTip = "Sort by Most Popular ASC order";
                    ArrowImage1.ImageUrl = Util.SortOptionArrowImage;
                    ArrowImage1.Visible = true;

                    if (Sby == 2)
                    {
                        LinkMostPopular.NavigateUrl = "~/recipename.aspx?letter=" + letter + "&ob=" + OrderBy + "&sb=1&page=" + iPage + "&layout=" + Layout;
                        LinkMostPopular.Text = "Most Popular";
                        LinkMostPopular.ToolTip = "Sort by Most Popular DESC order";
                        ArrowImage1.ImageUrl = Util.SortOptionArrowUpImage;
                        ArrowImage1.Visible = true;
                    }
                }
                else
                {
                    LinkMostPopular.NavigateUrl = "~/recipename.aspx?letter=" + letter + "&ob=1&sb=" + Sby + "&page=" + iPage + "&layout=" + Layout;
                    LinkMostPopular.Text = "Most Popular";
                    LinkMostPopular.ToolTip = "Sort by Most Popular";
                    ArrowImage1.Visible = false;
                }

                if (OrderBy == 2)
                {
                    LinkHighestRated.NavigateUrl = "~/recipename.aspx?letter=" + letter + "&ob=" + OrderBy + "&sb=2&page=" + iPage + "&layout=" + Layout;
                    LinkHighestRated.Text = "Highest Rated";
                    LinkHighestRated.ToolTip = "Sort by highest rated ASC order";
                    ArrowImage2.ImageUrl = Util.SortOptionArrowImage;
                    ArrowImage2.Visible = true;

                    if (Sby == 2)
                    {
                        LinkHighestRated.NavigateUrl = "~/recipename.aspx?letter=" + letter + "&ob=" + OrderBy + "&sb=1&page=" + iPage + "&layout=" + Layout;
                        LinkHighestRated.Text = "Highest Rated";
                        LinkHighestRated.ToolTip = "Sort by highest rated DESC order";
                        ArrowImage2.ImageUrl = Util.SortOptionArrowUpImage;
                        ArrowImage2.Visible = true;
                    }
                }
                else
                {
                    LinkHighestRated.NavigateUrl = "~/recipename.aspx?letter=" + letter + "&ob=2&sb=" + Sby + "&page=" + iPage + "&layout=" + Layout;
                    LinkHighestRated.Text = "Highest Rated";
                    LinkHighestRated.ToolTip = "Sort by highest rated";
                    ArrowImage2.Visible = false;
                }
                if (OrderBy == 3)
                {
                    LinkName.NavigateUrl = "~/recipename.aspx?letter=" + letter + "&ob=" + OrderBy + "&sb=1&page=" + iPage + "&layout=" + Layout;
                    LinkName.Text = "Name";
                    LinkName.ToolTip = "Sort by name DESC order";
                    ArrowImage3.ImageUrl = Util.SortOptionArrowImage;
                    ArrowImage3.Visible = true;

                    if (Sby == 1)
                    {
                        LinkName.NavigateUrl = "~/recipename.aspx?letter=" + letter + "&ob=" + OrderBy + "&sb=2&page=" + iPage + "&layout=" + Layout;
                        LinkName.Text = "Name";
                        LinkName.ToolTip = "Sort by name ASC order";
                        ArrowImage3.ImageUrl = Util.SortOptionArrowUpImage;
                        ArrowImage3.Visible = true;
                    }
                }
                else
                {
                    LinkName.NavigateUrl = "~/recipename.aspx?letter=" + letter + "&ob=3&sb=" + Sby + "&page=" + iPage + "&layout=" + Layout;
                    LinkName.Text = "Name";
                    LinkName.ToolTip = "Sort by name";
                    ArrowImage3.Visible = false;
                }
                if (OrderBy == 4)
                {
                    LinkNewest.NavigateUrl = "~/recipename.aspx?letter=" + letter + "&ob=" + OrderBy + "&sb=2&page=" + iPage + "&layout=" + Layout;
                    LinkNewest.Text = "Newest";
                    LinkNewest.ToolTip = "Sort by newest recipes ASC order";
                    ArrowImage4.ImageUrl = Util.SortOptionArrowImage;
                    ArrowImage4.Visible = true;

                    if (Sby == 2)
                    {
                        LinkNewest.NavigateUrl = "~/recipename.aspx?letter=" + letter + "&ob=" + OrderBy + "&sb=1&page=" + iPage + "&layout=" + Layout;
                        LinkNewest.Text = "Newest";
                        LinkNewest.ToolTip = "Sort by newest recipes DESC order";
                        ArrowImage4.ImageUrl = Util.SortOptionArrowUpImage;
                        ArrowImage4.Visible = true;
                    }
                }
                else
                {
                    LinkNewest.NavigateUrl = "~/recipename.aspx?letter=" + letter + "&ob=4&sb=" + Sby + "&page=" + iPage + "&layout=" + Layout;
                    LinkNewest.Text = "Newest";
                    LinkNewest.ToolTip = "Sort by newest recipes";
                    ArrowImage4.Visible = false;

                }
            }
            #endregion

         #region Sort option links for search.aspx
         //Handles the sort option links for the search.aspx
         if (!string.IsNullOrEmpty(Request.QueryString["find"]))
         {
             int CatId; 
             string strKeyword;

            CatId = (int)Util.Val(Request.QueryString["catid"]);
            strKeyword = Request.QueryString["find"].ToString();

        // Here we check what field are we going to sort, this depends the sort value
        if (OrderBy == 1)
        {
            LinkMostPopular.NavigateUrl = "~/searchrecipe.aspx?find=" + strKeyword + "&catid=" + CatId + "&ob=" + OrderBy;
            LinkMostPopular.Text = "Most Popular";
            LinkMostPopular.ToolTip = "Sort by Most Popular";
            ArrowImage1.ImageUrl = Util.SortOptionArrowImage;
            ArrowImage1.Visible = true;
        }
        else
        {
            LinkMostPopular.NavigateUrl = "~/searchrecipe.aspx?find=" + strKeyword + "&catid=" + CatId + "&ob=1";
            LinkMostPopular.Text = "Most Popular";
            LinkMostPopular.ToolTip = "Sort by Most Popular";
            ArrowImage1.Visible = false;
        }
        if (OrderBy == 2)
        {
            LinkHighestRated.NavigateUrl = "~/searchrecipe.aspx?find=" + strKeyword + "&catid=" + CatId + "&ob=" + OrderBy;
            LinkHighestRated.Text = "Highest Rated";
            LinkHighestRated.ToolTip = "Sort by highest rated";
            ArrowImage2.ImageUrl = Util.SortOptionArrowImage;
            ArrowImage2.Visible = true;
        }
        else
        {
            LinkHighestRated.NavigateUrl = "~/searchrecipe.aspx?find=" + strKeyword + "&catid=" + CatId + "&ob=2";
            LinkHighestRated.Text = "Highest Rated";
            LinkHighestRated.ToolTip = "Sort by highest rated";
            ArrowImage2.Visible = false;
        }
        if (OrderBy == 3)
        {
            LinkName.NavigateUrl = "~/searchrecipe.aspx?find=" + strKeyword + "&catid=" + CatId + "&ob=" + OrderBy;
            LinkName.Text = "Name";
            LinkName.ToolTip = "Sort by name";
            ArrowImage3.ImageUrl = Util.SortOptionArrowImage;
            ArrowImage3.Visible = true;
        }
        else
        {
            LinkName.NavigateUrl = "~/searchrecipe.aspx?find=" + strKeyword + "&catid=" + CatId + "&ob=3";
            LinkName.Text = "Name";
            LinkName.ToolTip = "Sort by name";
            ArrowImage3.Visible = false;
        }
        if (OrderBy == 4)
        {
            LinkNewest.NavigateUrl = "~/searchrecipe.aspx?find=" + strKeyword + "&catid=" + CatId + "&ob=" + OrderBy;
            LinkNewest.Text = "Newest";
            LinkNewest.ToolTip = "Sort by newest recipes";
            ArrowImage4.ImageUrl = Util.SortOptionArrowImage;
            ArrowImage4.Visible = true;
        }
        else
        {
            LinkNewest.NavigateUrl = "~/searchrecipe.aspx?find=" + strKeyword + "&catid=" + CatId + "&ob=4";
            LinkNewest.Text = "Newest";
            LinkNewest.ToolTip = "Sort by newest recipes";
            ArrowImage4.Visible = false;

        }
       }
       #endregion
     }
 }

