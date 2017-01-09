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
    public class Holiday

    {
        #region Varialbles
        private bool _isNew;
        private int _id;
        private string _code;
        private string _description;
        private DateTime _FromDate;
        private DateTime _ToDate;
        #endregion

        #region Constructor
        public Holiday()
        {
            _isNew = true;
            _id = 0;
            _code = string.Empty;
            _description = string.Empty;
            _FromDate = DateTime.Now;
            _ToDate = DateTime.Now;
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
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        public DateTime FromDate
        {
            get { return _FromDate; }
            set { _FromDate = value; }
        }
        public DateTime ToDate
        {
            get { return _ToDate; }
            set { _ToDate = value; }
        }
        #endregion
        #region SaveDelete
        public void Save()
        {
            if (this.Code.Length == 0)
            {
                throw new Exception("Code is required");
            }
            if (Global.IsExists("Holiday", "ID", "Code", this.ID, this.Code))
            {
                throw new Exception("Your entered Code is already exists here. Please enter your valid Code.");
            }
            if (_description.Length == 0)
            {
                throw new Exception("Description is required");
            }
            try
            {
                SQLConnector.OpenConnection();
                SQLConnector.BeginTransaction();
                string sql = string.Empty;
                if (_isNew)
                {
                    _id = Global.GenerateMaxNumber("Holiday", "ID");
                    sql = string.Format("INSERT INTO Holiday(ID,Code,Description,FromDate,ToDate) VALUES({0},'{1}','{2}','{3}','{4}')", _id, _code, _description, _FromDate, _ToDate);
                }
                else
                {
                    sql = string.Format("UPDATE Holiday SET Code = '{0}', Description = '{1}', FromDate = '{2}', ToDate = '{3}' WHERE ID = {4} ", _code, _description, _FromDate, _ToDate, _id);
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
                string sql = string.Format("DELETE FROM Holiday WHERE ID ={0}", id);
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
        public Holiday GetData(int id)
        {
            SQLConnector.OpenConnection();
            SqlCommand command = new SqlCommand();
            command.Connection = SQLConnector.Connection;
            command.CommandText = string.Format("SELECT * FROM Holiday WHERE ID ={0}", id);
            command.CommandType = System.Data.CommandType.Text;
            SqlDataReader reader = command.ExecuteReader();

            Holiday item = new Holiday();
            if (reader.Read())
            {
                item.IsNew = false;
                item.ID = Convert.ToInt32(reader["ID"]);
                item.Code = (reader["Code"].ToString());
                item.Description = (reader["Description"].ToString());
                item.FromDate = Convert.ToDateTime(reader["FromDate"]);
                item.ToDate = Convert.ToDateTime(reader["ToDate"]);
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
            return Global.IsExists("Holiday", "ID", "Code", _id, _code);
        }
        #endregion

        #region Collection
        public static List<Holiday> GetAllData()
        {
            List<Holiday> items = Holiday.GetAllData("ID", "0123");
            return items;
        }
        public static List<Holiday> GetAllData(string sortColumn, string sortDirection)
        {
            SQLConnector.OpenConnection();
            SqlCommand command = new SqlCommand();
            command.Connection = SQLConnector.Connection;
            command.CommandText = string.Format("SELECT * FROM Holiday ORDER BY {0} {1}", sortColumn, sortDirection);
            command.CommandType = System.Data.CommandType.Text;
            SqlDataReader reader = command.ExecuteReader();
            List<Holiday> items = new List<Holiday>();
            while (reader.Read())
            {
                    Holiday item = new Holiday();
                    item.IsNew = false;
                    item.ID = Convert.ToInt32(reader["ID"]);
                    item.Code = (reader["Code"].ToString());
                    item.Description = (reader["Description"].ToString());
                    item.FromDate = Convert.ToDateTime(reader["FromDate"]);
                    item.ToDate = Convert.ToDateTime(reader["ToDate"]);    
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