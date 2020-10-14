using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data;
using DBModules;
namespace Factory.DB
{
    class DBInstance : DBModules.DBManager
    {
        private static readonly DBInstance instance = new DBInstance(DBConfig.DBConn, DBConfig.Provider);
        public DBInstance (string connectionstr, string token):base(connectionstr, token)
        {

        }
        public static DBInstance init()
        {
            return instance;
        }
        public bool getallActors()
        {
            try
            {
                string q = @"INSERT INTO public.country(
	country_id, country, last_update)
	VALUES (1000, 'Help', now());";
                DbCommand cmd = this.createDBCommand(q);
                this.executenonquery(q);
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }
    }
}
