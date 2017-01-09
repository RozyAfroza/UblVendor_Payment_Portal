using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;

namespace Vendor.BO
{
    public class Global
    {
        #region Generate Max Number
        public static int GenerateMaxNumber(string tableName, string columnName)
        {
            return GenerateMaxNumber(tableName, columnName, string.Empty);
        }
        public static int GenerateMaxNumber(string tableName, string columnName, string whereClause)
        {
            string sql = string.Format("SELECT MAX({0}) FROM {1} {2}", columnName, tableName, whereClause);

            SQLConnector.OpenConnection();
            SqlCommand command = new SqlCommand();
            command.Connection = SQLConnector.Connection;
            command.Transaction = SQLConnector.Transaction;
            command.CommandText = sql;
            command.CommandType = System.Data.CommandType.Text;
            object maxID = command.ExecuteScalar();
            if (maxID == DBNull.Value)
            {
                maxID = 1;
            }
            else
            {
                maxID = Convert.ToInt32(maxID) + 1;
            }
            //SQLConnector.CloseConnection();

            return Convert.ToInt32(maxID);
        }
        #endregion

        #region IsExists
        public static bool IsExists(string tableName, string idColumnName, string duplicateColumnName, int idColumnValue, string duplicateColumnValue)
        {
            string sql = string.Format("SELECT COUNT({0}) FROM {1} WHERE {0} <> {2} AND {3} = '{4}'", idColumnName, tableName, idColumnValue, duplicateColumnName, duplicateColumnValue);

            SQLConnector.OpenConnection();
            SqlCommand command = new SqlCommand();
            command.Connection = SQLConnector.Connection;
            command.Transaction = SQLConnector.Transaction;
            command.CommandText = sql;
            command.CommandType = System.Data.CommandType.Text;
            object duplicateValue = command.ExecuteScalar();
            if (Convert.ToInt32(duplicateValue) == 0)
            {
                return false;
            }
            else
            {
                SQLConnector.CloseConnection();
                return true;
            }
        }
        #endregion
    }
}
