using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class JQUERY_UI_TESR : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        String txt = ",Hello";
        //ScriptManager.RegisterClientScriptBlock(this, GetType(), "Popup", "ShowPopup('" + TextBox1.Text + "');", true);
        // ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Popup", "ShowPopup('" + TextBox1.Text+ txt + "');", true);
        ScriptManager.RegisterClientScriptBlock(this, GetType(), "Popup", "ShowPopupConfirm('" + TextBox1.Text + txt + "');", true);
        Button2.Visible = true;
        Button2.Enabled = true;
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        try
        {
            String txt = ",Hello";
            Button2.Visible = false;
            //Button2.Enabled = false;
            int a = 100, b = 4;
            int c = a / 0 + b;
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "Popup", "ShowPopup('" + ex.Message + "');", true);
        }
    }


    protected void Button3_Click(object sender, EventArgs e)
    {
        //try
        //{
        //    //Button2.Enabled = false;
        //    int a = 100, b = 4;
        //    int c = a / 0 + b;
        //}
        //catch (Exception ex)
        //{
        //    ScriptManager.RegisterClientScriptBlock(this, GetType(), "Popup", "ShowPopup('" + ex.Message + "');", true);
        //}
    }



    protected void btnhidden_Click(object sender, EventArgs e)
    {
        try
        {
            //Button2.Enabled = false;
            int a = 100, b = 4;
            int c = a / 0 + b;
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "Popup", "ShowPopup('" + ex.Message + "');", true);
        }

    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        string saveDir = @"Uploads\";
        //因為反斜線會被解析,使用@方便閱讀
        //還是可寫成String saveDir= "\\FileUpload\\"; 
        //string saveDir = "\\FileUpload\\";
        string appPath = Request.PhysicalApplicationPath;//取得目錄完整位址
        string err = "";
        if (FileUpload1.HasFile)
        {
            string savePath = appPath + saveDir +
                Server.HtmlEncode(FileUpload1.FileName);
            FileUpload1.SaveAs(savePath);
            FileUpload1.Dispose();
            bool lockexcel= Class1.LockExcelInterop(savePath, 1, "1111",out err);
            if(lockexcel==true&& err=="")
            {
                Label1.Text = "lockexcel ok!";
            }
            else
            {
                Label1.Text = "lockexcel fail!";
                return;
            }
            Label1.Text += "Your file was uploaded successfully.";
        }
        else
        {
            Label1.Text  = "You did not specify a file to upload.";
        }
    }

    protected void Button5_Click(object sender, EventArgs e)
    {
        string saveDir = @"Uploads\";
        string appPath = Request.PhysicalApplicationPath;//取得目錄完整位址
        string savePath = appPath + saveDir +Server.HtmlEncode(FileUpload1.FileName);
        string err = "";
        bool lockexcel = Class1.UnLockExcelInterop(savePath, 1, "1111", out err);
        if (lockexcel == true && err == "")
        {
            Label1.Text = "Unlockexcel ok!";
        }
        else
        {
            Label1.Text = "Unlockexcel fail!";
            return;
        }
    }
}
