using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Employee
    {
        private int _code_employee;
        private string _name_employee;
        private string _data_birth;
        private string _phone;
        private int _id_position;

        public int Code_employee { get => _code_employee; set => _code_employee = value; }
        public string Name_employee { get => _name_employee; set => _name_employee = value; }
        public string Data_birth { get => _data_birth; set => _data_birth = value; }
        public string Phone { get => _phone; set => _phone = value; }
        public int Id_position { get => _id_position; set => _id_position = value; }
    }
}
