using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ENTITY;
using DATA;

namespace PROCESS
{
    [Serializable]
    public class ParticularBO
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

        public bool Insert(Particular Entity)
        {
            try
            {
                ParticularDO EntityDO = new ParticularDO();
                EntityDO.Insert(Entity);
                Success(string.Empty); //or pass success message
            }
            catch (Exception ex)
            {
                ExceptionOccurred(ex);
            }
            return _isSuccessful;
        }

        public bool Update(Particular Entity)
        {
            try
            {
                ParticularDO EntityDO = new ParticularDO();
                EntityDO.Update(Entity);
                Success(string.Empty); //or pass success message
            }
            catch (Exception ex)
            {
                ExceptionOccurred(ex);
            }
            return _isSuccessful;
        }

        public bool Delete(Particular Entity)
        {
            try
            {
                ParticularDO EntityDO = new ParticularDO();
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
                ParticularDO EntityDO = new ParticularDO();
                Success(string.Empty); //or pass success message
                return EntityDO.SelectAll();
            }
            catch (Exception ex)
            {
                ExceptionOccurred(ex);
            }
            return new DataTable();
        }

        public DataTable Select(Particular Entity)
        {
            try
            {
                ParticularDO EntityDO = new ParticularDO();
                Success(string.Empty); //or pass success message
                return EntityDO.Select(Entity);
            }
            catch (Exception ex)
            {
                ExceptionOccurred(ex);
            }
            return new DataTable();
        }
    }
}