using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class RoomDAL
    {
        private static RoomDAL instance;

        public static RoomDAL Instance
        {
            get { if (instance == null) instance = new RoomDAL(); return instance; }
            private set => instance = value;
        }

        private RoomDAL() { }

        public List<Room> LoadRoomList()
        {
            List<Room> listroom = new List<Room>();

            string query = "EXEC USP_GetRoomList";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Room room = new Room(item);
                listroom.Add(room);
            }

            return listroom;
        }

        public DataTable GetRoomList()
        {
            string query = "SELECT * FROM Room";

            return DataProvider.Instance.ExecuteQuery(query);
        }

        public DataTable GetRoomListBooking()
        {
            string query = "SELECT a.code_room,a.name_room,c.name_type,c.price FROM Room a,RoomStatus b, RoomType c WHERE b.code_room_status = N'001' AND a.code_status = b.code_room_status AND a.code_type = c.code_room_type";

            return DataProvider.Instance.ExecuteQuery(query);
        }
    }
}
