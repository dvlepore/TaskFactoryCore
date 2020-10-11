using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data;

namespace DBModules
{
    public abstract class DBUtil
    {
        private  string dbconnectionstr = string.Empty;
        private  DbProviderFactory dbProviderFactories;

        public DBUtil()
        {

        }
        public DBUtil(string dbconnection, string dbType)
        {
            dbProviderFactories = DbProviderFactories.GetFactory(dbType);
            this.dbconnectionstr = dbconnection;
        }
        public DbConnection GetDbConnection()
        {
            var connection = dbProviderFactories.CreateConnection();
            connection.ConnectionString = this.dbconnectionstr;
            return connection;
        }
        public DbConnection GetDbConnection(string connectionstring)
        {
            var connection = dbProviderFactories.CreateConnection();
            connection.ConnectionString = connectionstring;
            return connection;
        }

        public DbCommand GetDbCommand()
        {
            return dbProviderFactories.CreateCommand();
        }
        public DbCommand createDBCommand(string query)
        {
            DbCommand command = GetDbCommand();
            command.CommandText = query;
            return command;
        }
        public DbDataAdapter GetDataAdapter()
        {
            return dbProviderFactories.CreateDataAdapter();
        }

        public bool setCommandParm(DbCommand command, string parameterKey, string parameterValue)
        {
            try
            {
                var param = command.CreateParameter();
                param.ParameterName = parameterKey;
                param.Value = parameterValue;
                command.Parameters.Add(param);
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public DataTable GetDataTable(string query)
        {
            try
            {
                var command = this.createDBCommand(query);
                using(var conn = this.GetDbConnection(dbconnectionstr))
                {
                    command.Connection = conn;
                    using (var adapat = this.GetDataAdapter())
                    {
                        adapat.SelectCommand = command;
                        using (DataTable table = new DataTable())
                        {
                            adapat.Fill(table);
                            return table;
                        }
                    }
                }
            }
            catch(Exception e)
            {
                return null;
            }
        }

    }
}
