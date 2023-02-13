using ENTITY;
using PROCESS;
using System;
using System.Data;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace Falcon.Secure
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Request.IsAuthenticated)
            {
                Response.Redirect("~/Login.aspx");
            }

            if (!IsPostBack)
            {
                DataTable dt = new DataTable();
                User entity = new User();
                UserBO entityBO = new UserBO();

                try { entity.Userid = new Guid(Membership.GetUser().ProviderUserKey.ToString()); }
                catch { }

                dt = entityBO.SelectByUserId(entity);

                foreach(DataRow dr in dt.Rows)
                {
                    LabelFullName.Text = dr["fullname"].ToString();
                    LabelRole.Text = dr["rolename"].ToString();
                }

            }
        }

        protected void BtnLogout_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("~/Login.aspx");
        }
    }
}