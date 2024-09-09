using System;
using System.Data.SqlClient;
using System.Data;

namespace OpenCVTest
{
    internal class DBConnect
    {
        string ConnectString = "server=DESKTOP-8NLCHEE;" +
                $"database=barcordDB;" +
                $"uid=sa;" +
                $"pwd=12345;";

        public string msg = "";
        public string dbresult = "";

        SqlConnection conn;
        SqlDataAdapter dataAdapter;
        DataSet dataSet;

        public DataTable dt;

        public void connect()
        {
            try
            {
                conn = new SqlConnection(ConnectString);
                conn.Open();
                if (conn.State == ConnectionState.Open)
                    msg = "연결";
                else
                    msg = "실패";
            }
            catch (Exception ex)
            {
                msg = $"{ex.Message} : 연결 부분";
            }
            finally
            {
                conn.Close();
            }

        }

        public void insert(string company, string product, string production, DateTime date, string test)
        {
            try
            {
                dataAdapter = new SqlDataAdapter();
                dt = new DataTable();
                dataSet = new DataSet();

                conn.Open();

                string queryString = "INSERT INTO emp (d_company, d_product, d_production, d_date, d_test)" +
                    "VALUES (@d_company, @d_product, @d_production, @d_date, @d_test)";

                dataAdapter.InsertCommand = new SqlCommand(queryString, conn);
                dataAdapter.InsertCommand.Parameters.AddWithValue("@d_company", company);
                dataAdapter.InsertCommand.Parameters.AddWithValue("@d_product", product);
                dataAdapter.InsertCommand.Parameters.AddWithValue("@d_production", production);
                dataAdapter.InsertCommand.Parameters.AddWithValue("@d_date", date);
                dataAdapter.InsertCommand.Parameters.AddWithValue("@d_test", test);

                dataAdapter.InsertCommand.ExecuteNonQuery();

                string selectQuery = "SELECT * FROM emp";
                dataAdapter.SelectCommand = new SqlCommand(selectQuery, conn);

                dataSet.Clear();
                dataAdapter.Fill(dataSet, "emp");
                dt = dataSet.Tables["emp"];

            }
            catch (Exception ex)
            {
                msg = $"{ex.Message} : 입력 부분";
            }
            finally
            {
                conn.Close();
                dataAdapter.InsertCommand.Dispose();
            }

        }

        public void select(string company)
        {
            try
            {
                dataAdapter = new SqlDataAdapter();
                dt = new DataTable();
                dataSet = new DataSet();

                conn.Open();

                string queryString = "select * from emp where d_company = @d_company";

                dataAdapter.SelectCommand = new SqlCommand(queryString, conn);
                dataAdapter.SelectCommand.Parameters.AddWithValue("@d_company", company);

                dataSet.Clear();
                dataAdapter.Fill(dataSet, "emp");
                dt = dataSet.Tables["emp"];

            }
            catch (Exception ex)
            {
                msg = $"{ex.Message} : 조회 부분";
            }
            finally
            {
                conn.Close();
                dataAdapter.SelectCommand.Dispose();
            }

        }

    }
}

