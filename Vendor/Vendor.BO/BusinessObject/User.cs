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
    public class User
    {
        #region Varialbles
        private int _id;
        private string _userName;
        private string _userID;
        private string _password;
        private bool _isAdmin;
        private bool _isOperator;
        private bool _isNew;
        #endregion

        #region Constructor

        public User()
        {
            _isNew = true;
            _id = 0;
            _userName = string.Empty;
            _userID = string.Empty;
            _password = string.Empty;
            _isAdmin = true;
            _isOperator = true;
            
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
        public string UserID
        {
            get { return _userID; }
            set { _userID = value; }

        }
        public string Password
        {
            get { return _password; }
            set { _password = value; }

        }
        public bool IsAdmin
        {
            get { return _isAdmin; }
            set { _isAdmin = value; }

        }
        public bool IsOperator
        {
            get { return _isOperator; }
            set { _isOperator = value; }
        }


        #endregion

        #region SaveDelete
        public void Save()
        {
            if (this.UserName.Length == 0)
            {
                throw new Exception("User Name is required");
            }
            if (Global.IsExists("[User]", "ID", "UserName", this.ID, this.UserName))
            {
                throw new Exception("Your entered User ID or Password is wrong. Please enter your valid User ID or Password.");
            }
            if (_password.Length == 0)
            {
                throw new Exception("Password is required");
            }
            try
            {
                SQLConnector.OpenConnection();
                SQLConnector.BeginTransaction();
                string sql = string.Empty;
                if (_isNew)
                {
                    _id = Global.GenerateMaxNumber("[User]", "ID");
                    sql = string.Format("INSERT INTO [User](ID,UserName,UserID,Password,IsAdmin,IsOperator) VALUES({0},'{1}','{2}','{3}',{4},{5})", _id, _userName, _userID, _password,Convert.ToInt32(_isAdmin), Convert.ToInt32(_isOperator));
                }
                else
                {
                    sql = string.Format("UPDATE [User] SET UserName = '{0}', UserID = '{1}', Password = '{2}', IsAdmin = {3}, IsOperator = {4} WHERE ID = {5} ", _userName, _userID,_password,Convert.ToInt32(_isAdmin), Convert.ToInt32(_isOperator), _id);
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
                string sql = string.Format("DELETE FROM [User] WHERE ID ={0}", id);
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
        public User GetData(int id)
        {
            SQLConnector.OpenConnection();
            SqlCommand command = new SqlCommand();
            command.Connection = SQLConnector.Connection;
            command.CommandText = string.Format("SELECT * FROM [User] WHERE ID ={0}", id);
            command.CommandType = System.Data.CommandType.Text;
            SqlDataReader reader = command.ExecuteReader();
            User item = new User();
           
            if (reader.Read())
            {
                item = new User();
                item.ID = Convert.ToInt32(reader["ID"]);
                item.UserName = Convert.ToString(reader["UserName"]);
                item.UserID = Convert.ToString(reader["UserID"]);
                item.Password = (reader["Password"].ToString());
                item.IsAdmin = Convert.ToBoolean(reader["IsAdmin"]);
                item.IsOperator = Convert.ToBoolean(reader["IsOperator"]);
                item.IsNew = false;
            }
            reader.Close();
            reader.Dispose();
            reader = null;
            SQLConnector.CloseConnection();

            return item;
        }
        public User GetData(string userID)
        {
            SQLConnector.OpenConnection();
            SqlCommand command = new SqlCommand();
            command.Connection = SQLConnector.Connection;
            command.CommandText = string.Format("SELECT * FROM [User] WHERE UserID ='{0}'", userID);
            command.CommandType = System.Data.CommandType.Text;
            SqlDataReader reader = command.ExecuteReader();

            User item = new User();
            if (reader.Read())
            {
                item.IsNew = false;
                item = new User();
                item.ID = Convert.ToInt32(reader["ID"]);
                item.UserName = Convert.ToString(reader["UserName"]);
                item.UserID = Convert.ToString(reader["UserID"]);
                item.Password = (reader["Password"].ToString());
                item.IsAdmin = Convert.ToBoolean(reader["IsAdmin"]);
                item.IsOperator = Convert.ToBoolean(reader["IsOperator"]);
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

            return Global.IsExists("[User]", "ID", "UserName", _id, _userName);
        }
        #endregion

        #region Collection
        public static List<User> GetAllData()
        {
            List<User> items = User.GetAllData("ID", "0123");
            return items;
        }

        public static List<User> GetAllData(string sortColumn, string sortDirection)
        {

            SQLConnector.OpenConnection();
            SqlCommand command = new SqlCommand();
            command.Connection = SQLConnector.Connection;
            command.CommandText = string.Format("SELECT * FROM [User] ORDER BY {0} {1}", sortColumn, sortDirection);
            command.CommandType = System.Data.CommandType.Text;
            
            SqlDataReader reader = command.ExecuteReader();
            List<User> items = new List<User>();
            while (reader.Read())
            {
                User item = new User();
                item.IsNew = false;
                item.ID = Convert.ToInt32(reader["ID"]);
                item.UserName = Convert.ToString(reader["UserName"]);
                item.UserID = Convert.ToString(reader["UserID"]);
                item.Password = (reader["Password"].ToString());
                item.IsAdmin = Convert.ToBoolean(reader["IsAdmin"]);
                item.IsOperator = Convert.ToBoolean(reader["IsOperator"]);
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