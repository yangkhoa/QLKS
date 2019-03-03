using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ServiceCategoryBLL
    {
        private static ServiceCategoryBLL instance;

        public static ServiceCategoryBLL Instance
        {
            get { if (instance == null) instance = new ServiceCategoryBLL(); return instance; }
            private set => instance = value;
        }

        private ServiceCategoryBLL() { }

        public void InsertServiceCategory(string col_1, string col_2)
        {
            string query = "INSERT ServiceCategory(code_service_category,name_category) VALUES(N'{0}', N'{1}')";

            query = string.Format(query, col_1, col_2);

            DataProvider.Instance.ExecuteNonQuery(query);

        }

        public void EditServiceCategory(string col_1, string col_2)
        {
            string query = "UPDATE ServiceCategory SET name_category = N'{1}' WHERE code_service_category = N'{0}'";

            query = string.Format(query, col_1, col_2);

            DataProvider.Instance.ExecuteNonQuery(query);
        }

        public void DeleteServiceCategory(string code_service_category)
        {
            string query = "DELETE ServiceCategory WHERE code_service_category = N'{0}'";

            query = string.Format(query, code_service_category);

            DataProvider.Instance.ExecuteNonQuery(query);
        }
    }
}
