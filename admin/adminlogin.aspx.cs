#region XD World Recipe V 2.8
// FileName: adminlogin.cs
// Author: Dexter Zafra
// Date Created: 5/29/2008
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
using BLL;
using Util;

public partial class admin_adminlogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Note: You can use form authentication through web config. Just change the code
    }

    public void ProcessLogin(Object s, EventArgs e)
    {

        //Instantiate validation
        Utility Util = new Utility();

        string Username;
        string Userpass;

       #region Input Validations
        //Validate username and password both are empty.
        if (Request.Form["uname"].Trim() == "" && Request.Form["password"].Trim() == "")
        {
            lblerror.Text = "Please enter a username and a password.";
            JSLiteral.Text = Util.JSAlert("Please enter a username and a password");
            return;
        }
        if (Request.Form["uname"].Trim() == "")
        {
            lblerror.Text = "Please enter a username.";
            JSLiteral.Text = Util.JSAlert("Please enter a username.");
            return;         
        }
        if (Request.Form["password"].Trim() == "")
        {
            lblerror.Text = "Please enter a password.";
            JSLiteral.Text = Util.JSAlert("Please enter a password.");
            return;
        }
      #endregion

        //Retreive value from the request.form property and filter dirty character.
        Username = Util.FormatTextForInput(Request.Form["uname"]);
        Userpass = Util.FormatTextForInput(Request.Form["password"]);

        //Do final login process with validation
        ProcessLoginCheck(Username, Userpass);

        Util = null;
    }

    //Handles final login process with validation
    private void ProcessLoginCheck(string Username, string UserPwd)
    {

        //Instantiate validation
        Utility Util = new Utility();

        //Instantiate stored procedure logic
        Blogic myBL = new Blogic();

        //Check whether admin username and password exist in the admin user database.
        if (!myBL.AdminUserNameExist(Username))
        {
            lblerror.Text = "Username does not exist";
            JSLiteral.Text = Util.JSAlert("Username does not exist");
            return;
        }
        else if (!myBL.AdminPasswordExist(UserPwd))
        {
            lblerror.Text = "Invalid Password";
            JSLiteral.Text = Util.JSAlert("Invalid Password");
            return;   
        }
        else
        {
            //Assign variable for username and password to use for the session.
            string Getadminusername;
            string Getadminpassword;
            Getadminusername = myBL.GetAdminUserNameSession(Username);
            Getadminpassword = myBL.GetAdminPasswordSession(UserPwd);

            myBL = null;

            //Store admin username and password construct in session state
            Session.Add("adminuserid", Getadminusername);
            Session.Add("adminpassword", Getadminpassword);

            //If everything is okay, then redirect to the Admin Recipe Manager page.
            //5 = recipemanager
            Util.PageRedirect(5);
        }
    }
}
