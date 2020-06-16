using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Database
{
	public class Db
	{
		private string connectionString;
		private object value;

		public Db(string connectionString)
		{
			this.connectionString = connectionString;
		}

		public object GetValue(string storedProcedure)
		{
			using (SqlConnection sql = new SqlConnection(connectionString))
			{
				using (SqlCommand cmd = new SqlCommand(storedProcedure, sql))
				{
					sql.Open();

					cmd.CommandType = CommandType.StoredProcedure;

					value = cmd.ExecuteScalar();
				}
			}
			return value;
		}

		public object GetValue(string storedProcedure, DbParameter parameter)
		{
			using (SqlConnection sql = new SqlConnection(connectionString))
			{
				using (SqlCommand cmd = new SqlCommand(storedProcedure, sql))
				{
					sql.Open();

					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.AddWithValue(parameter.Name, parameter.Value);

					value = cmd.ExecuteScalar();
				}
			}
			return value;
		}

		public object GetValue(string storedProcedure,List<DbParameter> parameters)
		{
			using (SqlConnection sql = new SqlConnection(connectionString))
			{
				using (SqlCommand cmd = new SqlCommand(storedProcedure, sql))
				{
					sql.Open();

					cmd.CommandType = CommandType.StoredProcedure;

					foreach (var parameter in parameters)
					{
						cmd.Parameters.AddWithValue(parameter.Name, parameter.Value);
					}

					value = cmd.ExecuteScalar();
				}
			}
			return value;
		}
	}
}
