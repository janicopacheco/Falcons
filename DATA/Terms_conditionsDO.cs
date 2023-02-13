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
    public class Terms_conditionsDO
    {

        public DataTable SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase("ApplicationServices");
            String sqlcommand = "[dbo].[terms_conditions.SelectAll]";
            DbCommand dbcommand = db.GetStoredProcCommand(sqlcommand);
            return db.ExecuteDataSet(dbcommand).Tables[0];
        }

        public DataTable Select(Terms_conditions Entity)
        {
            object[] obj = new object[7];
            obj[0] = Entity.Id;
            obj[1] = Entity.Name;
            obj[2] = Entity.Sequence;
            obj[3] = Entity.Creator;
            obj[4] = Entity.Created;
            obj[5] = Entity.Updater;
            obj[6] = Entity.Updated;
            Database db = DatabaseFactory.CreateDatabase("ApplicationServices");
            String sqlcommand = "[dbo].[terms_conditions.Select]";
            DbCommand dbcommand = db.GetStoredProcCommand(sqlcommand, obj);
            return db.ExecuteDataSet(dbcommand).Tables[0];
        }

        public void Insert(Terms_conditions Entity)
        {
            int Result = 0;
            object[] obj = new object[7];
            obj[0] = Entity.Id;
            obj[1] = Entity.Name;
            obj[2] = Entity.Sequence;
            obj[3] = Entity.Creator;
            obj[4] = Entity.Created;
            obj[5] = Entity.Updater;
            obj[6] = Entity.Updated;
            Database db = DatabaseFactory.CreateDatabase("ApplicationServices");
            String sqlcommand = "[dbo].[terms_conditions.Insert]";
            DbCommand dbcommand = db.GetStoredProcCommand(sqlcommand, obj);
            Result = db.ExecuteNonQuery(dbcommand);

            //Entity.Indexid = Convert.ToInt32(dbcommand.Parameters["@indexid"].Value);
        }

        public void Update(Terms_conditions Entity)
        {
            int Result = 0;
            object[] obj = new object[7];
            obj[0] = Entity.Id;
            obj[1] = Entity.Name;
            obj[2] = Entity.Sequence;
            obj[3] = Entity.Creator;
            obj[4] = Entity.Created;
            obj[5] = Entity.Updater;
            obj[6] = Entity.Updated;
            Database db = DatabaseFactory.CreateDatabase("ApplicationServices");
            String sqlcommand = "[dbo].[terms_conditions.Update]";
            DbCommand dbcommand = db.GetStoredProcCommand(sqlcommand, obj);
            Result = db.ExecuteNonQuery(dbcommand);
        }

        public void Delete(Terms_conditions Entity)
        {
            int Result = 0;
            object[] obj = new object[2];
            obj[0] = Entity.Id;
            obj[1] = Entity.Updater;
            Database db = DatabaseFactory.CreateDatabase("ApplicationServices");
            String sqlcommand = "[dbo].[terms_conditions.Delete]";
            DbCommand dbcommand = db.GetStoredProcCommand(sqlcommand, obj);
            Result = db.ExecuteNonQuery(dbcommand);
        }
    }
}