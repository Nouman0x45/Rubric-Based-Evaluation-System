using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace RubricsBasedProject
{
    class Configuration
    {
        String ConnectionStr = @"Data Source=DESKTOP-AK2NRE3;Initial Catalog=ProjectB;Integrated Security=True;MultipleActiveResultSets=true";
        SqlConnection con;
        private static Configuration _instance;
        public static Configuration getInstance()
        {
            if (_instance == null)
                _instance = new Configuration();
            return _instance;
        }
        private Configuration()
        {
            con = new SqlConnection(ConnectionStr);
            con.Open();
        }
        public SqlConnection getConnection()
        {
            return con;
        }
    }
}






