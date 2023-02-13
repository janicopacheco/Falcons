using System;
using System.Text;

namespace ENTITY
{
    [Serializable]
    public class Quotation
    {
        private Nullable<int> _id;

        public Nullable<int> Id

        {
            get { return _id; }
            set { _id = value; }
        }

        private string _quotation_no;

        public string Quotation_no

        {
            get { return _quotation_no; }
            set { _quotation_no = value; }
        }

        private Nullable<int> _clientid;

        public Nullable<int> Clientid

        {
            get { return _clientid; }
            set { _clientid = value; }
        }

        private Nullable<int> _shipmentid;

        public Nullable<int> Shipmentid

        {
            get { return _shipmentid; }
            set { _shipmentid = value; }
        }

        private string _description;

        public string Description

        {
            get { return _description; }
            set { _description = value; }
        }

        private string _weight;

        public string Weight

        {
            get { return _weight; }
            set { _weight = value; }
        }

        private string _dimension;

        public string Dimension

        {
            get { return _dimension; }
            set { _dimension = value; }
        }

        private string _volume;

        public string Volume

        {
            get { return _volume; }
            set { _volume = value; }
        }

        private string _pol;

        public string Pol

        {
            get { return _pol; }
            set { _pol = value; }
        }

        private string _pod;

        public string Pod

        {
            get { return _pod; }
            set { _pod = value; }
        }

        private string _pickup_address;

        public string Pickup_address

        {
            get { return _pickup_address; }
            set { _pickup_address = value; }
        }

        private string _carrier;

        public string Carrier

        {
            get { return _carrier; }
            set { _carrier = value; }
        }

        private Nullable<DateTime> _transit_time;

        public Nullable<DateTime> Transit_time

        {
            get { return _transit_time; }
            set { _transit_time = value; }
        }

        private string _nature_of_cargo;

        public string Nature_of_cargo

        {
            get { return _nature_of_cargo; }
            set { _nature_of_cargo = value; }
        }

        private string _rate_validity;

        public string Rate_validity

        {
            get { return _rate_validity; }
            set { _rate_validity = value; }
        }

        private string _payment_terms;

        public string Payment_terms

        {
            get { return _payment_terms; }
            set { _payment_terms = value; }
        }

        private string _exchange_currency;

        public string Exchange_currency

        {
            get { return _exchange_currency; }
            set { _exchange_currency = value; }
        }

        private Nullable<double> _exchange_rate;

        public Nullable<double> Exchange_rate

        {
            get { return _exchange_rate; }
            set { _exchange_rate = value; }
        }

        private Nullable<int> _statusid;

        public Nullable<int> Statusid

        {
            get { return _statusid; }
            set { _statusid = value; }
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

        private string _preparedby;

        public string Preparedby

        {
            get { return _preparedby; }
            set { _preparedby = value; }
        }

        private string _position;

        public string Position

        {
            get { return _position; }
            set { _position = value; }
        }

        private Nullable<DateTime> _quotation_date;

        public Nullable<DateTime> Quotation_date

        {
            get { return _quotation_date; }
            set { _quotation_date = value; }
        }

        private string _clientname;

        public string Clientname

        {
            get { return _clientname; }
            set { _clientname = value; }
        }

        private string _shipmentname;

        public string Shipmentname

        {
            get { return _shipmentname; }
            set { _shipmentname = value; }
        }

        private string _statusname;

        public string Statusname

        {
            get { return _statusname; }
            set { _statusname = value; }
        }

        public Quotation()
        { }
    }
}