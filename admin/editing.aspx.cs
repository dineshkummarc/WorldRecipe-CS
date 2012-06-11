#region XD World Recipe V 2.8
// FileName: editing.cs
// Author: Dexter Zafra
// Date Created: 6/13/2008
// Website: www.ex-designz.net
#endregion
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.IO;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using XDRecipe.Model.AddUpdateDelete;
using XDRecipe.Model.RecipeDetail;
using RecipeImage;
using UserVal;
using XDRecipe.DropdownHelper;
using ProviderDropdownList;
using BLL;
using Util;
using ConstantVar;

public partial class admin_editing : System.Web.UI.Page
{
    //Instantiate sql params object
    Blogic myBL = new Blogic();

    //Instantiate validation
    Utility Util = new Utility();

    public string strRecipeImage;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //Validate admin session username and password by comparing them to the admin user database record.
            UserNameVal.ValidateAdminUserNameandPass();

            GetDropdownCategoryID();

            lblusername.Text = "Welcome Admin:&nbsp;" + UserNameVal.AdminUsername;

            //Instantiate database field
            RecipeDetails Recipe = new RecipeDetails();

            Recipe.ID = (int)Util.Val(Request.QueryString["id"]);

            strRecipeImage = GetRecipeImage.GetImage(Recipe.ID);

            Recipe.WhatPageID = constant.intRecipeAdminEditing; //Parameter 3 = we are pulling database field for Admin/editing.aspx

            //Fill up database fields
            Recipe.fillup();

            Name.Text = Recipe.RecipeName;
            Author.Text = Recipe.Author;
            Hits.Text = Recipe.Hits.ToString();
            Ingredients.Text = Recipe.Ingredients;
            Instructions.Text = Recipe.Instructions;

            //Release allocated memory
            Recipe = null;
            myBL = null;
        }
    }

    //Populate the dropdown category list
    private void GetDropdownCategoryID()
    {
        //Populate category dropdown list.
        DropdownlistHelper.FillUpDropDown(CategoryID, ProviderRecipeCategoryDropdown.categoryListRecipe, "Choose Category");
    }

    //Handles update recipe
    public void Update_Recipe(object sender, EventArgs e)
    {
        RecipeInfo Update = new RecipeInfo();

        Update.ID = (int)Util.Val(Request.QueryString["id"]);
        Update.RecipeName = Request.Form["Name"];
        Update.Author = Request.Form["Author"];
        Update.CatID = int.Parse(Request.Form["CategoryID"]);
        Update.Ingredients = Request.Form["Ingredients"];
        Update.Instructions = Request.Form["Instructions"];
        Update.Hits = int.Parse(Request.Form["Hits"]);

        #region Upload New Photo/Update Photo

        if (RecipeImageFileUpload.HasFile) //Check if there is a file
        {
            //Constant variables
            string Directory = GetRecipeImage.ImagePath; //Directory to store recipe images
            int maxFileSize = 30000; // Maximum file size limit

            int FileSize = RecipeImageFileUpload.PostedFile.ContentLength; //Get th file lenght
            string contentType = RecipeImageFileUpload.PostedFile.ContentType; // Get the file type
            string FileExist = Directory + RecipeImageFileUpload.PostedFile.FileName; // Get the filename from the directory and compare
            string FileName = Path.GetFileNameWithoutExtension(RecipeImageFileUpload.PostedFile.FileName); //Get the posted filename
            string FileExtention = Path.GetExtension(RecipeImageFileUpload.PostedFile.FileName); //Get the posted file extension
            string FilePath;
            string FileNameWithExtension;

            //File type validation
            if (!contentType.Equals("image/gif") &&
                !contentType.Equals("image/jpeg") &&
                !contentType.Equals("image/jpg") &&
                !contentType.Equals("image/png"))
            {
                lbvalenght.Text = "File format is invalid. Only gif, jpg, jpeg or png files are allowed.";
                lbvalenght.Visible = true;
                return;
            }
            // File size validation
            else if (FileSize > maxFileSize)
            {
                lbvalenght.Text = "File size exceed the maximun allowed 30000 bytes";
                lbvalenght.Visible = true;
                return;
            }
            else
            {
                //Check wether the image name already exist. 
                //We don't want images stored in the directory if they are not being use.
                if (File.Exists(Server.MapPath(FileExist)))
                {
                    //Create a random alpha numeric to make sure the updated image name is unique.
                    Random rand = new Random((int)DateTime.Now.Ticks);
                    int randnum = rand.Next(1, 10);
                    int CharCode = rand.Next(Convert.ToInt32('a'), Convert.ToInt32('z'));
                    char RandomChar = Convert.ToChar(CharCode);

                    //Get directory, the file name and the extension.
                    FilePath = string.Concat(Directory, FileName + randnum + RandomChar, "", FileExtention);

                    //Joined the filename and extension to insert into the database.
                    FileNameWithExtension = FileName + randnum + RandomChar + FileExtention;

                    //Initialize Add recipe object property to get the full image name
                    Update.RecipeImage = FileNameWithExtension;

                    try
                    {
                        //Delete old image
                        File.Delete(Server.MapPath(Directory + FileName + FileExtention));

                        //Save the recipe image to the specified directory
                        //Make sure the "RecipeImage" folder has write permission to upload image
                        RecipeImageFileUpload.SaveAs(Server.MapPath(FilePath));
                    }
                    catch (Exception ex)
                    {
                        JSLiteral.Text = "Error: " + ex.Message;
                        return;
                    }
                }
                else
                {
                    //Get directory, the file name and the extension.
                    FilePath = string.Concat(Directory, FileName, "", FileExtention);

                    //Joined the filename and extension to insert into the database.
                    FileNameWithExtension = FileName + FileExtention;

                    //Initialize Add recipe object property to get the full image name
                    Update.RecipeImage = FileNameWithExtension;

                    try
                    {
                        //Save the recipe image to the specified directory
                        //Make sure the "RecipeImage" folder has write permission to upload image
                        RecipeImageFileUpload.SaveAs(Server.MapPath(FilePath));

                    }
                    catch (Exception ex)
                    {
                        JSLiteral.Text = "Error: " + ex.Message;
                        return;
                    }
                }
            }
        }
        else
        {    //This section is executed if the input file is empty.
            //Then it check if an image filename exist in the database.
            //If it exist, just update it with the same value, else update it with an empty string.
            IDataReader dr = myBL.GetRecipeImageFileNameForUpdate(Update.ID);

            dr.Read();

            if (dr["RecipeImage"] != DBNull.Value)
            {
                Update.RecipeImage = (string)dr["RecipeImage"];
            }
            else
            {
                Update.RecipeImage = string.Empty;
            }

            dr.Close();
        }
        #endregion

        //Notify user if error occured.
        if (Update.Update() != 0)
        {
            JSLiteral.Text = Util.JSProcessingErrorAlert;
            return;
        }

        string strURLRedirect;
        strURLRedirect = "confirmdel.aspx?catname=" + Update.RecipeName + "&mode=update";

        //Release allocated memory
        Update = null;
        Util = null;

        Response.Redirect(strURLRedirect);

    }

    public void Cancel_Update(object sender, EventArgs e)
    {
        Response.Redirect("recipemanager.aspx");
    }
}
