using System;
using System.Collections.Generic;
using System.Text;
namespace DBModules
{
    public class DBManager : DBUtil
    {
        private static string dbconnection = null;
        private static string dbprovider = null;

        public  DBManager (string connectionstring, string provider) : base(connectionstring, provider)
        {
            dbprovider = provider;
        }


    }
}
