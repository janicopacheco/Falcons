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
    public class ClientDO
    {

        public DataTable SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase("ApplicationServices");
            String sqlcommand = "[dbo].[client.SelectAll]";
            DbCommand dbcommand = db.GetStoredProcCommand(sqlcommand);
            return db.ExecuteDataSet(dbcommand).Tables[0];
        }

        public DataTable Select(Client Entity)
        {
            object[] obj = new object[10];
            obj[0] = Entity.Id;
            obj[1] = Entity.Name;
            obj[2] = Entity.Address;
            obj[3] = Entity.Tin;
            obj[4] = Entity.Contactno;
            obj[5] = Entity.Contactperson;
            obj[6] = Entity.Creator;
            obj[7] = Entity.Created;
            obj[8] = Entity.Updater;
            obj[9] = Entity.Updated;
            Database db = DatabaseFactory.CreateDatabase("ApplicationServices");
            String sqlcommand = "[dbo].[client.Select]";
            DbCommand dbcommand = db.GetStoredProcCommand(sqlcommand, obj);
            return db.ExecuteDataSet(dbcommand).Tables[0];
        }

        public void Insert(Client Entity)
        {
            int Result = 0;
            object[] obj = new object[10];
            obj[0] = Entity.Id;
            obj[1] = Entity.Name;
            obj[2] = Entity.Address;
            obj[3] = Entity.Tin;
            obj[4] = Entity.Contactno;
            obj[5] = Entity.Contactperson;
            obj[6] = Entity.Creator;
            obj[7] = Entity.Created;
            obj[8] = Entity.Updater;
            obj[9] = Entity.Updated;
            Database db = DatabaseFactory.CreateDatabase("ApplicationServices");
            String sqlcommand = "[dbo].[client.Insert]";
            DbCommand dbcommand = db.GetStoredProcCommand(sqlcommand, obj);
            Result = db.ExecuteNonQuery(dbcommand);

            //Entity.Indexid = Convert.ToInt32(dbcommand.Parameters["@indexid"].Value);
        }

        public void Update(Client Entity)
        {
            int Result = 0;
            object[] obj = new object[10];
            obj[0] = Entity.Id;
            obj[1] = Entity.Name;
            obj[2] = Entity.Address;
            obj[3] = Entity.Tin;
            obj[4] = Entity.Contactno;
            obj[5] = Entity.Contactperson;
            obj[6] = Entity.Creator;
            obj[7] = Entity.Created;
            obj[8] = Entity.Updater;
            obj[9] = Entity.Updated;
            Database db = DatabaseFactory.CreateDatabase("ApplicationServices");
            String sqlcommand = "[dbo].[client.Update]";
            DbCommand dbcommand = db.GetStoredProcCommand(sqlcommand, obj);
            Result = db.ExecuteNonQuery(dbcommand);
        }

        public void Delete(Client Entity)
        {
            int Result = 0;
            object[] obj = new object[2];
            obj[0] = Entity.Id;
            obj[1] = Entity.Updater;
            Database db = DatabaseFactory.CreateDatabase("ApplicationServices");
            String sqlcommand = "[dbo].[client.Delete]";
            DbCommand dbcommand = db.GetStoredProcCommand(sqlcommand, obj);
            Result = db.ExecuteNonQuery(dbcommand);
        }
    }
}