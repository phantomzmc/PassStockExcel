using NoomLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;

namespace PassStockExcel
{
    public class Connection
    {
        private SqlConnection _conn;
        private string _constr;

        public SqlConnection SqlConnectioN
        {
            get { return _conn; }
            set { _conn = value; }
        }
        public Connection()
        {
            this._constr = "Data Source=" + PassStock2.Properties.Settings.Default.HOST + ","
                + PassStock2.Properties.Settings.Default.PORT + ";Network Library=DBMSSOCN;User ID="
                + PassStock2.Properties.Settings.Default.USERNAME + ";Password ="
                + PassStock2.Properties.Settings.Default.PASSWORD
                + ";Initial Catalog=" + PassStock2.Properties.Settings.Default.DB;
            _conn = new SqlConnection(this._constr);
        }

        public static CSQLConnection CSQLConnection
        {
            get
            {
                return new CSQLConnection(PassStock2.Properties.Settings.Default.HOST
                , PassStock2.Properties.Settings.Default.PORT
                , PassStock2.Properties.Settings.Default.USERNAME
                , PassStock2.Properties.Settings.Default.PASSWORD
                , PassStock2.Properties.Settings.Default.DB);
            }
        }
    }
}