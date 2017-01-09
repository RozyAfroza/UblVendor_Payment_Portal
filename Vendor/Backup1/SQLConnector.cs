using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DataAccess
{
    public class SQLConnector
    {
        #region Variables
        private static string _connectionString;
        private static SqlConnection _connection;
        private static SqlTransaction _transaction;
        #endregion

        #region Constructor
        static SQLConnector()
        {
            _connection = new SqlConnection();
            ConnectionString = ConfigurationSettings.AppSettings["ConnectionString"];
            _transaction = null;
        }
        #endregion

        #region Properties
        public static SqlConnection Connection
        {
            get { return _connection; }
        }
        public static SqlTransaction Transaction
        {
            get { return _transaction; }
        }

        public static string ConnectionString
        {
            get { return _connectionString; }
            set
            {
                _connectionString = value;
                _connection.ConnectionString = _connectionString;
            }
        }
        #endregion

        #region Methods
        public static void OpenConnection()
        {
            if (_connectionString.Length == 0)
            {
                throw new Exception("Connection string is empty.");
            }

            try
            {
                if (_connection.State != System.Data.ConnectionState.Open)
                {
                    _connection.Open();
                }
            }
            catch (SqlException sql)
            {
                throw new Exception(sql.Message, sql.InnerException);
            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message, exp.InnerException);
            }
        }
        public static void CloseConnection()
        {
            _connection.Close();
        }

        public static void BeginTransaction()
        {
            if (_connection.State != System.Data.ConnectionState.Open)
            {
                throw new Exception("Connection object is closed.");
            }

            _transaction = _connection.BeginTransaction();
        }
        public static void CommitTransaction()
        {
            if (_transaction == null)
            {
                throw new Exception("Transaction object is null.");
            }

            _transaction.Commit();
            _transaction = null;
        }
        public static void RollbackTransaction()
        {
            if (_transaction == null)
            {
                throw new Exception("Transaction object is null.");
            }

            _transaction.Rollback();
            _transaction = null;
        }
        #endregion
    }
}