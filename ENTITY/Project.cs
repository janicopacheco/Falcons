using System;
using System.Text;

namespace ENTITY
{
    [Serializable]
    public class Project
    {
        private Nullable<int> _id;

        public Nullable<int> Id

        {
            get { return _id; }
            set { _id = value; }
        }

        private string _project_no;

        public string Project_no

        {
            get { return _project_no; }
            set { _project_no = value; }
        }

        private Nullable<int> _quotation_id;

        public Nullable<int> Quotation_id

        {
            get { return _quotation_id; }
            set { _quotation_id = value; }
        }

        private string _quotation_no;

        public string Quotation_no

        {
            get { return _quotation_no; }
            set { _quotation_no = value; }
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

        public Project()
        { }
    }
}