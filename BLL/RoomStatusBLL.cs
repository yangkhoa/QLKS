using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class RoomStatusBLL
    {
        private static RoomStatusBLL instance;

        public static RoomStatusBLL Instance
        {
            get { if (instance == null) instance = new RoomStatusBLL(); return instance; }
            private set => instance = value;
        }

        private RoomStatusBLL() { }

        public void EditRoomType(string code_room_status, string name_status)
        {
            string query = "UPDATE RoomStatus SET name_status = N'{1}' WHERE code_room_status = N'{0}'";

            query = string.Format(query, code_room_status, name_status);

            DataProvider.Instance.ExecuteNonQuery(query);
        }

        public void DeleteRoomType(string code_room_status)
        {
            string query = "DELETE FROM RoomStatus WHERE code_room_status = N'{0}'";

            query = string.Format(query, code_room_status);

            DataProvider.Instance.ExecuteNonQuery(query);
        }

        public void InsertRoomType(string code_room_status, string name_status)
        {
            string query = "INSERT RoomStatus(code_room_status,name_status) VALUES (N'{0}',N'{1}')";

            query = string.Format(query, code_room_status, name_status);

            DataProvider.Instance.ExecuteNonQuery(query);
        }
    }
}
