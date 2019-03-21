using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class RoomTypeBLL
    {
        private static RoomTypeBLL instance;

        public static RoomTypeBLL Instance
        {
            get { if (instance == null) instance = new RoomTypeBLL(); return instance; }
            private set => instance = value;
        }

        private RoomTypeBLL() { }

        public void InsertRoomType(string code_room_type, string name_type, string price, string number_min, string number_max)
        {
            string query = "INSERT RoomType(code_room_type,name_type,price,number_min,number_max) VALUES (N'{0}',N'{1}',{2},{3},{4})";

            query = string.Format(query, code_room_type, name_type, price, number_min, number_max);

            DataProvider.Instance.ExecuteNonQuery(query);
        }

        public void EditRoomType(string code_room_type, string name_type, string price, string number_min, string number_max)
        {
            string query = "UPDATE RoomType SET name_type = N'{1}',price = {2},number_min = {3},number_max = {4} WHERE code_room_type = N'{0}'";

            query = string.Format(query, code_room_type, name_type, price, number_min, number_max);

            DataProvider.Instance.ExecuteNonQuery(query);
        }

        public void DeleteRoomType(string code_room_type)
        {
            string query = "DELETE FROM RoomType WHERE code_room_type = N'{0}'";

            query = string.Format(query, code_room_type);

            DataProvider.Instance.ExecuteNonQuery(query);
        }
    }
}
