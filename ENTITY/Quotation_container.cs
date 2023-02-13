using System;
using System.Text;

namespace ENTITY
{
    [Serializable]
    public class Quotation_container
    {
        private Nullable<int> _id;

        public Nullable<int> Id

        {
            get { return _id; }
            set { _id = value; }
        }

        private Nullable<int> _quotation_id;

        public Nullable<int> Quotation_id

        {
            get { return _quotation_id; }
            set { _quotation_id = value; }
        }

        private Nullable<int> _container_id;

        public Nullable<int> Container_id

        {
            get { return _container_id; }
            set { _container_id = value; }
        }

        private Nullable<int> _qty;

        public Nullable<int> Qty

        {
            get { return _qty; }
            set { _qty = value; }
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

        public Quotation_container()
        { }
    }
}