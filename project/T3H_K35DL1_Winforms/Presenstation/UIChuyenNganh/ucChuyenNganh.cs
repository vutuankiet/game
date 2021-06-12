using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using T3H_K35DL1_Winforms.Models.DAO;
using T3H_K35DL1_Winforms.Models.EF;

namespace T3H_K35DL1_Winforms.Presenstation.UIChuyenNganh
{
    public partial class ucChuyenNganh : UserControl
    {
        public ucChuyenNganh()
        {
            InitializeComponent();
        }

        private void ucChuyenNganh_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;

            LoadData();
        }

        private void LoadData()
        {
            ChuyenNganhDAO dao = new ChuyenNganhDAO();
            dgvChuyenNganh.DataSource = dao.GetAll().Select(t => new
            {
                MaCN = t.MaCN,
                TenCN = t.TenCN,
                MaKhoa = t.MaKhoa,
                TenKhoa = t.Khoa.TenKhoa,
            });
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ChuyenNganhDAO dao = new ChuyenNganhDAO();
            dgvChuyenNganh.DataSource = dao.GetByKeyword(txtKeyword.Text.Trim()).Select(t => new
            {
                MaCN = t.MaCN,
                TenCN = t.TenCN,
                MaKhoa = t.MaKhoa,
                TenKhoa = t.Khoa.TenKhoa,
            });
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string maChuyenNganh = dgvChuyenNganh.CurrentRow.Cells["MaCN"].Value.ToString();
            frmChuyenNganh frm = new frmChuyenNganh();
            frm.IsAdd = false;
            frm.MaChuyenNganh = maChuyenNganh;
            frm.ShowDialog();

            if (frm.Result)
            {
                LoadData();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmChuyenNganh frm = new frmChuyenNganh();
            frm.IsAdd = true;
            frm.ShowDialog();
            if (frm.Result)
            {
                LoadData();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            ChuyenNganhDAO dao = new ChuyenNganhDAO();

            string MaChuyenNganh = dgvChuyenNganh.CurrentRow.Cells["MaChuyenNganh"].Value.ToString();

            if (dao.Delete(MaChuyenNganh))
            {
                MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadData();
            }
            else
            {
                MessageBox.Show("Xóa thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
