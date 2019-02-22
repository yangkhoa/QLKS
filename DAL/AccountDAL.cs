using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class AccountDAL
    {
        private static AccountDAL instance;

        public static AccountDAL Instance
        {
            get { if (instance == null) instance = new AccountDAL(); return instance; }
            private set => instance = value;
        }

        private AccountDAL() { }

        public DataTable GetAccountList(string username)
        {
            // Lấy danh sách account nhưng bỏ đi account có username đang đăng nhập
            string query = "SELECT username,password,display_name,code_position FROM Account WHERE username != '"+username+"'";

            return DataProvider.Instance.ExecuteQuery(query); 
        }
    }
}
