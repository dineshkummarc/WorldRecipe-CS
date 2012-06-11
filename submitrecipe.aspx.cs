#region XD World Recipe V 2.8
// FileName: submitrecipe.cs
// Author: Dexter Zafra
// Date Created: 5/28/2008
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
using XDRecipe.Model.AddUpdateDelete;
using XDRecipe.UI;
using RecipeImage;
using EmailTemplates;
using BLL;
using Util;

public partial class submitrecipeform : BasePage
{
    //Instantiate recipe object.
    RecipeInfo Recipe = new RecipeInfo();

    //Instantiate utility/common object
    Utility Util = new Utility();

    private int CatId;

    protected void Page_Load(Object sender, EventArgs e)
    {
        BindList();
    }

    //Data bind
    private void BindList()
    {
        //Instantiate Action Stored Procedure object
        Blogic FetchData = new Blogic();

        Recipe.CatID = (int)Util.Val(Request.QueryString["catid"]);

        IDataReader dr = FetchData.GetCatName(Recipe.CatID);

        try
        {
            dr.Read();

            Recipe.Category = dr["CAT_TYPE"].ToString();
            lbcatname.Text = Recipe.Category.ToString();
            lbcatname2.Text = Recipe.Category.ToString();

            //Assing value to hidden HTML text field.
            Category.Value = Recipe.Category.ToString();
            CAT_ID.Value = Recipe.CatID.ToString();

            dr.Close();
        }
        catch
        {
            //If no record, redirect to page not found.
            Util.PageRedirect(1);
        }

        //Release allocated memory
        FetchData = null;
    }

    //Handles insert recipe
    public void Add_Recipe(Object s, EventArgs e)
    {
        //Perform spam validation by matching the value of the textbox security code to the session state variable
        //that store the random number.
        if (Page.IsValid && (txtsecfield.Text.ToString() == Session["randomstrsub"].ToString()))
        {
            //If all the fields are filled correctly, then process recipe submission.
            //Instantiate the SQL command object
            RecipeInfo Add = new RecipeInfo();

            //Filters harmful scripts from input string.
            Add.RecipeName = Util.FormatTextForInput(Request.Form[Name.UniqueID]);
            Add.Author = Util.FormatTextForInput(Request.Form[Author.UniqueID]);
            Add.CatID = (int)Util.Val(Request.QueryString["catid"]);
            Add.Category = Util.FormatTextForInput(Request.Form[Category.UniqueID]);
            Add.Ingredients = Util.FormatTextForInput(Request.Form[Ingredients.UniqueID]);
            Add.Instructions = Util.FormatTextForInput(Request.Form[Instructions.UniqueID]);

            #region Form Input Validator
            //Validate for empty recipe name
            if (Add.RecipeName.Length == 0)
            {
                lbvalenght.Text = "<br>Error: Recipe Name is empty, please enter a recipe name.";
                lbvalenght.Visible = true;
                txtsecfield.Text = "";
                return;
            }
            //Validate for empty author name
            if (Add.Author.Length == 0)
            {
                lbvalenght.Text = "<br>Error: Author Name is empty, please enter the author name";
                lbvalenght.Visible = true;
                txtsecfield.Text = "";
                return;
            }
            //Validate for empty ingredients
            if (Add.Ingredients.Length == 0)
            {
                lbvalenght.Text = "<br>Error: Ingredients is empty, please enter an ingredients.";
                lbvalenght.Visible = true;
                txtsecfield.Text = "";
                return;
            }
            //Validate for empty instruction
            if (Add.Instructions.Length == 0)
            {
                lbvalenght.Text = "<br>Error: Instructions is empty, please enter an instruction.";
                lbvalenght.Visible = true;
                txtsecfield.Text = "";
                return;
            }

            //Recipe name maximum of 50 char allowed
            if (Add.RecipeName.Length > 50)
            {
                lbvalenght.Text = "<br>Error: Recipe Name is too long. Max of 50 characters.";
                lbvalenght.Visible = true;
                Name.Value = "";
                txtsecfield.Text = "";
                return;
            }
            //Author name maximum of 25 char allowed
            if (Add.Author.Length > 25)
            {
                lbvalenght.Text = "<br>Error: Author Name is too long. Max of 25 characters.";
                lbvalenght.Visible = true;
                Author.Value = "";
                txtsecfield.Text = "";
                return;
            }
            //Ingredients maximum of 500 char allowed
            if (Add.Ingredients.Length > 500)
            {
                lbvalenght.Text = "<br>Error: Ingredients is too long. Max of 500 characters.";
                lbvalenght.Visible = true;
                txtsecfield.Text = "";
                return;
            }
            //Instruction maximum of 700 char allowed
            if (Add.Instructions.Length > 700)
            {
                lbvalenght.Text = "<br>Error: Instructions is too long. Max of 700 characters.";
                lbvalenght.Visible = true;
                txtsecfield.Text = "";
                return;
            }
            #endregion

            #region Recipe Image Upload

            if (RecipeImageFileUpload.HasFile) //Check if there is a file
            {
                //Constant variables
                string Directory = GetRecipeImage.ImagePathDetail; //Directory to store recipe images
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
                    lbvalenght.Text = "<br>File format is invalid. Only gif, jpg, jpeg or png files are allowed.";
                    lbvalenght.Visible = true;
                    return;
                }
                // File size validation
                else if (FileSize > maxFileSize)
                {
                    lbvalenght.Text = "<br>File size exceed the maximun allowed 30000 bytes";
                    lbvalenght.Visible = true;
                    return;
                }
                else
                {
                    //Check wether the image name already exist. 
                    //If the image name already exist, append a random 
                    //numeric and letter to ensure the image name is always unqiue.
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
                        Add.RecipeImage = FileNameWithExtension;

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
                    else
                    {
                        //Get directory, the file name and the extension.
                        FilePath = string.Concat(Directory, FileName, "", FileExtention);

                        //Joined the filename and extension to insert into the database.
                        FileNameWithExtension = FileName + FileExtention;

                        //Initialize Add recipe object property to get the full image name
                        Add.RecipeImage = FileNameWithExtension;

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
            {
                //If there is no image to be uploaded, then assign an empty string to the property
                Add.RecipeImage = string.Empty;
            }
            #endregion

            //Insert recipe to database. If an error occured notify user.
            if (Add.Add() != 0)
            {
                JSLiteral.Text = "Error occured while processing your submit.";
                return;
            }

            //Instantiate email template object
            //Comment this part if you don't want to receive an email notification
            EmailTemplate SendEMail = new EmailTemplate();

            SendEMail.ItemName = Add.RecipeName;

            //Send an email notification to the webmaster in HTML format.
            //Comment this part if you don't want to receive an email notification
            SendEMail.SendEmailAddRecipeNotify();

            //Release allocated memory
            Add = null;
            SendEMail = null;

            //If success, redirect to confirmation and thank you page.
            Util.PageRedirect(3);

            Util = null;
        }
        else
        {
            //Javascript validation
            JSLiteral.Text = Util.JSAlert("Invalid security code. Make sure you type it correctly.");
            return;

            // lblinvalidsecode.Text = "Invalid security code. Make sure you type it correctly.";
            // lblinvalidsecode.Visible = true;
        }
    }
}
