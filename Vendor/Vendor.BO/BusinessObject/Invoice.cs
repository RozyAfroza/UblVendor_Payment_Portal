using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Configuration;
using System.Text;
using DataAccess;

namespace Vendor.BO
{
    [Serializable]
    public class Invoice
    {
        #region Varialbles
        private int _id;
        private string _userName;
        private string _invoiceReference;
        private int _invoiceValue;
        private string _poReference;
        private DateTime _invoiceDate;
        private string _omniflowReference;
        private DateTime _receiveDate;
        private DateTime _paymentdueDate;
        private string _status;
        private bool _isNew;

        #endregion

        #region Constructor

        public Invoice()
        {
            _isNew = true;
            _id = 0;
            _userName = string.Empty;
            _invoiceReference = string.Empty;
            _invoiceValue = 0;
            _poReference = string.Empty;
            _invoiceDate = DateTime.Now;
            _omniflowReference = string.Empty;
            _receiveDate = DateTime.Now;
            _paymentdueDate = DateTime.Now;
            _status = string.Empty;

        }
        #endregion

        #region Properties

        public bool IsNew
        {
            get { return _isNew; }
            set { _isNew = value; }
        }
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }
        public string InvoiceReference
        {
            get { return _invoiceReference; }
            set { _invoiceReference = value; }
        }
        public int InvoiceValue
        {
            get { return _invoiceValue; }
            set { _invoiceValue = value; }
        }
         public string POReference
        {
            get { return _poReference; }
            set { _poReference = value; }
        }
        public DateTime InvoiceDate
        {
            get { return _invoiceDate; }
            set { _invoiceDate = value; }
        }
        public string OmniflowReference
        {
            get { return _omniflowReference; }
            set { _omniflowReference = value; }
        }
        public DateTime ReceiveDate{
            get { return _receiveDate; }
            set { _receiveDate = value; }
        }
        public DateTime PaymentdueDate
        {
            get { return _paymentdueDate; }
            set { _paymentdueDate = value; }
        }
        public string Status
        {
            get { return _status; }
            set { _status = value; }
        }
        #endregion

        #region SaveDelete
        public void Save()
        {
            if (this.UserName.Length == 0)
            {
                throw new Exception("UserName is required");
            }
            if (Global.IsExists("[Invoice]", "ID", "UserName", this.ID, this.UserName))
            {
                throw new Exception("Your entered User Name is already exists here. Please enter your valid User Name.");
            }
            if (_invoiceReference.Length == 0)
            {
                throw new Exception("Invoice Reference is required");
            }
            if (_omniflowReference.Length == 0)
            {
                throw new Exception("Omniflow Reference is required");
            }
            try
            {
                SQLConnector.OpenConnection();
                SQLConnector.BeginTransaction();
                string sql = string.Empty;
                if (_isNew)
                {
                    _id = Global.GenerateMaxNumber("[Invoice]", "ID");
                    sql = string.Format("INSERT INTO [Invoice](ID,UserName,InvoiceReference,InvoiceValue,POReference,InvoiceDate,OmniflowReference,ReceiveDate,PaymentdueDate,Status) VALUES({0},'{1}','{2}','{3}','{4}','{5}',{6},'{7}','{8}','{9}')", _id, _userName, _invoiceReference, _invoiceValue, _poReference, _invoiceDate, _omniflowReference, _receiveDate, _paymentdueDate, _status);
                }
                else
                {
                    sql = string.Format("UPDATE [Invoice] SET UserName='{0}',InvoiceReference = '{1}', InvoiceValue= {2}, POReference = '{3}',InvoiceDate = '{4}',OmniflowReference = '{5}',ReceiveDate = '{6}',PaymentdueDate = '{7}',Status = '{8}' WHERE ID = {9} ", _userName, _invoiceReference, _invoiceValue, _poReference, _invoiceDate, _omniflowReference, _receiveDate, _paymentdueDate, _status, _id);
                }
                SqlCommand command = new SqlCommand();
                command.Connection = SQLConnector.Connection;
                command.Transaction = SQLConnector.Transaction;
                command.CommandText = sql;
                command.CommandType = System.Data.CommandType.Text;
                command.ExecuteNonQuery();
                SQLConnector.CommitTransaction();
                SQLConnector.CloseConnection();
            }
            catch (Exception exp)
            {
                SQLConnector.RollbackTransaction();
                throw exp;
            }
        }
        public void Send()
        {
            this.Status = "Send";
            this.Save();
        }
        public void Paid()
        {
            this.Status = "Paid";
            this.Save();
        }
        public void Reject()
        {
            this.Status = "Reject";
            this.Save();
        }
        public void Delete(int id)
        {
            if (Convert.ToInt32(id) <= 0)
            {
                throw new Exception("ID is required.");
            }
            try
            {
                SQLConnector.OpenConnection();
                SQLConnector.BeginTransaction();
                string sql = string.Format("DELETE FROM [Invoice] WHERE ID ={0}", id);
                SqlCommand command = new SqlCommand();
                command.Connection = SQLConnector.Connection;
                command.Transaction = SQLConnector.Transaction;
                command.CommandText = sql;
                command.CommandType = System.Data.CommandType.Text;
                command.ExecuteNonQuery();
                SQLConnector.CommitTransaction();
                SQLConnector.CloseConnection();
            }
            catch (Exception exp)
            {
                SQLConnector.RollbackTransaction();
                throw exp;
            }
        }
        #endregion

