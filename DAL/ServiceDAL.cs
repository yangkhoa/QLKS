using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class ServiceDAL
    {
        private static ServiceDAL instance;

        public static ServiceDAL Instance
        {
            get { if (instance == null) instance = new ServiceDAL(); return instance; }
            private set => instance = value;
        }

        private ServiceDAL() { }

        public DataTable GetListService()
        {
            string query = "SELECT * FROM Service";

            return DataProvider.Instance.ExecuteQuery(query);
        }

        public DataTable GetListServiceByCategory(string code_category)
        {
            string query = "SELECT * FROM Service WHERE code_category=N'"+code_category+"'";

            return DataProvider.Instance.ExecuteQuery(query);
        }

        public Service GetServiceByCodeService(string code_service)
        {
            string query = "SELECT * FROM Service WHERE code_service=N'" + code_service + "'";

            DataRow item = DataProvider.Instance.ExecuteQuery(query).Rows[0];

            return new Service(item);
        }
    }
}
