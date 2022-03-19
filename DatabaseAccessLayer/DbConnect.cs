using System;
using Microsoft.Data.SqlClient;
using Microsoft.Data;
using CommonLayer;


namespace DatabaseAccessLayer
{
    public class DbConnect
    {
        public SqlConnection connection;
        public DbConnect()
        {
            connection = new SqlConnection(DbConnectionConfig.ConnectionString);
        }
    }
}
