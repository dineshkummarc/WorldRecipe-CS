#region XD World Recipe V 2.8
// FileName: adminusernamevalidation.cs - Validate session admin username against database record.
// Author: Dexter Zafra
// Date Created: 6/19/2008
// Website: www.ex-designz.net
#endregion
using System;
using System.Data;
using System.Web;
using BLL;
using Util;

namespace UserVal
{
    /// <summary>
    /// Object in this class manages admin username and password  validation
    /// </summary>
    public static class UserNameVal
    {

#region Get Session Admin UserID
        public static string AdminUsername
        {
            get { return HttpContext.Current.Session["adminuserid"].ToString(); }
        }
#endregion

#region Method to check wheter the admin username and password session exist and match to the DB record
        /// <summary>
        /// Perform Admin username and password session validation.
        /// </summary>
        public static void ValidateAdminUserNameandPass()
        {
            //Instantiate utility object
            Utility Util = new Utility();

            Blogic myBL = new Blogic();

            //If it is null, redirect to login page.
            if ((HttpContext.Current.Session["adminuserid"] == null) && (HttpContext.Current.Session["adminpassword"] == null))
            {
                //Redirect to admin login page.
                Util.PageRedirect(6);
                return;
            }

            try
            {
                //Get admin username stored in the database
                IDataReader dr = myBL.AdminGetCredentialSessionValidation;

                dr.Read();

                //Check whether admin username or password match from the admin user database, else redirect to the login page.
                if (HttpContext.Current.Session["adminuserid"].ToString() != dr["uname"].ToString() || HttpContext.Current.Session["adminpassword"].ToString() != dr["password"].ToString())
                {
                    //Redirect to admin login page.
                    Util.PageRedirect(6);
                }

                //Release allocated memory.
                dr.Close();
                dr = null;
                Util = null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
#endregion
    }
}
