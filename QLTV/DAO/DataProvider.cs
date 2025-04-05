using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;

namespace QLTV.DAO
{
    public class DataProvider
    {
        private static DataProvider instance;
        public static DataProvider Instance
        {
            get { if (instance == null) instance = new DataProvider(); return DataProvider.instance; }
            private set { DataProvider.instance = value; }
        }
        private DataProvider() { }
        private string connect = "Data Source=DESKTOP-15KAOEA;Initial Catalog=QLTV;Integrated Security=True";
        public DataTable ExecuteQuery(string query, object[] parameter = null)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection conn = new SqlConnection(connect))
            {
                SqlConnection sqlConnection = new SqlConnection(connect);

                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                if (parameter != null)
                {
                    string[] listPars = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPars)
                    {
                        if (item.Contains('@'))
                        {
                            sqlCommand.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);

                adapter.Fill(dataTable);

                sqlConnection.Close();
            }
            return dataTable;
        }
        public int ExecuteNonQuery(string query, object[] parameter = null)
        {
            int data = 0;
            using (SqlConnection conn = new SqlConnection(connect))
            {
                SqlConnection sqlConnection = new SqlConnection(connect);

                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                if (parameter != null)
                {
                    string[] listPars = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPars)
                    {
                        if (item.Contains("@"))
                        {
                            sqlCommand.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                data = sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
            return data;
        }
        public object ExecuteScalar(string query, object[] parameter = null)
        {
            object data = 0;
            using (SqlConnection conn = new SqlConnection(connect))
            {
                SqlConnection sqlConnection = new SqlConnection(connect);

                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                if (parameter != null)
                {
                    string[] listPars = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPars)
                    {
                        if (item.Contains("@"))
                        {
                            sqlCommand.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                data = sqlCommand.ExecuteScalar();
                sqlConnection.Close();
            }
            return data;
        }
    }
}
