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
    public class Quotation_containerDO
    {

        public DataTable SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase("ApplicationServices");
            String sqlcommand = "[dbo].[quotation_container.SelectAll]";
            DbCommand dbcommand = db.GetStoredProcCommand(sqlcommand);
            return db.ExecuteDataSet(dbcommand).Tables[0];
        }

        public DataTable Select(Quotation_container Entity)
        {
            object[] obj = new object[8];
            obj[0] = Entity.Id;
            obj[1] = Entity.Quotation_id;
            obj[2] = Entity.Container_id;
            obj[3] = Entity.Qty;
            obj[4] = Entity.Created;
            obj[5] = Entity.Creator;
            obj[6] = Entity.Updated;
            obj[7] = Entity.Updater;
            Database db = DatabaseFactory.CreateDatabase("ApplicationServices");
            String sqlcommand = "[dbo].[quotation_container.Select]";
            DbCommand dbcommand = db.GetStoredProcCommand(sqlcommand, obj);
            return db.ExecuteDataSet(dbcommand).Tables[0];
        }

        public void Insert(Quotation_container Entity)
        {
            int Result = 0;
            object[] obj = new object[8];
            obj[0] = Entity.Id;
            obj[1] = Entity.Quotation_id;
            obj[2] = Entity.Container_id;
            obj[3] = Entity.Qty;
            obj[4] = Entity.Created;
            obj[5] = Entity.Creator;
            obj[6] = Entity.Updated;
            obj[7] = Entity.Updater;
            Database db = DatabaseFactory.CreateDatabase("ApplicationServices");
            String sqlcommand = "[dbo].[quotation_container.Insert]";
            DbCommand dbcommand = db.GetStoredProcCommand(sqlcommand, obj);
            Result = db.ExecuteNonQuery(dbcommand);

            //Entity.Indexid = Convert.ToInt32(dbcommand.Parameters["@indexid"].Value);
        }

        public void Update(Quotation_container Entity)
        {
            int Result = 0;
            object[] obj = new object[8];
            obj[0] = Entity.Id;
            obj[1] = Entity.Quotation_id;
            obj[2] = Entity.Container_id;
            obj[3] = Entity.Qty;
            obj[4] = Entity.Created;
            obj[5] = Entity.Creator;
            obj[6] = Entity.Updated;
            obj[7] = Entity.Updater;
            Database db = DatabaseFactory.CreateDatabase("ApplicationServices");
            String sqlcommand = "[dbo].[quotation_container.Update]";
            DbCommand dbcommand = db.GetStoredProcCommand(sqlcommand, obj);
            Result = db.ExecuteNonQuery(dbcommand);
        }

        public void Delete(Quotation_container Entity)
        {
            int Result = 0;
            object[] obj = new object[2];
            obj[0] = Entity.Id;
            obj[1] = Entity.Updater;
            Database db = DatabaseFactory.CreateDatabase("ApplicationServices");
            String sqlcommand = "[dbo].[quotation_container.Delete]";
            DbCommand dbcommand = db.GetStoredProcCommand(sqlcommand, obj);
            Result = db.ExecuteNonQuery(dbcommand);
        }

        public DataTable SelectByQuotationId(Quotation_container Entity)
        {
            object[] obj = new object[1];
            obj[0] = Entity.Quotation_id;

            Database db = DatabaseFactory.CreateDatabase("ApplicationServices");
            String sqlcommand = "[dbo].[quotation_container.SelectByQuotationId]";
            DbCommand dbcommand = db.GetStoredProcCommand(sqlcommand, obj);
            return db.ExecuteDataSet(dbcommand).Tables[0];
        }
    }
}