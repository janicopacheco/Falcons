using ENTITY;
using PROCESS;
using System;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using System.IO;
using iText.IO.Image;
using iText.Kernel.Geom;
using iText.Layout.Borders;
using iText.Kernel.Colors;

namespace Falcon.Secure
{
    public partial class QuotationsForm : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropDownClient();
                BindDropDownShipment();
                BindDropDownStatus();
                BindDropDownCurrency();

                //Container
                BindDataGrid4();
                BindDropDownContainer();

                if (Request.QueryString["id"] != null)
                {
                    Panel1.Visible = true;
                    DataTable dt = new DataTable();
                    Quotation entity = new Quotation();
                    QuotationBO entityBO = new QuotationBO();

                    try { entity.Id = int.Parse(Request.QueryString["id"].ToString()); }
                    catch { }

                    dt = entityBO.Select(entity);

                    foreach (DataRow dr in dt.Rows)
                    {
                        try { DDLClient.SelectedValue = dr["clientid"].ToString(); }
                        catch { }
                        try { DDLShipment.SelectedValue = dr["shipmentid"].ToString(); }
                        catch { }

                        if (DDLShipment.SelectedItem.Text.Contains("LCL"))
                        {
                            PanelVolume.Visible = true;
                            PanelContainer.Visible = false;
                        }
                        else
                        {
                            PanelVolume.Visible = false;
                            PanelContainer.Visible = true;

                        }

                        TextBoxDescription.Text = dr["description"].ToString();
                        TextBoxWeight.Text = dr["weight"].ToString();
                        TextBoxDimension.Text = dr["dimension"].ToString();
                        TextBoxVolume.Text = dr["volume"].ToString();
                        TextBoxPOL.Text = dr["pol"].ToString();
                        TextBoxPOD.Text = dr["pod"].ToString();
                        TextBoxPickup.Text = dr["pickup_address"].ToString();
                        TextBoxCarrier.Text = dr["carrier"].ToString();

                        try { TextBoxTransit.Text = DateTime.Parse(dr["transit_time"].ToString()).ToString("yyyy-MM-dd"); }
                        catch { }

                        try { DropDownListCargo.SelectedValue = dr["nature_of_cargo"].ToString(); }
                        catch { }

                        TextBoxRateValidity.Text = dr["rate_validity"].ToString();
                        TextBoxPaymentTerms.Text = dr["payment_terms"].ToString();
                        try { DDLCurrency.SelectedValue = dr["exchange_currency"].ToString(); }
                        catch { }

                        TextBoxRate.Text = dr["exchange_rate"].ToString();
                        try { DDLStatus.SelectedValue = dr["statusid"].ToString(); }
                        catch { }

                        TextBoxPreparedBy.Text = dr["preparedby"].ToString();
                        TextBoxPosition.Text = dr["position"].ToString();

                        try { TextBoxDate.Text = DateTime.Parse(dr["quotation_date"].ToString()).ToString("yyyy-MM-dd"); }
                        catch { }
                    }

                    //Freight Charges
                    BindDataGrid1();
                    BindDropDownFreight();

                    //Origin Charges
                    BindDataGrid2();
                    BindDropDownOrigin();

                    //Local Charges
                    BindDataGrid3();
                    BindDropDownLocal();
                }
                else
                {
                    Panel1.Visible = false;
                    LnkBtnDownload.Visible = false;

                    PanelVolume.Visible = false;
                }
            }
        }


        public void GetEarnings()
        {
            DataTable dt = new DataTable();
            Quotation entity = new Quotation();
            QuotationBO entityBO = new QuotationBO();

            try { entity.Id = int.Parse(Request.QueryString["id"].ToString()); }
            catch { }

            dt = entityBO.SelectEarnings(entity);

            foreach (DataRow dr in dt.Rows)
            {
                lblEarnings.Text = dr["total_earnings"].ToString();
            }
        }

        #region Quotation Details
        public void BindDropDownClient()
        {
            DataTable dt = new DataTable();
            ClientBO entityBO = new ClientBO();

            dt = entityBO.SelectAll();
            DataRow toInsert = dt.NewRow();
            dt.Rows.InsertAt(toInsert, 0);

            DDLClient.DataSource = dt;
            DDLClient.DataBind();
        }

        public void BindDropDownShipment()
        {
            DataTable dt = new DataTable();
            ShipmentBO entityBO = new ShipmentBO();

            dt = entityBO.SelectAll();
            DataRow toInsert = dt.NewRow();
            dt.Rows.InsertAt(toInsert, 0);

            DDLShipment.DataSource = dt;
            DDLShipment.DataBind();
        }

        public void BindDropDownStatus()
        {
            DataTable dt = new DataTable();
            StatusBO entityBO = new StatusBO();

            dt = entityBO.SelectAll();
            DataRow toInsert = dt.NewRow();
            dt.Rows.InsertAt(toInsert, 0);

            DDLStatus.DataSource = dt;
            DDLStatus.DataBind();
        }

        public void BindDropDownCurrency()
        {
            DataTable dt = new DataTable();
            CurrencyBO entityBO = new CurrencyBO();

            dt = entityBO.SelectAll();
            DataRow toInsert = dt.NewRow();
            dt.Rows.InsertAt(toInsert, 0);

            DDLCurrency.DataSource = dt;
            DDLCurrency.DataBind();
        }



        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            Quotation entity = new Quotation();
            QuotationBO entityBO = new QuotationBO();

            if (Request.QueryString["id"] != null)
            {
                try { entity.Id = int.Parse(Request.QueryString["id"].ToString()); }
                catch { }
                try { entity.Clientid = int.Parse(DDLClient.SelectedValue.ToString()); }
                catch { }
                try { entity.Shipmentid = int.Parse(DDLShipment.SelectedValue.ToString()); }
                catch { }
                try { entity.Description = TextBoxDescription.Text.ToString().Trim(); }
                catch { }
                try { entity.Weight = TextBoxWeight.Text.ToString().Trim(); }
                catch { }
                try { entity.Dimension = TextBoxDimension.Text.ToString().Trim(); }
                catch { }
                try { entity.Volume = TextBoxVolume.Text.ToString().Trim(); }
                catch { }
                try { entity.Pol = TextBoxPOL.Text.ToString().Trim(); }
                catch { }
                try { entity.Pod = TextBoxPOD.Text.ToString().Trim(); }
                catch { }
                try { entity.Pickup_address = TextBoxPickup.Text.ToString().Trim(); }
                catch { }
                try { entity.Carrier = TextBoxCarrier.Text.ToString().Trim(); }
                catch { }
                try { entity.Transit_time = DateTime.Parse(TextBoxTransit.Text.ToString().Trim()); }
                catch { }
                try { entity.Nature_of_cargo = DropDownListCargo.SelectedValue.ToString(); }
                catch { }
                try { entity.Rate_validity = TextBoxRateValidity.Text.ToString().Trim(); }
                catch { }
                try { entity.Payment_terms = TextBoxPaymentTerms.Text.ToString().Trim(); }
                catch { }
                try { entity.Exchange_currency = DDLCurrency.SelectedValue.ToString().Trim(); }
                catch { }
                try { entity.Exchange_rate = double.Parse(TextBoxRate.Text.ToString().Trim()); }
                catch { }
                try { entity.Statusid = int.Parse(DDLStatus.SelectedValue.ToString()); }
                catch { }
                try { entity.Updater = new Guid(Membership.GetUser().ProviderUserKey.ToString()); }
                catch (Exception) { };

                try { entity.Preparedby = TextBoxPreparedBy.Text.ToString().Trim(); }
                catch { }
                try { entity.Position = TextBoxPosition.Text.ToString().Trim(); }
                catch { }
                try { entity.Quotation_date = DateTime.Parse(TextBoxDate.Text.ToString().Trim()); }
                catch { }

                entityBO.Update(entity);
            }
            else
            {
                if (DDLShipment.SelectedItem.Text.Contains("FCL"))
                {
                    string empty_container = string.Empty;

                    foreach (GridViewRow grr in GridView4.Rows)
                    {
                        Label Labelcontainer_name = (Label)grr.FindControl("Labelcontainer_name");
                        empty_container += Labelcontainer_name.Text.ToString().Trim();

                    }

                    if (string.IsNullOrEmpty(empty_container))
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('" + "- At least 1 container is needed." + "');", true);
                        return;
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(TextBoxVolume.Text.ToString()))
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('" + "- Chargeable Weight is required." + "');", true);
                        return;
                    }
                }

                try { entity.Clientid = int.Parse(DDLClient.SelectedValue.ToString()); }
                catch { }
                try { entity.Shipmentid = int.Parse(DDLShipment.SelectedValue.ToString()); }
                catch { }
                try { entity.Description = TextBoxDescription.Text.ToString().Trim(); }
                catch { }
                try { entity.Weight = TextBoxWeight.Text.ToString().Trim(); }
                catch { }
                try { entity.Dimension = TextBoxDimension.Text.ToString().Trim(); }
                catch { }
                try { entity.Volume = TextBoxVolume.Text.ToString().Trim(); }
                catch { }
                try { entity.Pol = TextBoxPOL.Text.ToString().Trim(); }
                catch { }
                try { entity.Pod = TextBoxPOD.Text.ToString().Trim(); }
                catch { }
                try { entity.Pickup_address = TextBoxPickup.Text.ToString().Trim(); }
                catch { }
                try { entity.Carrier = TextBoxCarrier.Text.ToString().Trim(); }
                catch { }
                try { entity.Transit_time = DateTime.Parse(TextBoxTransit.Text.ToString().Trim()); }
                catch { }
                try { entity.Nature_of_cargo = DropDownListCargo.SelectedValue.ToString(); }
                catch { }
                try { entity.Rate_validity = TextBoxRateValidity.Text.ToString().Trim(); }
                catch { }
                try { entity.Payment_terms = TextBoxPaymentTerms.Text.ToString().Trim(); }
                catch { }
                try { entity.Exchange_currency = DDLCurrency.SelectedValue.ToString().Trim(); }
                catch { }
                try { entity.Exchange_rate = double.Parse(TextBoxRate.Text.ToString().Trim()); }
                catch { }
                try { entity.Statusid = int.Parse(DDLStatus.SelectedValue.ToString()); }
                catch { }
                try { entity.Creator = new Guid(Membership.GetUser().ProviderUserKey.ToString()); }
                catch (Exception) { };

                try { entity.Preparedby = TextBoxPreparedBy.Text.ToString().Trim(); }
                catch { }
                try { entity.Position = TextBoxPosition.Text.ToString().Trim(); }
                catch { }
                try { entity.Quotation_date = DateTime.Parse(TextBoxDate.Text.ToString().Trim()); }
                catch { }

                int id = entityBO.Insert(entity);

                if (entityBO.IsSuccessful)
                {
                    Quotation_container entity2 = new Quotation_container();
                    Quotation_containerBO entityBO2 = new Quotation_containerBO();

                    foreach (GridViewRow row in GridView4.Rows)
                    {
                        HiddenField hdnContainerId = (HiddenField)row.FindControl("hdnContainerId");
                        Label Labelcontainer_name = (Label)row.FindControl("Labelcontainer_name");
                        Label Labelqty = (Label)row.FindControl("Labelqty");

                        try { entity2.Container_id = int.Parse(hdnContainerId.Value); }
                        catch { }
                        try { entity2.Quotation_id = id; }
                        catch { }
                        try { entity2.Qty = int.Parse(Labelqty.Text.ToString()); }
                        catch { }
                        try { entity2.Creator = new Guid(Membership.GetUser().ProviderUserKey.ToString()); }
                        catch { };

                        entityBO2.Insert(entity2);

                    }
                }
            }


            if (entityBO.IsSuccessful)
            {
                if (Request.QueryString["id"] != null)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Record has been successfully saved.');", true);
                    BindDropDownFreight();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Record has been successfully saved.'); window.location = 'Quotations.aspx';", true);
                }

            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('" + entityBO.TransactionMessage + "');", true);
            }
        }

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Quotations.aspx");
        }

        #endregion

        #region Freight Charges

        private void BindDataGrid1()
        {
            DataTable dt = new DataTable();
            Quotation_freight_charges entity = new Quotation_freight_charges();
            Quotation_freight_chargesBO entityBO = new Quotation_freight_chargesBO();

            try { entity.Quotationid = int.Parse(Request.QueryString["id"].ToString()); }
            catch { }

            dt = entityBO.Select(entity);

            if (dt.Rows.Count < 1)
            {
                DataRow toInsert = dt.NewRow();

                dt.Rows.InsertAt(toInsert, 0);
            }

            GridView1.DataSource = dt;
            GridView1.DataBind();

            double total = 0;

            foreach (DataRow dr in dt.Rows)
            {
                try { total += double.Parse(dr["total_amount"].ToString()); }
                catch { }
            }

            lblFreightTotal.Text = total.ToString("N");

            RepeaterF.DataSource = dt;
            RepeaterF.DataBind();

            GetEarnings();
        }

        private void BindDropDownFreight()
        {
            ParticularBO entityBO = new ParticularBO();
            DataTable dt = new DataTable();

            dt = entityBO.SelectAll();
            DataRow toInsert2 = dt.NewRow();
            dt.Rows.InsertAt(toInsert2, 0);

            DDLFreight.DataSource = dt;
            DDLFreight.DataBind();

            DataTable dt2 = new DataTable();
            CurrencyBO currencyBO = new CurrencyBO();

            dt2 = currencyBO.SelectAll();

            //dt2.Clear();
            //dt2.Columns.Add("id");
            //dt2.Columns.Add("name");

            //DataRow newrow = dt2.NewRow();
            //newrow["id"] = TextBoxRate.Text.ToString();
            //newrow["name"] = DDLCurrency.SelectedValue.ToString();
            //dt2.Rows.Add(newrow);

            //newrow = dt2.NewRow();
            //newrow["id"] = "PHP";
            //newrow["name"] = "PHP";
            //dt2.Rows.Add(newrow);

            DataRow toInsert = dt2.NewRow();
            dt2.Rows.InsertAt(toInsert, 0);

            DDLFCurrency.DataSource = dt2;
            DDLFCurrency.DataBind();

            TextBoxFVolume.Text = TextBoxVolume.Text;

            CheckShipment();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            BindDataGrid1();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Quotation_freight_charges entity = new Quotation_freight_charges();
            Quotation_freight_chargesBO entityBO = new Quotation_freight_chargesBO();

            try { entity.Id = int.Parse(GridView1.DataKeys[e.RowIndex].Values[0].ToString()); }
            catch { }
            try { entity.Updater = new Guid(Membership.GetUser().ProviderUserKey.ToString()); }
            catch (Exception) { };

            entityBO.Delete(entity);

            if (entityBO.IsSuccessful)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Record has been successfully deleted.');", true);
                GridView1.EditIndex = -1;
                BindDataGrid1();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('" + entityBO.TransactionMessage + "');", true);
            }

        }

        protected void BtnFSave_Click(object sender, EventArgs e)
        {
            Quotation_freight_charges entity = new Quotation_freight_charges();
            Quotation_freight_chargesBO entityBO = new Quotation_freight_chargesBO();

            try { entity.Quotationid = int.Parse(Request.QueryString["id"].ToString()); }
            catch { }
            try { entity.Particularid = int.Parse(DDLFreight.SelectedValue.ToString()); }
            catch { }
            try { entity.Currency = DDLFCurrency.SelectedItem.Text.ToString(); }
            catch { }
            try { entity.Unit_price = double.Parse(TextBoxFUnitPrice.Text.ToString().Trim()); }
            catch { }
            try
            {
                if (PanelFVolume.Visible)
                {
                    entity.Qty = double.Parse(TextBoxFVolume.Text.ToString());
                }
                else
                {
                    string qty = DDLFContainer.SelectedItem.ToString().Split('-')[1].Trim().Replace(" ", "");
                    entity.Qty = double.Parse(qty);
                }
                //entity.Qty = PanelFVolume.Visible ? double.Parse(TextBoxFVolume.Text.ToString()) : double.Parse(DDLFContainer.SelectedValue.ToString()); 
            }
            catch { }
            try { entity.Total_amount = double.Parse(TextBoxFTotalAmount.Text.ToString().Trim()); }
            catch { }
            try
            {
                entity.Remarks = PanelFVolume.Visible ? TextBoxFRemarks.Text.ToString() :
                  DDLFContainer.SelectedItem.ToString().Split('-')[0].Trim().Replace(" ", "") + " - " + TextBoxFRemarks.Text.ToString();
            }
            catch { }
            try { entity.Creator = new Guid(Membership.GetUser().ProviderUserKey.ToString()); }
            catch { }
            try { entity.Agent_amount = double.Parse(TextBoxFEstimate.Text.ToString().Trim()); }
            catch { }
            try { entity.Container_id = int.Parse(DDLFContainer.SelectedValue.ToString()); }
            catch { }
            try { entity.Updater = new Guid(Membership.GetUser().ProviderUserKey.ToString()); }
            catch { }
            try { entity.Id = int.Parse(lblFreightId.Text.ToString()); }
            catch { }

            if (lblFreightId.Text == "0")
            {
                entityBO.Insert(entity);
            }
            else
            {
                entityBO.Update(entity);
            }

            if (entityBO.IsSuccessful)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Record has been successfully saved.');", true);
                GridView1.EditIndex = -1;
                BindDataGrid1();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('" + entityBO.TransactionMessage + "');", true);
            }
        }


        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            BindDataGrid1();

            DataTable dt = new DataTable();
            GridViewRow gvr = GridView1.Rows[GridView1.EditIndex];
            DropDownList FreightEdit = gvr.FindControl("FreightEdit") as DropDownList;
            HiddenField HdnDDLFrieghtEdit = gvr.FindControl("HdnDDLFrieghtEdit") as HiddenField;
            ParticularBO entityBO = new ParticularBO();

            dt = entityBO.SelectAll();

            FreightEdit.DataSource = dt;
            FreightEdit.DataBind();

            try { FreightEdit.SelectedValue = HdnDDLFrieghtEdit.Value; }
            catch { }
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Quotation_freight_charges entity = new Quotation_freight_charges();
            Quotation_freight_chargesBO entityBO = new Quotation_freight_chargesBO();

            try { entity.Id = int.Parse(GridView1.DataKeys[e.RowIndex].Values[0].ToString()); }
            catch { }
            try { entity.Quotationid = int.Parse(Request.QueryString["id"].ToString()); }
            catch { }
            try { entity.Particularid = int.Parse(((DropDownList)GridView1.Rows[e.RowIndex].FindControl("FreightEdit")).SelectedValue.ToString()); }
            catch { }
            try { entity.Currency = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBoxFCurrencyEdit")).Text.ToString().Trim(); }
            catch { }
            try { entity.Unit_price = double.Parse(((TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBoxFUnitPriceEdit")).Text.ToString().Trim()); }
            catch { }
            try { entity.Qty = int.Parse(((TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBoxFQtyEdit")).Text.ToString().Trim()); }
            catch { }
            try { entity.Total_amount = double.Parse(((TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBoxFTotalAmountEdit")).Text.ToString().Trim()); }
            catch { }
            try { entity.Remarks = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBoxFRemarksEdit")).Text.ToString().Trim(); }
            catch { }
            try { entity.Updater = new Guid(System.Web.Security.Membership.GetUser().ProviderUserKey.ToString()); }
            catch { }

            entityBO.Update(entity);

            if (entityBO.IsSuccessful)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Record has been successfully saved.');", true);
                GridView1.EditIndex = -1;
                BindDataGrid1();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('" + entityBO.TransactionMessage + "');", true);
            }
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            BindDataGrid1();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.RowState.ToString().ToLower() == "normal")
                {
                    Label Labelparticularname = (Label)e.Row.FindControl("Labelparticularname");
                    LinkButton LnkButtonDelete = (LinkButton)e.Row.FindControl("LnkButtonDelete");
                    LinkButton LnkButtonEdit = (LinkButton)e.Row.FindControl("LnkButtonEdit");

                    HiddenField hdnFreightId = (HiddenField)e.Row.FindControl("hdnFreightId");

                    if (hdnFreightId.Value == "")
                    {
                        LnkButtonDelete.CssClass = LnkButtonDelete.CssClass + " disabled";
                        LnkButtonEdit.CssClass = LnkButtonEdit.CssClass + " disabled";
                    }
                }
            }
        }

        protected void TextBoxFUnitPrice_TextChanged(object sender, EventArgs e)
        {
            ComputeFreight();
        }

        protected void DDLFContainer_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComputeFreight();
        }

        protected void DDLFCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComputeFreight();

            if (DDLFCurrency.SelectedItem.Text.ToString().ToLower() == "php")
            {
                TextBoxFEx.Text = string.Empty;
                TextBoxFEx.Enabled = false;
            }
            else
            {
                TextBoxFEx.Enabled = true;
            }
        }

        protected void TextBoxFVolume_TextChanged(object sender, EventArgs e)
        {
            ComputeFreight();
        }

        protected void TextBoxFEx_TextChanged(object sender, EventArgs e)
        {
            ComputeFreight();
        }

        private void ComputeFreight()
        {
            if (DDLFCurrency.SelectedItem.Text.ToString().ToLower() == "php")
            {
                double qty = 0;
                double unit_price = 0;

                try
                {
                    if (PanelFVolume.Visible)
                    {
                        qty = double.Parse(TextBoxFVolume.Text.ToString());
                    }
                    else
                    {
                        string arr_qty = DDLFContainer.SelectedItem.ToString().Split('-')[1].Trim().Replace(" ", "");
                        qty = double.Parse(arr_qty);
                    }
                }
                catch { }
                try { unit_price = double.Parse(TextBoxFUnitPrice.Text.ToString()); }
                catch { }

                TextBoxFTotalAmount.Text = (qty * unit_price).ToString();
            }
            else
            {
                double qty = 0;
                double unit_price = 0;
                double exchange_rate = 0;

                try
                {
                    if (PanelFVolume.Visible)
                    {
                        qty = double.Parse(TextBoxFVolume.Text.ToString());
                    }
                    else
                    {
                        string arr_qty = DDLFContainer.SelectedItem.ToString().Split('-')[1].Trim().Replace(" ", "");
                        qty = double.Parse(arr_qty);
                    }
                }
                catch { }
                try { unit_price = double.Parse(TextBoxFUnitPrice.Text.ToString()); }
                catch { }
                try { exchange_rate = double.Parse(TextBoxFEx.Text.ToString()); }
                catch { }

                TextBoxFTotalAmount.Text = ((unit_price * exchange_rate) * qty).ToString();
            }

            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "OpenFreight();", true);
        }


        #endregion

        #region Origin Charges
        private void BindDataGrid2()
        {
            DataTable dt = new DataTable();
            Quotation_origin_charges entity = new Quotation_origin_charges();
            Quotation_origin_chargesBO entityBO = new Quotation_origin_chargesBO();

            try { entity.Quotationid = int.Parse(Request.QueryString["id"].ToString()); }
            catch { }

            dt = entityBO.Select(entity);

            if (dt.Rows.Count < 1)
            {
                DataRow toInsert = dt.NewRow();

                dt.Rows.InsertAt(toInsert, 0);
            }

            GridView2.DataSource = dt;
            GridView2.DataBind();

            double total = 0;

            foreach (DataRow dr in dt.Rows)
            {
                try { total += double.Parse(dr["total_amount"].ToString()); }
                catch { }
            }

            lblOriginTotal.Text = total.ToString("N");

            RepeaterO.DataSource = dt;
            RepeaterO.DataBind();

            GetEarnings();
        }

        private void BindDropDownOrigin()
        {
            ParticularBO entityBO = new ParticularBO();
            DataTable dt = new DataTable();

            dt = entityBO.SelectAll();
            DataRow toInsert2 = dt.NewRow();
            dt.Rows.InsertAt(toInsert2, 0);
            DDLOrigin.DataSource = dt;
            DDLOrigin.DataBind();

            CurrencyBO currencyBO = new CurrencyBO();
            DataTable dt2 = new DataTable();
            dt2 = currencyBO.SelectAll();

            //dt2.Clear();
            //dt2.Columns.Add("id");
            //dt2.Columns.Add("name");

            //DataRow newrow = dt2.NewRow();
            //newrow["id"] = TextBoxRate.Text.ToString();
            //newrow["name"] = DDLCurrency.SelectedValue.ToString();
            //dt2.Rows.Add(newrow);

            //newrow = dt2.NewRow();
            //newrow["id"] = "PHP";
            //newrow["name"] = "PHP";
            //dt2.Rows.Add(newrow);

            DataRow toInsert = dt2.NewRow();
            dt2.Rows.InsertAt(toInsert, 0);

            DDLOCurrency.DataSource = dt2;
            DDLOCurrency.DataBind();

            TextBoxOVolume.Text = TextBoxVolume.Text;

            CheckShipment();
        }

        protected void BtnOSave_Click(object sender, EventArgs e)
        {
            Quotation_origin_charges entity = new Quotation_origin_charges();
            Quotation_origin_chargesBO entityBO = new Quotation_origin_chargesBO();

            try { entity.Quotationid = int.Parse(Request.QueryString["id"].ToString()); }
            catch { }
            try { entity.Particularid = int.Parse(DDLOrigin.SelectedValue.ToString()); }
            catch { }
            try { entity.Currency = DDLOCurrency.SelectedItem.Text.ToString(); }
            catch { }
            try { entity.Unit_price = double.Parse(TextBoxOUnitPrice.Text.ToString().Trim()); }
            catch { }
            try
            {
                if (PanelOVolume.Visible)
                {
                    entity.Qty = double.Parse(TextBoxOVolume.Text.ToString());
                }
                else
                {
                    string qty = DDLOContainer.SelectedItem.ToString().Split('-')[1].Trim().Replace(" ", "");
                    entity.Qty = double.Parse(qty);
                }
            }
            catch { }
            try { entity.Total_amount = double.Parse(TextBoxOTotalAmount.Text.ToString().Trim()); }
            catch { }
            try { entity.Remarks = PanelOVolume.Visible ? TextBoxORemarks.Text.ToString() : DDLOContainer.SelectedItem.ToString().Split('-')[0].Trim().Replace(" ", "") + " - " + TextBoxORemarks.Text.ToString(); }
            catch { }
            try { entity.Creator = new Guid(Membership.GetUser().ProviderUserKey.ToString()); }
            catch { }
            try { entity.Agent_amount = double.Parse(TextBoxOEstimate.Text.ToString().Trim()); }
            catch { }
            try { entity.Container_id = int.Parse(DDLOContainer.SelectedValue.ToString()); }
            catch { }
            try { entity.Updater = new Guid(Membership.GetUser().ProviderUserKey.ToString()); }
            catch { }
            try { entity.Id = int.Parse(lblOriginId.Text.ToString()); }
            catch { }

            if (lblOriginId.Text == "0")
            {
                entityBO.Insert(entity);
            }
            else
            {
                entityBO.Update(entity);
            }

            if (entityBO.IsSuccessful)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Record has been successfully saved.');", true);
                GridView2.EditIndex = -1;
                BindDataGrid2();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('" + entityBO.TransactionMessage + "');", true);
            }
        }

        protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView2.PageIndex = e.NewPageIndex;
            BindDataGrid2();
        }

        protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Quotation_origin_charges entity = new Quotation_origin_charges();
            Quotation_origin_chargesBO entityBO = new Quotation_origin_chargesBO();

            try { entity.Id = int.Parse(GridView2.DataKeys[e.RowIndex].Values[0].ToString()); }
            catch { }
            try { entity.Updater = new Guid(Membership.GetUser().ProviderUserKey.ToString()); }
            catch (Exception) { };

            entityBO.Delete(entity);

            if (entityBO.IsSuccessful)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Record has been successfully deleted.');", true);
                GridView2.EditIndex = -1;
                BindDataGrid2();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('" + entityBO.TransactionMessage + "');", true);
            }
        }

        protected void GridView2_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView2.EditIndex = e.NewEditIndex;
            BindDataGrid2();

            DataTable dt = new DataTable();
            GridViewRow gvr = GridView2.Rows[GridView2.EditIndex];
            DropDownList OriginDDLList = gvr.FindControl("OriginDDLList") as DropDownList;
            HiddenField HdnDDLOriginEdit = gvr.FindControl("HdnDDLOriginEdit") as HiddenField;
            ParticularBO entityBO = new ParticularBO();

            dt = entityBO.SelectAll();

            OriginDDLList.DataSource = dt;
            OriginDDLList.DataBind();

            try { OriginDDLList.SelectedValue = HdnDDLOriginEdit.Value; }
            catch { }
        }

        protected void GridView2_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Quotation_origin_charges entity = new Quotation_origin_charges();
            Quotation_origin_chargesBO entityBO = new Quotation_origin_chargesBO();

            try { entity.Id = int.Parse(GridView2.DataKeys[e.RowIndex].Values[0].ToString()); }
            catch { }
            try { entity.Quotationid = int.Parse(Request.QueryString["id"].ToString()); }
            catch { }
            try { entity.Particularid = int.Parse(((DropDownList)GridView2.Rows[e.RowIndex].FindControl("OriginDDLList")).SelectedValue.ToString()); }
            catch { }
            try { entity.Currency = ((TextBox)GridView2.Rows[e.RowIndex].FindControl("TextBoxOCurrencyEdit")).Text.ToString().Trim(); }
            catch { }
            try { entity.Unit_price = double.Parse(((TextBox)GridView2.Rows[e.RowIndex].FindControl("TextBoxOUnitPriceEdit")).Text.ToString().Trim()); }
            catch { }
            try { entity.Qty = int.Parse(((TextBox)GridView2.Rows[e.RowIndex].FindControl("TextBoxOQtyEdit")).Text.ToString().Trim()); }
            catch { }
            try { entity.Total_amount = double.Parse(((TextBox)GridView2.Rows[e.RowIndex].FindControl("TextBoxOTotalAmountEdit")).Text.ToString().Trim()); }
            catch { }
            try { entity.Remarks = ((TextBox)GridView2.Rows[e.RowIndex].FindControl("TextBoxORemarksEdit")).Text.ToString().Trim(); }
            catch { }
            try { entity.Updater = new Guid(Membership.GetUser().ProviderUserKey.ToString()); }
            catch { }

            entityBO.Update(entity);

            if (entityBO.IsSuccessful)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Record has been successfully saved.');", true);
                GridView2.EditIndex = -1;
                BindDataGrid2();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('" + entityBO.TransactionMessage + "');", true);
            }
        }

        protected void GridView2_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView2.EditIndex = -1;
            BindDataGrid2();
        }

        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.RowState.ToString().ToLower() == "normal")
                {
                    Label Labelparticularname = (Label)e.Row.FindControl("Labelparticularname");
                    LinkButton LnkButtonDelete = (LinkButton)e.Row.FindControl("LnkButtonDelete");
                    LinkButton LnkButtonEdit = (LinkButton)e.Row.FindControl("LnkButtonEdit");

                    HiddenField hdnOriginId = (HiddenField)e.Row.FindControl("hdnOriginId");

                    if (hdnOriginId.Value == "")
                    {
                        LnkButtonDelete.CssClass = LnkButtonDelete.CssClass + " disabled";
                        LnkButtonEdit.CssClass = LnkButtonEdit.CssClass + " disabled";
                    }
                }
            }
        }


        protected void DDLOContainer_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComputeOrigin();
        }

        protected void TextBoxOVolume_TextChanged(object sender, EventArgs e)
        {
            ComputeOrigin();
        }

        protected void DDLOCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComputeOrigin();

            if (DDLOCurrency.SelectedItem.Text.ToString().ToLower() == "php")
            {
                TextBoxOEx.Text = string.Empty;
                TextBoxOEx.Enabled = false;
            }
            else
            {
                TextBoxOEx.Enabled = true;
            }
        }

        protected void TextBoxOUnitPrice_TextChanged(object sender, EventArgs e)
        {
            ComputeOrigin();
        }

        protected void TextBoxOEx_TextChanged(object sender, EventArgs e)
        {
            ComputeOrigin();
        }

        private void ComputeOrigin()
        {
            if (DDLOCurrency.SelectedItem.Text.ToString().ToLower() == "php")
            {
                double qty = 0;
                double unit_price = 0;

                try
                {
                    if (PanelOVolume.Visible)
                    {
                        qty = double.Parse(TextBoxOVolume.Text.ToString());
                    }
                    else
                    {
                        string arr_qty = DDLOContainer.SelectedItem.ToString().Split('-')[1].Trim().Replace(" ", "");
                        qty = double.Parse(arr_qty);
                    }
                }
                catch { }
                try { unit_price = double.Parse(TextBoxOUnitPrice.Text.ToString()); }
                catch { }

                TextBoxOTotalAmount.Text = (qty * unit_price).ToString();
            }
            else
            {
                double qty = 0;
                double unit_price = 0;
                double exchange_rate = 0;

                try
                {
                    if (PanelOVolume.Visible)
                    {
                        qty = double.Parse(TextBoxOVolume.Text.ToString());
                    }
                    else
                    {
                        string arr_qty = DDLOContainer.SelectedItem.ToString().Split('-')[1].Trim().Replace(" ", "");
                        qty = double.Parse(arr_qty);
                    }
                }
                catch { }
                try { unit_price = double.Parse(TextBoxOUnitPrice.Text.ToString()); }
                catch { }
                try { exchange_rate = double.Parse(TextBoxOEx.Text.ToString()); }
                catch { }

                TextBoxOTotalAmount.Text = ((unit_price * exchange_rate) * qty).ToString();
            }

            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "OpenOrigin();", true);
        }



        #endregion

        #region Local Charges
        private void BindDataGrid3()
        {
            DataTable dt = new DataTable();
            Quotation_local_charges entity = new Quotation_local_charges();
            Quotation_local_chargesBO entityBO = new Quotation_local_chargesBO();

            try { entity.Quotationid = int.Parse(Request.QueryString["id"].ToString()); }
            catch { }

            dt = entityBO.Select(entity);

            if (dt.Rows.Count < 1)
            {
                DataRow toInsert = dt.NewRow();

                dt.Rows.InsertAt(toInsert, 0);
            }

            GridView3.DataSource = dt;
            GridView3.DataBind();

            double total = 0;

            foreach (DataRow dr in dt.Rows)
            {
                try { total += double.Parse(dr["total_amount"].ToString()); }
                catch { }
            }

            lblLocalTotal.Text = total.ToString("N");

            RepeaterL.DataSource = dt;
            RepeaterL.DataBind();

            GetEarnings();
        }

        private void BindDropDownLocal()
        {
            ParticularBO entityBO = new ParticularBO();
            DataTable dt = new DataTable();

            dt = entityBO.SelectAll();
            DataRow toInsert2 = dt.NewRow();
            dt.Rows.InsertAt(toInsert2, 0);
            DDLLocal.DataSource = dt;
            DDLLocal.DataBind();

            CurrencyBO currencyBO = new CurrencyBO();
            DataTable dt2 = new DataTable();
            dt2 = currencyBO.SelectAll();

            //dt2.Clear();
            //dt2.Columns.Add("id");
            //dt2.Columns.Add("name");

            //DataRow newrow = dt2.NewRow();
            //newrow["id"] = TextBoxRate.Text.ToString();
            //newrow["name"] = DDLCurrency.SelectedValue.ToString();
            //dt2.Rows.Add(newrow);

            //newrow = dt2.NewRow();
            //newrow["id"] = "PHP";
            //newrow["name"] = "PHP";
            //dt2.Rows.Add(newrow);

            DataRow toInsert = dt2.NewRow();
            dt2.Rows.InsertAt(toInsert, 0);

            DDLLCurrency.DataSource = dt2;
            DDLLCurrency.DataBind();

            TextBoxLVolume.Text = TextBoxVolume.Text;

            CheckShipment();
        }

        protected void BtnLSave_Click(object sender, EventArgs e)
        {
            Quotation_local_charges entity = new Quotation_local_charges();
            Quotation_local_chargesBO entityBO = new Quotation_local_chargesBO();

            try { entity.Quotationid = int.Parse(Request.QueryString["id"].ToString()); }
            catch { }
            try { entity.Particularid = int.Parse(DDLLocal.SelectedValue.ToString()); }
            catch { }
            try { entity.Currency = DDLLCurrency.SelectedItem.Text.ToString(); }
            catch { }
            try { entity.Unit_price = double.Parse(TextBoxLUnitPrice.Text.ToString().Trim()); }
            catch { }
            try
            {
                if (PanelLVolume.Visible)
                {
                    entity.Qty = double.Parse(TextBoxLVolume.Text.ToString());
                }
                else
                {
                    string qty = DDLLContainer.SelectedItem.ToString().Split('-')[1].Trim().Replace(" ", "");
                    entity.Qty = double.Parse(qty);
                }
            }
            catch { }
            try { entity.Total_amount = double.Parse(TextBoxLTotalAmount.Text.ToString().Trim()); }
            catch { }
            try { entity.Remarks = PanelLVolume.Visible ? TextBoxLRemarks.Text.ToString() : DDLLContainer.SelectedItem.ToString().Split('-')[0].Trim().Replace(" ", "") + " - " + TextBoxLRemarks.Text.ToString(); }
            catch { }
            try { entity.Creator = new Guid(Membership.GetUser().ProviderUserKey.ToString()); }
            catch { }
            try { entity.Agent_amount = double.Parse(TextBoxLEstimate.Text.ToString().Trim()); }
            catch { }
            try { entity.Container_id = int.Parse(DDLLContainer.SelectedValue.ToString()); }
            catch { }
            try { entity.Updater = new Guid(Membership.GetUser().ProviderUserKey.ToString()); }
            catch { }
            try { entity.Id = int.Parse(lblLocalId.Text.ToString()); }
            catch { }

            if (lblLocalId.Text == "0")
            {
                entityBO.Insert(entity);
            }
            else
            {
                entityBO.Update(entity);
            }

            if (entityBO.IsSuccessful)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Record has been successfully saved.');", true);
                GridView3.EditIndex = -1;
                BindDataGrid3();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('" + entityBO.TransactionMessage + "');", true);
            }
        }


        protected void GridView3_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView3.PageIndex = e.NewPageIndex;
            BindDataGrid3();
        }

        protected void GridView3_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Quotation_local_charges entity = new Quotation_local_charges();
            Quotation_local_chargesBO entityBO = new Quotation_local_chargesBO();

            try { entity.Id = int.Parse(GridView3.DataKeys[e.RowIndex].Values[0].ToString()); }
            catch { }
            try { entity.Updater = new Guid(Membership.GetUser().ProviderUserKey.ToString()); }
            catch (Exception) { };

            entityBO.Delete(entity);

            if (entityBO.IsSuccessful)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Record has been successfully deleted.');", true);
                GridView3.EditIndex = -1;
                BindDataGrid3();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('" + entityBO.TransactionMessage + "');", true);
            }
        }

        protected void GridView3_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView3.EditIndex = e.NewEditIndex;
            BindDataGrid3();

            DataTable dt = new DataTable();
            GridViewRow gvr = GridView3.Rows[GridView3.EditIndex];
            DropDownList LocalDDLList = gvr.FindControl("LocalDDLList") as DropDownList;
            HiddenField HdnDDLLocalEdit = gvr.FindControl("HdnDDLLocalEdit") as HiddenField;
            ParticularBO entityBO = new ParticularBO();

            dt = entityBO.SelectAll();

            LocalDDLList.DataSource = dt;
            LocalDDLList.DataBind();

            try { LocalDDLList.SelectedValue = HdnDDLLocalEdit.Value; }
            catch { }
        }

        protected void GridView3_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Quotation_local_charges entity = new Quotation_local_charges();
            Quotation_local_chargesBO entityBO = new Quotation_local_chargesBO();

            try { entity.Id = int.Parse(GridView3.DataKeys[e.RowIndex].Values[0].ToString()); }
            catch { }
            try { entity.Quotationid = int.Parse(Request.QueryString["id"].ToString()); }
            catch { }
            try { entity.Particularid = int.Parse(((DropDownList)GridView3.Rows[e.RowIndex].FindControl("LocalDDLList")).SelectedValue.ToString()); }
            catch { }
            try { entity.Currency = ((TextBox)GridView3.Rows[e.RowIndex].FindControl("TextBoxLCurrencyEdit")).Text.ToString().Trim(); }
            catch { }
            try { entity.Unit_price = double.Parse(((TextBox)GridView3.Rows[e.RowIndex].FindControl("TextBoxLUnitPriceEdit")).Text.ToString().Trim()); }
            catch { }
            try { entity.Qty = int.Parse(((TextBox)GridView3.Rows[e.RowIndex].FindControl("TextBoxLQtyEdit")).Text.ToString().Trim()); }
            catch { }
            try { entity.Total_amount = double.Parse(((TextBox)GridView3.Rows[e.RowIndex].FindControl("TextBoxLTotalAmountEdit")).Text.ToString().Trim()); }
            catch { }
            try { entity.Remarks = ((TextBox)GridView3.Rows[e.RowIndex].FindControl("TextBoxLRemarksEdit")).Text.ToString().Trim(); }
            catch { }
            try { entity.Updater = new Guid(Membership.GetUser().ProviderUserKey.ToString()); }
            catch { }

            entityBO.Update(entity);

            if (entityBO.IsSuccessful)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Record has been successfully saved.');", true);
                GridView3.EditIndex = -1;
                BindDataGrid3();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('" + entityBO.TransactionMessage + "');", true);
            }
        }

        protected void GridView3_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView3.EditIndex = -1;
            BindDataGrid3();
        }

        protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.RowState.ToString().ToLower() == "normal")
                {
                    Label Labelparticularname = (Label)e.Row.FindControl("Labelparticularname");
                    LinkButton LnkButtonDelete = (LinkButton)e.Row.FindControl("LnkButtonDelete");
                    LinkButton LnkButtonEdit = (LinkButton)e.Row.FindControl("LnkButtonEdit");

                    HiddenField hdnLocalId = (HiddenField)e.Row.FindControl("hdnLocalId");

                    if (hdnLocalId.Value == "")
                    {
                        LnkButtonDelete.CssClass = LnkButtonDelete.CssClass + " disabled";
                        LnkButtonEdit.CssClass = LnkButtonEdit.CssClass + " disabled";
                    }
                }
            }
        }

        protected void DDLLContainer_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComputeLocal();
        }

        protected void TextBoxLVolume_TextChanged(object sender, EventArgs e)
        {
            ComputeLocal();
        }

        protected void DDLLCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComputeLocal();

            if (DDLLCurrency.SelectedItem.Text.ToString().ToLower() == "php")
            {
                TextBoxLEx.Text = string.Empty;
                TextBoxLEx.Enabled = false;
            }
            else
            {
                TextBoxLEx.Enabled = true;
            }
        }

        protected void TextBoxLUnitPrice_TextChanged(object sender, EventArgs e)
        {
            ComputeLocal();
        }

        protected void TextBoxLEx_TextChanged(object sender, EventArgs e)
        {
            ComputeLocal();
        }

        private void ComputeLocal()
        {
            if (DDLLCurrency.SelectedItem.Text.ToString().ToLower() == "php")
            {
                double qty = 0;
                double unit_price = 0;

                try
                {
                    if (PanelLVolume.Visible)
                    {
                        qty = double.Parse(TextBoxLVolume.Text.ToString());
                    }
                    else
                    {
                        string arr_qty = DDLLContainer.SelectedItem.ToString().Split('-')[1].Trim().Replace(" ", "");
                        qty = double.Parse(arr_qty);
                    }
                }
                catch { }
                try { unit_price = double.Parse(TextBoxLUnitPrice.Text.ToString()); }
                catch { }

                TextBoxLTotalAmount.Text = (qty * unit_price).ToString();
            }
            else
            {
                double qty = 0;
                double unit_price = 0;
                double exchange_rate = 0;

                try
                {
                    if (PanelLVolume.Visible)
                    {
                        qty = double.Parse(TextBoxLVolume.Text.ToString());
                    }
                    else
                    {
                        string arr_qty = DDLLContainer.SelectedItem.ToString().Split('-')[1].Trim().Replace(" ", "");
                        qty = double.Parse(arr_qty);
                    }
                }
                catch { }
                try { unit_price = double.Parse(TextBoxLUnitPrice.Text.ToString()); }
                catch { }
                try { exchange_rate = double.Parse(TextBoxLEx.Text.ToString()); }
                catch { }

                TextBoxLTotalAmount.Text = ((unit_price * exchange_rate) * qty).ToString();
            }

            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "OpenLocal();", true);
        }


        #endregion


        #region Container
        private void BindDataGrid4()
        {
            DataTable dt = new DataTable();
            Quotation_container entity = new Quotation_container();
            Quotation_containerBO entityBO = new Quotation_containerBO();

            try { entity.Quotation_id = int.Parse(Request.QueryString["id"].ToString()); }
            catch { }

            dt = entityBO.SelectByQuotationId(entity);

            if (dt.Rows.Count < 1)
            {
                DataRow toInsert = dt.NewRow();

                dt.Rows.InsertAt(toInsert, 0);
            }

            GridView4.DataSource = dt;
            GridView4.DataBind();


            DataRow toInsert2 = dt.NewRow();
            dt.Rows.InsertAt(toInsert2, 0);

            DDLFContainer.DataSource = dt;
            DDLFContainer.DataBind();

            DDLOContainer.DataSource = dt;
            DDLOContainer.DataBind();

            DDLLContainer.DataSource = dt;
            DDLLContainer.DataBind();
        }

        private void BindDropDownContainer()
        {
            ContainerBO entityBO = new ContainerBO();
            DataTable dt = new DataTable();

            dt = entityBO.SelectAll();

            DataRow toInsert = dt.NewRow();

            dt.Rows.InsertAt(toInsert, 0);

            DDLContainer.DataSource = dt;
            DDLContainer.DataBind();
        }


        protected void DDLShipment_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckShipment();
        }

        protected void GridView4_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                Quotation_container entity = new Quotation_container();
                Quotation_containerBO entityBO = new Quotation_containerBO();

                try { entity.Id = int.Parse(GridView4.DataKeys[e.RowIndex].Values[0].ToString()); }
                catch { }
                try { entity.Updater = new Guid(Membership.GetUser().ProviderUserKey.ToString()); }
                catch (Exception) { };

                entityBO.Delete(entity);

                if (entityBO.IsSuccessful)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Record has been successfully deleted.');", true);
                    GridView4.EditIndex = -1;
                    BindDataGrid4();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('" + entityBO.TransactionMessage + "');", true);
                }
            }
            else
            {
                DataTable dt = new DataTable();
                dt.Clear();
                dt.Columns.Add("id");
                dt.Columns.Add("container_id");
                dt.Columns.Add("container_name");
                dt.Columns.Add("qty");


                string id = GridView4.DataKeys[e.RowIndex].Values[0].ToString();

                foreach (GridViewRow row in GridView4.Rows)
                {
                    HiddenField hdnContainerId = (HiddenField)row.FindControl("hdnContainerId");
                    Label Labelcontainer_name = (Label)row.FindControl("Labelcontainer_name");
                    Label Labelqty = (Label)row.FindControl("Labelqty");

                    string theDataKey = GridView4.DataKeys[row.RowIndex].Value.ToString();

                    if (id != theDataKey)
                    {
                        DataRow newrow = dt.NewRow();
                        newrow["id"] = dt.Rows.Count + 1;
                        newrow["container_id"] = hdnContainerId.Value;
                        newrow["container_name"] = Labelcontainer_name.Text.ToString();
                        newrow["qty"] = Labelqty.Text.ToString();

                        dt.Rows.Add(newrow);
                    }
                }

                if (dt.Rows.Count == 0)
                {
                    DataRow newrow = dt.NewRow();
                    newrow["container_name"] = "";
                    dt.Rows.Add(newrow);
                }

                GridView4.DataSource = dt;
                GridView4.DataBind();
            }



        }


        protected void GridView4_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.RowState.ToString().ToLower() == "normal")
                {
                    Label Labelcontainer_name = (Label)e.Row.FindControl("Labelcontainer_name");
                    LinkButton LnkButtonDelete = (LinkButton)e.Row.FindControl("LnkButtonDelete");

                    if (string.IsNullOrEmpty(Labelcontainer_name.Text))
                    {
                        LnkButtonDelete.CssClass = LnkButtonDelete.CssClass + " disabled";
                    }
                }
            }
        }


        protected void BtnContainer_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                Quotation_container entity = new Quotation_container();
                Quotation_containerBO entityBO = new Quotation_containerBO();

                try { entity.Quotation_id = int.Parse(Request.QueryString["id"]); }
                catch { }
                try { entity.Container_id = int.Parse(DDLContainer.SelectedValue.ToString()); }
                catch { }
                try { entity.Qty = int.Parse(txtContainerQty.Text); }
                catch { }

                entityBO.Insert(entity);

                if (entityBO.IsSuccessful)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Record has been successfully saved.');", true);
                    GridView4.EditIndex = -1;
                    BindDataGrid4();
                    LocalContainerField();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('" + entityBO.TransactionMessage + "');", true);
                }
            }
            else
            {
                DataTable dt = new DataTable();
                dt.Clear();
                dt.Columns.Add("id");
                dt.Columns.Add("container_id");
                dt.Columns.Add("container_name");
                dt.Columns.Add("qty");

                foreach (GridViewRow row in GridView4.Rows)
                {
                    HiddenField hdnContainerId = (HiddenField)row.FindControl("hdnContainerId");
                    Label Labelcontainer_name = (Label)row.FindControl("Labelcontainer_name");
                    Label Labelqty = (Label)row.FindControl("Labelqty");


                    if (!string.IsNullOrEmpty(Labelcontainer_name.Text))
                    {
                        DataRow newrow = dt.NewRow();
                        newrow["id"] = dt.Rows.Count + 1;
                        newrow["container_id"] = hdnContainerId.Value;
                        newrow["container_name"] = Labelcontainer_name.Text.ToString();
                        newrow["qty"] = Labelqty.Text.ToString();

                        dt.Rows.Add(newrow);
                    }
                }

                DataRow newrows = dt.NewRow();
                newrows["id"] = dt.Rows.Count + 1;
                newrows["container_id"] = DDLContainer.SelectedValue.ToString();
                newrows["container_name"] = DDLContainer.SelectedItem.ToString();
                newrows["qty"] = txtContainerQty.Text;

                dt.Rows.Add(newrows);

                GridView4.DataSource = dt;
                GridView4.DataBind();
                LocalContainerField();
            }



        }

        public void LocalContainerField()
        {
            txtContainerQty.Text = string.Empty;
        }


        private void CheckShipment()
        {
            if (DDLShipment.SelectedItem.Text.Contains("LCL"))
            {
                PanelVolume.Visible = true;
                PanelContainer.Visible = false;

                //Freight
                PanelFVolume.Visible = true;
                PanelFContainer.Visible = false;
                RequiredFieldValidator18.Enabled = true;
                RequiredFieldValidator17.Enabled = false;

                //ORIGIN
                PanelOVolume.Visible = true;
                PanelOContainer.Visible = false;
                RequiredOVolume.Enabled = true;
                RequiredOContainer.Enabled = false;

                //Local
                PanelLVolume.Visible = true;
                PanelLContainer.Visible = false;
                RequiredLVolume.Enabled = true;
                RequiredLContainer.Enabled = false;

            }
            else
            {
                PanelVolume.Visible = false;
                PanelContainer.Visible = true;

                //Freight
                PanelFVolume.Visible = false;
                PanelFContainer.Visible = true;
                RequiredFieldValidator18.Enabled = false;
                RequiredFieldValidator17.Enabled = true;

                //ORIGIN
                PanelOVolume.Visible = false;
                PanelOContainer.Visible = true;
                RequiredOVolume.Enabled = false;
                RequiredOContainer.Enabled = true;

                //LOCAL
                PanelLVolume.Visible = false;
                PanelLContainer.Visible = true;
                RequiredLVolume.Enabled = false;
                RequiredLContainer.Enabled = true;
            }
        }


        #endregion

        #region Download PDF
        protected void LnkBtnDownload_Click(object sender, EventArgs e)
        {
            string filename = string.Empty;
            DataTable dt = new DataTable();
            Quotation entity = new Quotation();
            QuotationBO entityBO = new QuotationBO();

            try { entity.Id = int.Parse(Request.QueryString["id"].ToString()); }
            catch { }

            dt = entityBO.Select(entity);

            string q_date = string.Empty;
            string q_no = string.Empty;
            string q_client = string.Empty;
            string q_shipment = string.Empty;
            string q_description = string.Empty;
            string q_weight = string.Empty;
            string q_dimension = string.Empty;
            string q_volume = string.Empty;
            string q_pol = string.Empty;
            string q_pod = string.Empty;
            string q_pickup = string.Empty;
            string q_carrier = string.Empty;
            string q_transittime = string.Empty;
            string q_natureofcargo = string.Empty;
            string q_ratevalidity = string.Empty;
            string q_paymentterms = string.Empty;
            string q_exchangerate = string.Empty;

            string q_preparedby = string.Empty;
            string q_position = string.Empty;

            foreach (DataRow dr in dt.Rows)
            {
                try { q_date = DateTime.Parse(dr["quotation_date"].ToString()).ToString("MMMM dd, yyyy"); }
                catch { }
                q_no = dr["quotation_no"].ToString();
                filename = "RFQ " + dr["quotation_no"].ToString();
                q_client = dr["clientname"].ToString();
                q_shipment = dr["shipmentname"].ToString();
                q_description = dr["description"].ToString();
                q_weight = dr["weight"].ToString();
                q_dimension = dr["dimension"].ToString();
                q_volume = dr["volume"].ToString();
                q_pol = dr["pol"].ToString();
                q_pod = dr["pod"].ToString();
                q_pickup = dr["pickup_address"].ToString();
                q_carrier = dr["carrier"].ToString();

                try { q_transittime = DateTime.Parse(dr["transit_time"].ToString()).ToString("MMMM dd, yyyy hh:mm tt"); }
                catch { }

                q_natureofcargo = dr["nature_of_cargo"].ToString();
                q_ratevalidity = dr["rate_validity"].ToString();
                q_paymentterms = dr["payment_terms"].ToString();
                q_exchangerate = dr["exchange_rate"].ToString();

                q_preparedby = dr["preparedby"].ToString();
                q_position = dr["position"].ToString();
            }

            if (DDLShipment.SelectedItem.Text.Contains("FCL"))
            {
                q_volume = string.Empty;

                DataTable dtCont = new DataTable();
                Quotation_container entityCont = new Quotation_container();
                Quotation_containerBO entityBOCont = new Quotation_containerBO();

                try { entityCont.Quotation_id = int.Parse(Request.QueryString["id"].ToString()); }
                catch { }

                dtCont = entityBOCont.SelectByQuotationId(entityCont);

                foreach (DataRow drCont in dtCont.Rows)
                {
                    q_volume += drCont["container_name"].ToString() + " ";
                }
            }


            DataTable dtFreight = new DataTable();
            Quotation_freight_charges entityFreight = new Quotation_freight_charges();
            Quotation_freight_chargesBO entityBOFreight = new Quotation_freight_chargesBO();
            try { entityFreight.Quotationid = int.Parse(Request.QueryString["id"].ToString()); }
            catch { }
            dtFreight = entityBOFreight.Select(entityFreight);


            DataTable dtOrigin = new DataTable();
            Quotation_origin_charges entityOrigin = new Quotation_origin_charges();
            Quotation_origin_chargesBO entityBOOrigin = new Quotation_origin_chargesBO();
            try { entityOrigin.Quotationid = int.Parse(Request.QueryString["id"].ToString()); }
            catch { }
            dtOrigin = entityBOOrigin.Select(entityOrigin);

            DataTable dtLocal = new DataTable();
            Quotation_local_charges entityLocal = new Quotation_local_charges();
            Quotation_local_chargesBO entityBOLocal = new Quotation_local_chargesBO();

            try { entityLocal.Quotationid = int.Parse(Request.QueryString["id"].ToString()); }
            catch { }

            dtLocal = entityBOLocal.Select(entityLocal);


            string sub_total_freight_origin = string.Empty;
            try { sub_total_freight_origin = (double.Parse(lblFreightTotal.Text) + double.Parse(lblOriginTotal.Text)).ToString("N"); }
            catch { }

            string sub_total_local = string.Empty;
            try { sub_total_local = lblLocalTotal.Text; }
            catch { }

            string total_amount = string.Empty;
            try { total_amount = (double.Parse(sub_total_freight_origin) + double.Parse(sub_total_local)).ToString("N"); }
            catch { }

            DataTable dtTermsConditions = new DataTable();
            Terms_conditionsBO entityBOTerms = new Terms_conditionsBO();
            dtTermsConditions = entityBOTerms.SelectAll();
            string TermsCondition = string.Empty;

            foreach (DataRow dr in dtTermsConditions.Rows)
            {
                TermsCondition += dr["name"].ToString() + "\n";
            }



            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=" + filename + ".pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            var stream = new MemoryStream();
            var writer = new PdfWriter(stream);
            var pdf = new PdfDocument(writer);
            var document = new Document(pdf, PageSize.A4);

            // Add image
            iText.Layout.Element.Image img = new iText.Layout.Element.Image(ImageDataFactory.Create("https://straightforward-ph.com/secure/img/falcon-logo.png"));
            img.SetTextAlignment(TextAlignment.CENTER);
            img.SetWidth(200);
            document.Add(img);

            // New line
            Paragraph newline = new Paragraph(new Text("\n"));
            document.Add(newline);

            // Table
            iText.Layout.Element.Table table = new iText.Layout.Element.Table(4);
            table.SetWidth(500);
            table.SetFontSize(6);

            //ROW 1
            Cell cell11 = new Cell(1, 1)
                .SetTextAlignment(TextAlignment.RIGHT).SetBorder(Border.NO_BORDER).SetPadding(0f)
               .Add(new Paragraph("Date").SetBold());
            Cell cell12 = new Cell(1, 1)
               .SetTextAlignment(TextAlignment.CENTER).SetBorder(Border.NO_BORDER).SetPadding(0f)
               .Add(new Paragraph(q_date));
            Cell cell13 = new Cell(1, 1)
                .SetTextAlignment(TextAlignment.RIGHT).SetBorder(Border.NO_BORDER).SetPadding(0f)
                .Add(new Paragraph("POD").SetBold());
            Cell cell14 = new Cell(1, 1)
               .SetTextAlignment(TextAlignment.CENTER).SetBorder(Border.NO_BORDER).SetPadding(0f)
               .Add(new Paragraph(q_pod));

            table.AddCell(cell11);
            table.AddCell(cell12);
            table.AddCell(cell13);
            table.AddCell(cell14);

            //ROW 2
            Cell cell21 = new Cell(1, 1)
               .SetTextAlignment(TextAlignment.RIGHT).SetBorder(Border.NO_BORDER).SetPadding(0f)
               .Add(new Paragraph("Quotation No.").SetBold());
            Cell cell22 = new Cell(1, 1)
               .SetTextAlignment(TextAlignment.CENTER).SetBorder(Border.NO_BORDER).SetPadding(0f)
               .Add(new Paragraph(q_no));
            Cell cell23 = new Cell(1, 1)
               .SetTextAlignment(TextAlignment.RIGHT).SetBorder(Border.NO_BORDER).SetPadding(0f)
               .Add(new Paragraph("Pick up Add").SetBold());
            Cell cell24 = new Cell(1, 1)
               .SetTextAlignment(TextAlignment.CENTER).SetBorder(Border.NO_BORDER).SetPadding(0f)
               .Add(new Paragraph(q_pickup));

            table.AddCell(cell21);
            table.AddCell(cell22);
            table.AddCell(cell23);
            table.AddCell(cell24);

            //ROW 3
            Cell cell31 = new Cell(1, 1)
                .SetTextAlignment(TextAlignment.RIGHT).SetBorder(Border.NO_BORDER).SetPadding(0f)
                .Add(new Paragraph("Client's Name").SetBold());
            Cell cell32 = new Cell(1, 1)
               .SetTextAlignment(TextAlignment.CENTER).SetBorder(Border.NO_BORDER).SetPadding(0f)
               .Add(new Paragraph(q_client));
            Cell cell33 = new Cell(1, 1)
               .SetTextAlignment(TextAlignment.RIGHT).SetBorder(Border.NO_BORDER).SetPadding(0f)
               .Add(new Paragraph("Carrier").SetBold());
            Cell cell34 = new Cell(1, 1)
               .SetTextAlignment(TextAlignment.CENTER).SetBorder(Border.NO_BORDER).SetPadding(0f)
               .Add(new Paragraph(q_carrier));

            table.AddCell(cell31);
            table.AddCell(cell32);
            table.AddCell(cell33);
            table.AddCell(cell34);

            //ROW 4
            Cell cell41 = new Cell(1, 1)
               .SetTextAlignment(TextAlignment.RIGHT).SetBorder(Border.NO_BORDER).SetPadding(0f)
               .Add(new Paragraph("Mode & Terms of Shipment").SetBold());
            Cell cell42 = new Cell(1, 1)
               .SetTextAlignment(TextAlignment.CENTER).SetBorder(Border.NO_BORDER).SetPadding(0f)
               .Add(new Paragraph(q_shipment));
            Cell cell43 = new Cell(1, 1)
              .SetTextAlignment(TextAlignment.RIGHT).SetBorder(Border.NO_BORDER).SetPadding(0f)
              .Add(new Paragraph("Transit time").SetBold());
            Cell cell44 = new Cell(1, 1)
               .SetTextAlignment(TextAlignment.CENTER).SetBorder(Border.NO_BORDER).SetPadding(0f)
               .Add(new Paragraph(q_transittime));

            table.AddCell(cell41);
            table.AddCell(cell42);
            table.AddCell(cell43);
            table.AddCell(cell44);

            //ROW 5
            Cell cell51 = new Cell(1, 1)
               .SetTextAlignment(TextAlignment.RIGHT).SetBorder(Border.NO_BORDER).SetPadding(0f)
               .Add(new Paragraph("Description").SetBold());
            Cell cell52 = new Cell(1, 1)
               .SetTextAlignment(TextAlignment.CENTER).SetBorder(Border.NO_BORDER).SetPadding(0f)
               .Add(new Paragraph(q_description));
            Cell cell53 = new Cell(1, 1)
              .SetTextAlignment(TextAlignment.RIGHT).SetBorder(Border.NO_BORDER).SetPadding(0f)
              .Add(new Paragraph("Nature of Cargo").SetBold());
            Cell cell54 = new Cell(1, 1)
               .SetTextAlignment(TextAlignment.CENTER).SetBorder(Border.NO_BORDER).SetPadding(0f)
               .Add(new Paragraph(q_natureofcargo));

            table.AddCell(cell51);
            table.AddCell(cell52);
            table.AddCell(cell53);
            table.AddCell(cell54);

            //ROW 6
            Cell cell61 = new Cell(1, 1)
             .SetTextAlignment(TextAlignment.RIGHT).SetBorder(Border.NO_BORDER).SetPadding(0f)
             .Add(new Paragraph("Gross Weight (kgs)").SetBold());
            Cell cell62 = new Cell(1, 1)
               .SetTextAlignment(TextAlignment.CENTER).SetBorder(Border.NO_BORDER).SetPadding(0f)
               .Add(new Paragraph(q_weight));
            Cell cell63 = new Cell(1, 1)
                .SetTextAlignment(TextAlignment.RIGHT).SetBorder(Border.NO_BORDER).SetPadding(0f)
                .Add(new Paragraph("Rate Validity").SetBold());
            Cell cell64 = new Cell(1, 1)
               .SetTextAlignment(TextAlignment.CENTER).SetBorder(Border.NO_BORDER).SetPadding(0f)
               .Add(new Paragraph(q_ratevalidity));

            table.AddCell(cell61);
            table.AddCell(cell62);
            table.AddCell(cell63);
            table.AddCell(cell64);

            //ROW 7
            Cell cell71 = new Cell(1, 1)
             .SetTextAlignment(TextAlignment.RIGHT).SetBorder(Border.NO_BORDER).SetPadding(0f)
             .Add(new Paragraph("Dimension/s (CBM)").SetBold());
            Cell cell72 = new Cell(1, 1)
               .SetTextAlignment(TextAlignment.CENTER).SetBorder(Border.NO_BORDER).SetPadding(0f)
               .Add(new Paragraph(q_dimension));
            Cell cell73 = new Cell(1, 1)
               .SetTextAlignment(TextAlignment.RIGHT).SetBorder(Border.NO_BORDER).SetPadding(0f)
                .Add(new Paragraph("Payment Terms").SetBold());
            Cell cell74 = new Cell(1, 1)
               .SetTextAlignment(TextAlignment.CENTER).SetBorder(Border.NO_BORDER).SetPadding(0f)
               .Add(new Paragraph(q_paymentterms));

            table.AddCell(cell71);
            table.AddCell(cell72);
            table.AddCell(cell73);
            table.AddCell(cell74);

            //ROW 8
            Cell cell81 = new Cell(1, 1)
             .SetTextAlignment(TextAlignment.RIGHT).SetBorder(Border.NO_BORDER).SetPadding(0f)
             .Add(new Paragraph("Chargeable Weight").SetBold());
            Cell cell82 = new Cell(1, 1)
               .SetTextAlignment(TextAlignment.CENTER).SetBorder(Border.NO_BORDER).SetPadding(0f)
               .Add(new Paragraph(q_volume));
            Cell cell83 = new Cell(1, 1)
            .SetTextAlignment(TextAlignment.RIGHT).SetBorder(Border.NO_BORDER).SetPadding(0f)
            .Add(new Paragraph("Exchange Rate (Subject to Change)").SetBold());
            Cell cell84 = new Cell(1, 1)
               .SetTextAlignment(TextAlignment.CENTER).SetBorder(Border.NO_BORDER).SetPadding(0f)
               .Add(new Paragraph(q_exchangerate));

            table.AddCell(cell81);
            table.AddCell(cell82);
            table.AddCell(cell83);
            table.AddCell(cell84);

            //ROW 9
            Cell cell91 = new Cell(1, 1)
             .SetTextAlignment(TextAlignment.RIGHT).SetBorder(Border.NO_BORDER).SetPadding(0f)
             .Add(new Paragraph("POL").SetBold());
            Cell cell92 = new Cell(1, 1)
               .SetTextAlignment(TextAlignment.CENTER).SetBorder(Border.NO_BORDER).SetPadding(0f)
               .Add(new Paragraph(q_pol));
            Cell cell93 = new Cell(1, 1)
                .SetTextAlignment(TextAlignment.RIGHT).SetBorder(Border.NO_BORDER).SetPadding(0f)
                .Add(new Paragraph("").SetBold());
            Cell cell94 = new Cell(1, 1)
               .SetTextAlignment(TextAlignment.CENTER).SetBorder(Border.NO_BORDER).SetPadding(0f)
               .Add(new Paragraph(""));

            table.AddCell(cell91);
            table.AddCell(cell92);
            table.AddCell(cell93);
            table.AddCell(cell94);

            document.Add(table);
            document.Add(newline);

            // Table #2
            iText.Layout.Element.Table table2 = new iText.Layout.Element.Table(6);
            table2.SetWidth(500);
            table2.SetFontSize(6);

            //ROW 1
            Cell row11 = new Cell(1, 1).SetTextAlignment(TextAlignment.CENTER).SetPadding(0f).Add(new Paragraph("PARTICULAR/S").SetBackgroundColor(Color.ConvertRgbToCmyk(new DeviceRgb(21, 74, 150))).SetFontColor(Color.ConvertRgbToCmyk(new DeviceRgb(255, 255, 255))));
            Cell row12 = new Cell(1, 1).SetTextAlignment(TextAlignment.CENTER).SetPadding(0f).Add(new Paragraph("CURRENCY").SetBackgroundColor(Color.ConvertRgbToCmyk(new DeviceRgb(21, 74, 150))).SetFontColor(Color.ConvertRgbToCmyk(new DeviceRgb(255, 255, 255))));
            Cell row13 = new Cell(1, 1).SetTextAlignment(TextAlignment.CENTER).SetPadding(0f).Add(new Paragraph("UNIT PRICE").SetBackgroundColor(Color.ConvertRgbToCmyk(new DeviceRgb(21, 74, 150))).SetFontColor(Color.ConvertRgbToCmyk(new DeviceRgb(255, 255, 255))));
            Cell row14 = new Cell(1, 1).SetTextAlignment(TextAlignment.CENTER).SetPadding(0f).Add(new Paragraph("QTY").SetBackgroundColor(Color.ConvertRgbToCmyk(new DeviceRgb(21, 74, 150))).SetFontColor(Color.ConvertRgbToCmyk(new DeviceRgb(255, 255, 255))));
            Cell row15 = new Cell(1, 1).SetTextAlignment(TextAlignment.CENTER).SetPadding(0f).Add(new Paragraph("TOTAL AMOUNT").SetBackgroundColor(Color.ConvertRgbToCmyk(new DeviceRgb(21, 74, 150))).SetFontColor(Color.ConvertRgbToCmyk(new DeviceRgb(255, 255, 255))));
            Cell row16 = new Cell(1, 1).SetTextAlignment(TextAlignment.CENTER).SetPadding(0f).Add(new Paragraph("REMARKS").SetBackgroundColor(Color.ConvertRgbToCmyk(new DeviceRgb(21, 74, 150))).SetFontColor(Color.ConvertRgbToCmyk(new DeviceRgb(255, 255, 255))));

            table2.AddCell(row11);
            table2.AddCell(row12);
            table2.AddCell(row13);
            table2.AddCell(row14);
            table2.AddCell(row15);
            table2.AddCell(row16);

            //ROW 2
            Cell row21 = new Cell(1, 6).SetTextAlignment(TextAlignment.LEFT).SetBold().SetPadding(0f).Add(new Paragraph("FREIGHT CHARGES:").SetPaddingLeft(3)).SetBackgroundColor(Color.ConvertRgbToCmyk(new DeviceRgb(255, 255, 0)));
            table2.AddCell(row21);


            foreach (DataRow dr in dtFreight.Rows)
            {
                //ROW 3
                Cell row31 = new Cell(1, 1).SetTextAlignment(TextAlignment.LEFT).SetPadding(0f).Add(new Paragraph(dr["particularname"].ToString()).SetPaddingLeft(3));
                Cell row32 = new Cell(1, 1).SetTextAlignment(TextAlignment.CENTER).SetPadding(0f).Add(new Paragraph(dr["currency"].ToString()));
                Cell row33 = new Cell(1, 1).SetTextAlignment(TextAlignment.RIGHT).SetPadding(0f).Add(new Paragraph(dr["currency"].ToString() + " " + double.Parse(dr["unit_price"].ToString()).ToString("N")).SetPaddingRight(3));
                Cell row34 = new Cell(1, 1).SetTextAlignment(TextAlignment.RIGHT).SetPadding(0f).Add(new Paragraph(dr["qty"].ToString()).SetPaddingRight(3));
                Cell row35 = new Cell(1, 1).SetTextAlignment(TextAlignment.RIGHT).SetPadding(0f).Add(new Paragraph("PHP " + double.Parse(dr["total_amount"].ToString()).ToString("N")).SetPaddingRight(3));
                Cell row36 = new Cell(1, 1).SetTextAlignment(TextAlignment.LEFT).SetPadding(0f).Add(new Paragraph(dr["remarks"].ToString()).SetPaddingLeft(3));

                table2.AddCell(row31);
                table2.AddCell(row32);
                table2.AddCell(row33);
                table2.AddCell(row34);
                table2.AddCell(row35);
                table2.AddCell(row36);
            }

            //ROW 4
            Cell row41 = new Cell(1, 6).SetPadding(0f).Add(newline);
            table2.AddCell(row41);

            //ROW 5
            Cell row51 = new Cell(1, 6).SetTextAlignment(TextAlignment.LEFT).SetBold().SetPadding(0f).Add(new Paragraph("ORIGIN CHARGES:").SetPaddingLeft(3)).SetBackgroundColor(Color.ConvertRgbToCmyk(new DeviceRgb(255, 255, 0)));
            table2.AddCell(row51);


            foreach (DataRow dr in dtOrigin.Rows)
            {
                //ROW 6
                Cell row61 = new Cell(1, 1).SetTextAlignment(TextAlignment.LEFT).SetPadding(0f).Add(new Paragraph(dr["particularname"].ToString()).SetPaddingLeft(3));
                Cell row62 = new Cell(1, 1).SetTextAlignment(TextAlignment.CENTER).SetPadding(0f).Add(new Paragraph(dr["currency"].ToString()));
                Cell row63 = new Cell(1, 1).SetTextAlignment(TextAlignment.RIGHT).SetPadding(0f).Add(new Paragraph(dr["currency"].ToString() + " " + double.Parse(dr["unit_price"].ToString()).ToString("N")).SetPaddingRight(3));
                Cell row64 = new Cell(1, 1).SetTextAlignment(TextAlignment.RIGHT).SetPadding(0f).Add(new Paragraph(dr["qty"].ToString()).SetPaddingRight(3));
                Cell row65 = new Cell(1, 1).SetTextAlignment(TextAlignment.RIGHT).SetPadding(0f).Add(new Paragraph("PHP " + double.Parse(dr["total_amount"].ToString()).ToString("N")).SetPaddingRight(3));
                Cell row66 = new Cell(1, 1).SetTextAlignment(TextAlignment.LEFT).SetPadding(0f).Add(new Paragraph(dr["remarks"].ToString()).SetPaddingLeft(3));

                table2.AddCell(row61);
                table2.AddCell(row62);
                table2.AddCell(row63);
                table2.AddCell(row64);
                table2.AddCell(row65);
                table2.AddCell(row66);
            }

            //ROW 9
            Cell row91 = new Cell(1, 4).SetTextAlignment(TextAlignment.CENTER).SetPadding(0f).SetBold().Add(new Paragraph("SUBTOTAL"));
            Cell row92 = new Cell(1, 2).SetTextAlignment(TextAlignment.LEFT).SetPadding(0f).SetBold().Add(new Paragraph("PHP " + sub_total_freight_origin).SetPaddingLeft(3));

            table2.AddCell(row91);
            table2.AddCell(row92);

            //ROW 10
            Cell row101 = new Cell(1, 6).SetPadding(0f).Add(newline);
            table2.AddCell(row101);

            //ROW 11
            Cell row111 = new Cell(1, 6).SetTextAlignment(TextAlignment.LEFT).SetBold().SetPadding(0f).Add(new Paragraph("DESTINATION LOCAL CHARGES:").SetPaddingLeft(3)).SetBackgroundColor(Color.ConvertRgbToCmyk(new DeviceRgb(255, 255, 0)));
            table2.AddCell(row111);

            foreach (DataRow dr in dtLocal.Rows)
            {
                //ROW 12
                Cell row121 = new Cell(1, 1).SetTextAlignment(TextAlignment.LEFT).SetPadding(0f).Add(new Paragraph(dr["particularname"].ToString()).SetPaddingLeft(3));
                Cell row122 = new Cell(1, 1).SetTextAlignment(TextAlignment.CENTER).SetPadding(0f).Add(new Paragraph(dr["currency"].ToString()));
                Cell row123 = new Cell(1, 1).SetTextAlignment(TextAlignment.RIGHT).SetPadding(0f).Add(new Paragraph(dr["currency"].ToString() + " " + double.Parse(dr["unit_price"].ToString()).ToString("N")).SetPaddingRight(3));
                Cell row124 = new Cell(1, 1).SetTextAlignment(TextAlignment.RIGHT).SetPadding(0f).Add(new Paragraph(dr["qty"].ToString()).SetPaddingRight(3));
                Cell row125 = new Cell(1, 1).SetTextAlignment(TextAlignment.RIGHT).SetPadding(0f).Add(new Paragraph("PHP " + double.Parse(dr["total_amount"].ToString()).ToString("N")).SetPaddingRight(3));
                Cell row126 = new Cell(1, 1).SetTextAlignment(TextAlignment.LEFT).SetPadding(0f).Add(new Paragraph(dr["remarks"].ToString()).SetPaddingLeft(3));

                table2.AddCell(row121);
                table2.AddCell(row122);
                table2.AddCell(row123);
                table2.AddCell(row124);
                table2.AddCell(row125);
                table2.AddCell(row126);
            }

            //ROW 18
            Cell row181 = new Cell(1, 4).SetTextAlignment(TextAlignment.CENTER).SetPadding(0f).SetBold().Add(new Paragraph("SUBTOTAL"));
            Cell row182 = new Cell(1, 2).SetTextAlignment(TextAlignment.LEFT).SetPadding(0f).SetBold().Add(new Paragraph("PHP " + sub_total_local).SetPaddingLeft(3));

            table2.AddCell(row181);
            table2.AddCell(row182);

            //ROW 19
            Cell row191 = new Cell(1, 4).SetTextAlignment(TextAlignment.CENTER).SetPadding(0f).Add(new Paragraph("ESTIMATED TOTAL CHARGES (SUBJECT TO CHANGE)").SetBackgroundColor(Color.ConvertRgbToCmyk(new DeviceRgb(21, 74, 150))).SetFontColor(Color.ConvertRgbToCmyk(new DeviceRgb(255, 255, 255))));
            Cell row192 = new Cell(1, 2).SetTextAlignment(TextAlignment.CENTER).SetPadding(0f).Add(new Paragraph("PHP " + total_amount).SetBackgroundColor(Color.ConvertRgbToCmyk(new DeviceRgb(21, 74, 150))).SetFontColor(Color.ConvertRgbToCmyk(new DeviceRgb(255, 255, 255))));

            table2.AddCell(row191);
            table2.AddCell(row192);

            document.Add(table2);


            //Terms & Condition
            document.Add(newline);
            Paragraph paragraph1 = new Paragraph("Terms & Conditions:").SetBold().SetFontSize(5);
            document.Add(paragraph1);

            Paragraph paragraph2 = new Paragraph(TermsCondition).SetFontSize(5);
            document.Add(paragraph2);

            //Prepared By
            document.Add(newline);
            Paragraph paragraph3 = new Paragraph("Prepared by:").SetBold().SetFontSize(5);
            document.Add(paragraph3);

            // Table
            iText.Layout.Element.Table table3 = new iText.Layout.Element.Table(1);
            table3.SetWidth(100);
            table3.SetFontSize(5);

            Cell Table3Cell11 = new Cell(1, 1)
                .SetTextAlignment(TextAlignment.LEFT).SetBorder(Border.NO_BORDER).SetPadding(0f)
               .Add(new Paragraph(q_preparedby).SetBold());
            table3.AddCell(Table3Cell11);

            Cell Table3Cell21 = new Cell(1, 1)
                .SetTextAlignment(TextAlignment.LEFT).SetBorder(Border.NO_BORDER).SetPadding(0f)
               .Add(new Paragraph(q_position));
            table3.AddCell(Table3Cell21);

            document.Add(table3);
            document.Add(newline);

            //Signatory
            Paragraph paragraph4 = new Paragraph("Accepted by:").SetBold().SetFontSize(5).SetTextAlignment(TextAlignment.RIGHT);
            document.Add(paragraph4);

            Paragraph paragraph5 = new Paragraph("Name & Signature: __________________________________ \n" +
                "Company Name & Position: __________________________________ \n" +
                "Date: __________________________________ ").SetFontSize(5).SetTextAlignment(TextAlignment.RIGHT);
            document.Add(paragraph5);

            document.Close();
            Response.BinaryWrite(stream.ToArray());
            Response.End();


        }
        #endregion

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ActionAdd")
            {
                lblFreightId.Text = "0";
                try { DDLFreight.SelectedValue = string.Empty; }
                catch { }
                try { DDLFContainer.SelectedValue = string.Empty; }
                catch { }
                try { DDLFCurrency.SelectedValue = string.Empty; }
                catch { }
                try { TextBoxFUnitPrice.Text = string.Empty; }
                catch { }
                try { TextBoxFTotalAmount.Text = string.Empty; }
                catch { }
                try { TextBoxFEstimate.Text = string.Empty; }
                catch { }
                try { TextBoxFRemarks.Text = string.Empty; }
                catch { }

                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "OpenFreight();", true);
            }

            if (e.CommandName == "ActionEdit")
            {
                lblFreightId.Text = e.CommandArgument.ToString();

                DataTable dt = new DataTable();
                Quotation_freight_charges entity = new Quotation_freight_charges();
                Quotation_freight_chargesBO entityBO = new Quotation_freight_chargesBO();

                try { entity.Id = int.Parse(e.CommandArgument.ToString()); }
                catch { }

                dt = entityBO.Select(entity);

                foreach (DataRow dr in dt.Rows)
                {
                    try { DDLFreight.SelectedValue = dr["particularid"].ToString(); }
                    catch { }
                    try { DDLFContainer.SelectedValue = dr["quotation_container_id"].ToString(); }
                    catch { }
                    try { DDLFCurrency.SelectedValue = DDLFCurrency.Items.FindByText(dr["currency"].ToString()).Value; }
                    catch { }
                    try { TextBoxFUnitPrice.Text = dr["unit_price"].ToString(); }
                    catch { }
                    try { TextBoxFTotalAmount.Text = dr["total_amount"].ToString(); }
                    catch { }
                    try { TextBoxFEstimate.Text = dr["agent_amount"].ToString(); }
                    catch { }
                    try { TextBoxFRemarks.Text = dr["remarks"].ToString(); }
                    catch { }
                    try { TextBoxFVolume.Text = dr["qty"].ToString(); }
                    catch { }
                }

                try
                {
                    TextBoxFEx.Text = ((double.Parse(TextBoxFTotalAmount.Text.ToString()) / double.Parse(TextBoxFUnitPrice.Text.ToString())) / double.Parse(TextBoxFVolume.Text.ToString())).ToString();
                }
                catch { }

                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "OpenFreight();", true);
            }
        }

        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ActionAdd")
            {
                lblOriginId.Text = "0";
                try { DDLOrigin.SelectedValue = string.Empty; }
                catch { }
                try { DDLOContainer.SelectedValue = string.Empty; }
                catch { }
                try { DDLOCurrency.SelectedValue = string.Empty; }
                catch { }
                try { TextBoxOUnitPrice.Text = string.Empty; }
                catch { }
                try { TextBoxOTotalAmount.Text = string.Empty; }
                catch { }
                try { TextBoxOEstimate.Text = string.Empty; }
                catch { }
                try { TextBoxORemarks.Text = string.Empty; }
                catch { }

                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "OpenOrigin();", true);
            }

            if (e.CommandName == "ActionEdit")
            {
                lblOriginId.Text = e.CommandArgument.ToString();

                DataTable dt = new DataTable();
                Quotation_origin_charges entity = new Quotation_origin_charges();
                Quotation_origin_chargesBO entityBO = new Quotation_origin_chargesBO();

                try { entity.Id = int.Parse(e.CommandArgument.ToString()); }
                catch { }

                dt = entityBO.Select(entity);

                foreach (DataRow dr in dt.Rows)
                {
                    try { DDLOrigin.SelectedValue = dr["particularid"].ToString(); }
                    catch { }
                    try { DDLOContainer.SelectedValue = dr["quotation_container_id"].ToString(); }
                    catch { }
                    try { DDLOCurrency.SelectedValue = DDLOCurrency.Items.FindByText(dr["currency"].ToString()).Value; }
                    catch { }
                    try { TextBoxOUnitPrice.Text = dr["unit_price"].ToString(); }
                    catch { }
                    try { TextBoxOTotalAmount.Text = dr["total_amount"].ToString(); }
                    catch { }
                    try { TextBoxOEstimate.Text = dr["agent_amount"].ToString(); }
                    catch { }
                    try { TextBoxORemarks.Text = dr["remarks"].ToString(); }
                    catch { }
                    try { TextBoxOVolume.Text = dr["qty"].ToString(); }
                    catch { }
                }

                try
                {
                    TextBoxOEx.Text = ((double.Parse(TextBoxOTotalAmount.Text.ToString()) / double.Parse(TextBoxOUnitPrice.Text.ToString())) / double.Parse(TextBoxOVolume.Text.ToString())).ToString();
                }
                catch { }

                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "OpenOrigin();", true);
            }
        }

        protected void GridView3_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ActionAdd")
            {
                lblLocalId.Text = "0";
                try { DDLLocal.SelectedValue = string.Empty; }
                catch { }
                try { DDLLContainer.SelectedValue = string.Empty; }
                catch { }
                try { DDLLCurrency.SelectedValue = string.Empty; }
                catch { }
                try { TextBoxLUnitPrice.Text = string.Empty; }
                catch { }
                try { TextBoxLTotalAmount.Text = string.Empty; }
                catch { }
                try { TextBoxLEstimate.Text = string.Empty; }
                catch { }
                try { TextBoxLRemarks.Text = string.Empty; }
                catch { }

                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "OpenLocal();", true);
            }

            if (e.CommandName == "ActionEdit")
            {
                lblLocalId.Text = e.CommandArgument.ToString();

                DataTable dt = new DataTable();
                Quotation_local_charges entity = new Quotation_local_charges();
                Quotation_local_chargesBO entityBO = new Quotation_local_chargesBO();

                try { entity.Id = int.Parse(e.CommandArgument.ToString()); }
                catch { }

                dt = entityBO.Select(entity);

                foreach (DataRow dr in dt.Rows)
                {
                    try { DDLLocal.SelectedValue = dr["particularid"].ToString(); }
                    catch { }
                    try { DDLLContainer.SelectedValue = dr["quotation_container_id"].ToString(); }
                    catch { }
                    try { DDLLCurrency.SelectedValue = DDLLCurrency.Items.FindByText(dr["currency"].ToString()).Value; }
                    catch { }
                    try { TextBoxLUnitPrice.Text = dr["unit_price"].ToString(); }
                    catch { }
                    try { TextBoxLTotalAmount.Text = dr["total_amount"].ToString(); }
                    catch { }
                    try { TextBoxLEstimate.Text = dr["agent_amount"].ToString(); }
                    catch { }
                    try { TextBoxLRemarks.Text = dr["remarks"].ToString(); }
                    catch { }
                    try { TextBoxLVolume.Text = dr["qty"].ToString(); }
                    catch { }
                }

                try
                {
                    TextBoxLEx.Text = ((double.Parse(TextBoxLTotalAmount.Text.ToString()) / double.Parse(TextBoxLUnitPrice.Text.ToString())) / double.Parse(TextBoxLVolume.Text.ToString())).ToString();
                }
                catch { }

                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "OpenLocal();", true);
            }
        }


    }
}