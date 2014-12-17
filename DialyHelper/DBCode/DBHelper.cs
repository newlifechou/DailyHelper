using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.OleDb;

using System.Configuration;

namespace DialyHelper.DBCode
{
    /// <summary>
    /// DB Operation Class
    /// </summary>
    public class DBHelper
    {
        /// <summary>
        /// public con and cmd object
        /// </summary>
        private OleDbConnection con;
        private OleDbCommand cmd;

        /// <summary>
        /// Initialize the connection and command
        /// </summary>
        public DBHelper()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["dailyhelperdb"].ConnectionString;
            con = new OleDbConnection(connectionString);
            cmd = con.CreateCommand();
        }

        /// <summary>
        /// GetDBReader
        /// !!!Must CloseTheDataReader in order to close the collection
        /// </summary>
        /// <param name="sqlcmd"></param>
        /// <param name="paras"></param>
        /// <returns></returns>
        public OleDbDataReader GetDBReader(string sqlcmd, OleDbParameter[] paras)
        {
            cmd.CommandText = sqlcmd;
            foreach (var para in paras)
            {
                cmd.Parameters.Add(para);
            }

            OleDbDataReader dr;
            try
            {
                con.Open();
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dr;
        }

        /// <summary>
        /// GetDBSchalar
        /// </summary>
        /// <param name="sqlcmd"></param>
        /// <param name="paras"></param>
        /// <returns>object</returns>
        public object GetDBSchalar(string sqlcmd, OleDbParameter[] paras)
        {
            cmd.CommandText = sqlcmd;
            foreach (var para in paras)
            {
                cmd.Parameters.Add(para);
            }

            object value;
            try
            {
                con.Open();
                value = cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return value;
        }
    }
}
