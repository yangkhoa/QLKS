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
    public partial class FServiceCategory : DevExpress.XtraEditors.XtraForm
    {
        public FServiceCategory()
        {
            InitializeComponent();
            LoadServiceCategory();
        }

        private void LoadServiceCategory()
        {
            gridControl_ServiceCategory.DataSource = ServiceCategoryDAL.Instance.GetListServiceCategory();
        }

        private void Btn_Approve_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!gridView1.IsNewItemRow(gridView1.FocusedRowHandle))
            {
                string code_service_category = "" + gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString() + "";
                string name_cateogory = "" + gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[1]).ToString() + "";
                try
                {
                    ServiceCategoryBLL.Instance.EditServiceCategory(code_service_category, name_cateogory);
                }
                catch
                {
                    LoadServiceCategory();
                }            
            }
            this.Close();
        }

        private void GridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            GridView view = sender as GridView;

            // Kiểm tra xem đây là dòng mới hay cũ e.RowHandle --> trả về thứ tự dòng đang trỏ
            if (view.IsNewItemRow(e.RowHandle))
            {
                // Thêm mới trực tiếp vào form
                string code_service_category = "" + view.GetRowCellValue(e.RowHandle, view.Columns[0]).ToString() + "";
                string name_cateogory = "" + view.GetRowCellValue(e.RowHandle, view.Columns[1]).ToString() + "";

                try
                {
                   ServiceCategoryBLL.Instance.InsertServiceCategory(code_service_category, name_cateogory);
                }
                catch
                {
                    LoadServiceCategory();
                }
            }
            else
            {
                // Sửa trực tiếp trên form
                string code_service_category = "" + view.GetRowCellValue(e.RowHandle, view.Columns[0]).ToString() + "";
                string name_cateogory = "" + view.GetRowCellValue(e.RowHandle, view.Columns[1]).ToString() + "";              
                try
                {
                    ServiceCategoryBLL.Instance.EditServiceCategory(code_service_category, name_cateogory);
                }
                catch
                {
                    LoadServiceCategory();
                }
            }
        }

        private void Btn_Remove_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa dòng này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string code_service_cateogry = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString();
                try
                {
                    ServiceCategoryBLL.Instance.DeleteServiceCategory(code_service_cateogry);

                    LoadServiceCategory();
                }
                catch
                {
                    MessageBox.Show("Lỗi do có phát sinh dữ liệu","Thông báo",MessageBoxButtons.OK);

                    LoadServiceCategory();
                }
            }
        }
    }
}