﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace T3H_K35DL1_Winforms.Models.EF
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class QuanLiSinhVienEntities : DbContext
    {
        public QuanLiSinhVienEntities()
            : base("name=QuanLiSinhVienEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BoMon> BoMons { get; set; }
        public virtual DbSet<ChuyenNganh> ChuyenNganhs { get; set; }
        public virtual DbSet<Diem> Diems { get; set; }
        public virtual DbSet<GiangVien> GiangViens { get; set; }
        public virtual DbSet<HanhKiem> HanhKiems { get; set; }
        public virtual DbSet<HocKi> HocKis { get; set; }
        public virtual DbSet<Khoa> Khoas { get; set; }
        public virtual DbSet<KhoaHoc> KhoaHocs { get; set; }
        public virtual DbSet<LichSu> LichSus { get; set; }
        public virtual DbSet<Lop> Lops { get; set; }
        public virtual DbSet<MonHoc> MonHocs { get; set; }
        public virtual DbSet<PhanHoiSinhVien> PhanHoiSinhViens { get; set; }
        public virtual DbSet<PhanQuyen> PhanQuyens { get; set; }
        public virtual DbSet<SinhVien> SinhViens { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
    }
}