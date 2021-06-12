using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using T3H_K35DL1_Winforms.Models.EF;

namespace T3H_K35DL1_Winforms.Models.DAO
{
    public class SinhVienDAO : BaseDAO
    {
        public List<SinhVien> GetAll()
        {
            return db_.SinhViens.ToList();
        }

        // tìm kiếm theo keyword
        public List<SinhVien> GetByKeyword(string keyword)
        {
            return db_.SinhViens.Where(t => t.MaSV == keyword || t.HoTen.Contains(keyword)).ToList();
        }

        // lấy theo ID
        public SinhVien GetSingleByID(string maSV)
        {
            return db_.SinhViens.Where(t => t.MaSV == maSV).FirstOrDefault();
        }

        // thêm Sinh Viên
        public bool Add(SinhVien info)
        {
            try
            {
                db_.SinhViens.Add(info);
                db_.SaveChanges();
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            return true;
        }

        // Sửa thông tin
        public bool Edit(SinhVien info)
        {
            try
            {
                var info0 = GetSingleByID(info.MaSV);
                if (info0 != null)
                {
                    info0.HoTen = info.HoTen;
                    info0.GioiTinh = info.GioiTinh;
                    info0.NgaySinh = info.NgaySinh;
                    info0.QueQuan = info.QueQuan;
                    info0.DiaChi = info.DiaChi;
                    info0.EMail = info.EMail;
                    info0.SDT = info.SDT;
                    info0.MaLop = info.MaLop;
                    info0.Pic = info.Pic;

                    db_.SaveChanges();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            return true;
        }

        // xóa theo mã Sinh Viên
        public bool Delete(string maSV)
        {
            try
            {
                var info0 = GetSingleByID(maSV);
                if (info0 != null)
                {
                    db_.SinhViens.Remove(info0);

                    db_.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            return true;
        }
    }
}
