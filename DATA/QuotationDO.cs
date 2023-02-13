using System;

using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

using ENTITY;

namespace DATA
{
    [Serializable]
    public class QuotationDO
    {

        public DataTable SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase("ApplicationServices");
            String sqlcommand = "[dbo].[quotation.SelectAll]";
            DbCommand dbcommand = db.GetStoredProcCommand(sqlcommand);
            return db.ExecuteDataSet(dbcommand).Tables[0];
        }

        public DataTable Select(Quotation Entity)
        {
            object[] obj = new object[23];
            obj[0] = Entity.Id;
            obj[1] = Entity.Quotation_no;
            obj[2] = Entity.Clientid;
            obj[3] = Entity.Shipmentid;
            obj[4] = Entity.Description;
            obj[5] = Entity.Weight;
            obj[6] = Entity.Dimension;
            obj[7] = Entity.Volume;
            obj[8] = Entity.Pol;
            obj[9] = Entity.Pod;
            obj[10] = Entity.Pickup_address;
            obj[11] = Entity.Carrier;
            obj[12] = Entity.Transit_time;
            obj[13] = Entity.Nature_of_cargo;
            obj[14] = Entity.Rate_validity;
            obj[15] = Entity.Payment_terms;
            obj[16] = Entity.Exchange_currency;
            obj[17] = Entity.Exchange_rate;
            obj[18] = Entity.Statusid;
            obj[19] = Entity.Created;
            obj[20] = Entity.Creator;
            obj[21] = Entity.Updated;
            obj[22] = Entity.Updater;
            Database db = DatabaseFactory.CreateDatabase("ApplicationServices");
            String sqlcommand = "[dbo].[quotation.Select]";
            DbCommand dbcommand = db.GetStoredProcCommand(sqlcommand, obj);
            return db.ExecuteDataSet(dbcommand).Tables[0];
        }

        public int Insert(Quotation Entity)
        {
            int Result = 0;

            object[] obj = new object[26];
            obj[0] = Entity.Id;
            obj[1] = Entity.Quotation_no;
            obj[2] = Entity.Clientid;
            obj[3] = Entity.Shipmentid;
            obj[4] = Entity.Description;
            obj[5] = Entity.Weight;
            obj[6] = Entity.Dimension;
            obj[7] = Entity.Volume;
            obj[8] = Entity.Pol;
            obj[9] = Entity.Pod;
            obj[10] = Entity.Pickup_address;
            obj[11] = Entity.Carrier;
            obj[12] = Entity.Transit_time;
            obj[13] = Entity.Nature_of_cargo;
            obj[14] = Entity.Rate_validity;
            obj[15] = Entity.Payment_terms;
            obj[16] = Entity.Exchange_currency;
            obj[17] = Entity.Exchange_rate;
            obj[18] = Entity.Statusid;
            obj[19] = Entity.Created;
            obj[20] = Entity.Creator;
            obj[21] = Entity.Updated;
            obj[22] = Entity.Updater;
            obj[23] = Entity.Preparedby;
            obj[24] = Entity.Position;
            obj[25] = Entity.Quotation_date;
            Database db = DatabaseFactory.CreateDatabase("ApplicationServices");
            String sqlcommand = "[dbo].[quotation.Insert]";
            DbCommand dbcommand = db.GetStoredProcCommand(sqlcommand, obj);
            Result = db.ExecuteNonQuery(dbcommand);

            try
            {
                return Convert.ToInt32(dbcommand.Parameters["@id"].Value);
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public void Update(Quotation Entity)
        {
            int Result = 0;
            object[] obj = new object[26];
            obj[0] = Entity.Id;
            obj[1] = Entity.Quotation_no;
            obj[2] = Entity.Clientid;
            obj[3] = Entity.Shipmentid;
            obj[4] = Entity.Description;
            obj[5] = Entity.Weight;
            obj[6] = Entity.Dimension;
            obj[7] = Entity.Volume;
            obj[8] = Entity.Pol;
            obj[9] = Entity.Pod;
            obj[10] = Entity.Pickup_address;
            obj[11] = Entity.Carrier;
            obj[12] = Entity.Transit_time;
            obj[13] = Entity.Nature_of_cargo;
            obj[14] = Entity.Rate_validity;
            obj[15] = Entity.Payment_terms;
            obj[16] = Entity.Exchange_currency;
            obj[17] = Entity.Exchange_rate;
            obj[18] = Entity.Statusid;
            obj[19] = Entity.Created;
            obj[20] = Entity.Creator;
            obj[21] = Entity.Updated;
            obj[22] = Entity.Updater;
            obj[23] = Entity.Preparedby;
            obj[24] = Entity.Position;
            obj[25] = Entity.Quotation_date;
            Database db = DatabaseFactory.CreateDatabase("ApplicationServices");
            String sqlcommand = "[dbo].[quotation.Update]";
            DbCommand dbcommand = db.GetStoredProcCommand(sqlcommand, obj);
            Result = db.ExecuteNonQuery(dbcommand);
        }

        public void Delete(Quotation Entity)
        {
            int Result = 0;
            object[] obj = new object[2];
            obj[0] = Entity.Id;
            obj[1] = Entity.Updater;
            Database db = DatabaseFactory.CreateDatabase("ApplicationServices");
            String sqlcommand = "[dbo].[quotation.Delete]";
            DbCommand dbcommand = db.GetStoredProcCommand(sqlcommand, obj);
            Result = db.ExecuteNonQuery(dbcommand);
        }

        public DataTable Search(Quotation Entity)
        {
            object[] obj = new object[5];
            obj[0] = Entity.Quotation_no;
            obj[1] = Entity.Clientname;
            obj[2] = Entity.Shipmentname;
            obj[3] = Entity.Description;
            obj[4] = Entity.Statusname;

            Database db = DatabaseFactory.CreateDatabase("ApplicationServices");
            String sqlcommand = "[dbo].[quotation.Search]";
            DbCommand dbcommand = db.GetStoredProcCommand(sqlcommand, obj);
            return db.ExecuteDataSet(dbcommand).Tables[0];
        }

        public DataTable SearchCancelled(Quotation Entity)
        {
            object[] obj = new object[5];
            obj[0] = Entity.Quotation_no;
            obj[1] = Entity.Clientname;
            obj[2] = Entity.Shipmentname;
            obj[3] = Entity.Description;
            obj[4] = Entity.Statusname;

            Database db = DatabaseFactory.CreateDatabase("ApplicationServices");
            String sqlcommand = "[dbo].[quotation.SearchCancelled]";
            DbCommand dbcommand = db.GetStoredProcCommand(sqlcommand, obj);
            return db.ExecuteDataSet(dbcommand).Tables[0];
        }

        public DataTable SelectEarnings(Quotation Entity)
        {
            object[] obj = new object[1];
            obj[0] = Entity.Id;
            Database db = DatabaseFactory.CreateDatabase("ApplicationServices");
            String sqlcommand = "[dbo].[quotation.SelectEarnings]";
            DbCommand dbcommand = db.GetStoredProcCommand(sqlcommand, obj);
            return db.ExecuteDataSet(dbcommand).Tables[0];
        }

    }
}