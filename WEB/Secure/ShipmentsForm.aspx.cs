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
    public partial class ShipmentsForm : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    DataTable dt = new DataTable();
                    Shipment entity = new Shipment();
                    ShipmentBO entityBO = new ShipmentBO();

                    try { entity.Id = int.Parse(Request.QueryString["id"].ToString()); }
                    catch { }

                    dt = entityBO.Select(entity);

                    foreach (DataRow dr in dt.Rows)
                    {
                        TextBoxName.Text = dr["name"].ToString();
                        TextBoxDescription.Text = dr["description"].ToString();
                    }
                }
            }
        }

        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            Shipment entity = new Shipment();
            ShipmentBO entityBO = new ShipmentBO();

            if (Request.QueryString["id"] != null)
            {
                try { entity.Id = int.Parse(Request.QueryString["id"].ToString()); }
                catch { }
                try { entity.Name = TextBoxName.Text.ToString().Trim(); }
                catch { }
                try { entity.Description = TextBoxDescription.Text.ToString().Trim(); }
                catch { }
                try { entity.Updater = new Guid(Membership.GetUser().ProviderUserKey.ToString()); }
                catch (Exception) { }

                entityBO.Update(entity);
            }
            else
            {
                try { entity.Name = TextBoxName.Text.ToString().Trim(); }
                catch { }
                try { entity.Description = TextBoxDescription.Text.ToString().Trim(); }
                catch { }
                try { entity.Creator = new Guid(Membership.GetUser().ProviderUserKey.ToString()); }
                catch (Exception) { };

                entityBO.Insert(entity);
            }
              

            if (entityBO.IsSuccessful)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Record has been successfully saved.'); window.location = 'Shipments.aspx';", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('" + entityBO.TransactionMessage + "');", true);
            }
        }

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Shipments.aspx");
        }
    }
}