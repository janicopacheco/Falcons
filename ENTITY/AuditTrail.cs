using System;
using System.Text;

namespace ENTITY
{
    [Serializable]
    public class Audittrail
    {
        private Nullable<int> _audittrailid;

        public Nullable<int> Audittrailid

        {
            get { return _audittrailid; }
            set { _audittrailid = value; }
        }

        private Nullable<Guid> _userid;

        public Nullable<Guid> Userid

        {
            get { return _userid; }
            set { _userid = value; }
        }

        private string _username;

        public string Username

        {
            get { return _username; }
            set { _username = value; }
        }

        private string _action;

        public string Action

        {
            get { return _action; }
            set { _action = value; }
        }

        private string _type;

        public string Type

        {
            get { return _type; }
            set { _type = value; }
        }

        private Nullable<int> _contentid;

        public Nullable<int> Contentid

        {
            get { return _contentid; }
            set { _contentid = value; }
        }

        private string _contentname;

        public string Contentname

        {
            get { return _contentname; }
            set { _contentname = value; }
        }

        private string _details;

        public string Details

        {
            get { return _details; }
            set { _details = value; }
        }

        private string _target;

        public string Target

        {
            get { return _target; }
            set { _target = value; }
        }

        private Nullable<DateTime> _auditdate;

        public Nullable<DateTime> Auditdate

        {
            get { return _auditdate; }
            set { _auditdate = value; }
        }

        private string _date;

        public string Date

        {
            get { return _date; }
            set { _date = value; }
        }

        private string _remarks;

        public string Remarks

        {
            get { return _remarks; }
            set { _remarks = value; }
        }

        private string _contentcode;

        public string Contentcode

        {
            get { return _contentcode; }
            set { _contentcode = value; }
        }

        public Audittrail()
        { }
    }
}