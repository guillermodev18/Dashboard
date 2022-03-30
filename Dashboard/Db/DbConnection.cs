using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard.Db
{
    public abstract class DbConnection
    {
        private readonly string _connectionString;

        public DbConnection()
        {
            _connectionString = @"Server=GUILLERMO-PC\SQLEXPRESS;Database=Dashboard_DB;Trusted_Connection=True;";

        }

        protected MySqlConnection GetMySqlConnection()
        {
            return new MySqlConnection(_connectionString);
        }
    }
}
