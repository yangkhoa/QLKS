using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class RoomTypeDAL
    {
        private static RoomTypeDAL instance;

        public static RoomTypeDAL Instance
        {
            get { if (instance == null) instance = new RoomTypeDAL(); return instance; }
            private set => instance = value;
        }

        private RoomTypeDAL() { }

        public DataTable GetListRoomType()
        {
            string query = "SELECT * FROM RoomType";

            return DataProvider.Instance.ExecuteQuery(query);
        }
    }
}
