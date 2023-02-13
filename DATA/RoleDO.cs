using System;

using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ENTITY;

namespace DATA
{
    [Serializable]
    public class RolesDO
    {

        public DataTable SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase("ApplicationServices");
            String sqlcommand = "[dbo].[aspnet_roles.SelectAll]";
            DbCommand dbcommand = db.GetStoredProcCommand(sqlcommand);
            return db.ExecuteDataSet(dbcommand).Tables[0];
        }

        public DataTable Select(Role Entity)
        {
            object[] obj = new object[5];
            obj[0] = Entity.Applicationid;
            obj[1] = Entity.Roleid;
            obj[2] = Entity.RoleName;
            obj[3] = Entity.LoweredRoleName;
            obj[4] = Entity.Description;
            Database db = DatabaseFactory.CreateDatabase("ApplicationServices");
            String sqlcommand = "[dbo].[aspnet_roles.Select]";
            DbCommand dbcommand = db.GetStoredProcCommand(sqlcommand, obj);
            return db.ExecuteDataSet(dbcommand).Tables[0];
        }

        public void Insert(Role Entity)
        {
            int Result = 0;
            object[] obj = new object[5];
            obj[0] = Entity.Applicationid;
            obj[1] = Entity.Roleid;
            obj[2] = Entity.RoleName;
            obj[3] = Entity.LoweredRoleName;
            obj[4] = Entity.Description;
            Database db = DatabaseFactory.CreateDatabase("ApplicationServices");
            String sqlcommand = "[dbo].[aspnet_roles.Insert]";
            DbCommand dbcommand = db.GetStoredProcCommand(sqlcommand, obj);
            Result = db.ExecuteNonQuery(dbcommand);

            //Entity.Indexid = Convert.ToInt32(dbcommand.Parameters["@indexid"].Value);
        }

        public void Update(Role Entity)
        {
            int Result = 0;
            object[] obj = new object[9];
            obj[0] = Entity.Applicationid;
            obj[1] = Entity.Roleid;
            obj[2] = Entity.RoleName;
            obj[3] = Entity.LoweredRoleName;
            obj[4] = Entity.Description;
            obj[5] = Entity.Creator;
            obj[6] = Entity.Created;
            obj[7] = Entity.Updater;
            obj[8] = Entity.Updated;
            Database db = DatabaseFactory.CreateDatabase("ApplicationServices");
            String sqlcommand = "[dbo].[aspnet_roles.Update]";
            DbCommand dbcommand = db.GetStoredProcCommand(sqlcommand, obj);
            Result = db.ExecuteNonQuery(dbcommand);
        }

        public void Delete(Role Entity)
        {
            int Result = 0;
            object[] obj = new object[2];
            obj[0] = Entity.Applicationid;
            //obj[1] = Entity.Updater;
            Database db = DatabaseFactory.CreateDatabase("ApplicationServices");
            String sqlcommand = "[dbo].[aspnet_roles.Delete]";
            DbCommand dbcommand = db.GetStoredProcCommand(sqlcommand, obj);
            Result = db.ExecuteNonQuery(dbcommand);
        }
    }
}