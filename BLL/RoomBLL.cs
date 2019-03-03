using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class RoomBLL
    {
        private static RoomBLL instance;

        public static RoomBLL Instance
        {
            get { if (instance == null) instance = new RoomBLL(); return instance; }
            private set => instance = value;
        }

        private RoomBLL() { }

        public void EditRoom(string col_1, string col_2, string col_3, string col_4, string col_5)
        {
            string query = "UPDATE Room SET name_room = N'{1}', code_type = N'{2}', code_status = N'{3}', note = N'{4}' WHERE code_room = N'{0}'";

            query = string.Format(query, col_1, col_2,col_3,col_4,col_5);

            DataProvider.Instance.ExecuteNonQuery(query);
        }

        public void DeleteRoom(string code_room)
        {
            string query = "DELETE FROM Room WHERE code_room = N'{0}'";

            query = string.Format(query, code_room);

            DataProvider.Instance.ExecuteNonQuery(query);
        }

        public void InsertRoom(string col_1, string col_2, string col_3, string col_4, string col_5)
        {
            string query = "INSERT Room(code_room,name_room,code_type,code_status,note) VALUES (N'{0}',N'{1}',N'{2}',N'{3}',N'{4}')";

            query = string.Format(query, col_1, col_2, col_3, col_4, col_5);

            DataProvider.Instance.ExecuteNonQuery(query);
        }
    }
}
