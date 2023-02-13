using ENTITY;
using PROCESS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Falcon.Secure
{
    public partial class UserRolesForm : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    DataTable dt = new DataTable();
                    Role entity = new Role();
                    RolesBO entityBO = new RolesBO();

                    try { entity.Roleid = new Guid(Request.QueryString["id"].ToString()); }
                    catch { }

                    dt = entityBO.Select(entity);

                    foreach (DataRow dr in dt.Rows)
                    {
                        TextBoxName.Text = dr["RoleName"].ToString();
                    }
                }
            }
        }

        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            Role entity = new Role();
            RolesBO entityBO = new RolesBO();

            if (Request.QueryString["id"] != null)
            {
                try { entity.Roleid = new Guid(Request.QueryString["id"].ToString()); }
                catch { }
                try { entity.RoleName = TextBoxName.Text.ToString().Trim(); }
                catch { }
                try { entity.Updater = new Guid(Membership.GetUser().ProviderUserKey.ToString()); }
                catch (Exception) { }

                entityBO.Update(entity);

                if (entityBO.IsSuccessful)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Record has been successfully saved.'); window.location = 'UserRoles.aspx';", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('" + entityBO.TransactionMessage + "');", true);
                }
            }
            else
            {
                if (Roles.RoleExists(TextBoxName.Text.ToString().Trim()))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Role name already exists.');", true);
                }
                else
                {
                    Roles.CreateRole(TextBoxName.Text.ToString().Trim());
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Record has been successfully saved.'); window.location = 'UserRoles.aspx';", true);
                }
            }
 
          
        }

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserRoles.aspx");
        }
    }
}