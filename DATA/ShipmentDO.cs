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
    public class ShipmentDO
    {

        public DataTable SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase("ApplicationServices");
            String sqlcommand = "[dbo].[shipment.SelectAll]";
            DbCommand dbcommand = db.GetStoredProcCommand(sqlcommand);
            return db.ExecuteDataSet(dbcommand).Tables[0];
        }

        public DataTable Select(Shipment Entity)
        {
            object[] obj = new object[7];
            obj[0] = Entity.Id;
            obj[1] = Entity.Name;
            obj[2] = Entity.Description;
            obj[3] = Entity.Created;
            obj[4] = Entity.Creator;
            obj[5] = Entity.Updated;
            obj[6] = Entity.Updater;
            Database db = DatabaseFactory.CreateDatabase("ApplicationServices");
            String sqlcommand = "[dbo].[shipment.Select]";
            DbCommand dbcommand = db.GetStoredProcCommand(sqlcommand, obj);
            return db.ExecuteDataSet(dbcommand).Tables[0];
        }

        public void Insert(Shipment Entity)
        {
            int Result = 0;
            object[] obj = new object[7];
            obj[0] = Entity.Id;
            obj[1] = Entity.Name;
            obj[2] = Entity.Description;
            obj[3] = Entity.Created;
            obj[4] = Entity.Creator;
            obj[5] = Entity.Updated;
            obj[6] = Entity.Updater;
            Database db = DatabaseFactory.CreateDatabase("ApplicationServices");
            String sqlcommand = "[dbo].[shipment.Insert]";
            DbCommand dbcommand = db.GetStoredProcCommand(sqlcommand, obj);
            Result = db.ExecuteNonQuery(dbcommand);

            //Entity.Indexid = Convert.ToInt32(dbcommand.Parameters["@indexid"].Value);
        }

        public void Update(Shipment Entity)
        {
            int Result = 0;
            object[] obj = new object[7];
            obj[0] = Entity.Id;
            obj[1] = Entity.Name;
            obj[2] = Entity.Description;
            obj[3] = Entity.Created;
            obj[4] = Entity.Creator;
            obj[5] = Entity.Updated;
            obj[6] = Entity.Updater;
            Database db = DatabaseFactory.CreateDatabase("ApplicationServices");
            String sqlcommand = "[dbo].[shipment.Update]";
            DbCommand dbcommand = db.GetStoredProcCommand(sqlcommand, obj);
            Result = db.ExecuteNonQuery(dbcommand);
        }

        public void Delete(Shipment Entity)
        {
            int Result = 0;
            object[] obj = new object[2];
            obj[0] = Entity.Id;
            obj[1] = Entity.Updater;
            Database db = DatabaseFactory.CreateDatabase("ApplicationServices");
            String sqlcommand = "[dbo].[shipment.Delete]";
            DbCommand dbcommand = db.GetStoredProcCommand(sqlcommand, obj);
            Result = db.ExecuteNonQuery(dbcommand);
        }
    }
}