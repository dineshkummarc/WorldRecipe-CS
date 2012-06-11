#region XD World Recipe V 2.8
// FileName: categorymanager.cs
// Author: Dexter Zafra
// Date Created: 7/3/2008
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
using XDRecipe.Model.AddUpdateDeleteRecipeCategory;
using System.Data.SqlClient;
using GetAdminRecipeCategory;
using CacheData;
using UserVal;
using BLL;

public partial class admin_categorymanager : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //Instantiate sql params object
            Blogic myBL = new Blogic();

            //Validate admin session username and password by comparing them to the admin user database record.
            UserNameVal.ValidateAdminUserNameandPass();

            //Get admin username from the sessioan variable and place it in the label.
            lblusername.Text = "Welcome Admin:&nbsp;" + UserNameVal.AdminUsername;

            lbCountRecipe.Text = "There are " + string.Format("{0:#,###}", myBL.GetHomepageTotalRecipeCount) + " Approved Recipe";

            lbCountCat.Text = "Total Category: " + myBL.GetHomepageTotalCategoryCount;

            //Hide comment editing form
            Panel1.Visible = false;
            catmanagerlink.Enabled = false;

            BindData();

            myBL = null;
        }
        else
        {
            //Show comment editing form
            Panel1.Visible = true;
            catmanagerlink.Enabled = true;
        }
    }

    //Data binding
    private void BindData()
    {
        Recipes_table.DataSource = AdminRecipeCategoryProvider.GetCategories();
        Recipes_table.DataBind();
    }

    //Handles update comment
    public void Update_Category(Object s, EventArgs e)
    {
        //Instantiate the SQL command object
        RecipeCategory UpdateCat = new RecipeCategory();

        UpdateCat.CatID = int.Parse(Request.Form["CategoryID"]);
        UpdateCat.Category = Request.Form["CategoryName"];

        Caching.PurgeCacheItems("MainCourse_RecipeCategory");
        Caching.PurgeCacheItems("Ethnic_RecipeCategory");
        Caching.PurgeCacheItems("RecipeCategory_SideMenu");
        Caching.PurgeCacheItems("Submission_RecipeCategory");

        //Notify user if error occured.
        if (UpdateCat.Update() != 0)
        {
            JSLiteral.Text = "Error occured while processing your submit.";
            return;
        }

        Response.Redirect("confirmcatedit.aspx?catname=" + UpdateCat.Category + "&mode=update");
    }

    //Handle the category delete
    public void Delete_Category(Object s, EventArgs e)
    {
        //Instantiate the SQL command object
        RecipeCategory DeleteCat = new RecipeCategory();

        DeleteCat.CatID = int.Parse(Request.Form["CategoryID"]);

        Caching.PurgeCacheItems("MainCourse_RecipeCategory");
        Caching.PurgeCacheItems("Ethnic_RecipeCategory");
        Caching.PurgeCacheItems("RecipeCategory_SideMenu");
        Caching.PurgeCacheItems("Submission_RecipeCategory");

        //Notify user if error occured.
        if (DeleteCat.Delete() != 0)
        {
            JSLiteral.Text = "Error occured while processing your submit.";
            return;
        }

        Response.Redirect("confirmcatedit.aspx?catname=" + Request.Form["CategoryName"] + "&mode=del");

    }

    //Handle add new category
    public void Add_Category(Object s, EventArgs e)
    {
        //Instantiate the SQL command object
        RecipeCategory AddCat = new RecipeCategory();

        AddCat.Category = Request.Form["CategoryName"];
        AddCat.CatGroupID = int.Parse(Request.Form["GroupID"]);

        Caching.PurgeCacheItems("MainCourse_RecipeCategory");
        Caching.PurgeCacheItems("Ethnic_RecipeCategory");
        Caching.PurgeCacheItems("RecipeCategory_SideMenu");
        Caching.PurgeCacheItems("Submission_RecipeCategory");

        //Notify user if error occured.
        if (AddCat.Add() != 0)
        {
            JSLiteral.Text = "Error occured while processing your submit.";
            return;
        }
 
        Response.Redirect("confirmcatedit.aspx?catname=" + AddCat.Category + "&mode=add");
    }

    //Handle edit databound
    public void Edit_Handle(object sender, DataGridCommandEventArgs e)
    {
        if ((e.CommandName == "edit"))
        {
            TableCell iIdNumber = e.Item.Cells[0];
            TableCell iCatName = e.Item.Cells[1];

            Panel1.Visible = true;
            Panel3.Visible = false;
            AddNewCat.Visible = false;
            lblnamedis2.Text = "Category Name:";
            updatebutton.Visible = true;
            DelCategory.Visible = false;
            GroupID.Visible = false;
            CategoryID.Visible = true;
            lblheaderform.Text = "Updating Recipe Category #:&nbsp;" + iIdNumber.Text;

            e.Item.BackColor = System.Drawing.ColorTranslator.FromHtml("#F0E68C");

            //This will be the value to be populated into the textboxes
            string CatName = iCatName.Text;
            CategoryName.Text = CatName.Substring(0, CatName.IndexOf("(")).Trim(); //Strip off recipe count
            CategoryID.Value = iIdNumber.Text;
        }
        else if ((e.CommandName == "delete"))
        {
            TableCell iIdNumber = e.Item.Cells[0];
            TableCell iCatName = e.Item.Cells[1];

            Panel1.Visible = true;
            Panel3.Visible = true;
            AddNewCat.Visible = false;
            lblnamedis2.Text = "Category Name:";
            updatebutton.Visible = false;
            CategoryID.Visible = true;
            DelCategory.Visible = true;
            GroupID.Visible = false;
            CategoryID.Value = iIdNumber.Text;
            lblheaderform.Text = "Deleting Recipe Category #:&nbsp;" + iIdNumber.Text;

            e.Item.BackColor = System.Drawing.ColorTranslator.FromHtml("#F0E68C");

            //This will be the value to be populated into the textboxes
            string CatNamedel = iCatName.Text;
            CategoryName.Text = CatNamedel.Substring(0, CatNamedel.IndexOf("(")).Trim(); //Strip off recipe count

            //Instantiate sql params object
            Blogic myBL = new Blogic();

            lblrcdcount2.Text = "The number of recipes belong to&nbsp;" + CategoryName.Text + "&nbsp;category:&nbsp; " + myBL.CategoryCount(int.Parse(iIdNumber.Text));

            myBL = null;
        }
    }

    //Handles page change links - paging system
    public void New_Page(object sender, DataGridPageChangedEventArgs e)
    {
        Recipes_table.CurrentPageIndex = e.NewPageIndex;
        BindData();
    }

    public void dgCat_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        //First, make sure we're not dealing with a Header or Footer row
        if (e.Item.ItemType != ListItemType.Header && e.Item.ItemType != ListItemType.Footer)
        {
            LinkButton editButton = (LinkButton)(e.Item.Cells[3].Controls[0]);
            LinkButton deleteButton = (LinkButton)(e.Item.Cells[4].Controls[0]);

            string PopToolTip = "Category ID: " + DataBinder.Eval(e.Item.DataItem, "CatID") + " - " + DataBinder.Eval(e.Item.DataItem, "Category") + " Category (" + DataBinder.Eval(e.Item.DataItem, "RecordCount") + ") Recipes";

            e.Item.Cells[0].ToolTip = PopToolTip.ToString();
            e.Item.Cells[1].ToolTip = PopToolTip.ToString();

            e.Item.Cells[1].Text = DataBinder.Eval(e.Item.DataItem, "Category") + " (" + DataBinder.Eval(e.Item.DataItem, "RecordCount") + ")";

            deleteButton.ToolTip = "Delete category (" + DataBinder.Eval(e.Item.DataItem, "Category") + ") CAT ID #:" + DataBinder.Eval(e.Item.DataItem, "CatID");
            editButton.ToolTip = "Edit category (" + DataBinder.Eval(e.Item.DataItem, "Category") + ") CAT ID #:" + DataBinder.Eval(e.Item.DataItem, "CatID");

            //Data row mouseover changecolor
            e.Item.Attributes.Add("onmouseover", "this.style.backgroundColor='#F4F9FF'");
            e.Item.Attributes.Add("onmouseout", "this.style.backgroundColor='#ffffff'");
        }
    }

    //Switch to Add Category mode
    public void ChangeToAddCat(object s, EventArgs e)
    {
        DelCategory.Visible = false;
        GroupID.Visible = true;
        CategoryName.Text = "";
        CategoryID.Visible = false;
        Panel1.Visible = true;
        Panel3.Visible = false;
        AddNewCat.Visible = true;
        updatebutton.Visible = false;
        lblheaderform.Text = "Adding New Category";
        lblnamedis2.Text = "Category Name:";
    }
}