using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.DataBaseConnection
{
    class Connection
    {
        private static Connection instance;
        public static SqlConnection SqlConnection { get; private set; }
        private Connection()
        {
            SqlConnection = new SqlConnection(@"Data Source=localhost;Initial Catalog=Desktop;Integrated Security=True");
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
