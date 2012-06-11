#region XD World Recipe V 2.8
// FileName: providerarticledropdownlist.cs - Populate article category dropdown menu
// Author: Dexter Zafra
// Date Created: 6/19/2008
// Website: www.ex-designz.net
#endregion
using System;
using System.Data;
using System.Web.UI.WebControls;
using System.Collections;
using BLL;
using ConstantVar;

namespace ProviderDropdownList
{
    /// <summary>
    /// Object in this class populate article category dropdownlist.
    /// </summary>
    public static class ProviderArticleCategoryDropdown
    {
        private static Hashtable _CategoryListArticle;

        /// <summary>
        /// Return a hashtable of article category
        /// </summary>
        public static Hashtable categoryListArticle
        {
            get
            {
                if (_CategoryListArticle == null)
                    createCategoryListArticle();
                return _CategoryListArticle;
            }
        }

        /// <summary>
        /// Create a hashtable for Article Category dropdownlist
        /// </summary>
        private static void createCategoryListArticle()
        {
            //Instantiate Action Stored Procedure object
            Blogic FetchData = new Blogic();

            IDataReader dr = FetchData.GetArticleCategoryList;

            try
            {
                Hashtable ht = new Hashtable();
                while (dr.Read())
                {
                    ht.Add(dr["CAT_ID"].ToString(), dr["CAT_NAME"].ToString());

                    _CategoryListArticle = ht;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            //Release allocated memory
            dr.Close();

            FetchData = null;
        }
    }
}