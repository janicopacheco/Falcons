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
    public class ProjectDO
    {

        public DataTable SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase("ApplicationServices");
            String sqlcommand = "[dbo].[project.SelectAll]";
            DbCommand dbcommand = db.GetStoredProcCommand(sqlcommand);
            return db.ExecuteDataSet(dbcommand).Tables[0];
        }

        public DataTable Select(Project Entity)
        {
            object[] obj = new object[7];
            obj[0] = Entity.Id;
            obj[1] = Entity.Project_no;
            obj[2] = Entity.Quotation_id;
            obj[3] = Entity.Created;
            obj[4] = Entity.Creator;
            obj[5] = Entity.Updated;
            obj[6] = Entity.Updater;
            Database db = DatabaseFactory.CreateDatabase("ApplicationServices");
            String sqlcommand = "[dbo].[project.Select]";
            DbCommand dbcommand = db.GetStoredProcCommand(sqlcommand, obj);
            return db.ExecuteDataSet(dbcommand).Tables[0];
        }

        public void Insert(Project Entity)
        {
            int Result = 0;
            object[] obj = new object[7];
            obj[0] = Entity.Id;
            obj[1] = Entity.Project_no;
            obj[2] = Entity.Quotation_id;
            obj[3] = Entity.Created;
            obj[4] = Entity.Creator;
            obj[5] = Entity.Updated;
            obj[6] = Entity.Updater;
            Database db = DatabaseFactory.CreateDatabase("ApplicationServices");
            String sqlcommand = "[dbo].[project.Insert]";
            DbCommand dbcommand = db.GetStoredProcCommand(sqlcommand, obj);
            Result = db.ExecuteNonQuery(dbcommand);

            //Entity.Indexid = Convert.ToInt32(dbcommand.Parameters["@indexid"].Value);
        }

        public void Update(Project Entity)
        {
            int Result = 0;
            object[] obj = new object[7];
            obj[0] = Entity.Id;
            obj[1] = Entity.Project_no;
            obj[2] = Entity.Quotation_id;
            obj[3] = Entity.Created;
            obj[4] = Entity.Creator;
            obj[5] = Entity.Updated;
            obj[6] = Entity.Updater;
            Database db = DatabaseFactory.CreateDatabase("ApplicationServices");
            String sqlcommand = "[dbo].[project.Update]";
            DbCommand dbcommand = db.GetStoredProcCommand(sqlcommand, obj);
            Result = db.ExecuteNonQuery(dbcommand);
        }

        public void Delete(Project Entity)
        {
            int Result = 0;
            object[] obj = new object[2];
            obj[0] = Entity.Id;
            obj[1] = Entity.Updater;
            Database db = DatabaseFactory.CreateDatabase("ApplicationServices");
            String sqlcommand = "[dbo].[project.Delete]";
            DbCommand dbcommand = db.GetStoredProcCommand(sqlcommand, obj);
            Result = db.ExecuteNonQuery(dbcommand);
        }

        public DataTable Search(Project Entity)
        {
            object[] obj = new object[1];
            obj[0] = Entity.Quotation_no;
            Database db = DatabaseFactory.CreateDatabase("ApplicationServices");
            String sqlcommand = "[dbo].[project.Search]";
            DbCommand dbcommand = db.GetStoredProcCommand(sqlcommand, obj);
            return db.ExecuteDataSet(dbcommand).Tables[0];
        }

    }
}