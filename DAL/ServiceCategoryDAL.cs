using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ServiceCategoryDAL
    {
        private static ServiceCategoryDAL instance;

        public static ServiceCategoryDAL Instance
        {
            get { if (instance == null) instance = new ServiceCategoryDAL(); return instance; }
            private set => instance = value;
        }

        private ServiceCategoryDAL() { }

        public DataTable GetListServiceCategory()
        {
            string query = "SELECT * FROM ServiceCategory";

            return DataProvider.Instance.ExecuteQuery(query);
        }
    }
}
