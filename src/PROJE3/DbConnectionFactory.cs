using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace PROJE3
{

    public static class DbConnectionFactory
    {
        private static readonly string _connStr
            = ConfigurationManager
                .ConnectionStrings["DefaultConnection"]
                .ConnectionString;

        public static MySqlConnection CreateConnection()
        {
            return new MySqlConnection(_connStr);
        }
    }
}