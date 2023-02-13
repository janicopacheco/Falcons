using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

using ENTITY;

namespace DATA
{
    [Serializable]
    public class Quotation_origin_chargesDO
    {

        public DataTable SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase("ApplicationServices");
            String sqlcommand = "[dbo].[quotation_origin_charges.SelectAll]";
            DbCommand dbcommand = db.GetStoredProcCommand(sqlcommand);
            return db.ExecuteDataSet(dbcommand).Tables[0];
        }

        public DataTable Select(Quotation_origin_charges Entity)
        {
            object[] obj = new object[12];
            obj[0] = Entity.Id;
            obj[1] = Entity.Quotationid;
            obj[2] = Entity.Particularid;
            obj[3] = Entity.Currency;
            obj[4] = Entity.Unit_price;
            obj[5] = Entity.Qty;
            obj[6] = Entity.Total_amount;
            obj[7] = Entity.Remarks;
            obj[8] = Entity.Created;
            obj[9] = Entity.Creator;
            obj[10] = Entity.Updated;
            obj[11] = Entity.Updater;
            Database db = DatabaseFactory.CreateDatabase("ApplicationServices");
            String sqlcommand = "[dbo].[quotation_origin_charges.Select]";
            DbCommand dbcommand = db.GetStoredProcCommand(sqlcommand, obj);
            return db.ExecuteDataSet(dbcommand).Tables[0];
        }

        public void Insert(Quotation_origin_charges Entity)
        {
            int Result = 0;
            object[] obj = new object[14];
            obj[0] = Entity.Id;
            obj[1] = Entity.Quotationid;
            obj[2] = Entity.Particularid;
            obj[3] = Entity.Currency;
            obj[4] = Entity.Unit_price;
            obj[5] = Entity.Qty;
            obj[6] = Entity.Total_amount;
            obj[7] = Entity.Remarks;
            obj[8] = Entity.Created;
            obj[9] = Entity.Creator;
            obj[10] = Entity.Updated;
            obj[11] = Entity.Updater;
            obj[12] = Entity.Agent_amount;
            obj[13] = Entity.Container_id;
            Database db = DatabaseFactory.CreateDatabase("ApplicationServices");
            String sqlcommand = "[dbo].[quotation_origin_charges.Insert]";
            DbCommand dbcommand = db.GetStoredProcCommand(sqlcommand, obj);
            Result = db.ExecuteNonQuery(dbcommand);

            //Entity.Indexid = Convert.ToInt32(dbcommand.Parameters["@indexid"].Value);
        }

        public void Update(Quotation_origin_charges Entity)
        {
            int Result = 0;
            object[] obj = new object[14];
            obj[0] = Entity.Id;
            obj[1] = Entity.Quotationid;
            obj[2] = Entity.Particularid;
            obj[3] = Entity.Currency;
            obj[4] = Entity.Unit_price;
            obj[5] = Entity.Qty;
            obj[6] = Entity.Total_amount;
            obj[7] = Entity.Remarks;
            obj[8] = Entity.Created;
            obj[9] = Entity.Creator;
            obj[10] = Entity.Updated;
            obj[11] = Entity.Updater;
            obj[12] = Entity.Agent_amount;
            obj[13] = Entity.Container_id;
            Database db = DatabaseFactory.CreateDatabase("ApplicationServices");
            String sqlcommand = "[dbo].[quotation_origin_charges.Update]";
            DbCommand dbcommand = db.GetStoredProcCommand(sqlcommand, obj);
            Result = db.ExecuteNonQuery(dbcommand);
        }

        public void Delete(Quotation_origin_charges Entity)
        {
            int Result = 0;
            object[] obj = new object[2];
            obj[0] = Entity.Id;
            obj[1] = Entity.Updater;
            Database db = DatabaseFactory.CreateDatabase("ApplicationServices");
            String sqlcommand = "[dbo].[quotation_origin_charges.Delete]";
            DbCommand dbcommand = db.GetStoredProcCommand(sqlcommand, obj);
            Result = db.ExecuteNonQuery(dbcommand);
        }
    }
}