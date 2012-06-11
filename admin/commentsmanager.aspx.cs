#region XD World Recipe V 2.8
// FileName: commentsmanager.cs
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
using System.Data.SqlClient;
using XDRecipe.Model.AddUpdateDeleteRecipeComment;
using UserVal;
using BLL;

public partial class admin_commentsmanager : System.Web.UI.Page
{
    //Instantiate sql params object
    Blogic myBL = new Blogic();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //Validate admin session username and password by comparing them to the admin user database record.
            UserNameVal.ValidateAdminUserNameandPass();

            //Get admin username from the sessioan variable and place it in the label.
            lblusername.Text = "Welcome Admin:&nbsp;" + UserNameVal.AdminUsername;

            lbCountRecipe.Text = "There are " + string.Format("{0:#,###}", myBL.GetHomepageTotalRecipeCount) + " Approved Recipe";

            //Hide comment editing form
            Panel1.Visible = false;
            countcommentlink.Enabled = false;

            BindData();      
        }
        else
        {
            //Show comment editing form
            Panel1.Visible = true;
            countcommentlink.Enabled = true;
        }

        myBL = null;
    }

    //Data binding
    private void BindData()
    {       
        //Return datatable. 
        DataTable dt = myBL.AdminGetRecipeComments;

        //Assign dt to new DataView object
        DataView dv = new DataView(dt);

        lbCountComments.Text = "Total Comments: " + dv.Count.ToString();

         Recipes_table.DataSource = dv;
         Recipes_table.DataBind();

        //Release allocated memory
         myBL = null;
    }

    //Handles update comment
    public void Update_Comments(Object s, EventArgs e)
    {
        //Instantiate the SQL command object
        CommentInfo UpdateComm = new CommentInfo();

        UpdateComm.ID = int.Parse(Request.Form["KeyIDs"]);
        UpdateComm.Author = Request.Form["Author"];
        UpdateComm.Email = Request.Form["Email"];
        UpdateComm.Comments = Request.Form["Comments"];

        //Notify user if error occured.
        if (UpdateComm.Update() != 0)
        {
            JSLiteral.Text = "Error occured while processing your submit.";
            return;
        }

        Response.Redirect("confirmcommentupdate.aspx?mode=update");
    }

    //Handle the delete button click event
    public void Delete_Comment(object sender, DataGridCommandEventArgs e)
    {
        if ((e.CommandName == "Delete"))
        {
            TableCell iIdKeyNumber = e.Item.Cells[2];
            TableCell iIdCommNumber = e.Item.Cells[3];

            //Instantiate the SQL command object
            CommentInfo DeleteComm = new CommentInfo();

            DeleteComm.ID = int.Parse(iIdKeyNumber.Text);
            DeleteComm.RECID = int.Parse(iIdCommNumber.Text);

            //Perform delete recipe
            DeleteComm.Delete();

            //Redirect to confirm delete page
            Response.Redirect("confirmcommentupdate.aspx?mode=del");
        }
    }

    //Handle edit databound
    public void Edit_Handle(object sender, DataGridCommandEventArgs e)
    {
        if ((e.CommandName == "edit"))
        {
            TableCell iComIDNum = e.Item.Cells[2];
            TableCell iAuthorName = e.Item.Cells[4];
            TableCell iAuthorEmail = e.Item.Cells[5];
            TableCell iComment = e.Item.Cells[7];

            Panel1.Visible = true;

            //This will be the value to be populated into the textboxes
            Author.Text = iAuthorName.Text;
            Email.Text = iAuthorEmail.Text;
            Comments.Text = iComment.Text;
            KeyIDs.Value = iComIDNum.Text;
            lblheaderform.Text = "Updating Comment #:&nbsp;" + iComIDNum.Text;
        }
    }

    //Handles page change links - paging system
    public void New_Page(object sender, DataGridPageChangedEventArgs e)
    {
        Recipes_table.CurrentPageIndex = e.NewPageIndex;
        BindData();
    }

    public void dgComment_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
         //First, make sure we're not dealing with a Header or Footer row
        if (e.Item.ItemType != ListItemType.Header && e.Item.ItemType != ListItemType.Footer)
        {
            LinkButton editButton = (LinkButton)(e.Item.Cells[0].Controls[0]);
            LinkButton deleteButton = (LinkButton)(e.Item.Cells[1].Controls[0]);

            //We can now add the onclick event handler
            deleteButton.Attributes["onclick"] = "javascript:return confirm('Are you sure you want to delete Comment ID # " + DataBinder.Eval(e.Item.DataItem, "COM_ID") + "?')";

            editButton.ToolTip = "Update comment ID #: " + DataBinder.Eval(e.Item.DataItem, "COM_ID") + " author: " + DataBinder.Eval(e.Item.DataItem, "Author");
            deleteButton.ToolTip = "Delete comment ID #: " + DataBinder.Eval(e.Item.DataItem, "COM_ID") + " author: " + DataBinder.Eval(e.Item.DataItem, "Author");

            //Data row mouseover changecolor
            e.Item.Attributes.Add("onmouseover", "this.style.backgroundColor='#F4F9FF'");
            e.Item.Attributes.Add("onmouseout", "this.style.backgroundColor='#ffffff'");
        }
    }
}
