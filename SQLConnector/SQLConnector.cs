using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace DBConnector
{
	public class SQLConnector : DBCBase
	{

		public SQLConnector(string connectionString) : base(connectionString)
		{
		}

		public SQLConnector()
		{
		}

		public DataTable GetDataTable(string StoredProcedure)
		{
			try
			{
				ClearError();

				DataTable dt = new DataTable();
				using (SqlConnection conn = new SqlConnection(ConnectionString))
				{
					conn.Open();
					using (SqlCommand cmd = new SqlCommand(StoredProcedure, conn))
					{
						cmd.CommandType = CommandType.StoredProcedure;
						using (SqlDataAdapter da = new SqlDataAdapter(cmd))
						{
							da.Fill(dt);
						}
						
					}
				}
				return dt;
			}
			catch (Exception ex)
			{
				SetError(ex.Message);
				return null;
			}
			
		}

		public string GetString(string StoredProcedure)
		{
			try
			{
				ClearError();

				string result = "";
				using (SqlConnection conn = new SqlConnection(ConnectionString))
				{
					conn.Open();
					using (SqlCommand cmd = new SqlCommand(StoredProcedure, conn))
					{
						cmd.CommandType = CommandType.StoredProcedure;
						result = cmd.ExecuteScalar().ToString();
					}
				}
				return result;
			}
			catch (Exception ex)
			{
				SetError(ex.Message);
				return null;
			}
		}

		public int ExecuteNonQuery(string StoredProcedure)
		{
			try
			{
				ClearError();

				int result = 0;
				using (SqlConnection conn = new SqlConnection(ConnectionString))
				{
					conn.Open();
					using (SqlCommand cmd = new SqlCommand(StoredProcedure, conn))
					{
						cmd.CommandType = CommandType.StoredProcedure;
						result = cmd.ExecuteNonQuery();
					}
				}
				return result;
			}
			catch (Exception ex)
			{
				SetError(ex.Message);
				return -1;
			}
		}

		public int GetInt(string StoredProcedure)
		{
			try
			{
				ClearError();

				int result = 0;
				using (SqlConnection conn = new SqlConnection(ConnectionString))
				{
					conn.Open();
					using (SqlCommand cmd = new SqlCommand(StoredProcedure, conn))
					{
						cmd.CommandType = CommandType.StoredProcedure;
						result = Convert.ToInt32(cmd.ExecuteScalar());
					}
				}
				return result;
			}
			catch (Exception ex)
			{
				SetError(ex.Message);
				return -1;
			}
		}

		public decimal GetDecimal(string StoredProcedure)
		{
			try
			{
				ClearError();

				decimal result = 0;
				using (SqlConnection conn = new SqlConnection(ConnectionString))
				{
					conn.Open();
					using (SqlCommand cmd = new SqlCommand(StoredProcedure, conn))
					{
						cmd.CommandType = CommandType.StoredProcedure;
						result = Convert.ToDecimal(cmd.ExecuteScalar());
					}
				}
				return result;
			}
			catch (Exception ex)
			{
				SetError(ex.Message);
				return -1;
			}
		}

	}
}
