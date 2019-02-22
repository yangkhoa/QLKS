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
    public partial class FRoomStatus : DevExpress.XtraEditors.XtraForm
    {
        public FRoomStatus()
        {
            InitializeComponent();
            LoadListRoomStatus();
        }

        public void LoadListRoomStatus()
        {
            gridControl_RoomStatus.DataSource = RoomStatusDAL.Instance.GetListRoomStatus();
        }

        private void Btn_Approve_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!gridView1.IsNewItemRow(gridView1.FocusedRowHandle))
            {
                string col_1 = "" + gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString() + "";
                string col_2 = "" + gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[1]).ToString() + "";

                RoomStatusBLL.Instance.EditRoomType(col_1, col_2);
            }


            this.Close();
        }
        private void Btn_Delete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa dòng này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string code_room_status = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString();
                
                try
                {
                    RoomStatusBLL.Instance.DeleteRoomType(code_room_status);

                    LoadListRoomStatus();
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
                string col_1 = "" + view.GetRowCellValue(e.RowHandle, view.Columns[0]).ToString() + "";
                string col_2 = "" + view.GetRowCellValue(e.RowHandle, view.Columns[1]).ToString() + "";

                RoomStatusBLL.Instance.InsertRoomType(col_1, col_2);
            }
            else
            {
                // Sửa trực tiếp trên form
                string col_1 = "" + view.GetRowCellValue(e.RowHandle, view.Columns[0]).ToString() + "";
                string col_2 = "" + view.GetRowCellValue(e.RowHandle, view.Columns[1]).ToString() + "";


                RoomStatusBLL.Instance.EditRoomType(col_1, col_2);
            }
        }
    }
}