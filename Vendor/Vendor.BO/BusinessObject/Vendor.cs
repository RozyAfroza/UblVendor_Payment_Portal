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
    public class Vendor
    {
        #region Varialbles
        private int _id;
        private string _code;
        private string _userName;
        private string _address;
        private string _email;
        private string _contactNo;
        private string _bankName;
        private string _accountNo;
        private int _paymentTerm;
        private bool _isActive;
        private string _entryuserId;
        private string _updateuserId;
        private DateTime _updateDate;
        private bool _isNew;

        #endregion
    
        #region Constructor
        
        public Vendor()
        {
            _isNew = true;
            _id = 0;
            _userName = string.Empty;
            _code = string.Empty;
            _address = string.Empty;
            _email = string.Empty;
            _contactNo = string.Empty;
            _bankName = string.Empty;
            _accountNo = string.Empty;
            _paymentTerm = 0;
            _isActive = true;
            _entryuserId = string.Empty;
            _updateDate = DateTime.Now;
            _updateuserId = string.Empty;
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

        public string Code
        {
            get { return _code; }
            set { _code = value; }
        }

        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        public string  ContactNo
        {
            get { return _contactNo; }
            set { _contactNo = value; }
        }

        public string BankName
        {
            get { return _bankName; }
            set { _bankName = value; }
        }

        public string  AccountNo
        {
            get { return _accountNo; }
            set { _accountNo = value; }
        }
         public int  PaymentTerm
        {
            get { return _paymentTerm; }
            set { _paymentTerm = value; }
        }
        public bool  IsActive
        {
            get { return _isActive; }
            set { _isActive = value; }
        }

        public string EntryuserId
        {
            get { return _entryuserId; }
            set { _entryuserId = value; }
        }
         public string  UpdateuserId
        {
            get { return _updateuserId; }
            set { _updateuserId = value; }
        }
          public DateTime  UpdateDate
        {
            get { return _updateDate; }
            set { _updateDate = value; }
        }
        
        #endregion

        #region SaveDelete
        public void Save()
        {
            if (this.Code.Length == 0)
            {
                throw new Exception("Code is required");
            }
            if (Global.IsExists("Vendor", "ID", "Code", this.ID, this.Code))
            {
                throw new Exception("Your entered Code is already exists here. Please enter your valid Code.");
            }
            if (_email.Length == 0)
            {
                throw new Exception("Email is required");
            }
            if (_userName.Length == 0)
            {
                throw new Exception("UserName is required");
            }
            try
            {
                SQLConnector.OpenConnection();
                SQLConnector.BeginTransaction();
                string sql = string.Empty;
                if (_isNew)
                {
                    _id = Global.GenerateMaxNumber("Vendor", "ID");
                    sql = string.Format("INSERT INTO Vendor(ID,UserName,Code,Address,Email,ContactNo,BankName,AccountNo,PaymentTerm,EntryUserId,UpdateUserId,UpdateDate,isActive) VALUES({0},'{1}','{2}','{3}','{4}','{5}','{6}','{7}',{8},'{9}','{10}','{11}',{12})", _id, _userName, _code, _address, _email, _contactNo, _bankName, _accountNo, _paymentTerm, _entryuserId, _updateuserId, _updateDate, Convert.ToInt32(_isActive));
                                                            
                
                }
                else
                {
                    sql = string.Format("UPDATE Vendor SET UserName = '{0}', Code='{1}',Address = '{2}', Email= '{3}', ContactNo= '{4}',BankName = '{5}',AccountNo = '{6}',PaymentTerm = {7},EntryUserId = '{8}',UpdateUserId = '{9}',UpdateDate = '{10}',IsActive = {11} WHERE ID = {12} ", _userName, _code, _address, _email, _contactNo, _bankName, _accountNo, _paymentTerm, _entryuserId, _updateuserId, _updateDate, Convert.ToInt32(_isActive), _id);
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
                string sql = string.Format("DELETE FROM Vendor WHERE ID ={0}", id);
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
        public Vendor GetData(int id)
        {
            SQLConnector.OpenConnection();
            SqlCommand command = new SqlCommand();
            command.Connection = SQLConnector.Connection;
            command.CommandText = string.Format("SELECT * FROM Vendor WHERE ID ={0}", id);
            command.CommandType = System.Data.CommandType.Text;
            SqlDataReader reader = command.ExecuteReader();

            Vendor item = new Vendor();
            if (reader.Read())
            {
                item.IsNew = false;
                item.ID = Convert.ToInt32(reader["ID"]);
                item.UserName = (reader["UserName"].ToString());
                item.Code = (reader["Code"].ToString());
                item.Email = (reader["Email"]).ToString();
                item.Address = (reader["Address"]).ToString();
                item.ContactNo = (reader["ContactNo"]).ToString();
                item.BankName = (reader["BankName"]).ToString();
                item.AccountNo = (reader["AccountNo"]).ToString(); 
                item.PaymentTerm = Convert.ToInt32(reader["PaymentTerm"]);
                item.IsActive = Convert.ToBoolean(reader["IsActive"]);
                item.EntryuserId = (reader["EntryUserID"].ToString());
                item.UpdateuserId = (reader["UpdateUserID"].ToString());
                item.UpdateDate = Convert.ToDateTime(reader["UpdateDate"]);
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

            return Global.IsExists("Vendor", "ID", "Code", _id, _code);
        }
        #endregion

        #region Collection
        public static List<Vendor> GetAllData()
        {
            List<Vendor> items = Vendor.GetAllData("ID", "0123");
            return items;
        }

        public static List<Vendor> GetAllData(string sortColumn, string sortDirection)
        {

            SQLConnector.OpenConnection();
            SqlCommand command = new SqlCommand();
            command.Connection = SQLConnector.Connection;
            command.CommandText = string.Format("SELECT * FROM Vendor ORDER BY {0} {1}", sortColumn, sortDirection);
            command.CommandType = System.Data.CommandType.Text;

            SqlDataReader reader = command.ExecuteReader();
            List<Vendor> items = new List<Vendor>();
            while (reader.Read())
            {
                Vendor item = new Vendor();

                item.IsNew = false;
                item.ID = Convert.ToInt32(reader["ID"]);
                item.UserName = (reader["UserName"].ToString());
                item.Code = (reader["Code"].ToString());
                item.Email = (reader["Email"]).ToString();
                item.Address = (reader["Address"]).ToString();
                item.ContactNo = (reader["ContactNo"]).ToString();
                item.BankName = (reader["BankName"]).ToString();
                item.AccountNo = (reader["AccountNo"]).ToString();
                item.PaymentTerm = Convert.ToInt32(reader["PaymentTerm"]);
                item.IsActive = Convert.ToBoolean(reader["IsActive"]);
                item.EntryuserId = (reader["EntryUserID"].ToString());
                item.UpdateuserId = (reader["UpdateUserID"].ToString());
                item.UpdateDate = Convert.ToDateTime(reader["UpdateDate"]);
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