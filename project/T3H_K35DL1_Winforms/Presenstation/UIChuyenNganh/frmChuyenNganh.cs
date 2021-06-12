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
    public partial class frmChuyenNganh : Form
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
        private string maChuyenNganh_ = "";
        public string MaChuyenNganh
        {
            set
            {
                maChuyenNganh_ = value;
            }
        }
        public frmChuyenNganh()
        {
            InitializeComponent();
        }

        private void Khoa_Load()
        {
            KhoaDAO dao = new KhoaDAO();

            cbbKhoa.DisplayMember = "TenKhoa";
            cbbKhoa.ValueMember = "MaKhoa";

            cbbKhoa.DataSource = dao.GetAll();
        }
        private void frmChuyenNganh_Load(object sender, EventArgs e)
        {
            if (!isAdd_)
            {
                txtMaCN.Enabled = false;
                ChuyenNganhDAO dao = new ChuyenNganhDAO();
                var info = dao.GetSingleByID(maChuyenNganh_);
                if (info != null)
                {
                    txtMaCN.Text = info.MaCN.Trim();
                    txtTenCN.Text = info.TenCN.Trim();
                    cbbKhoa.SelectedValue = info.MaKhoa;

                }
                else
                {
                    this.Close();
                }
            }
        }

        private ChuyenNganh InitChuyenNganh()
        {
            ChuyenNganh Khoa = new ChuyenNganh();
            Khoa.MaCN = txtMaCN.Text.Trim();
            Khoa.TenCN = txtTenCN.Text.Trim();
            Khoa.MaKhoa = cbbKhoa.SelectedValue.ToString();


            return Khoa;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            ChuyenNganhDAO dao = new ChuyenNganhDAO();
            ChuyenNganh info = InitChuyenNganh();
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
    }
}
