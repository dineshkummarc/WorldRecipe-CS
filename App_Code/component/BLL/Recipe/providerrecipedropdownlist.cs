#region XD World Recipe V 2.8
// FileName: providerrecipedropdownlist.cs - Populate recipe category dropdown
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
    /// Object in this class populate recipe category dropdownlist
    /// </summary>
    public static class ProviderRecipeCategoryDropdown
    {
        private static Hashtable _CategoryListRecipe;

        /// <summary>
        /// Return a hashtable of recipe category
        /// </summary>
        public static Hashtable categoryListRecipe
        {
            get
            {
                if (_CategoryListRecipe == null)
                    createCategoryListRecipe();
                return _CategoryListRecipe;
            }
        }

        /// <summary>
        /// Create a hashtable for Recipe Category dropdownlist
        /// </summary>
        private static void createCategoryListRecipe()
        {
            //Instantiate Action Stored Procedure object
            Blogic FetchData = new Blogic();

            //Get data
            IDataReader dr = FetchData.GetRecipeCategoryDropdownlist;

            try
            {
                Hashtable ht = new Hashtable();
                while (dr.Read())
                {
                    ht.Add(dr["CAT_ID"].ToString(), dr["CAT_TYPE"].ToString());

                    _CategoryListRecipe = ht;
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