using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace DAL
{
    public class DBConnection
    {
        private OleDbConnection GetOleDbConnection()
        {
            
            OleDbConnection conn = new OleDbConnection();
            conn.ConnectionString = @"Provider = Microsoft.Jet.OLEDB.4.0; Data Source =|DataDirectory|\Library.mdb";  //Access bağlantı stringi
            conn.Open();
            return conn;
        }

        public OleDbCommand GetOleDbCommand()
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = GetOleDbConnection();
            return cmd;
        }
    }
}
