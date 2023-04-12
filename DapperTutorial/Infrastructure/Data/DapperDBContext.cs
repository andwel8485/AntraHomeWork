using System;
using System.Data;
using Dapper;
using System.Data.SqlClient;
namespace Infrastructure.Data
{
	public class DapperDBContext
	{
		IDbConnection dbConnection;

		public IDbConnection GetConnectition()
		{
			dbConnection = new SqlConnection("Server=localhost; Database=Enterprise; User Id=sa; Password=#Wmafs6119107");
			Console.WriteLine("Connect to DB successfully!");
			return dbConnection;
        }
	}
}

