namespace WebsiteRaoVat.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BaiDang")]
    public partial class BaiDang
    {
        [Key]
        public int MaBaiDang { get; set; }

        [StringLength(200)]
        public string Username { get; set; }

        public int? MaLoaiSP { get; set; }

        [Column(TypeName = "text")]
        public string NoiDung { get; set; }

        public long? Gia { get; set; }

        public bool? TinhTrang { get; set; }

        public virtual LoaiSanPham LoaiSanPham { get; set; }

        public virtual TaiKhoan TaiKhoan { get; set; }
    }
}
