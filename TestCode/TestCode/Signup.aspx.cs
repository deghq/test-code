using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Signup : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txtEmailAddress.Text) || string.IsNullOrEmpty(txtPassword.Text))
        {
            Response.Write("Please input all field");
            return;
        }
        else
        {
            try
            {
                User UserModel = new User();
                UserModel.Email = txtEmailAddress.Text.ToString();
                UserModel.Password = txtPassword.Text.ToString();
                UserModel.Phone = txtPhone.Text.ToString();
                if (!new SqlUserRepository().IsDuplicate(UserModel.Email))
                {
                    new SqlUserRepository().Save(UserModel);
                    Response.Redirect("Login.aspx");
                    ResetText();
                }
                else
                {
                    Response.Write("Email already exist");
                }

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
    }

    void ResetText()
    {
        txtEmailAddress.Text = "";
        txtPassword.Text = "";
        txtPhone.Text = "";
    }
    protected void txtPassword_TextChanged(object sender, EventArgs e)
    {

    }
}