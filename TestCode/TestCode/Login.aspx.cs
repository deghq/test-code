using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{


    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txtEmalAddress.Text) || string.IsNullOrEmpty(txtPassword.Text))
        {
            Response.Write("Invalid EmailAddress or Wrong Password");
            return;
        }
        else
        {
            try
            {
                User usermodel = new SqlUserRepository().ReadByEmailAndPassword(txtEmalAddress.Text, txtPassword.Text);

                if (usermodel != null)
                {
                    Session["Id"] = usermodel.Id;
                    Session["Email"] = usermodel.Email;
                    Session["Phone"] = usermodel.Phone;

                    Response.Redirect("Dashboard.aspx");
                } 
                else
                {
                    Response.Write("Invalid Email Account and Password");
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
    }
    protected void linklblRegistration_Click(object sender, EventArgs e)
    {
        Response.Redirect("Signup.aspx");
    }
}