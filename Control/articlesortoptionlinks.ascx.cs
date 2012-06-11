#region XD World Recipe V 2.8
// FileName: articlesortoptionlinks.ascx.cs
// Author: Dexter Zafra
// Date Created: 7/18/2008
// Website: www.ex-designz.net
#endregion
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Util;

public partial class articlesortoptionlinks : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
            //Instantiate utility object
            Utility Util = new Utility();

            int CatId, OrderBy, SortBy;
            OrderBy = (int)Util.Val(Request.QueryString["ob"]);
            SortBy = (int)Util.Val(Request.QueryString["sb"]);

            if (Request.QueryString["catid"] != null)
            {
                CatId = (int)Util.Val(Request.QueryString["catid"]);

                // Here we check what field are we going to sort, this depends on the sort value
                if (OrderBy == 1)
                {
                    LinkMostPopular.NavigateUrl = "~/articlecategory.aspx?catid=" + CatId + "&ob=" + OrderBy + "&sb=2";
                    LinkMostPopular.Text = "Most Popular";
                    LinkMostPopular.ToolTip = "Sort category by Most Popular ASC Order";
                    ArrowImage1.ImageUrl = Util.SortOptionArrowImage;
                    ArrowImage1.Visible = true;

                    if (SortBy == 2)
                    {
                        LinkMostPopular.NavigateUrl = "~/articlecategory.aspx?catid=" + CatId + "&ob=" + OrderBy + "&sb=1";
                        LinkMostPopular.Text = "Most Popular";
                        LinkMostPopular.ToolTip = "Sort category by Most Popular DESC order";
                        ArrowImage1.ImageUrl = Util.SortOptionArrowUpImage;
                        ArrowImage1.Visible = true;
                    }
                }
                else
                {
                    LinkMostPopular.NavigateUrl = "~/articlecategory.aspx?catid=" + CatId + "&ob=1";
                    LinkMostPopular.Text = "Most Popular";
                    LinkMostPopular.ToolTip = "Sort category by Most Popular";
                    ArrowImage1.Visible = false;
                }
                if (OrderBy == 2)
                {
                    LinkHighestRated.NavigateUrl = "~/articlecategory.aspx?catid=" + CatId + "&ob=" + OrderBy + "&sb=2";
                    LinkHighestRated.Text = "Highest Rated";
                    LinkHighestRated.ToolTip = "Sort by Highest Rated ASC Order";
                    ArrowImage2.ImageUrl = Util.SortOptionArrowImage;
                    ArrowImage2.Visible = true;

                    if (SortBy == 2)
                    {
                        LinkHighestRated.NavigateUrl = "~/articlecategory.aspx?catid=" + CatId + "&ob=" + OrderBy + "&sb=1";
                        LinkHighestRated.Text = "Highest Rated";
                        LinkHighestRated.ToolTip = "Sort category by Highest Rated DESC order";
                        ArrowImage2.ImageUrl = Util.SortOptionArrowUpImage;
                        ArrowImage2.Visible = true;
                    }
                }
                else
                {
                    LinkHighestRated.NavigateUrl = "~/articlecategory.aspx?catid=" + CatId + "&ob=2";
                    LinkHighestRated.Text = "Highest Rated";
                    LinkHighestRated.ToolTip = "Sort by Highest Rated";
                    ArrowImage2.Visible = false;
                }
                if (OrderBy == 3)
                {
                    LinkName.NavigateUrl = "~/articlecategory.aspx?catid=" + CatId + "&ob=" + OrderBy + "&sb=1";
                    LinkName.Text = "Name";
                    LinkName.ToolTip = "Sort by article title DESC order";
                    ArrowImage3.ImageUrl = Util.SortOptionArrowImage;
                    ArrowImage3.Visible = true;

                    if (SortBy == 1)
                    {
                        LinkName.NavigateUrl = "~/articlecategory.aspx?catid=" + CatId + "&ob=" + OrderBy + "&sb=2";
                        LinkName.Text = "Name";
                        LinkName.ToolTip = "Sort by article title ASC order";
                        ArrowImage3.ImageUrl = Util.SortOptionArrowUpImage;
                        ArrowImage3.Visible = true;
                    }
                }
                else
                {
                    LinkName.NavigateUrl = "~/articlecategory.aspx?catid=" + CatId + "&ob=3";
                    LinkName.Text = "Name";
                    LinkName.ToolTip = "Sort category by name";
                    ArrowImage3.Visible = false;
                }
                if (OrderBy == 4)
                {
                    LinkNewest.NavigateUrl = "~/articlecategory.aspx?catid=" + CatId + "&ob=" + OrderBy + "&sb=2";
                    LinkNewest.Text = "Newest";
                    LinkNewest.ToolTip = "Sort category by newest recipes ASC order";
                    ArrowImage4.ImageUrl = Util.SortOptionArrowImage;
                    ArrowImage4.Visible = true;

                    if (SortBy == 2)
                    {
                        LinkNewest.NavigateUrl = "~/articlecategory.aspx?catid=" + CatId + "&ob=" + OrderBy + "&sb=1";
                        LinkNewest.Text = "Newest";
                        LinkNewest.ToolTip = "Sort category by newest recipes DESC order";
                        ArrowImage4.ImageUrl = Util.SortOptionArrowUpImage;
                        ArrowImage4.Visible = true;
                    }
                }
                else
                {
                    LinkNewest.NavigateUrl = "~/articlecategory.aspx?catid=" + CatId + "&ob=4";
                    LinkNewest.Text = "Newest";
                    LinkNewest.ToolTip = "Sort category by newest article";
                    ArrowImage4.Visible = false;

                }
            }

            if (Request.QueryString["find"] != null)
            {

                string strKeyword;

                CatId = (int)Util.Val(Request.QueryString["catid"]);
                strKeyword = Request.QueryString["find"].ToString();

                // Here we check what field are we going to sort, this depends the sort value
                if (OrderBy == 1)
                {
                    LinkMostPopular.NavigateUrl = "~/searcharticle.aspx?find=" + strKeyword + "&catid=" + CatId + "&ob=" + OrderBy + "&sb=2";
                    LinkMostPopular.Text = "Most Popular";
                    LinkMostPopular.ToolTip = "Sort by Most Popular ASC Order";
                    ArrowImage1.ImageUrl = Util.SortOptionArrowImage;
                    ArrowImage1.Visible = true;

                    if (SortBy == 2)
                    {
                        LinkMostPopular.NavigateUrl = "~/searcharticle.aspx?find=" + strKeyword + "&catid=" + CatId + "&ob=" + OrderBy + "&sb=1";
                        LinkMostPopular.Text = "Most Popular";
                        LinkMostPopular.ToolTip = "Sort category by Most Popular DESC order";
                        ArrowImage1.ImageUrl = Util.SortOptionArrowUpImage;
                        ArrowImage1.Visible = true;
                    }
                }
                else
                {
                    LinkMostPopular.NavigateUrl = "~/searcharticle.aspx?find=" + strKeyword + "&catid=" + CatId + "&ob=1";
                    LinkMostPopular.Text = "Most Popular";
                    LinkMostPopular.ToolTip = "Sort by Most Popular";
                    ArrowImage1.Visible = false;
                }
                if (OrderBy == 2)
                {
                    LinkHighestRated.NavigateUrl = "~/searcharticle.aspx?find=" + strKeyword + "&catid=" + CatId + "&ob=" + OrderBy + "&sb=2";
                    LinkHighestRated.Text = "Highest Rated";
                    LinkHighestRated.ToolTip = "Sort by Highest Rated ASC Order";
                    ArrowImage2.ImageUrl = Util.SortOptionArrowImage;
                    ArrowImage2.Visible = true;

                    if (SortBy == 2)
                    {
                        LinkHighestRated.NavigateUrl = "~/searcharticle.aspx?find=" + strKeyword + "&catid=" + CatId + "&ob=" + OrderBy + "&sb=1";
                        LinkHighestRated.Text = "Highest Rated";
                        LinkHighestRated.ToolTip = "Sort category by Highest Rated DESC order";
                        ArrowImage2.ImageUrl = Util.SortOptionArrowUpImage;
                        ArrowImage2.Visible = true;
                    }
                }
                else
                {
                    LinkHighestRated.NavigateUrl = "~/searcharticle.aspx?find=" + strKeyword + "&catid=" + CatId + "&ob=2";
                    LinkHighestRated.Text = "Highest Rated";
                    LinkHighestRated.ToolTip = "Sort by Highest Rated";
                    ArrowImage2.Visible = false;
                }
                if (OrderBy == 3)
                {
                    LinkName.NavigateUrl = "~/searcharticle.aspx?find=" + strKeyword + "&catid=" + CatId + "&ob=" + OrderBy + "&sb=1";
                    LinkName.Text = "Name";
                    LinkName.ToolTip = "Sort by Name DESC Order";
                    ArrowImage3.ImageUrl = Util.SortOptionArrowImage;
                    ArrowImage3.Visible = true;

                    if (SortBy == 1)
                    {
                        LinkName.NavigateUrl = "~/searcharticle.aspx?find=" + strKeyword + "&catid=" + CatId + "&ob=" + OrderBy + "&sb=2";
                        LinkName.Text = "Name";
                        LinkName.ToolTip = "Sort category by Name ASC order";
                        ArrowImage3.ImageUrl = Util.SortOptionArrowUpImage;
                        ArrowImage3.Visible = true;
                    }
                }
                else
                {
                    LinkName.NavigateUrl = "~/searcharticle.aspx?find=" + strKeyword + "&catid=" + CatId + "&ob=3";
                    LinkName.Text = "Name";
                    LinkName.ToolTip = "Sort by Name";
                    ArrowImage3.Visible = false;
                }
                if (OrderBy == 4)
                {
                    LinkNewest.NavigateUrl = "~/searcharticle.aspx?find=" + strKeyword + "&catid=" + CatId + "&ob=" + OrderBy + "&sb=2";
                    LinkNewest.Text = "Newest";
                    LinkNewest.ToolTip = "Sort by Newest ASC Order";
                    ArrowImage4.ImageUrl = Util.SortOptionArrowImage;
                    ArrowImage4.Visible = true;

                    if (SortBy == 2)
                    {
                        LinkNewest.NavigateUrl = "~/searcharticle.aspx?find=" + strKeyword + "&catid=" + CatId + "&ob=" + OrderBy + "&sb=1";
                        LinkNewest.Text = "Newest";
                        LinkNewest.ToolTip = "Sort by Newest DESC order";
                        ArrowImage4.ImageUrl = Util.SortOptionArrowUpImage;
                        ArrowImage4.Visible = true;
                    }
                }
                else
                {
                    LinkNewest.NavigateUrl = "~/searcharticle.aspx?find=" + strKeyword + "&catid=" + CatId + "&ob=4";
                    LinkNewest.Text = "Newest";
                    LinkNewest.ToolTip = "Sort by Newest";
                    ArrowImage4.Visible = false;
                }
            }
        }
}
