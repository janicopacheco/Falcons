using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ENTITY;
using DATA;

namespace PROCESS
{
    [Serializable]
    public class Menu_permissionBO
    {

        #region "Transaction Members"

        //transaction
        private Exception _exception;
        private bool _isSuccessful;
        private string _message;

        //successful
        private void Success(string msg)
        {
            _exception = null;
            _isSuccessful = true;
            _message = msg;
            if (msg == string.Empty)
                _message = "Successful transaction!";
        }

        //failed
        private void Failed(string msg)
        {
            _exception = null;
            _isSuccessful = true;
            _message = msg;
            if (msg == string.Empty)
                _message = "Failed transaction!";
        }

        //exception occurred
        private void ExceptionOccurred(Exception ex)
        {
            _exception = ex;
            _isSuccessful = false;
            _message = ex.Message;
        }

        //returns the result of the transaction
        public Exception TransactionException
        {
            get { return _exception; }
        }

        //returns if transaction is successful or not
        public bool IsSuccessful
        {
            get { return _isSuccessful; }
        }

        //returns transaction Message
        public string TransactionMessage
        {
            get { return _message; }
        }
        #endregion

        public bool Insert(Menu_permission Entity)
        {
            try
            {
                Menu_permissionDO EntityDO = new Menu_permissionDO();
                EntityDO.Insert(Entity);
                Success(string.Empty); //or pass success message
            }
            catch (Exception ex)
            {
                ExceptionOccurred(ex);
            }
            return _isSuccessful;
        }

        public bool Update(Menu_permission Entity)
        {
            try
            {
                Menu_permissionDO EntityDO = new Menu_permissionDO();
                EntityDO.Update(Entity);
                Success(string.Empty); //or pass success message
            }
            catch (Exception ex)
            {
                ExceptionOccurred(ex);
            }
            return _isSuccessful;
        }

        public bool Delete(Menu_permission Entity)
        {
            try
            {
                Menu_permissionDO EntityDO = new Menu_permissionDO();
                EntityDO.Delete(Entity);
                Success(string.Empty); //or pass success message
            }
            catch (Exception ex)
            {
                ExceptionOccurred(ex);
            }
            return _isSuccessful;
        }

        public DataTable SelectAll()
        {
            try
            {
                Menu_permissionDO EntityDO = new Menu_permissionDO();
                Success(string.Empty); //or pass success message
                return EntityDO.SelectAll();
            }
            catch (Exception ex)
            {
                ExceptionOccurred(ex);
            }
            return new DataTable();
        }

        public DataTable Select(Menu_permission Entity)
        {
            try
            {
                Menu_permissionDO EntityDO = new Menu_permissionDO();
                Success(string.Empty); //or pass success message
                return EntityDO.Select(Entity);
            }
            catch (Exception ex)
            {
                ExceptionOccurred(ex);
            }
            return new DataTable();
        }

        public DataTable SelectParent(Menu_permission Entity)
        {
            try
            {
                Menu_permissionDO EntityDO = new Menu_permissionDO();
                Success(string.Empty); //or pass success message
                return EntityDO.SelectParent(Entity);
            }
            catch (Exception ex)
            {
                ExceptionOccurred(ex);
            }
            return new DataTable();
        }

        public DataTable SelectChild(Menu_permission Entity)
        {
            try
            {
                Menu_permissionDO EntityDO = new Menu_permissionDO();
                Success(string.Empty); //or pass success message
                return EntityDO.SelectChild(Entity);
            }
            catch (Exception ex)
            {
                ExceptionOccurred(ex);
            }
            return new DataTable();
        }
    }
}