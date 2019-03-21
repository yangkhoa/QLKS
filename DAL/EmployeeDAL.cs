using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class EmployeeDAL
    {
        private static EmployeeDAL instance;

        public static EmployeeDAL Instance
        {
            get { if (instance == null) instance = new EmployeeDAL(); return instance; }
            private set => instance = value;
        }

        private EmployeeDAL() { }

        public DataTable GetListEmployee()
        {
            string query = "SELECT * FROM Employee";

            return DataProvider.Instance.ExecuteQuery(query);
        }
    }
}
