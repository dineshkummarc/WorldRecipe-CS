#region XD World Recipe V 2.8
// FileName: getrecipeimage.cs
// Author: Dexter Zafra
// Date Created: 9/11/2008
// Website: www.ex-designz.net
#endregion
using System;
using System.Data;
using BLL;

namespace RecipeImage
{
    /// <summary>
    /// Object in this class manages recipe image and path
    /// </summary>
    public static class GetRecipeImage
    {
        /// <summary>
        /// Return the recipe image
        /// </summary>
        public static string GetImage(int ID) 
        {
            //Instantiate sql params object
            Blogic myBL = new Blogic();

            string FileName;

            FileName = "../RecipeImageUpload/noimageavailable.gif";

            IDataReader dr = myBL.GetRecipeImageFileNameForUpdate(ID);

            dr.Read();

            if (dr["RecipeImage"] != DBNull.Value)
            {
                FileName = "../RecipeImageUpload/" + (string)dr["RecipeImage"];
            }

            dr.Close();

            myBL = null;

            return FileName;          
        }

        /// <summary>
        /// Return recipe image path for Admin
        /// </summary>
        public static string ImagePath
        {
            get
            {
                return "../RecipeImageUpload/";
            }
        }

        /// <summary>
        /// Return recipe image path for recipedetail
        /// </summary>
        public static string ImagePathDetail
        {
            get
            {
                return "RecipeImageUpload/";
            }
        }
    }
}
