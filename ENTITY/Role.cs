using System;
using System.Text;

namespace ENTITY
{
    [Serializable]
    public class Role
    {
        private Nullable<Guid> _ApplicationId;

        public Nullable<Guid> Applicationid

        {
            get { return _ApplicationId; }
            set { _ApplicationId = value; }
        }

        private Nullable<Guid> _RoleId;

        public Nullable<Guid> Roleid

        {
            get { return _RoleId; }
            set { _RoleId = value; }
        }

        private string _RoleName;

        public string RoleName

        {
            get { return _RoleName; }
            set { _RoleName = value; }
        }

        private string _LoweredRoleName;

        public string LoweredRoleName

        {
            get { return _LoweredRoleName; }
            set { _LoweredRoleName = value; }
        }

        private string _Description;

        public string Description

        {
            get { return _Description; }
            set { _Description = value; }
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

        public Role()
        { }
    }
}