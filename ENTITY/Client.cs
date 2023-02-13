using System;
using System.Text;

namespace ENTITY
{
    [Serializable]
    public class Client
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

        private string _address;

        public string Address

        {
            get { return _address; }
            set { _address = value; }
        }

        private string _tin;

        public string Tin

        {
            get { return _tin; }
            set { _tin = value; }
        }

        private string _contactno;

        public string Contactno

        {
            get { return _contactno; }
            set { _contactno = value; }
        }

        private string _contactperson;

        public string Contactperson

        {
            get { return _contactperson; }
            set { _contactperson = value; }
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

        public Client()
        { }
    }
}