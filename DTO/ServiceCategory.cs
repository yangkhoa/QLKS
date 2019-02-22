using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ServiceCategory
    {
        private string _code_service_category;
        private string _name_category;

        public string Code_service_category { get => _code_service_category; set => _code_service_category = value; }
        public string Name_category { get => _name_category; set => _name_category = value; }

        public ServiceCategory()
        {

        }
    }
}
