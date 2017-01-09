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
    public class Report
    {
        #region Varialbles
        private int _id;
        private string _code;
        private string _userName;
        private string _invoiceReference;
        private DateTime _invoiceDate;
        private string _poReference;
        private int _invoiceValue;
        private string _omniflowReference;
        private DateTime _receiveDate;
        private int _paymentTerm;
        private DateTime _paymentdueDate;       
        private DateTime _paymentDate;
        private string _paidAmount;
        private string _taxDeduction;
        private string _vatDeduction;
        private string _status;
        private bool _isNew;

        #endregion

        #region Constructor

        public Report()
        {
            _isNew = true;
            _id = 0;
            _code = string.Empty;
            _userName = string.Empty;
            _invoiceReference = string.Empty;
            _invoiceDate = DateTime.Now;
            _poReference = string.Empty;
            _invoiceValue = 0;
            _omniflowReference = string.Empty;
            _receiveDate = DateTime.Now;
            _paymentTerm = 0;
            _paymentdueDate = DateTime.Now;
            _paymentDate = DateTime.Now;
            _paidAmount = string.Empty;
            _taxDeduction = string.Empty;
            _vatDeduction = string.Empty;
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
        public string Code
        {
            get { return _code; }
            set { _code = value; }
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
        public DateTime InvoiceDate
        {
            get { return _invoiceDate; }
            set { _invoiceDate = value; }
        }
        public string POReference
        {
            get { return _poReference; }
            set { _poReference = value; }
        }
        public int InvoiceValue
        {
            get { return _invoiceValue; }
            set { _invoiceValue = value; }
        }      

        public string OmniflowReference
        {
            get { return _omniflowReference; }
            set { _omniflowReference = value; }
        }
        public DateTime ReceiveDate
        {
            get { return _receiveDate; }
            set { _receiveDate = value; }
        }
        public int PaymentTerm
        {
            get { return _paymentTerm; }
            set { _paymentTerm = value; }
        }
        public DateTime PaymentdueDate
        {
            get { return _paymentdueDate; }
            set { _paymentdueDate = value; }
        }
        public DateTime PaymentDate
        {
            get { return _paymentDate; }
            set { _paymentDate = value; }
        }
        public string PaidAmount
        {
            get { return _paidAmount; }
            set { _paidAmount = value; }
        }
        public string TaxDeduction
        {
            get { return _taxDeduction; }
            set { _taxDeduction = value; }
        }
        public string VatDeduction
        {
            get { return _vatDeduction; }
            set { _vatDeduction = value; }
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
            if (Global.IsExists("Report", "ID", "UserName", this.ID, this.UserName))
            {
                throw new Exception("Your entered UserName is already exists here. Please enter your valid UserName.");
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
                    _id = Global.GenerateMaxNumber("Report", "ID");
                    sql = string.Format("INSERT INTO Report(ID,Code,UserName,InvoiceReference,InvoiceDate,POReference,InvoiceValue,OmniflowReference,ReceiveDate,PaymentTerm,PaymentdueDate,PaymentDate,PaidAmount,TaxDeduction,VatDeduction,Status) VALUES({0},'{1}','{2}',{3},'{4}','{5}',{6},{7},'{8}',{9},'{10}','{11}','{12}','{13}','{14}','{15}')", _id, _code, _userName, _invoiceReference, _invoiceDate, _poReference, _invoiceValue, _omniflowReference, _receiveDate, _paymentTerm, _paymentdueDate, _paymentDate, _paidAmount,_taxDeduction,_vatDeduction, _status);
                }
                else
                {
                    sql = string.Format("UPDATE Report SET Code ='{0}',UserName='{1}',InvoiceReference = '{2}',InvoiceDate = '{3}',POReference = '{4}',InvoiceValue = {5},OmniflowReference = '{6}',ReceiveDate = '{7}',PaymentTerm = {8},PaymentdueDate = '{9}',PaymentDate = '{10}',PaidAmount = '{11}',TaxDeduction = '{12}',VatDeduction = '{13}' ,Status = '{14}' WHERE ID = {15} ", _code, _userName, _invoiceReference, _invoiceDate, _poReference, _invoiceValue, _omniflowReference, _receiveDate, _paymentTerm, _paymentdueDate, _paymentDate, _paidAmount, _taxDeduction, _vatDeduction, _status, _id);
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
        public void Unpaid()
        {
            this.Status = "Unpaid";
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
                string sql = string.Format("DELETE FROM Report WHERE ID ={0}", id);
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
        public Report GetData(int id)
        {
            SQLConnector.OpenConnection();
            SqlCommand command = new SqlCommand();
            command.Connection = SQLConnector.Connection;
            command.CommandText = string.Format("SELECT * FROM Report WHERE ID ={0}", id);
            command.CommandType = System.Data.CommandType.Text;
            SqlDataReader reader = command.ExecuteReader();

            Report item = new Report();
            if (reader.Read())
            {
                item.IsNew = false;
                item.ID = Convert.ToInt32(reader["ID"]);
                item.Code = (reader["Code"].ToString());
                item.UserName = (reader["UserName"].ToString());
                item.InvoiceReference = (reader["InvoiceReference"].ToString());
                item.InvoiceDate = Convert.ToDateTime(reader["InvoiceDate"]);
                item.POReference = (reader["POReference"].ToString());
                item.InvoiceValue = Convert.ToInt32(reader["InvoiceValue"]);
                item.OmniflowReference = (reader["OmniflowReference"]).ToString();
                item.ReceiveDate = Convert.ToDateTime(reader["ReceiveDate"]);
                item.PaymentTerm = Convert.ToInt32(reader["PaymentTerm"]);
                item.PaymentdueDate = Convert.ToDateTime(reader["PaymentdueDate"]);
                item.PaymentDate = Convert.ToDateTime(reader["PaymentDate"]);
                item.PaidAmount = (reader["PaidAmount "].ToString());
                item.TaxDeduction = (reader["TaxDeduction"].ToString());
                item.VatDeduction = (reader["VatDeduction"].ToString());
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

            return Global.IsExists("Report", "ID", "UserName", _id, _userName);
        }
        #endregion

        #region Collection
        public static List<Report> GetAllData()
        {
            List<Report> items = Report.GetAllData("ID", "Status", "0123");
            return items;
        }

        public static List<Report> GetAllData(string status, string sortColumn, string sortDirection)
        {
            string whereClause = string.Empty;
            if (status.Length > 0)
            {
                whereClause = string.Format("WHERE Status = '{0}'", status);
            }
            SQLConnector.OpenConnection();
            SqlCommand command = new SqlCommand();
            command.Connection = SQLConnector.Connection;
            command.CommandText = string.Format("SELECT * FROM Report {0} ORDER BY {1} {2}", whereClause, sortColumn, sortDirection);
            command.CommandType = System.Data.CommandType.Text;
            SqlDataReader reader = command.ExecuteReader();


            List<Report> items = new List<Report>();
            while (reader.Read())
            {
                Report item = new Report();

                item.IsNew = false;
                item.ID = Convert.ToInt32(reader["ID"]);
                item.Code = (reader["Code"].ToString());
                item.UserName = (reader["UserName"].ToString());
                item.InvoiceReference = (reader["InvoiceReference"].ToString());
                item.InvoiceDate = Convert.ToDateTime(reader["InvoiceDate"]);
                item.POReference = (reader["POReference"].ToString());
                item.InvoiceValue = Convert.ToInt32(reader["InvoiceValue"]);
                item.OmniflowReference = (reader["OmniflowReference"]).ToString();
                item.ReceiveDate = Convert.ToDateTime(reader["ReceiveDate"]);
                item.PaymentTerm = Convert.ToInt32(reader["PaymentTerm"]);
                item.PaymentdueDate = Convert.ToDateTime(reader["PaymentdueDate"]);
                item.PaymentDate = Convert.ToDateTime(reader["PaymentDate"]);
                item.PaidAmount = (reader["PaidAmount "].ToString());
                item.TaxDeduction = (reader["TaxDeduction"].ToString());
                item.VatDeduction = (reader["VatDeduction"].ToString());
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