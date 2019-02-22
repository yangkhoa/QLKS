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

        public void InsertRoomType(string col_1, string col_2, string col_3, string col_4, string col_5)
        {
            string query = "INSERT RoomType(code_room_type,name_type,price,number_min,number_max) VALUES (N'{0}',N'{1}',{2},{3},{4})";

            query = string.Format(query, col_1, col_2, col_3, col_4, col_5);

            DataProvider.Instance.ExecuteQuery(query);
            
        }

        public void EditRoomType(string col_1, string col_2, string col_3, string col_4, string col_5)
        {
            string query = "UPDATE RoomType SET name_type = N'{1}',price = {2},number_min = {3},number_max = {4} WHERE code_room_type = N'{0}'";

            query = string.Format(query, col_1, col_2, col_3, col_4, col_5);

            DataProvider.Instance.ExecuteQuery(query);
        }

        public void DeleteRoomType(string code_room_type)
        {
            string query = "DELETE FROM RoomType WHERE code_room_type = N'{0}'";

            query = string.Format(query, code_room_type);

            DataProvider.Instance.ExecuteQuery(query);
        }
    }
}
