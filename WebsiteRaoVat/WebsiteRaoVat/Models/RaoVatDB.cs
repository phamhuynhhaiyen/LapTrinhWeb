namespace WebsiteRaoVat.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class RaoVatDB : DbContext
    {
        public RaoVatDB()
            : base("name=RaoVatDB")
        {
        }

        public virtual DbSet<BaiDang> BaiDangs { get; set; }
        public virtual DbSet<DanhMuc> DanhMucs { get; set; }
        public virtual DbSet<LoaiSanPham> LoaiSanPhams { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BaiDang>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<DanhMuc>()
                .Property(e => e.Hinh)
                .IsUnicode(false);

            modelBuilder.Entity<DanhMuc>()
                .HasMany(e => e.LoaiSanPhams)
                .WithOptional(e => e.DanhMuc)
                .WillCascadeOnDelete();

            modelBuilder.Entity<LoaiSanPham>()
                .HasMany(e => e.BaiDangs)
                .WithOptional(e => e.LoaiSanPham)
                .WillCascadeOnDelete();

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.SDT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.Hinh)
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoan>()
                .HasMany(e => e.BaiDangs)
                .WithOptional(e => e.TaiKhoan)
                .WillCascadeOnDelete();
        }
    }
}
