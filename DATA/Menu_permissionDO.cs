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
    public class Menu_permissionDO
    {

        public DataTable SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase("ApplicationServices");
            String sqlcommand = "[dbo].[menu_permission.SelectAll]";
            DbCommand dbcommand = db.GetStoredProcCommand(sqlcommand);
            return db.ExecuteDataSet(dbcommand).Tables[0];
        }

        public DataTable Select(Menu_permission Entity)
        {
            object[] obj = new object[7];
            obj[0] = Entity.Menuid;
            obj[1] = Entity.Roleid;
            obj[2] = Entity.Permitted;
            obj[3] = Entity.Created;
            obj[4] = Entity.Creator;
            obj[5] = Entity.Updated;
            obj[6] = Entity.Updater;
            Database db = DatabaseFactory.CreateDatabase("ApplicationServices");
            String sqlcommand = "[dbo].[menu_permission.Select]";
            DbCommand dbcommand = db.GetStoredProcCommand(sqlcommand, obj);
            return db.ExecuteDataSet(dbcommand).Tables[0];
        }

        public void Insert(Menu_permission Entity)
        {
            int Result = 0;
            object[] obj = new object[7];
            obj[0] = Entity.Menuid;
            obj[1] = Entity.Roleid;
            obj[2] = Entity.Permitted;
            obj[3] = Entity.Created;
            obj[4] = Entity.Creator;
            obj[5] = Entity.Updated;
            obj[6] = Entity.Updater;
            Database db = DatabaseFactory.CreateDatabase("ApplicationServices");
            String sqlcommand = "[dbo].[menu_permission.Insert]";
            DbCommand dbcommand = db.GetStoredProcCommand(sqlcommand, obj);
            Result = db.ExecuteNonQuery(dbcommand);

            //Entity.Indexid = Convert.ToInt32(dbcommand.Parameters["@indexid"].Value);
        }

        public void Update(Menu_permission Entity)
        {
            int Result = 0;
            object[] obj = new object[7];
            obj[0] = Entity.Menuid;
            obj[1] = Entity.Roleid;
            obj[2] = Entity.Permitted;
            obj[3] = Entity.Created;
            obj[4] = Entity.Creator;
            obj[5] = Entity.Updated;
            obj[6] = Entity.Updater;
            Database db = DatabaseFactory.CreateDatabase("ApplicationServices");
            String sqlcommand = "[dbo].[menu_permission.Update]";
            DbCommand dbcommand = db.GetStoredProcCommand(sqlcommand, obj);
            Result = db.ExecuteNonQuery(dbcommand);
        }

        public void Delete(Menu_permission Entity)
        {
            int Result = 0;
            object[] obj = new object[2];
            obj[0] = Entity.Menuid;
            obj[1] = Entity.Updater;
            Database db = DatabaseFactory.CreateDatabase("ApplicationServices");
            String sqlcommand = "[dbo].[menu_permission.Delete]";
            DbCommand dbcommand = db.GetStoredProcCommand(sqlcommand, obj);
            Result = db.ExecuteNonQuery(dbcommand);
        }

        public DataTable SelectParent(Menu_permission Entity)
        {
            object[] obj = new object[1];
            obj[0] = Entity.Roleid;
   
            Database db = DatabaseFactory.CreateDatabase("ApplicationServices");
            String sqlcommand = "[dbo].[menu_permission.SelectParent]";
            DbCommand dbcommand = db.GetStoredProcCommand(sqlcommand, obj);
            return db.ExecuteDataSet(dbcommand).Tables[0];
        }

        public DataTable SelectChild(Menu_permission Entity)
        {
            object[] obj = new object[2];
            obj[0] = Entity.Roleid;
            obj[1] = Entity.Menuid;

            Database db = DatabaseFactory.CreateDatabase("ApplicationServices");
            String sqlcommand = "[dbo].[menu_permission.SelectChild]";
            DbCommand dbcommand = db.GetStoredProcCommand(sqlcommand, obj);
            return db.ExecuteDataSet(dbcommand).Tables[0];
        }
    }
}