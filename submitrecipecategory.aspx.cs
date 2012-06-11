#region XD World Recipe V 2.8
// FileName: submitrecipecategory.cs
// Author: Dexter Zafra
// Date Created: 5/28/2008
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
using GetSubmitRecipeCategory;

public partial class submitrecipecategory : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        submitrecipecategoryprovider GetCategory = new submitrecipecategoryprovider();

        //Get category datatable
        RecipeCat.DataSource = GetCategory.GetSubmitCategory();
        RecipeCat.DataBind();

        //Release allocated memory
        GetCategory = null;
    }
}
