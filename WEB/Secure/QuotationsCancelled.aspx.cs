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
    public partial class QuotationsCancelled : System.Web.UI.Page
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
            Quotation entity = new Quotation();
            QuotationBO entityBO = new QuotationBO();

            try { entity.Quotation_no = txtSearchQuotationNo.Text.ToString().Trim(); }
            catch { }
            try { entity.Clientname = txtSearchClient.Text.ToString().Trim(); }
            catch { }
            try { entity.Shipmentname = txtSearchShipment.Text.ToString().Trim(); }
            catch { }
            try { entity.Description = txtSearchDescription.Text.ToString().Trim(); }
            catch { }
            try { entity.Statusname = txtSearchStatus.Text.ToString().Trim(); }
            catch { }

            dt = entityBO.SearchCancelled(entity);

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
                LinkButton LnkButtonEdit = (LinkButton)e.Row.FindControl("LnkButtonEdit");
                LnkButtonEdit.PostBackUrl = "QuotationsForm.aspx?id=" + GridView1.DataKeys[e.Row.RowIndex].Values[0].ToString();

                Label LabelDescription = (Label)e.Row.FindControl("LabelDescription");

                if (string.IsNullOrEmpty(LabelDescription.Text))
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