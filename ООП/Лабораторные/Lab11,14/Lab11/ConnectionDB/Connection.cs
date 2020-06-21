using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11.ConnectionDB
{
    class Connection
    {
        private static Connection instance;
        public static SqlConnection SqlConnection { get; private set; }
        private Connection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection = new SqlConnection(connectionString);
            SqlConnection.Open();
        }
        public static Connection getInstance()
        {
            if (instance == null)
                instance = new Connection();
            return instance;
        }
        public static void Close()
        {
            if (SqlConnection.State == System.Data.ConnectionState.Open)
                SqlConnection.Close();
        }
    }
}
