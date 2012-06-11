#region XD World Recipe V 2.8
// FileName: getrecipeimageroundedcorner.cs
// Author: Dexter Zafra
// Date Created: 9/6/2008
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
using System.Drawing;
using Util;
using BLL;

public partial class getrecipeimageroundedcorner : System.Web.UI.Page
{
    //Instantiate object
    Utility Util = new Utility();

    private void Page_Init(Object sender, EventArgs e)
    {
        //Instantiate sql params object
        Blogic myBL = new Blogic();

        int ID = (int)Util.Val(Request.QueryString["id"]);
        string FileName = "";

        try
        {
            IDataReader dr = myBL.GetRecipeImageFileNameForUpdate(ID);

            dr.Read();

            if (dr["RecipeImage"] != DBNull.Value)
            {
                FileName = (string)dr["RecipeImage"];
            }

            dr.Close();
        }
        catch
        {
            //Redirect to image not found.
            //1 = pagenotfound.aspx
            Util.PageRedirect(1);
        }

        string Directory = Server.MapPath("~/RecipeImageUpload/");  
        string path = Directory + FileName;

        int roundedDia = 30;

        using (System.Drawing.Image imgin = System.Drawing.Image.FromFile(path))
        {

            System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(imgin.Width, imgin.Height);
            Graphics g = Graphics.FromImage(bitmap);
            g.Clear(Color.White);
            Brush brush = new System.Drawing.TextureBrush(imgin);

            FillRoundedRectangle(g, new Rectangle(0, 0, imgin.Width, imgin.Height), roundedDia, brush);

            // done with drawing dispose graphics object.

            g.Dispose();

            // Stream Image to client.
            Response.Clear();

            Response.ContentType = "image/pjpeg";

            bitmap.Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);

            Response.End();

            //dispose bitmap object.

            bitmap.Dispose();

            //Release allocated memory
            myBL = null;
            Util = null;

        }

    }

    public static void FillRoundedRectangle(Graphics g, Rectangle r, int d, Brush b)
    {
        // anti alias distorts fill so remove it.
        System.Drawing.Drawing2D.SmoothingMode mode = g.SmoothingMode;
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;
        g.FillPie(b, r.X, r.Y, d, d, 180, 90);
        g.FillPie(b, r.X + r.Width - d, r.Y, d, d, 270, 90);
        g.FillPie(b, r.X, r.Y + r.Height - d, d, d, 90, 90);
        g.FillPie(b, r.X + r.Width - d, r.Y + r.Height - d, d, d, 0, 90);
        g.FillRectangle(b, r.X + d / 2, r.Y, r.Width - d, d / 2);
        g.FillRectangle(b, r.X, r.Y + d / 2, r.Width, r.Height - d);
        g.FillRectangle(b, r.X + d / 2, r.Y + r.Height - d / 2, r.Width - d, d / 2);
        g.SmoothingMode = mode;
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }
}
