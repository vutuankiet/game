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

namespace T3H_K35DL1_Winforms.Presenstation.UIKhoa
{
    public partial class ucKhoa : UserControl
    {
        public ucKhoa()
        {
            InitializeComponent();
        }

        private void ucKhoa_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;

            LoadData();
        }

        private void LoadData()
        {
            KhoaDAO dao = new KhoaDAO();
            dgvKhoa.DataSource = dao.GetAll();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            KhoaDAO dao = new KhoaDAO();
            dgvKhoa.DataSource = dao.GetByKeyword(txtKeyword.Text.Trim());
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string maKhoa = dgvKhoa.CurrentRow.Cells["MaKhoa"].Value.ToString();
            frmKhoa frm = new frmKhoa();
            frm.IsAdd = false;
            frm.MaKhoa = maKhoa;
            frm.ShowDialog();

            if (frm.Result)
            {
                LoadData();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmKhoa frm = new frmKhoa();
            frm.IsAdd = true;
            frm.ShowDialog();
            if (frm.Result)
            {
                LoadData();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            KhoaDAO dao = new KhoaDAO();

            string MaKhoa = dgvKhoa.CurrentRow.Cells["MaKhoa"].Value.ToString();

            if (dao.Delete(MaKhoa))
            {
                MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadData();
            }
            else
            {
                MessageBox.Show("Xóa thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtKeyword_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dgvKhoa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
