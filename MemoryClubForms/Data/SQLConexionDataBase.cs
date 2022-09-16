using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace MemoryClubForms.Data
{
    public class SQLConexionDataBase
    {
		/// <summary>
		/// Método para ejecutar una consulta SQL (Select) sobre la base de datos SQL Server
		/// </summary>
		/// <param name="query">La consulta a ejecutar (Select)</param>
		/// <returns>El DataSet con los datos recibidos</returns>
		public static DataTable Query(string query)
		{
			SqlConnection sqlConnection = BuildSqlConnection();

			try
			{
				sqlConnection.Open();
				SqlDataAdapter dataAdapter = new SqlDataAdapter();
				DataTable dataTable = new DataTable();
				dataAdapter.SelectCommand = new SqlCommand(query, sqlConnection);
				dataAdapter.Fill(dataTable);
				return dataTable;
			}
			catch (Exception ex)
			{
				throw;
			}
			finally
			{
				sqlConnection.Close();
			}
		}

		/// <summary>
		/// Método para ejecutar (Insert, Update, Delete) SQL sobre la base de datos SQL Server.
		/// </summary>
		/// <param name="strSentence">La sentencia a ejecutar</param>
		/// <returns>El resultado de que si se ejecuto o no la sentencia</returns>
		public static bool Execute(string strSentence)
		{
			using (SqlConnection sqlConnection = BuildSqlConnection())
			{
				sqlConnection.Open();

				using (SqlTransaction transaction = sqlConnection.BeginTransaction())
				{
					try
					{
						SqlCommand sqlCommand = sqlConnection.CreateCommand();
						sqlCommand.Transaction = transaction;
						sqlCommand.CommandText = strSentence;
						sqlCommand.ExecuteNonQuery();

						transaction.Commit();
						return true;
					}
					catch (Exception ex)
					{
						transaction.Rollback();
						throw;
					}
					finally
					{
						sqlConnection.Close();
					}
				}
			}
		}
		public static SqlConnection BuildSqlConnection()
		{
			SqlConnection sqlConnString = new SqlConnection(ConfigurationManager.ConnectionStrings["DBProd"].ConnectionString);
			//SqlConnection sqlConnection = null;

			//sqlConnection = new SqlConnection(sqlConnString);

			//return sqlConnection;
			return sqlConnString;
		}
	}
}
