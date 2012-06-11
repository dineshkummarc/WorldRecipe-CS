#region XD World Recipe V 2.8
// FileName: emailnotificationsettings.cs
// Author: Dexter Zafra
// Date Created: 7/8/2008
// Website: www.ex-designz.net
#endregion
using System;
using BLL;
using System.Data;
using XDRecipe.Model;

namespace EmailNotificationSetting
{
    /// <summary>
    /// Object in this class manages email notification "FromEmail" and "ToEmail".
    /// </summary>
    public sealed class EmailNotificationSettings : Email
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public EmailNotificationSettings()
        {
        }

        /// <summary>
        /// Get data
        /// </summary>
        public override void fillup()
        {
            try
            {
                //Instantiate Action Stored Procedure object
                Blogic FetchData = new Blogic();

                //Get email and SMTP configuration
                IDataReader dr = FetchData.GetConfiguration;

                dr.Read();

                if (dr["Email"] != DBNull.Value)
                {
                    this._FromAdminEmail = (string)dr["Email"];
                }
                if (dr["SmtpServer"] != DBNull.Value)
                {
                    this._ToAdminEmail = (string)dr["SmtpServer"]; //This use to be the STMP server, but now changed to ToAdminEmail
                }

                dr.Close();
                dr = null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
