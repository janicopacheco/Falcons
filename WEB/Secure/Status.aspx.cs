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
    public partial class Status : System.Web.UI.Page
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
            StatusBO entityBO = new StatusBO();
            dt = entityBO.SelectAll();

            if (dt.Rows.Count < 1)
            {
                DataRow toInsert = dt.NewRow();

                dt.Rows.InsertAt(toInsert, 0);
            }

            GridView1.DataSource = dt;
            GridView1.DataBind();

          
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            BindDataGrid();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            ENTITY.Status entity = new ENTITY.Status();
            StatusBO entityBO = new StatusBO();

            try { entity.Id = int.Parse(GridView1.DataKeys[e.RowIndex].Values[0].ToString()); }
            catch { }
            try { entity.Updater = new Guid(Membership.GetUser().ProviderUserKey.ToString()); }
            catch (Exception) { };

            entityBO.Delete(entity);

            if (entityBO.IsSuccessful)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Record has been successfully deleted.');", true);
                GridView1.EditIndex = -1;
                BindDataGrid();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('" + entityBO.TransactionMessage + "');", true);
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label Labelname = (Label)e.Row.FindControl("Labelname");
                LinkButton LnkButtonDelete = (LinkButton)e.Row.FindControl("LnkButtonDelete");
                LinkButton LnkButtonEdit = (LinkButton)e.Row.FindControl("LnkButtonEdit");
                LnkButtonEdit.PostBackUrl = "StatusForm.aspx?id=" + GridView1.DataKeys[e.Row.RowIndex].Values[0].ToString();

                if (string.IsNullOrEmpty(Labelname.Text))
                {
                    LnkButtonDelete.CssClass = LnkButtonDelete.CssClass + " disabled";
                    LnkButtonEdit.CssClass = LnkButtonEdit.CssClass + " disabled";
                }
            }
        }
    }
}