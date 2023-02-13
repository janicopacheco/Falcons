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
    public class CurrencyDO
    {

        public DataTable SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase("ApplicationServices");
            String sqlcommand = "[dbo].[currency.SelectAll]";
            DbCommand dbcommand = db.GetStoredProcCommand(sqlcommand);
            return db.ExecuteDataSet(dbcommand).Tables[0];
        }

        public DataTable Select(Currency Entity)
        {
            object[] obj = new object[7];
            obj[0] = Entity.Id;
            obj[1] = Entity.Name;
            obj[2] = Entity.Amount;
            obj[3] = Entity.Creator;
            obj[4] = Entity.Created;
            obj[5] = Entity.Updater;
            obj[6] = Entity.Updated;
            Database db = DatabaseFactory.CreateDatabase("ApplicationServices");
            String sqlcommand = "[dbo].[currency.Select]";
            DbCommand dbcommand = db.GetStoredProcCommand(sqlcommand, obj);
            return db.ExecuteDataSet(dbcommand).Tables[0];
        }

        public void Insert(Currency Entity)
        {
            int Result = 0;
            object[] obj = new object[7];
            obj[0] = Entity.Id;
            obj[1] = Entity.Name;
            obj[2] = Entity.Amount;
            obj[3] = Entity.Creator;
            obj[4] = Entity.Created;
            obj[5] = Entity.Updater;
            obj[6] = Entity.Updated;
            Database db = DatabaseFactory.CreateDatabase("ApplicationServices");
            String sqlcommand = "[dbo].[currency.Insert]";
            DbCommand dbcommand = db.GetStoredProcCommand(sqlcommand, obj);
            Result = db.ExecuteNonQuery(dbcommand);

            //Entity.Indexid = Convert.ToInt32(dbcommand.Parameters["@indexid"].Value);
        }

        public void Update(Currency Entity)
        {
            int Result = 0;
            object[] obj = new object[7];
            obj[0] = Entity.Id;
            obj[1] = Entity.Name;
            obj[2] = Entity.Amount;
            obj[3] = Entity.Creator;
            obj[4] = Entity.Created;
            obj[5] = Entity.Updater;
            obj[6] = Entity.Updated;
            Database db = DatabaseFactory.CreateDatabase("ApplicationServices");
            String sqlcommand = "[dbo].[currency.Update]";
            DbCommand dbcommand = db.GetStoredProcCommand(sqlcommand, obj);
            Result = db.ExecuteNonQuery(dbcommand);
        }

        public void Delete(Currency Entity)
        {
            int Result = 0;
            object[] obj = new object[2];
            obj[0] = Entity.Id;
            obj[1] = Entity.Updater;
            Database db = DatabaseFactory.CreateDatabase("ApplicationServices");
            String sqlcommand = "[dbo].[currency.Delete]";
            DbCommand dbcommand = db.GetStoredProcCommand(sqlcommand, obj);
            Result = db.ExecuteNonQuery(dbcommand);
        }
    }
}