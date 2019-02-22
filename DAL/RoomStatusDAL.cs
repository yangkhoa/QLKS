using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class RoomStatusDAL
    {
        private static RoomStatusDAL instance;

        public static RoomStatusDAL Instance
        {
            get { if (instance == null) instance = new RoomStatusDAL(); return instance; }
            private set => instance = value;
        }

        private RoomStatusDAL() { }

        public DataTable GetListRoomStatus()
        {
            string query = "SELECT * FROM RoomStatus";

            return DataProvider.Instance.ExecuteQuery(query);
        }
    }
}
