using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class EmployeeBLL
    {
        private static EmployeeBLL instance;

        public static EmployeeBLL Instance
        {
            get { if (instance == null) instance = new EmployeeBLL(); return instance; }
            private set => instance = value;
        }

        private EmployeeBLL() { }

        public void EditInfoEmployee(string code_employee, string name_employee, string date_birth, string phone)
        {
            string query = "INSERT Employee(code_employee,name_employee,date_birth,phone) VALUES(N'{0}', N'{1}', N'{2}', N'{3}')";

            query = string.Format(query, code_employee, name_employee, date_birth, phone);

            DataProvider.Instance.ExecuteNonQuery(query);
        }

        public void DeleteEmployeeByCode(string code_employee)
        {
            string query = "DELETE Employee WHERE code_employee = N'{0}'";

            query = string.Format(query,code_employee);

            DataProvider.Instance.ExecuteNonQuery(query);
        }

        public void InsertEmployee(string code_employee, string name_employee, string date_birth, string phone)
        {
            string query = "UPDATE Employee SET name_employee=N'{1}' , date_birth = N'{2}' , phone = N'{3}' WHERE code_employee = N'{0}'";

            query = string.Format(query, code_employee, name_employee, date_birth, phone);

            DataProvider.Instance.ExecuteNonQuery(query);
        }
    }
}