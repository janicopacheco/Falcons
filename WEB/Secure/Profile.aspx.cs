using ENTITY;
using PROCESS;
using System;
using System.Data;
using System.Web.Security;
using System.Web.UI;

using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using System.Web;
using System.IO;
using iText.IO.Image;
using iText.Kernel.Geom;
using iText.Layout.Borders;
using iText.Kernel.Colors;

namespace Falcon.Secure
{
    public partial class Profile : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDataGrid();
            }
        }

        public void BindDataGrid()
        {
            DataTable dt = new DataTable();
            User entity = new User();
            UserBO entityBO = new UserBO();

            try { entity.Userid = new Guid(Membership.GetUser().ProviderUserKey.ToString()); }
            catch { }

            dt = entityBO.SelectByUserId(entity);

            foreach (DataRow dr in dt.Rows)
            {
                TextBoxUsername.Text = dr["Email"].ToString();
                TextBoxRole.Text = dr["RoleName"].ToString();
                TextBoxFName.Text = dr["FirstName"].ToString();
                TextBoxMName.Text = dr["MiddleName"].ToString();
                TextBoxLName.Text = dr["LastName"].ToString();
            }
        }

        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            User entity = new User();
            UserBO entityBO = new UserBO();

            try { entity.Userid = new Guid(Membership.GetUser().ProviderUserKey.ToString()); }
            catch { };
            try { entity.Firstname = TextBoxFName.Text.ToString().Trim(); }
            catch { }
            try { entity.Middlename = TextBoxMName.Text.ToString().Trim(); }
            catch { }
            try { entity.Lastname = TextBoxLName.Text.ToString().Trim(); }
            catch { }

            entityBO.Update(entity);

            if (entityBO.IsSuccessful)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Record has been successfully saved.');", true);
                BindDataGrid();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('" + entityBO.TransactionMessage + "');", true);
            }
        }

        protected void BtnUpdatePassword_Click(object sender, EventArgs e)
        {
            if (Membership.ValidateUser(Membership.GetUser().UserName, TextBoxOld.Text.ToString()))
            {
                try
                {
                    Membership.GetUser().ChangePassword(TextBoxOld.Text.ToString().Trim(), TextBoxNew.Text.ToString().Trim());
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Record has been successfully saved.');", true);
                }
                catch (Exception ee)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('" + ee.Message.Replace("'", "*") + "');", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('The old password you have entered is incorrect.');", true);
            }
        }

        protected void ButtonPdf_Click(object sender, EventArgs e)
        {

            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=print.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            var stream = new MemoryStream();
            var writer = new PdfWriter(stream);
            var pdf = new PdfDocument(writer);
            var document = new Document(pdf, PageSize.A4);

            // Add image //../assets/image/logo.png
            Image img = new Image(ImageDataFactory.Create("https://straightforward-ph.com/secure/img/falcon-logo.png"));
            img.SetTextAlignment(TextAlignment.CENTER);
            img.SetWidth(200);
            document.Add(img);

            // New line
            Paragraph newline = new Paragraph(new Text("\n"));
            document.Add(newline);

            // Table
            Table table = new Table(4);
            table.SetWidth(500);
            table.SetFontSize(6);

         
            //ROW 1
            Cell cell11 = new Cell(1, 1)
                .SetTextAlignment(TextAlignment.RIGHT).SetBorder(Border.NO_BORDER).SetPadding(0f)
               .Add(new Paragraph("Date").SetBold());
            Cell cell12 = new Cell(1, 1)
               .SetTextAlignment(TextAlignment.CENTER).SetBorder(Border.NO_BORDER).SetPadding(0f)
               .Add(new Paragraph("July 1, 2022"));
            Cell cell13 = new Cell(1, 1)
                .SetTextAlignment(TextAlignment.RIGHT).SetBorder(Border.NO_BORDER).SetPadding(0f)
                .Add(new Paragraph("POD").SetBold());
            Cell cell14 = new Cell(1, 1)
               .SetTextAlignment(TextAlignment.CENTER).SetBorder(Border.NO_BORDER).SetPadding(0f)
               .Add(new Paragraph("MANILA NORTH"));

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
               .Add(new Paragraph("202207-001"));
            Cell cell23 = new Cell(1, 1)
               .SetTextAlignment(TextAlignment.RIGHT).SetBorder(Border.NO_BORDER).SetPadding(0f)
               .Add(new Paragraph("Pick up Add").SetBold());
            Cell cell24 = new Cell(1, 1)
               .SetTextAlignment(TextAlignment.CENTER).SetBorder(Border.NO_BORDER).SetPadding(0f)
               .Add(new Paragraph("75-1 Hasunuma-Cho, Itabashi-Ku, Tokyo 174 - 8580, Japan"));

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
               .Add(new Paragraph("SICCION MARKETING INC"));
            Cell cell33 = new Cell(1, 1)
               .SetTextAlignment(TextAlignment.RIGHT).SetBorder(Border.NO_BORDER).SetPadding(0f)
               .Add(new Paragraph("Carrier").SetBold());
            Cell cell34 = new Cell(1, 1)
               .SetTextAlignment(TextAlignment.CENTER).SetBorder(Border.NO_BORDER).SetPadding(0f)
               .Add(new Paragraph(""));

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
               .Add(new Paragraph("LCL - EXW"));
            Cell cell43 = new Cell(1, 1)
              .SetTextAlignment(TextAlignment.RIGHT).SetBorder(Border.NO_BORDER).SetPadding(0f)
              .Add(new Paragraph("Transit time").SetBold());
            Cell cell44 = new Cell(1, 1)
               .SetTextAlignment(TextAlignment.CENTER).SetBorder(Border.NO_BORDER).SetPadding(0f)
               .Add(new Paragraph(""));

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
               .Add(new Paragraph("DETACHABLE LI-ION BATERY"));
            Cell cell53 = new Cell(1, 1)
              .SetTextAlignment(TextAlignment.RIGHT).SetBorder(Border.NO_BORDER).SetPadding(0f)
              .Add(new Paragraph("Nature of Cargo").SetBold());
            Cell cell54 = new Cell(1, 1)
               .SetTextAlignment(TextAlignment.CENTER).SetBorder(Border.NO_BORDER).SetPadding(0f)
               .Add(new Paragraph("DG UN3480 Class9 **NO USED ONLY"));

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
               .Add(new Paragraph("3.01"));
            Cell cell63 = new Cell(1, 1)
                .SetTextAlignment(TextAlignment.RIGHT).SetBorder(Border.NO_BORDER).SetPadding(0f)
                .Add(new Paragraph("Rate Validity").SetBold());
            Cell cell64 = new Cell(1, 1)
               .SetTextAlignment(TextAlignment.CENTER).SetBorder(Border.NO_BORDER).SetPadding(0f)
               .Add(new Paragraph("END OF JULY"));

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
               .Add(new Paragraph("0.111"));
            Cell cell73 = new Cell(1, 1)
               .SetTextAlignment(TextAlignment.RIGHT).SetBorder(Border.NO_BORDER).SetPadding(0f)
                .Add(new Paragraph("Payment Terms").SetBold());
            Cell cell74 = new Cell(1, 1)
               .SetTextAlignment(TextAlignment.CENTER).SetBorder(Border.NO_BORDER).SetPadding(0f)
               .Add(new Paragraph("7 DAYS"));

            table.AddCell(cell71);
            table.AddCell(cell72);
            table.AddCell(cell73);
            table.AddCell(cell74);

            //ROW 8
            Cell cell81 = new Cell(1, 1)
             .SetTextAlignment(TextAlignment.RIGHT).SetBorder(Border.NO_BORDER).SetPadding(0f)
             .Add(new Paragraph("Volume").SetBold());
            Cell cell82 = new Cell(1, 1)
               .SetTextAlignment(TextAlignment.CENTER).SetBorder(Border.NO_BORDER).SetPadding(0f)
               .Add(new Paragraph("LCL"));
            Cell cell83 = new Cell(1, 1)
            .SetTextAlignment(TextAlignment.RIGHT).SetBorder(Border.NO_BORDER).SetPadding(0f)
            .Add(new Paragraph("Exchange Rate (Subject to Change)").SetBold());
            Cell cell84 = new Cell(1, 1)
               .SetTextAlignment(TextAlignment.CENTER).SetBorder(Border.NO_BORDER).SetPadding(0f)
               .Add(new Paragraph("PHP 53.00"));

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
               .Add(new Paragraph("TOKYO CFS"));
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
            Table table2 = new Table(6);
            table2.SetWidth(500);
            table2.SetFontSize(6);

            //ROW 1
            Cell row11 = new Cell(1, 1).SetTextAlignment(TextAlignment.CENTER).SetPadding(0f).Add(new Paragraph("PARTICULAR/S").SetBackgroundColor(Color.ConvertRgbToCmyk(new DeviceRgb(21, 74, 150))).SetFontColor(Color.ConvertRgbToCmyk(new DeviceRgb(255,255,255))));
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

            //ROW 3
            Cell row31 = new Cell(1, 1).SetTextAlignment(TextAlignment.LEFT).SetPadding(0f).Add(new Paragraph("OCEAN FREIGHT").SetPaddingLeft(3));
            Cell row32 = new Cell(1, 1).SetTextAlignment(TextAlignment.CENTER).SetPadding(0f).Add(new Paragraph("USD"));
            Cell row33 = new Cell(1, 1).SetTextAlignment(TextAlignment.RIGHT).SetPadding(0f).Add(new Paragraph("USD 185.00").SetPaddingRight(3));
            Cell row34 = new Cell(1, 1).SetTextAlignment(TextAlignment.RIGHT).SetPadding(0f).Add(new Paragraph("1").SetPaddingRight(3));
            Cell row35 = new Cell(1, 1).SetTextAlignment(TextAlignment.RIGHT).SetPadding(0f).Add(new Paragraph("PHP 9,805.00").SetPaddingRight(3));
            Cell row36 = new Cell(1, 1).SetTextAlignment(TextAlignment.LEFT).SetPadding(0f).Add(new Paragraph("MIN. OF 1 CBM").SetPaddingLeft(3));

            table2.AddCell(row31);
            table2.AddCell(row32);
            table2.AddCell(row33);
            table2.AddCell(row34);
            table2.AddCell(row35);
            table2.AddCell(row36);

            //ROW 4
            Cell row41 = new Cell(1, 6).SetPadding(0f).Add(newline);
            table2.AddCell(row41);

            //ROW 5
            Cell row51 = new Cell(1, 6).SetTextAlignment(TextAlignment.LEFT).SetBold().SetPadding(0f).Add(new Paragraph("ORIGIN CHARGES:").SetPaddingLeft(3)).SetBackgroundColor(Color.ConvertRgbToCmyk(new DeviceRgb(255, 255, 0)));
            table2.AddCell(row51);

            //ROW 6
            Cell row61 = new Cell(1, 1).SetTextAlignment(TextAlignment.LEFT).SetPadding(0f).Add(new Paragraph("FAF").SetPaddingLeft(3));
            Cell row62 = new Cell(1, 1).SetTextAlignment(TextAlignment.CENTER).SetPadding(0f).Add(new Paragraph("USD"));
            Cell row63 = new Cell(1, 1).SetTextAlignment(TextAlignment.RIGHT).SetPadding(0f).Add(new Paragraph("USD 22.00").SetPaddingRight(3));
            Cell row64 = new Cell(1, 1).SetTextAlignment(TextAlignment.RIGHT).SetPadding(0f).Add(new Paragraph("1").SetPaddingRight(3));
            Cell row65 = new Cell(1, 1).SetTextAlignment(TextAlignment.RIGHT).SetPadding(0f).Add(new Paragraph("PHP 1,166.00").SetPaddingRight(3));
            Cell row66 = new Cell(1, 1).SetTextAlignment(TextAlignment.LEFT).SetPadding(0f).Add(new Paragraph("PER RT").SetPaddingLeft(3));

            table2.AddCell(row61);
            table2.AddCell(row62);
            table2.AddCell(row63);
            table2.AddCell(row64);
            table2.AddCell(row65);
            table2.AddCell(row66);

            //ROW 7
            Cell row71 = new Cell(1, 1).SetTextAlignment(TextAlignment.LEFT).SetPadding(0f).Add(new Paragraph("LSS").SetPaddingLeft(3));
            Cell row72 = new Cell(1, 1).SetTextAlignment(TextAlignment.CENTER).SetPadding(0f).Add(new Paragraph("USD"));
            Cell row73 = new Cell(1, 1).SetTextAlignment(TextAlignment.RIGHT).SetPadding(0f).Add(new Paragraph("USD 11.00").SetPaddingRight(3));
            Cell row74 = new Cell(1, 1).SetTextAlignment(TextAlignment.RIGHT).SetPadding(0f).Add(new Paragraph("1").SetPaddingRight(3));
            Cell row75 = new Cell(1, 1).SetTextAlignment(TextAlignment.RIGHT).SetPadding(0f).Add(new Paragraph("PHP 583.00").SetPaddingRight(3));
            Cell row76 = new Cell(1, 1).SetTextAlignment(TextAlignment.LEFT).SetPadding(0f).Add(new Paragraph("PER RT").SetPaddingLeft(3));

            table2.AddCell(row71);
            table2.AddCell(row72);
            table2.AddCell(row73);
            table2.AddCell(row74);
            table2.AddCell(row75);
            table2.AddCell(row76);

            //ROW 8
            Cell row81 = new Cell(1, 1).SetTextAlignment(TextAlignment.LEFT).SetPadding(0f).Add(new Paragraph("PSS").SetPaddingLeft(3));
            Cell row82 = new Cell(1, 1).SetTextAlignment(TextAlignment.CENTER).SetPadding(0f).Add(new Paragraph("USD"));
            Cell row83 = new Cell(1, 1).SetTextAlignment(TextAlignment.RIGHT).SetPadding(0f).Add(new Paragraph("USD 38.00").SetPaddingRight(3));
            Cell row84 = new Cell(1, 1).SetTextAlignment(TextAlignment.RIGHT).SetPadding(0f).Add(new Paragraph("1").SetPaddingRight(3));
            Cell row85 = new Cell(1, 1).SetTextAlignment(TextAlignment.RIGHT).SetPadding(0f).Add(new Paragraph("PHP 2,014.00").SetPaddingRight(3));
            Cell row86 = new Cell(1, 1).SetTextAlignment(TextAlignment.LEFT).SetPadding(0f).Add(new Paragraph("PER RT").SetPaddingLeft(3));

            table2.AddCell(row81);
            table2.AddCell(row82);
            table2.AddCell(row83);
            table2.AddCell(row84);
            table2.AddCell(row85);
            table2.AddCell(row86);

            //ROW 9
            Cell row91 = new Cell(1, 4).SetTextAlignment(TextAlignment.CENTER).SetPadding(0f).SetBold().Add(new Paragraph("SUBTOTAL"));
            Cell row92 = new Cell(1, 2).SetTextAlignment(TextAlignment.LEFT).SetPadding(0f).SetBold().Add(new Paragraph("PHP 21,518.00").SetPaddingLeft(3));

            table2.AddCell(row91);
            table2.AddCell(row92);

            //ROW 10
            Cell row101 = new Cell(1, 6).SetPadding(0f).Add(newline);
            table2.AddCell(row101);

            //ROW 11
            Cell row111 = new Cell(1, 6).SetTextAlignment(TextAlignment.LEFT).SetBold().SetPadding(0f).Add(new Paragraph("DESTINATION LOCAL CHARGES:").SetPaddingLeft(3)).SetBackgroundColor(Color.ConvertRgbToCmyk(new DeviceRgb(255, 255, 0)));
            table2.AddCell(row111);

        

            //ROW 12
            Cell row121 = new Cell(1, 1).SetTextAlignment(TextAlignment.LEFT).SetPadding(0f).Add(new Paragraph("LCL").SetPaddingLeft(3));
            Cell row122 = new Cell(1, 1).SetTextAlignment(TextAlignment.CENTER).SetPadding(0f).Add(new Paragraph("PHP"));
            Cell row123 = new Cell(1, 1).SetTextAlignment(TextAlignment.RIGHT).SetPadding(0f).Add(new Paragraph("PHP 800.00").SetPaddingRight(3));
            Cell row124 = new Cell(1, 1).SetTextAlignment(TextAlignment.RIGHT).SetPadding(0f).Add(new Paragraph("1").SetPaddingRight(3));
            Cell row125 = new Cell(1, 1).SetTextAlignment(TextAlignment.RIGHT).SetPadding(0f).Add(new Paragraph("PHP 800.00").SetPaddingRight(3));
            Cell row126 = new Cell(1, 1).SetTextAlignment(TextAlignment.LEFT).SetPadding(0f).Add(new Paragraph("PER RT").SetPaddingLeft(3));

            table2.AddCell(row121);
            table2.AddCell(row122);
            table2.AddCell(row123);
            table2.AddCell(row124);
            table2.AddCell(row125);
            table2.AddCell(row126);

            //ROW 13
            Cell row131 = new Cell(1, 1).SetTextAlignment(TextAlignment.LEFT).SetPadding(0f).Add(new Paragraph("THC").SetPaddingLeft(3));
            Cell row132 = new Cell(1, 1).SetTextAlignment(TextAlignment.CENTER).SetPadding(0f).Add(new Paragraph("PHP"));
            Cell row133 = new Cell(1, 1).SetTextAlignment(TextAlignment.RIGHT).SetPadding(0f).Add(new Paragraph("PHP 300.00").SetPaddingRight(3));
            Cell row134 = new Cell(1, 1).SetTextAlignment(TextAlignment.RIGHT).SetPadding(0f).Add(new Paragraph("1").SetPaddingRight(3));
            Cell row135 = new Cell(1, 1).SetTextAlignment(TextAlignment.RIGHT).SetPadding(0f).Add(new Paragraph("PHP 300.00").SetPaddingRight(3));
            Cell row136 = new Cell(1, 1).SetTextAlignment(TextAlignment.LEFT).SetPadding(0f).Add(new Paragraph("PER RT").SetPaddingLeft(3));

            table2.AddCell(row131);
            table2.AddCell(row132);
            table2.AddCell(row133);
            table2.AddCell(row134);
            table2.AddCell(row135);
            table2.AddCell(row136);

            //ROW 14
            Cell row141 = new Cell(1, 1).SetTextAlignment(TextAlignment.LEFT).SetPadding(0f).Add(new Paragraph("HANDLING FEE").SetPaddingLeft(3));
            Cell row142 = new Cell(1, 1).SetTextAlignment(TextAlignment.CENTER).SetPadding(0f).Add(new Paragraph("PHP"));
            Cell row143 = new Cell(1, 1).SetTextAlignment(TextAlignment.RIGHT).SetPadding(0f).Add(new Paragraph("PHP 800.00").SetPaddingRight(3));
            Cell row144 = new Cell(1, 1).SetTextAlignment(TextAlignment.RIGHT).SetPadding(0f).Add(new Paragraph("1").SetPaddingRight(3));
            Cell row145 = new Cell(1, 1).SetTextAlignment(TextAlignment.RIGHT).SetPadding(0f).Add(new Paragraph("PHP 800.00").SetPaddingRight(3));
            Cell row146 = new Cell(1, 1).SetTextAlignment(TextAlignment.LEFT).SetPadding(0f).Add(new Paragraph("PER BL").SetPaddingLeft(3));

            table2.AddCell(row141);
            table2.AddCell(row142);
            table2.AddCell(row143);
            table2.AddCell(row144);
            table2.AddCell(row145);
            table2.AddCell(row146);

            //ROW 15
            Cell row151 = new Cell(1, 1).SetTextAlignment(TextAlignment.LEFT).SetPadding(0f).Add(new Paragraph("DOCUMENTATION").SetPaddingLeft(3));
            Cell row152 = new Cell(1, 1).SetTextAlignment(TextAlignment.CENTER).SetPadding(0f).Add(new Paragraph("PHP"));
            Cell row153 = new Cell(1, 1).SetTextAlignment(TextAlignment.RIGHT).SetPadding(0f).Add(new Paragraph("PHP 800.00").SetPaddingRight(3));
            Cell row154 = new Cell(1, 1).SetTextAlignment(TextAlignment.RIGHT).SetPadding(0f).Add(new Paragraph("1").SetPaddingRight(3));
            Cell row155 = new Cell(1, 1).SetTextAlignment(TextAlignment.RIGHT).SetPadding(0f).Add(new Paragraph("PHP 800.00").SetPaddingRight(3));
            Cell row156 = new Cell(1, 1).SetTextAlignment(TextAlignment.LEFT).SetPadding(0f).Add(new Paragraph("PER BL").SetPaddingLeft(3));

            table2.AddCell(row151);
            table2.AddCell(row152);
            table2.AddCell(row153);
            table2.AddCell(row154);
            table2.AddCell(row155);
            table2.AddCell(row156);

            //ROW 16
            Cell row161 = new Cell(1, 1).SetTextAlignment(TextAlignment.LEFT).SetPadding(0f).Add(new Paragraph("TURNOVER FEE").SetPaddingLeft(3));
            Cell row162 = new Cell(1, 1).SetTextAlignment(TextAlignment.CENTER).SetPadding(0f).Add(new Paragraph("PHP"));
            Cell row163 = new Cell(1, 1).SetTextAlignment(TextAlignment.RIGHT).SetPadding(0f).Add(new Paragraph("PHP 800.00").SetPaddingRight(3));
            Cell row164 = new Cell(1, 1).SetTextAlignment(TextAlignment.RIGHT).SetPadding(0f).Add(new Paragraph("1").SetPaddingRight(3));
            Cell row165 = new Cell(1, 1).SetTextAlignment(TextAlignment.RIGHT).SetPadding(0f).Add(new Paragraph("PHP 800.00").SetPaddingRight(3));
            Cell row166 = new Cell(1, 1).SetTextAlignment(TextAlignment.LEFT).SetPadding(0f).Add(new Paragraph("PER BL").SetPaddingLeft(3));

            table2.AddCell(row161);
            table2.AddCell(row162);
            table2.AddCell(row163);
            table2.AddCell(row164);
            table2.AddCell(row165);
            table2.AddCell(row166);

            //ROW 17
            Cell row171 = new Cell(1, 1).SetTextAlignment(TextAlignment.LEFT).SetPadding(0f).Add(new Paragraph("BL FEE").SetPaddingLeft(3));
            Cell row172 = new Cell(1, 1).SetTextAlignment(TextAlignment.CENTER).SetPadding(0f).Add(new Paragraph("USD"));
            Cell row173 = new Cell(1, 1).SetTextAlignment(TextAlignment.RIGHT).SetPadding(0f).Add(new Paragraph("PHP 45.00").SetPaddingRight(3));
            Cell row174 = new Cell(1, 1).SetTextAlignment(TextAlignment.RIGHT).SetPadding(0f).Add(new Paragraph("1").SetPaddingRight(3));
            Cell row175 = new Cell(1, 1).SetTextAlignment(TextAlignment.RIGHT).SetPadding(0f).Add(new Paragraph("PHP 2,385.00").SetPaddingRight(3));
            Cell row176 = new Cell(1, 1).SetTextAlignment(TextAlignment.LEFT).SetPadding(0f).Add(new Paragraph("PER BL").SetPaddingLeft(3));

            table2.AddCell(row171);
            table2.AddCell(row172);
            table2.AddCell(row173);
            table2.AddCell(row174);
            table2.AddCell(row175);
            table2.AddCell(row176);


            //ROW 18
            Cell row181 = new Cell(1, 4).SetTextAlignment(TextAlignment.CENTER).SetPadding(0f).SetBold().Add(new Paragraph("SUBTOTAL"));
            Cell row182 = new Cell(1, 2).SetTextAlignment(TextAlignment.LEFT).SetPadding(0f).SetBold().Add(new Paragraph("PHP 13,866.50").SetPaddingLeft(3));

            table2.AddCell(row181);
            table2.AddCell(row182);

            //ROW 19
            Cell row191 = new Cell(1, 4).SetTextAlignment(TextAlignment.CENTER).SetPadding(0f).Add(new Paragraph("ESTIMATED TOTAL CHARGES (SUBJECT TO CHANGE)").SetBackgroundColor(Color.ConvertRgbToCmyk(new DeviceRgb(21, 74, 150))).SetFontColor(Color.ConvertRgbToCmyk(new DeviceRgb(255, 255, 255))));
            Cell row192 = new Cell(1, 2).SetTextAlignment(TextAlignment.CENTER).SetPadding(0f).Add(new Paragraph("PHP 45,189.50").SetBackgroundColor(Color.ConvertRgbToCmyk(new DeviceRgb(21, 74, 150))).SetFontColor(Color.ConvertRgbToCmyk(new DeviceRgb(255, 255, 255))));

            table2.AddCell(row191);
            table2.AddCell(row192);

            document.Add(table2);




            document.Add(newline);
            Paragraph paragraph1 = new Paragraph("Terms & Conditions:").SetBold().SetFontSize(5);
            document.Add(paragraph1);
            Paragraph paragraph2 = new Paragraph("1. Freight and service charges are to be deemed earned whether cargo is damaged or lost.\n" +
                "2. Coverage for All-risk marine insurance will be the responsibility of the customer and hence shall be for the account of the customer.\n" +
                "3. Above rates are subject to change without prior notice.\n" +
                "4. Local service charges are subject to 12% VAT.\n" +
                "5. Above proposal is subject to equipment and space availability.\n" +
                "6. As a freight forwarder, Falcons Freight Forwarding Services, shall not be liable for delay, damage, loss of cargo due to any event of force majeure, acts of God or unforeseen fortuitous events beyond our control.\n" +
                "7. All transactions are subject to our Company’s standard trading conditions.\n" +
                "8. In the event the shipping documents are amended to specify the cargoes, parties in interest, rates and other entries, upon instruction of shipper or consignee or their agents, to reflect the intent of the parties or to comply with regulations of the country / s of destination, the instructing party shall hold FFFS free from any claim or liabilities thereon.\n" +
                "9. 5% of the air or ocean freight is subject to 12% VAT per BIR Revenue Memorandum Circular (RMC) 35-2006 dated June 21, 2006.\n" +
                "10. Any question, clarification to our invoice and charges must be raised and cleared within 5 business days from receipt, otherwise invoices are deemed acceptable and subject for payment.").SetFontSize(5);
            document.Add(paragraph2);

            document.Add(newline);
            Paragraph paragraph3 = new Paragraph("Prepared by:").SetBold().SetFontSize(5);
            document.Add(paragraph3);


            // Table
            Table table3 = new Table(1);
            table3.SetWidth(100);
            table3.SetFontSize(5);

            Cell Table3Cell11 = new Cell(1, 1)
                .SetTextAlignment(TextAlignment.LEFT).SetBorder(Border.NO_BORDER).SetPadding(0f)
               .Add(new Paragraph("Arron Alvaro").SetBold());
            table3.AddCell(Table3Cell11);

            Cell Table3Cell21 = new Cell(1, 1)
                .SetTextAlignment(TextAlignment.LEFT).SetBorder(Border.NO_BORDER).SetPadding(0f)
               .Add(new Paragraph("Sales Specialist"));
            table3.AddCell(Table3Cell21);

            document.Add(table3);

            document.Add(newline);

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
    }

}