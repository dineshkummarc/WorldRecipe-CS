#region XD World Recipe V 2.8
// FileName: default.cs
// Author: Dexter Zafra
// Date Created: 5/19/2008
// Website: www.ex-designz.net
#endregion
using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using GetMainCourseRecipeCategory;
using GetEthnicRecipeCategory;
using XDRecipe.UI;
using BLL;
using Util;

public partial class _default : BasePage
{
    protected void Page_Load(Object sender, EventArgs e)
    {
        //Instantiate Action Stored Procedure object
        Blogic FetchData = new Blogic();

        GetMetaKeywords();

        lbltotalRecipe.Text = "There are " + string.Format("{0:#,###}",
        FetchData.GetHomepageTotalRecipeCount) + " recipes in " + FetchData.GetHomepageTotalCategoryCount + " categories";

        BindList();

        //Display random image
        Myranimage.ImageUrl = Utility.GetRandomImage;

        FetchData = null;
    }

    //Data bind
    private void BindList()
    {
        //Return main course
        MainCourseCategory.DataSource = MainCourseRecipeCategoryProvider.GetMainCourseCategory();
        MainCourseCategory.DataBind();

        //Return Ehtnic regional
        EthnicRegionalCat.DataSource = EthnicRecipeCategoryProvider.GetEthnicCategory();
        EthnicRegionalCat.DataBind();
    }

    //Assign Metatag
    private void GetMetaKeywords()
    {
        //Assign page title and meta keywords
        Page.Header.Title = "XD World Recipe";
        HtmlMeta metaTag = new HtmlMeta();
        metaTag.Name = "Keywords";
        //You can add more keywords if you want.
        metaTag.Content = "chinese recipe, barbeque recipe, seafoods recipes, salad recipe, mexican recipe";
        this.Header.Controls.Add(metaTag);
    }
}
