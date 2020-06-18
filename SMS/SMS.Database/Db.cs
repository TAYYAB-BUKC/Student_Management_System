using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Database
{
	public class Db
	{
		private string connectionString;
		private object value;
		private DataTable dataTable = new DataTable();

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

		public DataTable GetList(string storedProcedure)
		{
			if (dataTable.Rows.Count >= 0)
			{
				dataTable = new DataTable();
			}
			using (SqlConnection sql = new SqlConnection(connectionString))
			{
				using (SqlCommand cmd = new SqlCommand(storedProcedure, sql))
				{
					sql.Open();

					cmd.CommandType = CommandType.StoredProcedure;

					SqlDataReader dataReader = cmd.ExecuteReader();

					dataTable.Load(dataReader);
				}
			}
			return dataTable;
		}

		public DataTable GetList(string storedProcedure, DbParameter parameter)
		{
			if (dataTable.Rows.Count >= 0)
			{
				dataTable = new DataTable();
			}
			using (SqlConnection sql = new SqlConnection(connectionString))
			{
				using (SqlCommand cmd = new SqlCommand(storedProcedure, sql))
				{
					sql.Open();

					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.AddWithValue(parameter.Name, parameter.Value);

					SqlDataReader dataReader = cmd.ExecuteReader();

					dataTable.Load(dataReader);
				}
			}
			return dataTable;
		}

		public DataTable GetList(string storedProcedure, List<DbParameter> parameters)
		{
			if (dataTable.Rows.Count >= 0)
			{
				dataTable = new DataTable();
			}
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

					SqlDataReader dataReader = cmd.ExecuteReader();

					dataTable.Load(dataReader);
				}
			}
			return dataTable;
		}

		public void WriteValues(string storedProcedure, object obj)
		{
			using (SqlConnection sql = new SqlConnection(connectionString))
			{
				using (SqlCommand cmd = new SqlCommand(storedProcedure, sql))
				{
					sql.Open();

					cmd.CommandType = CommandType.StoredProcedure;

					Type type = obj.GetType();
					BindingFlags flags = BindingFlags.Public | BindingFlags.Instance;
					List<PropertyInfo> properties = type.GetProperties(flags).ToList();

					foreach (var property in properties)
					{
						cmd.Parameters.AddWithValue("@" + property.Name, property.GetValue(obj,null));
					}
					cmd.ExecuteNonQuery();

				}
			}
		}

	}
}
