using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class RoomStatus
    {
        private string _code_room_status;
        private string _name_status;

        public string Code_room_status { get => _code_room_status; set => _code_room_status = value; }
        public string Name_status { get => _name_status; set => _name_status = value; }
    }
}
