using System;
using System.Text;

namespace ENTITY
{
    [Serializable]
    public class User
    {
        private Nullable<Guid> _ApplicationId;

        public Nullable<Guid> Applicationid

        {
            get { return _ApplicationId; }
            set { _ApplicationId = value; }
        }

        private Nullable<Guid> _UserId;

        public Nullable<Guid> Userid

        {
            get { return _UserId; }
            set { _UserId = value; }
        }

        private Nullable<Guid> _RoleId;

        public Nullable<Guid> RoleId

        {
            get { return _RoleId; }
            set { _RoleId = value; }
        }


        private string _Email;

        public string Email

        {
            get { return _Email; }
            set { _Email = value; }
        }

        private string _Password;

        public string Password

        {
            get { return _Password; }
            set { _Password = value; }
        }

        private Nullable<bool> _IsApproved;

        public Nullable<bool> Isapproved

        {
            get { return _IsApproved; }
            set { _IsApproved = value; }
        }

        private Nullable<bool> _IsLockedOut;

        public Nullable<bool> Islockedout

        {
            get { return _IsLockedOut; }
            set { _IsLockedOut = value; }
        }

        private Nullable<DateTime> _CreateDate;

        public Nullable<DateTime> Createdate

        {
            get { return _CreateDate; }
            set { _CreateDate = value; }
        }

        private Nullable<DateTime> _LastLoginDate;

        public Nullable<DateTime> Lastlogindate

        {
            get { return _LastLoginDate; }
            set { _LastLoginDate = value; }
        }

        private Nullable<DateTime> _LastPasswordChangedDate;

        public Nullable<DateTime> Lastpasswordchangeddate

        {
            get { return _LastPasswordChangedDate; }
            set { _LastPasswordChangedDate = value; }
        }

        private Nullable<DateTime> _LastLockoutDate;

        public Nullable<DateTime> Lastlockoutdate

        {
            get { return _LastLockoutDate; }
            set { _LastLockoutDate = value; }
        }

        private Nullable<int> _FailedPasswordAttemptCount;

        public Nullable<int> Failedpasswordattemptcount

        {
            get { return _FailedPasswordAttemptCount; }
            set { _FailedPasswordAttemptCount = value; }
        }

        private Nullable<DateTime> _FailedPasswordAttemptWindowStart;

        public Nullable<DateTime> Failedpasswordattemptwindowstart

        {
            get { return _FailedPasswordAttemptWindowStart; }
            set { _FailedPasswordAttemptWindowStart = value; }
        }

        private Nullable<int> _FailedPasswordAnswerAttemptCount;

        public Nullable<int> Failedpasswordanswerattemptcount

        {
            get { return _FailedPasswordAnswerAttemptCount; }
            set { _FailedPasswordAnswerAttemptCount = value; }
        }

        private Nullable<DateTime> _FailedPasswordAnswerAttemptWindowStart;

        public Nullable<DateTime> Failedpasswordanswerattemptwindowstart

        {
            get { return _FailedPasswordAnswerAttemptWindowStart; }
            set { _FailedPasswordAnswerAttemptWindowStart = value; }
        }

        private string _Comment;

        public string Comment

        {
            get { return _Comment; }
            set { _Comment = value; }
        }

        private string _FirstName;

        public string Firstname

        {
            get { return _FirstName; }
            set { _FirstName = value; }
        }

        private string _MiddleName;

        public string Middlename

        {
            get { return _MiddleName; }
            set { _MiddleName = value; }
        }

        private string _LastName;

        public string Lastname

        {
            get { return _LastName; }
            set { _LastName = value; }
        }

        private Nullable<DateTime> _ValidityDate;

        public Nullable<DateTime> Validitydate

        {
            get { return _ValidityDate; }
            set { _ValidityDate = value; }
        }

        public User()
        { }
    }
}