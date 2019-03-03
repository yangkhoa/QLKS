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
    public partial class FCustomer : DevExpress.XtraEditors.XtraForm
    {
        public FCustomer()
        {
            InitializeComponent();
            
            LoadListCustomer();
        }

        private void LoadListCustomer()
        {
            gridControl_Customer.DataSource = CustomerDAL.Instance.GetListCustomer();
        }

        private void Btn_Approve_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!gridView1.IsNewItemRow(gridView1.FocusedRowHandle))
            {
                string col_1 = "" + gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString().Trim() + "";
                string col_2 = "" + gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[1]).ToString() + "";
                string col_3 = "" + gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[2]).ToString() + "";
                string col_4 = "" + gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[3]).ToString() + "";
                string col_5 = "" + gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[4]).ToString() + "";
                try
                {
                    CustomerBLL.Instance.EditInfoCustomer(col_1, col_2, col_3, col_4, col_5);
                }
                catch
                {
                    LoadListCustomer();
                }               
            }
            this.Close();
        }

        private void Btn_Delete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa dòng này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string code_customer = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString().Trim();
                try
                {
                    CustomerBLL.Instance.DeleteCustomerByCode(code_customer);

                    LoadListCustomer();
                }
                catch
                {
                    MessageBox.Show("Lỗi do có phát sinh dữ liệu");
                }
            }
        }

        private void gridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            GridView view = sender as GridView;

            // Kiểm tra xem đây là dòng mới hay cũ e.RowHandle --> trả về thứ tự dòng đang trỏ
            if (view.IsNewItemRow(e.RowHandle))
            {
                // Thêm mới trực tiếp vào form
                string col_1 = "" + gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString().Trim() + "";
                string col_2 = "" + gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[1]).ToString() + "";
                string col_3 = "" + gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[2]).ToString() + "";
                string col_4 = "" + gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[3]).ToString() + "";
                string col_5 = "" + gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[4]).ToString() + "";           
                try
                {
                    CustomerBLL.Instance.InsertCustomer(col_1, col_2, col_3, col_4, col_5);
                }
                catch
                {
                    LoadListCustomer();
                }
            }
            else
            {
                // Sửa trực tiếp trên form
                string col_1 = "" + gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString().Trim() + "";
                string col_2 = "" + gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[1]).ToString() + "";
                string col_3 = "" + gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[2]).ToString() + "";
                string col_4 = "" + gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[3]).ToString() + "";
                string col_5 = "" + gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[4]).ToString() + "";

                try
                {
                    CustomerBLL.Instance.EditInfoCustomer(col_1, col_2, col_3, col_4, col_5);
                }
                catch
                {
                    LoadListCustomer();
                }
            }
        }
    }
}