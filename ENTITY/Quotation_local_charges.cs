using System;
using System.Text;

namespace ENTITY
{
    [Serializable]
    public class Quotation_local_charges
    {
        private Nullable<int> _id;

        public Nullable<int> Id

        {
            get { return _id; }
            set { _id = value; }
        }

        private Nullable<int> _quotationid;

        public Nullable<int> Quotationid

        {
            get { return _quotationid; }
            set { _quotationid = value; }
        }

        private Nullable<int> _particularid;

        public Nullable<int> Particularid

        {
            get { return _particularid; }
            set { _particularid = value; }
        }

        private string _currency;

        public string Currency

        {
            get { return _currency; }
            set { _currency = value; }
        }

        private Nullable<double> _unit_price;

        public Nullable<double> Unit_price

        {
            get { return _unit_price; }
            set { _unit_price = value; }
        }

        private Nullable<double> _qty;

        public Nullable<double> Qty

        {
            get { return _qty; }
            set { _qty = value; }
        }

        private Nullable<double> _total_amount;

        public Nullable<double> Total_amount

        {
            get { return _total_amount; }
            set { _total_amount = value; }
        }

        private string _remarks;

        public string Remarks

        {
            get { return _remarks; }
            set { _remarks = value; }
        }

        private Nullable<DateTime> _created;

        public Nullable<DateTime> Created

        {
            get { return _created; }
            set { _created = value; }
        }

        private Nullable<Guid> _creator;

        public Nullable<Guid> Creator

        {
            get { return _creator; }
            set { _creator = value; }
        }

        private Nullable<DateTime> _updated;

        public Nullable<DateTime> Updated

        {
            get { return _updated; }
            set { _updated = value; }
        }

        private Nullable<Guid> _updater;

        public Nullable<Guid> Updater

        {
            get { return _updater; }
            set { _updater = value; }
        }

        private Nullable<double> _agent_amount;

        public Nullable<double> Agent_amount

        {
            get { return _agent_amount; }
            set { _agent_amount = value; }
        }

        private Nullable<int> _container_id;

        public Nullable<int> Container_id

        {
            get { return _container_id; }
            set { _container_id = value; }
        }

        public Quotation_local_charges()
        { }
    }
}