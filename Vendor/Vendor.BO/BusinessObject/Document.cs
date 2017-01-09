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
    public class Document 
    {
        #region Varialbles
        private bool _isNew;
        private int _id;
        private string _description;
        private bool _isMendatory;
        #endregion
      
        #region Constructor
        
        public Document()
        {
            _isNew = true;
            _id = 0;
            _description = string.Empty;
            _isMendatory = true;
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

        public string Description
        {
            get { return _description; }
            set { _description = value; }

        }
        public bool IsMendatory
        {
            get { return _isMendatory; }
            set { _isMendatory = value; }
        }
        #endregion

        #region SaveDelete
        public void Save()
        {
            if (this.Description.Length == 0)
            {
                throw new Exception("Description is required");
            }
            if (Global.IsExists("Document", "ID", "Description", this.ID, this.Description))
            {
                throw new Exception("Your entered Description is already exists here. Please enter your valid Description.");
            }
                try
            {
                SQLConnector.OpenConnection();
                SQLConnector.BeginTransaction();
                string sql = string.Empty;
                if (_isNew)
                {
                    _id = Global.GenerateMaxNumber("Document", "ID");
                    sql = string.Format("INSERT INTO Document(ID,Description,isMendatory) VALUES({0},'{1}',{2})", _id, _description, Convert.ToInt32(_isMendatory));
                }
                else
                {
                    sql = string.Format("UPDATE Document SET Description = '{0}', IsMendatory = {1} WHERE ID = {2} ", _description,Convert.ToInt32(_isMendatory), _id);
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
                string sql = string.Format("DELETE FROM Document WHERE ID ={0}", id);
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
        public Document GetData(int id)
        {
            SQLConnector.OpenConnection();
            SqlCommand command = new SqlCommand();
            command.Connection = SQLConnector.Connection;
            command.CommandText = string.Format("SELECT * FROM Document WHERE ID ={0}", id);
            command.CommandType = System.Data.CommandType.Text;
            SqlDataReader reader = command.ExecuteReader();

            Document item = new Document();
            if (reader.Read())
            {
                item.IsNew = false;
                item.ID = Convert.ToInt32(reader["ID"]);
                item.Description = (reader["Description"].ToString());
                item.IsMendatory = Convert.ToBoolean(reader["IsMendatory"]);
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

            return Global.IsExists("Document", "ID", "Description", _id, _description);
        }
        #endregion

        #region Collection
        public static List<Document> GetAllData()
        {
            List<Document> items = Document.GetAllData("ID", "0123");
            return items;
        }

        public static List<Document> GetAllData(string sortColumn, string sortDirection)
        {

            SQLConnector.OpenConnection();
            SqlCommand command = new SqlCommand();
            command.Connection = SQLConnector.Connection;
            command.CommandText = string.Format("SELECT * FROM Document ORDER BY {0} {1}", sortColumn, sortDirection);
            command.CommandType = System.Data.CommandType.Text;

            SqlDataReader reader = command.ExecuteReader();
            List<Document> items = new List<Document>();
            while (reader.Read())
            {
                Document item = new Document();

                item.IsNew = false;
                item.ID = Convert.ToInt32(reader["ID"]);
                item.Description = (reader["Description"].ToString());
                item.IsMendatory = Convert.ToBoolean(reader["IsMendatory"]);
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