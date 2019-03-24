using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DAL;
using BLL;
using DevExpress.XtraGrid.Views.Grid;

namespace QLKS
{
    public partial class FRoom : DevExpress.XtraEditors.XtraForm
    {
        public FRoom()
        {
            InitializeComponent();

            LoadListRoom();

            LoadRoomType();

            LoadRoomStatus();
        }

        private void LoadRoomStatus()
        {
            string query = "SELECT * FROM RoomStatus";

            repositoryItemSearchLookUp_RoomStatus.DataSource = DataProvider.Instance.ExecuteQuery(query);

            repositoryItemSearchLookUp_RoomStatus.ValueMember = "code_room_status";

            repositoryItemSearchLookUp_RoomStatus.DisplayMember = "name_status";

            // dòng này để gridcontrol trong GridlookupEdit tự động resize các column để không thừa không thiếu nội dung
            repositoryItemSearchLookUp_RoomStatus.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFit;

        }

        private void LoadRoomType()
        {
            string query = "SELECT * FROM RoomType";
            repositoryItemSearchLookUp_RoomType.DataSource = DataProvider.Instance.ExecuteQuery(query);

            repositoryItemSearchLookUp_RoomType.ValueMember = "code_room_type";

            repositoryItemSearchLookUp_RoomType.DisplayMember = "name_type";

            // dòng này để gridcontrol trong GridlookupEdit tự động resize các column để không thừa không thiếu nội dung
            repositoryItemSearchLookUp_RoomType.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFit;

        }

        private void LoadListRoom()
        {
            gridControl_Room.DataSource = RoomDAL.Instance.GetRoomList();
        }

        private void Btn_Approve_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!gridView1.IsNewItemRow(gridView1.FocusedRowHandle))
            {
                string code_room = "" + gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString().Trim() + "";
                string name_room = "" + gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[1]).ToString() + "";
                string code_type = "" + gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[2]).ToString().Trim() + "";
                string code_status = "" + gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[3]).ToString().Trim() + "";
                string note = "" + gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[4]).ToString() + "";
                try
                {
                    RoomBLL.Instance.EditRoom(code_room, name_room, code_type, code_status, note);
                }
                catch
                {
                    LoadListRoom();
                }
            }


            this.Close();
        }

        private void Btn_Delete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa dòng này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string code_room = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString().Trim();

                try
                {
                    RoomBLL.Instance.DeleteRoom(code_room);

                    LoadListRoom();
                }
                catch
                {
                    MessageBox.Show("Lỗi do có phát sinh dữ liệu");
                }
            }
        }

        private void GridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            GridView view = sender as GridView;

            // Kiểm tra xem đây là dòng mới hay cũ e.RowHandle --> trả về thứ tự dòng đang trỏ
            if (view.IsNewItemRow(e.RowHandle))
            {
                // Thêm mới trực tiếp vào form
                string code_room = "" + gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString().Trim() + "";
                string name_room = "" + gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[1]).ToString() + "";
                string code_type = "" + gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[2]).ToString().Trim() + "";
                string code_status = "" + gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[3]).ToString().Trim() + "";
                string note = "" + gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[4]).ToString() + "";

                try
                {
                    RoomBLL.Instance.InsertRoom(code_room, name_room, code_type, code_status, note);
                }
                catch
                {
                    LoadListRoom();
                }
                
            }
            else
            {
                // Sửa trực tiếp trên form
                string code_room = "" + gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString().Trim() + "";
                string name_room = "" + gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[1]).ToString() + "";
                string code_type = "" + gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[2]).ToString().Trim() + "";
                string code_status = "" + gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[3]).ToString().Trim() + "";
                string note = "" + gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[4]).ToString() + "";

                try
                {
                    RoomBLL.Instance.EditRoom(code_room, name_room, code_type, code_status, note);
                }
                catch
                {
                    LoadListRoom();
                }               
            }
        }
    }
}