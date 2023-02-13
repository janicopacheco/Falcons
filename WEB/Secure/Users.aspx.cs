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
    public partial class Users : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDataGrid();
            }
        }

        private void BindDataGrid()
        {
            DataTable dt = new DataTable();
            UserBO entityBO = new UserBO();
            dt = entityBO.SelectAll();

            GridView1.DataSource = dt;
            GridView1.DataBind(); 
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            BindDataGrid();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton LnkButtonEdit = (LinkButton)e.Row.FindControl("LnkButtonEdit");
                LnkButtonEdit.PostBackUrl = "UsersForm.aspx?id=" + GridView1.DataKeys[e.Row.RowIndex].Values[0].ToString();

                
            }
        }

        protected void LinkButtonReset_Click(object sender, EventArgs e)
        {
            LinkButton LinkButtonReset = (LinkButton)sender;
            int rowIndex = int.Parse(LinkButtonReset.CommandArgument.ToString());
            MembershipUser user = Membership.GetUser((Guid)this.GridView1.DataKeys[rowIndex]["userid"]);

            string oldpswd = user.ResetPassword();
            string newpswd = "P@ssw0rd!";

            user.ChangePassword(oldpswd, newpswd);

            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Account password has been reset.');", true);
        }
    }
}