using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using ENTITY;
using PROCESS;

namespace StraightForward
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //MembershipUser newUser = Membership.CreateUser("rootadmin@yahoo.com", "P@ssw0rd!", "rootadmin@yahoo.com");
            //Roles.AddUserToRole("rootadmin@yahoo.com", "Root Administrator");

            //MembershipUser user = Membership.GetUser("janicopacheco@yahoo.com");

            //string oldpswd = user.ResetPassword();
            //string newpswd = "P@ssw0rd!";

            //user.ChangePassword(oldpswd, newpswd);

            try
            {
                if (Request.QueryString["e"] != null)
                {
                    if (Request.QueryString["e"].ToString() == "1")
                    {
                        lblError.Text = "Your login attempt was not successful. Please try again.";
                    }

                    if (Request.QueryString["e"].ToString() == "2")
                    {
                        lblError.Text = "Your account is no longer valid. Please contact your administrator.";
                    }
                }
            }
            catch { }
        }

        protected void ButtonLogin_Click(object sender, EventArgs e)
        {

            DataTable dt = new DataTable();
            User entity = new User();
            UserBO entityBO = new UserBO();

            try { entity.Email = TextBoxUsername.Text.ToString().Trim(); }
            catch { }

            dt = entityBO.SelectByUsername(entity);

            bool ValidAccount = false;

            foreach (DataRow dr in dt.Rows)
            {
                try { ValidAccount = bool.Parse(dr["IsValid"].ToString()); }
                catch { ValidAccount = false; }
            }

            //CHECK USER VALIDITY
            if (!ValidAccount)
            {
                FormsAuthentication.SignOut();
                Session.Abandon();
                Response.Redirect("Login.aspx?e=2");
            }


            if (Membership.ValidateUser(TextBoxUsername.Text, TextBoxPassword.Text))
            {
                FormsAuthentication.SetAuthCookie(TextBoxUsername.Text, true);
                Response.Redirect("/Secure/Home");
            }
            else
            {
                FormsAuthentication.SignOut();
                Session.Abandon();
                Response.Redirect("Login?e=1");
            }
        }

    }
}