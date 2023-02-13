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
    public class UserDO
    {

        public DataTable SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase("ApplicationServices");
            String sqlcommand = "[dbo].[users.SelectAll]";
            DbCommand dbcommand = db.GetStoredProcCommand(sqlcommand);
            return db.ExecuteDataSet(dbcommand).Tables[0];
        }

        public DataTable SelectAllAccounts()
        {
            Database db = DatabaseFactory.CreateDatabase("ApplicationServices");
            String sqlcommand = "[dbo].[users.SelectAllAccounts]";
            DbCommand dbcommand = db.GetStoredProcCommand(sqlcommand);
            return db.ExecuteDataSet(dbcommand).Tables[0];
        }

        public DataTable Select(User Entity)
        {
            object[] obj = new object[25];
            obj[0] = Entity.Applicationid;
            obj[1] = Entity.Userid;
            //obj[2] = Entity.Password;
            //obj[3] = Entity.Passwordformat;
            //obj[4] = Entity.Passwordsalt;
            //obj[5] = Entity.Mobilepin;
            obj[6] = Entity.Email;
            //obj[7] = Entity.Loweredemail;
            //obj[8] = Entity.Passwordquestion;
            //obj[9] = Entity.Passwordanswer;
            obj[10] = Entity.Isapproved;
            obj[11] = Entity.Islockedout;
            obj[12] = Entity.Createdate;
            obj[13] = Entity.Lastlogindate;
            obj[14] = Entity.Lastpasswordchangeddate;
            obj[15] = Entity.Lastlockoutdate;
            obj[16] = Entity.Failedpasswordattemptcount;
            obj[17] = Entity.Failedpasswordattemptwindowstart;
            obj[18] = Entity.Failedpasswordanswerattemptcount;
            obj[19] = Entity.Failedpasswordanswerattemptwindowstart;
            obj[20] = Entity.Comment;
            obj[21] = Entity.Firstname;
            obj[22] = Entity.Middlename;
            obj[23] = Entity.Lastname;
            obj[24] = Entity.Validitydate;
            Database db = DatabaseFactory.CreateDatabase("ApplicationServices");
            String sqlcommand = "[dbo].[aspnet_membership.Select]";
            DbCommand dbcommand = db.GetStoredProcCommand(sqlcommand, obj);
            return db.ExecuteDataSet(dbcommand).Tables[0];
        }

        public void Insert(User Entity)
        {
            int Result = 0;
            object[] obj = new object[25];
            obj[0] = Entity.Applicationid;
            obj[1] = Entity.Userid;
            //obj[2] = Entity.Password;
            //obj[3] = Entity.Passwordformat;
            //obj[4] = Entity.Passwordsalt;
            //obj[5] = Entity.Mobilepin;
            obj[6] = Entity.Email;
            //obj[7] = Entity.Loweredemail;
            //obj[8] = Entity.Passwordquestion;
            //obj[9] = Entity.Passwordanswer;
            obj[10] = Entity.Isapproved;
            obj[11] = Entity.Islockedout;
            obj[12] = Entity.Createdate;
            obj[13] = Entity.Lastlogindate;
            obj[14] = Entity.Lastpasswordchangeddate;
            obj[15] = Entity.Lastlockoutdate;
            obj[16] = Entity.Failedpasswordattemptcount;
            obj[17] = Entity.Failedpasswordattemptwindowstart;
            obj[18] = Entity.Failedpasswordanswerattemptcount;
            obj[19] = Entity.Failedpasswordanswerattemptwindowstart;
            obj[20] = Entity.Comment;
            obj[21] = Entity.Firstname;
            obj[22] = Entity.Middlename;
            obj[23] = Entity.Lastname;
            obj[24] = Entity.Validitydate;
            Database db = DatabaseFactory.CreateDatabase("ApplicationServices");
            String sqlcommand = "[dbo].[aspnet_membership.Insert]";
            DbCommand dbcommand = db.GetStoredProcCommand(sqlcommand, obj);
            Result = db.ExecuteNonQuery(dbcommand);

            //Entity.Indexid = Convert.ToInt32(dbcommand.Parameters["@indexid"].Value);
        }

        public void Update(User Entity)
        {
            int Result = 0;
            object[] obj = new object[5];
            obj[0] = Entity.Userid;
            obj[1] = Entity.Firstname;
            obj[2] = Entity.Middlename;
            obj[3] = Entity.Lastname;
            obj[4] = Entity.Validitydate;
            Database db = DatabaseFactory.CreateDatabase("ApplicationServices");
            String sqlcommand = "[dbo].[users.Update]";
            DbCommand dbcommand = db.GetStoredProcCommand(sqlcommand, obj);
            Result = db.ExecuteNonQuery(dbcommand);
        }

        public void Delete(User Entity)
        {
            int Result = 0;
            object[] obj = new object[2];
            obj[0] = Entity.Applicationid;
            //obj[1] = Entity.Updater;
            Database db = DatabaseFactory.CreateDatabase("ApplicationServices");
            String sqlcommand = "[dbo].[aspnet_membership.Delete]";
            DbCommand dbcommand = db.GetStoredProcCommand(sqlcommand, obj);
            Result = db.ExecuteNonQuery(dbcommand);
        }

        public DataTable SelectByUserId(User Entity)
        {
            object[] obj = new object[1];
            obj[0] = Entity.Userid;
            Database db = DatabaseFactory.CreateDatabase("ApplicationServices");
            String sqlcommand = "[dbo].[users.SelectByUserId]";
            DbCommand dbcommand = db.GetStoredProcCommand(sqlcommand, obj);
            return db.ExecuteDataSet(dbcommand).Tables[0];
        }

        public DataTable SelectByUserName(User Entity)
        {
            object[] obj = new object[1];
            obj[0] = Entity.Email;
            Database db = DatabaseFactory.CreateDatabase("ApplicationServices");
            String sqlcommand = "[dbo].[users.SelectByUserName]";
            DbCommand dbcommand = db.GetStoredProcCommand(sqlcommand, obj);
            return db.ExecuteDataSet(dbcommand).Tables[0];
        }

    }
}