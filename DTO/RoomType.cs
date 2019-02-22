using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class RoomType
    {
        private string _code_room_type;
        private string _name_type;
        private float _price;
        private int _number_min;
        private int _number_max;

        public string Code_room_type { get => _code_room_type; set => _code_room_type = value; }
        public string Name_type { get => _name_type; set => _name_type = value; }
        public float Price { get => _price; set => _price = value; }
        public int Number_min { get => _number_min; set => _number_min = value; }
        public int Number_max { get => _number_max; set => _number_max = value; }
    }
}
