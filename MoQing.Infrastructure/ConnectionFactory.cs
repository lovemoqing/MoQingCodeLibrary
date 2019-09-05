using MoQing.Infrastructure.Config;
using SqlSugar;
using System.Collections.Generic;
using System.Data;

namespace Infrastructure
{
    public class ConnectionFactory
    {
        private static string DBConStr = ConfigExtensions.Configuration["DBConnection:MySqlConnection"];
        public static IDbConnection CreateConnection<T>() where T : IDbConnection, new()
        {
            IDbConnection connection = new T();
            connection.ConnectionString = DBConStr;
            connection.Open();
            return connection;
        }

        public static SqlSugarClient CreateSqlSugarClient()
        {
            SqlSugarClient db = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = DBConStr,
                DbType = SqlSugar.DbType.MySql,
                IsAutoCloseConnection = true
            });
            return db;
        }

        public static SqlSugarClient CreateSqlSugarClient(string connection)
        {
            SqlSugarClient db = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = connection,
                DbType = SqlSugar.DbType.MySql,
                IsAutoCloseConnection = true
            });
            return db;
        }

    }
}
