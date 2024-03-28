using System;
using System.Data.Common;

namespace AutofacDemo
{
    public class DbContext : IDbContext
    {
        private readonly DbConnection _connection;
        private readonly bool _flag;

        public DbContext(DbConnection connection, bool flag)
        {
            _connection = connection;
            _flag = flag;
        }

        public void Connect()
        {
            Console.WriteLine($"⛳ Connecting with {_connection.ConnectionString}");
        }
    }
}

