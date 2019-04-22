using System;
using System.Collections.Generic;
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
}