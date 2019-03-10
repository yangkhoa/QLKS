using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Room
    {
        private string _code_room;
        private string _name_room;
        private string _code_type;
        private string _code_status;
        private string _note;

        public string Code_room { get => _code_room; set => _code_room = value; }
        public string Name_room { get => _name_room; set => _name_room = value; }
        public string Code_type { get => _code_type; set => _code_type = value; }
        public string Code_status { get => _code_status; set => _code_status = value; }
        public string Note { get => _note; set => _note = value; }

        public Room(string code, string name, string status, string type)
        {
            this.Code_room = code;
            this.Code_status = status;
            this.Code_type = type;
            this.Name_room = name;
        }
       
        public Room(DataRow row)
        {
            this.Code_room = row["code_room"].ToString();
            this.Name_room = row["name_room"].ToString();
            this.Code_status = row["name_status"].ToString();
            this.Code_type = row["name_type"].ToString();
        }
    }
}
