using System;
using System.Text;

namespace ENTITY
{
    [Serializable]
    public class Currency
    {
        private Nullable<int> _id;

        public Nullable<int> Id

        {
            get { return _id; }
            set { _id = value; }
        }

        private string _name;

        public string Name

        {
            get { return _name; }
            set { _name = value; }
        }
        private Nullable<double> _amount;

        public Nullable<double> Amount

        {
            get { return _amount; }
            set { _amount = value; }
        }

        private Nullable<Guid> _creator;

        public Nullable<Guid> Creator

        {
            get { return _creator; }
            set { _creator = value; }
        }

        private Nullable<DateTime> _created;

        public Nullable<DateTime> Created

        {
            get { return _created; }
            set { _created = value; }
        }

        private Nullable<Guid> _updater;

        public Nullable<Guid> Updater

        {
            get { return _updater; }
            set { _updater = value; }
        }

        private Nullable<DateTime> _updated;

        public Nullable<DateTime> Updated

        {
            get { return _updated; }
            set { _updated = value; }
        }

        public Currency()
        { }
    }
}