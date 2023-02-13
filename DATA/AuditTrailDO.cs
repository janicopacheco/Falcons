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
    public class AudittrailDO
    {

        public DataTable SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase("ApplicationServices");
            String sqlcommand = "[dbo].[audittrail.SelectAll]";
            DbCommand dbcommand = db.GetStoredProcCommand(sqlcommand);
            return db.ExecuteDataSet(dbcommand).Tables[0];
        }

        public DataTable Select(Audittrail Entity)
        {
            object[] obj = new object[11];
            obj[0] = Entity.Audittrailid;
            obj[1] = Entity.Userid;
            obj[2] = Entity.Action;
            obj[3] = Entity.Type;
            obj[4] = Entity.Contentid;
            obj[5] = Entity.Contentname;
            obj[6] = Entity.Details;
            obj[7] = Entity.Target;
            obj[8] = Entity.Auditdate;
            obj[9] = Entity.Remarks;
            obj[10] = Entity.Contentcode;
            Database db = DatabaseFactory.CreateDatabase("ApplicationServices");
            String sqlcommand = "[dbo].[audittrail.Select]";
            DbCommand dbcommand = db.GetStoredProcCommand(sqlcommand, obj);
            return db.ExecuteDataSet(dbcommand).Tables[0];
        }

        public void Insert(Audittrail Entity)
        {
            int Result = 0;
            object[] obj = new object[11];
            obj[0] = Entity.Audittrailid;
            obj[1] = Entity.Userid;
            obj[2] = Entity.Action;
            obj[3] = Entity.Type;
            obj[4] = Entity.Contentid;
            obj[5] = Entity.Contentname;
            obj[6] = Entity.Details;
            obj[7] = Entity.Target;
            obj[8] = Entity.Auditdate;
            obj[9] = Entity.Remarks;
            obj[10] = Entity.Contentcode;
            Database db = DatabaseFactory.CreateDatabase("ApplicationServices");
            String sqlcommand = "[dbo].[audittrail.Insert]";
            DbCommand dbcommand = db.GetStoredProcCommand(sqlcommand, obj);
            Result = db.ExecuteNonQuery(dbcommand);

            //Entity.Indexid = Convert.ToInt32(dbcommand.Parameters["@indexid"].Value);
        }

        public void Update(Audittrail Entity)
        {
            int Result = 0;
            object[] obj = new object[11];
            obj[0] = Entity.Audittrailid;
            obj[1] = Entity.Userid;
            obj[2] = Entity.Action;
            obj[3] = Entity.Type;
            obj[4] = Entity.Contentid;
            obj[5] = Entity.Contentname;
            obj[6] = Entity.Details;
            obj[7] = Entity.Target;
            obj[8] = Entity.Auditdate;
            obj[9] = Entity.Remarks;
            obj[10] = Entity.Contentcode;
            Database db = DatabaseFactory.CreateDatabase("ApplicationServices");
            String sqlcommand = "[dbo].[audittrail.Update]";
            DbCommand dbcommand = db.GetStoredProcCommand(sqlcommand, obj);
            Result = db.ExecuteNonQuery(dbcommand);
        }

        public void Delete(Audittrail Entity)
        {
            int Result = 0;
            object[] obj = new object[2];
            obj[0] = Entity.Audittrailid;
            //obj[1] = Entity.Updater;
            Database db = DatabaseFactory.CreateDatabase("ApplicationServices");
            String sqlcommand = "[dbo].[audittrail.Delete]";
            DbCommand dbcommand = db.GetStoredProcCommand(sqlcommand, obj);
            Result = db.ExecuteNonQuery(dbcommand);
        }

        public DataTable Search(Audittrail Entity)
        {
            object[] obj = new object[13];
            obj[0] = Entity.Audittrailid;
            obj[1] = Entity.Userid;
            obj[2] = Entity.Action;
            obj[3] = Entity.Type;
            obj[4] = Entity.Contentid;
            obj[5] = Entity.Contentname;
            obj[6] = Entity.Details;
            obj[7] = Entity.Target;
            obj[8] = Entity.Auditdate;
            obj[9] = Entity.Remarks;
            obj[10] = Entity.Contentcode;
            obj[11] = Entity.Username;
            obj[12] = Entity.Date;
            Database db = DatabaseFactory.CreateDatabase("ApplicationServices");
            String sqlcommand = "[dbo].[audittrail.Search]";
            DbCommand dbcommand = db.GetStoredProcCommand(sqlcommand, obj);
            return db.ExecuteDataSet(dbcommand).Tables[0];
        }

        public DataTable GetDate()
        {
            Database db = DatabaseFactory.CreateDatabase("ApplicationServices");
            String sqlcommand = "[dbo].[audittrail.GetDate]";
            DbCommand dbcommand = db.GetStoredProcCommand(sqlcommand);
            return db.ExecuteDataSet(dbcommand).Tables[0];
        }

    }
}