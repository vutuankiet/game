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
    public partial class frmKhoa : Form
    {
        private bool isAdd_ = true;
        public bool IsAdd
        {
            set
            {
                isAdd_ = value;
            }
        }
        private bool result_ = true;
        public bool Result
        {
            get
            {
                return result_;
            }
        }
        private string maKhoa_ = "";
        public string MaKhoa
        {
            set
            {
                maKhoa_ = value;
            }
        }
        public frmKhoa()
        {
            InitializeComponent();
        }

        private void frmKhoa_Load(object sender, EventArgs e)
        {
            if (!isAdd_)
            {
                KhoaDAO dao = new KhoaDAO();
                var info = dao.GetSingleByID(maKhoa_);
                if (info != null)
                {
                    txtMaKhoa.Text = info.MaKhoa.Trim();
                    txtTenKhoa.Text = info.TenKhoa.Trim();
                    txtDiaChi.Text = info.DiaChi.Trim();
                    txtSoDienThoai.Text = info.SoDienThoai.Trim();
                    
                }
                else
                {
                    this.Close();
                }
            }
        }

        private Khoa InitKhoa()
        {
            Khoa Khoa = new Khoa();
            Khoa.MaKhoa = txtMaKhoa.Text.Trim();
            Khoa.TenKhoa = txtTenKhoa.Text.Trim();
            Khoa.DiaChi = txtDiaChi.Text.Trim();
            Khoa.SoDienThoai = txtSoDienThoai.Text.Trim();
           

            return Khoa;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            KhoaDAO dao = new KhoaDAO();
            Khoa info = InitKhoa();
            if (isAdd_)
            {
                if (dao.Add(info))
                {
                    MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    result_ = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (dao.Edit(info))
                {
                    MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    result_ = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Sửa thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //private void txtMaLop_Click(object sender, EventArgs e)
        //{
        //    frmSelectMaLop frm = new frmSelectMaLop();

        //    frm.ShowDialog();

        //    if (frm.Result_)
        //    {
        //        txtSoDienThoai.Text = frm.MaLop_;
        //    }
        //}
    }
}
