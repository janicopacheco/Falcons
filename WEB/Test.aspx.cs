using PROCESS;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StraightForward
{
    public partial class Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                BindGrid();
            }

        }


        private void BindGrid()
        {
            DataTable dt = new DataTable();
            StatusBO entityBO = new StatusBO();

            dt = entityBO.SelectAll();

            //GridView1.DataSource = dt;
            //GridView1.DataBind();
            ////Required for jQuery DataTables to work.
            //GridView1.UseAccessibleHeader = true;
            //GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;

            DataTable dt2 = new DataTable();
            ParticularBO particularBO = new ParticularBO();

            dt2 = particularBO.SelectAll();

            Repeater1.DataSource = dt2;
            Repeater1.DataBind();


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                string email = "falconsystem@straightforward-ph.com";//ConfigurationManager.AppSettings["user_email"];
                string pwd = "P@ssw0rd!";//ConfigurationManager.AppSettings["user_pwd"];

                string to = "janicopacheco@yahoo.com";
                string from = email;//"janicotest@company.com";
                string subject = "Test Subject";
                string body = "Hello World Email";

                MailMessage message = new MailMessage(from, to, subject, body);

                //SmtpClient client = new SmtpClient("mail5016.site4now.net", 465); //Gmail smtp    
                //System.Net.NetworkCredential basicCredential1 = new
                //System.Net.NetworkCredential(email, pwd);
                //client.EnableSsl = true;
                //client.UseDefaultCredentials = false;
                //client.Credentials = basicCredential1;

                //client.Send(message);


                System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
                //create the mail message 
                MailMessage mail = new MailMessage();

                //set the addresses 
                mail.From = new MailAddress("falconsystem@straightforward-ph.com"); //IMPORTANT: This must be same as your smtp authentication address.
                mail.To.Add("janicopacheco@yahoo.com");

                //set the content 
                mail.Subject = "This is an email";
                mail.Body = "This is from system.net.mail using C sharp with smtp authentication.";
                //send the message 
                SmtpClient smtp = new SmtpClient("mail.straightforward-ph.com");

                //IMPORANT:  Your smtp login email MUST be same as your FROM address. 
                NetworkCredential Credentials = new NetworkCredential("falconsystem@straightforward-ph.com", "P@ssw0rd!");
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = Credentials;
                smtp.Port = 8889;    //alternative port number is 8889
                smtp.EnableSsl = false;
                smtp.Send(mail);



                LabelMsg.Text = "Sent Successfully";
            }
            catch (Exception ex)
            {
                LabelMsg.Text = "Failed: " + ex.Message;
            }

        }
    }
}