using ENTITY;
using PROCESS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;

namespace StraightForward
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public string GetData()
        {
            DataTable dt = new DataTable();
            StatusBO entityBO = new StatusBO();
            List<Status> liststatus = new List<Status>();

            dt = entityBO.SelectAll();

            foreach(DataRow dr in dt.Rows)
            {
                Status entity = new Status();

                entity.Id = int.Parse(dr["id"].ToString());
                entity.Name = dr["name"].ToString();

                liststatus.Add(entity);
            }


            // Method 1: use built-in serializer:
            //StringBuilder sb = new StringBuilder();
            //JavaScriptSerializer js = new JavaScriptSerializer();
            //sb.Append("callback" + "(");
            //sb.Append(js.Serialize(liststatus));
            //sb.Append(");");

            //Context.Response.Clear();
            //Context.Response.ContentType = "application/json";
            //Context.Response.Write(sb.ToString());
            //Context.Response.End();
            return DataTableToJSONWithJavaScriptSerializer(dt);
        }   


        private string DataTableToJSONWithJavaScriptSerializer(DataTable table)
        {
            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            List<Dictionary<string, object>> parentRow = new List<Dictionary<string, object>>();
            Dictionary<string, object> childRow;
            foreach (DataRow row in table.Rows)
            {
                childRow = new Dictionary<string, object>();
                foreach (DataColumn col in table.Columns)
                {
                    childRow.Add(col.ColumnName, row[col]);
                }
                parentRow.Add(childRow);
            }
            return jsSerializer.Serialize(parentRow);
        }
    }
}
