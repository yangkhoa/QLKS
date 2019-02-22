using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class AccountBLL
    {
        private static AccountBLL instance;

        public static AccountBLL Instance
        {
            get { if (instance == null) instance = new AccountBLL(); return instance; }
            private set => instance = value;
        }

        public bool Login(string username, string password)
        {
            string query = "EXEC dbo.USP_Login @_username , @_password";

            DataTable rs = DataProvider.Instance.ExecuteQuery(query, new object[] { username, password });

            return rs.Rows.Count > 0;
        }

        public Account FindAccountByUser(string username)
        {
            DataTable result = DataProvider.Instance.ExecuteQuery("SELECT * FROM Account WHERE username = '" + username + "'");

            foreach (DataRow item in result.Rows)
            {
                return new Account(item);
            }
            return null;
        }

        public bool UpdateAccount(string username, string displayname, string oldpass, string newpass)
        {
            int rs = DataProvider.Instance.ExecuteNonQuery("USP_UpdateAccount @username , @displayname , @password , @newpassword", new object[] { username, displayname, oldpass, newpass });

            return rs > 0;
        }

        public void InsertAccount(string col_1, string col_2, string col_3, string col_4)
        {
            string query = "INSERT Account(username,password,display_name,code_position) VALUES(N'{0}', N'{1}', N'{2}', N'{3}')";

            query = string.Format(query, col_1, col_2, col_3, col_4);

            DataProvider.Instance.ExecuteNonQuery(query);
        }

        public void EditAccount(string col_1, string col_2, string col_3, string col_4)
        {
            string query = "UPDATE Account SET password = N'{1}',display_name = N'{2}',code_position = N'{3}' WHERE username = N'{0}'";

            query = string.Format(query, col_1, col_2, col_3, col_4);

            DataProvider.Instance.ExecuteNonQuery(query);
        }
    }
}
