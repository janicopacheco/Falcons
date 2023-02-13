using ENTITY;
using PROCESS;
using System;
using System.Data;
using System.Web.Security;
using System.Web.UI;

namespace Falcon.Secure
{
    public partial class UsersForm : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropDown();

                if (Request.QueryString["id"] != null)
                {
                    DataTable dt = new DataTable();
                    User entity = new User();
                    UserBO entityBO = new UserBO();

                    try { entity.Userid = new Guid(Request.QueryString["id"].ToString()); }
                    catch { }

                    dt = entityBO.SelectByUserId(entity);

                    foreach (DataRow dr in dt.Rows)
                    {
                        TextBoxUserName.Enabled = false;
                        TextBoxUserName.Text = dr["email"].ToString();
                        TextBoxFName.Text = dr["firstname"].ToString();
                        TextBoxMName.Text = dr["middlename"].ToString();
                        TextBoxLName.Text = dr["lastname"].ToString();

                        try { DropDownListRole.SelectedValue = dr["RoleId"].ToString(); }
                        catch { }
                        try { TextBoxValidity.Text = DateTime.Parse(dr["validitydate"].ToString()).ToString("yyyy-MM-ddTHH:mm:ss.ss"); }
                        catch { }

                    }
                }
            }
        }

        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            User entity = new User();
            UserBO entityBO = new UserBO();

            if (Request.QueryString["id"] != null)
            {
                try { entity.Userid = new Guid(Request.QueryString["id"].ToString()); }
                catch { }
                try { entity.Firstname = TextBoxFName.Text.ToString().Trim(); }
                catch { }
                try { entity.Middlename = TextBoxMName.Text.ToString().Trim(); }
                catch { }
                try { entity.Lastname = TextBoxLName.Text.ToString().Trim(); }
                catch { }
                try { entity.Validitydate = DateTime.Parse(TextBoxValidity.Text.ToString().Trim()); }
                catch { };

                entityBO.Update(entity);

                if (entityBO.IsSuccessful)
                {
                    MembershipUser memUser = Membership.GetUser(entity.Userid);
                    Roles.RemoveUserFromRole(memUser.UserName, Roles.GetRolesForUser((memUser.UserName))[0].ToString());
                    Roles.AddUserToRole(memUser.UserName, DropDownListRole.SelectedItem.Text.ToString());
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Record has been successfully saved.'); window.location = 'Users.aspx';", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('" + entityBO.TransactionMessage + "');", true);
                }
            }
            else
            {
                try { entity.Email = TextBoxUserName.Text.ToString().Trim(); }
                catch { }
                try { entity.Firstname = TextBoxFName.Text.ToString().Trim(); }
                catch { }
                try { entity.Middlename = TextBoxMName.Text.ToString().Trim(); }
                catch { }
                try { entity.Lastname = TextBoxLName.Text.ToString().Trim(); }
                catch { }
                try { entity.Password = "P@ssw0rd!"; }
                catch { }
                try { entity.RoleId = new Guid(DropDownListRole.SelectedValue.ToString()); }
                catch { };
                try { entity.Validitydate = DateTime.Parse(TextBoxValidity.Text.ToString().Trim()); }
                catch { };

                try
                {
                    Membership.CreateUser(entity.Email, entity.Password, entity.Email);
                    Roles.AddUserToRole(entity.Email, DropDownListRole.SelectedItem.Text.ToString());

                    try { entity.Userid = new Guid(Membership.GetUser(entity.Email).ProviderUserKey.ToString()); }
                    catch (Exception) { };

                    entityBO.Update(entity);

                    if (entityBO.IsSuccessful)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Record has been successfully saved.'); window.location = 'Users.aspx';", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('" + entityBO.TransactionMessage + "');", true);
                    }
                }
                catch { }

            }
        }

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Users.aspx");
        }

        public void BindDropDown()
        {
            DataTable dt = new DataTable();
            RolesBO entityBO = new RolesBO();

            dt = entityBO.SelectAll();

            DropDownListRole.DataSource = dt;
            DropDownListRole.DataBind();

        }
    }
}