        #region GetData
        public Invoice GetData(int id)
        {
            SQLConnector.OpenConnection();
            SqlCommand command = new SqlCommand();
            command.Connection = SQLConnector.Connection;
            command.CommandText = string.Format("SELECT * FROM [Invoice] WHERE ID ={0}", id);
            command.CommandType = System.Data.CommandType.Text;
            SqlDataReader reader = command.ExecuteReader();

            Invoice item = new Invoice();
            if (reader.Read())
            {
                item.IsNew = false;
                item.ID = Convert.ToInt32(reader["ID"]);
                item.UserName = (reader["UserName"].ToString());
                item.InvoiceReference = (reader["InvoiceReference"]).ToString();
                item.InvoiceValue = Convert.ToInt32(reader["InvoiceValue"]);
                item.POReference = (reader["POReference"].ToString());
                item.InvoiceDate = Convert.ToDateTime(reader["InvoiceDate"]);
                item.OmniflowReference = (reader["OmniflowReference"]).ToString();
                item.ReceiveDate = Convert.ToDateTime(reader["ReceiveDate"]);
                item.PaymentdueDate = Convert.ToDateTime(reader["PaymentdueDate"]);
                item.Status = (reader["Status"]).ToString();               
            }
            reader.Close();
            reader.Dispose();
            reader = null;
            SQLConnector.CloseConnection();
            return item;
        }
        #endregion

        #region Duplicate Validation
        public bool IsExists(int id)
        {

            return Global.IsExists("[Invoice]", "ID", "UserName", _id, _userName);
        }
        #endregion

        #region Collection
        public static List<Invoice> GetAllData()
        {
            List<Invoice> items = Invoice.GetAllData("ID","Status", "0123");
            return items;
        }

        public static List<Invoice> GetAllData(string status, string sortColumn, string sortDirection)
        {
            string whereClause = string.Empty;
            if (status.Length > 0)
            {
                whereClause = string.Format("WHERE Status = '{0}'", status);
            }
            SQLConnector.OpenConnection();
            SqlCommand command = new SqlCommand();
            command.Connection = SQLConnector.Connection;
            command.CommandText = string.Format("SELECT * FROM [Invoice] {0} ORDER BY {1} {2}", whereClause, sortColumn, sortDirection);
            command.CommandType = System.Data.CommandType.Text;
            SqlDataReader reader = command.ExecuteReader();
            
            
            List<Invoice> items = new List<Invoice>();
            while (reader.Read())
            {
                Invoice item = new Invoice();

                item.IsNew = false;
                item.ID = Convert.ToInt32(reader["ID"]);
                item.UserName = (reader["UserName"].ToString());
                item.InvoiceReference = (reader["InvoiceReference"]).ToString();
                item.InvoiceValue = Convert.ToInt32(reader["InvoiceValue"]);
                item.POReference = (reader["POReference"].ToString());
                item.InvoiceDate = Convert.ToDateTime(reader["InvoiceDate"]);
                item.OmniflowReference = (reader["OmniflowReference"]).ToString();
                item.ReceiveDate = Convert.ToDateTime(reader["ReceiveDate"]);
                item.PaymentdueDate = Convert.ToDateTime(reader["PaymentdueDate"]);
                item.Status = (reader["Status"]).ToString(); 
                items.Add(item);
            }
            reader.Close();
            reader.Dispose();
            reader = null;
            SQLConnector.CloseConnection();
            return items;
        }
        #endregion
    }

}