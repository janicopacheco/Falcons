using System;
using System.Text;

namespace ENTITY
{
    [Serializable]
    public class Menu_permission
    {
        private Nullable<int> _menuid;

        public Nullable<int> Menuid

        {
            get { return _menuid; }
            set { _menuid = value; }
        }

        private Nullable<Guid> _roleid;

        public Nullable<Guid> Roleid

        {
            get { return _roleid; }
            set { _roleid = value; }
        }

        private Nullable<bool> _permitted;

        public Nullable<bool> Permitted

        {
            get { return _permitted; }
            set { _permitted = value; }
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

        public Menu_permission()
        { }
    }
}