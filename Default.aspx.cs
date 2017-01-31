using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void LoginButton_Click(object sender, EventArgs e)
    {
        LoginClass lc = new LoginClass(EmailTextBox.Text, PasswordTextBox.Text);
        int key = lc.ValidateLogin();
        if (key != 0)
        {
            Session["PersonKey"] = key;
            Response.Redirect("GrantRequests.aspx");
        }
        else
        {
            ResultLabel.Text = "Invalid Login";
        }

    }
}