using ENTITY;
using PROCESS;
using System;
using System.Data;
using System.Web.Security;
using System.Web.UI;

namespace Falcon.Secure
{
    public partial class CustomerForm : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    DataTable dt = new DataTable();
                    Client entity = new Client();
                    ClientBO entityBO = new ClientBO();

                    try { entity.Id = int.Parse(Request.QueryString["id"].ToString()); }
                    catch { }

                    dt = entityBO.Select(entity);

                    foreach (DataRow dr in dt.Rows)
                    {
                        TextBoxName.Text = dr["name"].ToString();
                        TextBoxAddress.Text = dr["address"].ToString();
                        TextBoxTin.Text = dr["tin"].ToString();
                        TextBoxContactNo.Text = dr["contactno"].ToString();
                        TextBoxContactPerson.Text = dr["contactperson"].ToString();
                    }
                }
            }
        }

        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            Client entity = new Client();
            ClientBO entityBO = new ClientBO();

            if (Request.QueryString["id"] != null)
            {
                try { entity.Id = int.Parse(Request.QueryString["id"].ToString()); }
                catch { }
                try { entity.Name = TextBoxName.Text.ToString().Trim(); }
                catch { }
                try { entity.Address = TextBoxAddress.Text.ToString().Trim(); }
                catch { }
                try { entity.Tin = TextBoxTin.Text.ToString().Trim(); }
                catch { }
                try { entity.Contactno = TextBoxContactNo.Text.ToString().Trim(); }
                catch { }
                try { entity.Contactperson = TextBoxContactPerson.Text.ToString().Trim(); }
                catch { }
                try { entity.Updater = new Guid(Membership.GetUser().ProviderUserKey.ToString()); }
                catch (Exception) { }

                entityBO.Update(entity);
            }
            else
            {
                try { entity.Name = TextBoxName.Text.ToString().Trim(); }
                catch { }
                try { entity.Address = TextBoxAddress.Text.ToString().Trim(); }
                catch { }
                try { entity.Tin = TextBoxTin.Text.ToString().Trim(); }
                catch { }
                try { entity.Contactno = TextBoxContactNo.Text.ToString().Trim(); }
                catch { }
                try { entity.Contactperson = TextBoxContactPerson.Text.ToString().Trim(); }
                catch { }
                try { entity.Creator = new Guid(Membership.GetUser().ProviderUserKey.ToString()); }
                catch (Exception) { };

                entityBO.Insert(entity);
            }
              

            if (entityBO.IsSuccessful)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Record has been successfully saved.'); window.location = 'Customer.aspx';", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('" + entityBO.TransactionMessage + "');", true);
            }
        }

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Customer.aspx");
        }
    }
}