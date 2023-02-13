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
    public partial class Projects : System.Web.UI.Page
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
            Project entity = new Project();
            ProjectBO entityBO = new ProjectBO();

            try { entity.Quotation_no = txtSearchQuotationNo.Text.ToString().Trim(); }
            catch { }

            dt = entityBO.Search(entity);

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

        
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hdnQuotationId = (HiddenField)e.Row.FindControl("hdnQuotationId");
                LinkButton LnkButtonEdit = (LinkButton)e.Row.FindControl("LnkButtonEdit");
                LnkButtonEdit.PostBackUrl = "QuotationsForm.aspx?id=" + hdnQuotationId.Value.ToString();

                Label Labelproject_no = (Label)e.Row.FindControl("Labelproject_no");

                if (string.IsNullOrEmpty(Labelproject_no.Text))
                {
                    LnkButtonEdit.CssClass = LnkButtonEdit.CssClass + " disabled";
                }
            }
        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            BindDataGrid();

        }
    }
}