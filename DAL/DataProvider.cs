using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataProvider
    {
        private static DataProvider instance;

        public static DataProvider Instance
        {
            get { if (instance == null) instance = new DataProvider(); return instance; }
            private set => instance = value;
        }

        private DataProvider(){}

        private readonly string connectstring = @"Data Source=DESKTOP-6K1L4RK\YANG;Initial Catalog=QLKS;Integrated Security=True";

        public DataTable ExecuteQuery(string query, object[] param = null)
        {
            DataTable data = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectstring))
            {
                connection.Open();
                //Dùng để execute câu query trên cái connection

                SqlCommand command = new SqlCommand(query, connection);

                //Thêm n param vào chuỗi query
                if (param != null)
                {
                    string[] listparam = query.Split(' ');
                    int i = 0;
                    foreach (var item in listparam)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, param[i]);
                            i++;
                        }
                    }
                }

                //Dùng để đổ dữ liệu ra
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                //Đổ ra data table
                adapter.Fill(data);
        
                connection.Close();

            }
            return data;
        }

        // Trả về số dòng Execute
        public int ExecuteNonQuery(string query, object[] param = null)
        {
            int data = 0;

            using (SqlConnection connection = new SqlConnection(connectstring))
            {
                connection.Open();

                //Dùng để execute câu query trên cái connection
                SqlCommand command = new SqlCommand(query, connection);

                //Thêm n param vào chuỗi query
                if (param != null)
                {
                    string[] listparam = query.Split(' ');
                    int i = 0;
                    foreach (string item in listparam)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, param[i]);
                            i++;
                        }
                    }
                }

                data = command.ExecuteNonQuery();

                connection.Close();
            }
            return data;
        }

        // Trả về cột của dòng đầu tiên --> sử dụng cho Count()
        public object ExecuteScalarQuery(string query, object[] param = null)
        {
            object data = 0;

            using (SqlConnection connection = new SqlConnection(connectstring))
            {
                connection.Open();

                //Dùng để execute câu query trên cái connection
                SqlCommand command = new SqlCommand(query, connection);

                //Thêm n param vào chuỗi query
                if (param != null)
                {
                    string[] listparam = query.Split(' ');
                    int i = 0;
                    foreach (var item in listparam)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, param[i]);
                            i++;
                        }
                    }
                }

                data = command.ExecuteScalar();

                connection.Close();
            }
            return data;
        }
    }
}   
