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
    public partial class AuditTrails : System.Web.UI.Page
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
            Audittrail entity = new Audittrail();
            AudittrailBO entityBO = new AudittrailBO();


            try { entity.Date = ((TextBox)GridView1.HeaderRow.FindControl("txtDate")).Text.ToString().Trim(); }
            catch { }
            try { entity.Username = ((TextBox)GridView1.HeaderRow.FindControl("txtUsername")).Text.ToString().Trim(); }
            catch { }
            try { entity.Action = ((TextBox)GridView1.HeaderRow.FindControl("txtAction")).Text.ToString().Trim(); }
            catch { }
            try { entity.Type = ((TextBox)GridView1.HeaderRow.FindControl("txtType")).Text.ToString().Trim(); }
            catch { }
            try { entity.Contentname = ((TextBox)GridView1.HeaderRow.FindControl("txtContent")).Text.ToString().Trim(); }
            catch { }
            try { entity.Details = ((TextBox)GridView1.HeaderRow.FindControl("txtDetails")).Text.ToString().Trim(); }
            catch { }

            dt = entityBO.Search(entity);

            GridView1.DataSource = dt;
            GridView1.DataBind();

            try { ((TextBox)GridView1.HeaderRow.FindControl("txtDate")).Text = entity.Date; }
            catch { }
            try { ((TextBox)GridView1.HeaderRow.FindControl("txtUsername")).Text = entity.Username; }
            catch { }
            try { ((TextBox)GridView1.HeaderRow.FindControl("txtAction")).Text = entity.Action; }
            catch { }
            try { ((TextBox)GridView1.HeaderRow.FindControl("txtType")).Text = entity.Type; }
            catch { }
            try { ((TextBox)GridView1.HeaderRow.FindControl("txtContent")).Text = entity.Contentname; }
            catch { }
            try { ((TextBox)GridView1.HeaderRow.FindControl("txtDetails")).Text = entity.Details; }
            catch { }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            BindDataGrid();
        }

        protected void txt_TextChanged(object sender, EventArgs e)
        {
            BindDataGrid();
        }
    }
}