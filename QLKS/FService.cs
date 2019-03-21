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
    public partial class FService : DevExpress.XtraEditors.XtraForm
    {
        public FService()
        {
            InitializeComponent();

            LoadTreeCategory();

            LoadService();
   
        }

        private void LoadTreeCategory()
        {
            DataTable data = ServiceCategoryDAL.Instance.GetListServiceCategory();

            treeView_Category.Nodes.Clear();           

            foreach (DataRow item in data.Rows)
            {
                TreeNode node = new TreeNode
                {
                    Text = item["name_category"].ToString(),
                    Tag = item["code_service_category"].ToString()
                };
                treeView_Category.Nodes.Add(node);
            }
        }

        private void LoadService(string code_category = null)
        {
            gridControl_Service.DataSource = ServiceDAL.Instance.GetListServiceByCategory(code_category);
        }

        private void TreeView_Category_AfterSelect(object sender, TreeViewEventArgs e)
        {
            LoadService(treeView_Category.SelectedNode.Tag.ToString());
        }

        private void Btn_Approve_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!gridView1.IsNewItemRow(gridView1.FocusedRowHandle))
                {
                    string code_service = "" + gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString() + "";
                    string name_service = "" + gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[1]).ToString() + "";
                    string unit = "" + gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[2]).ToString() + "";
                    string price_service = "" + gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[3]).ToString() + "";
                    string code_category = treeView_Category.SelectedNode.Tag.ToString();

                    ServiceBLL.Instance.EditService(code_service, name_service, unit, price_service, code_category);
                }
            }
            catch
            {
                this.Close();
            }
            this.Close();
        }

        private void Btn_Delete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa dòng này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string code_service = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString();

                try
                {
                    ServiceBLL.Instance.DeleteService(code_service);

                    LoadService(treeView_Category.SelectedNode.Tag.ToString());
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
                string code_service = "" + gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString() + "";
                string name_service = "" + gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[1]).ToString() + "";
                string unit = "" + gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[2]).ToString() + "";
                string price_service = "" + gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[3]).ToString() + "";
                string code_category = treeView_Category.SelectedNode.Tag.ToString();
                try
                {
                    ServiceBLL.Instance.InsertService(code_service, name_service, unit, price_service, code_category);
                }
                catch
                {
                    LoadService();
                }               
            }
            else
            {
                // Sửa trực tiếp trên form
                string code_service = "" + gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString() + "";
                string name_service = "" + gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[1]).ToString() + "";
                string unit = "" + gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[2]).ToString() + "";
                string price_service = "" + gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[3]).ToString() + "";
                string code_category = treeView_Category.SelectedNode.Tag.ToString();
                try
                {
                    ServiceBLL.Instance.EditService(code_service, name_service, unit, price_service, code_category);
                }
                catch
                {
                    LoadService();
                }               
            }
        }
    }
}