namespace WebsiteRaoVat.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DanhMuc")]
    public partial class DanhMuc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DanhMuc()
        {
            LoaiSanPhams = new HashSet<LoaiSanPham>();
        }

        [Key]
        public int MaDanhMuc { get; set; }

        [StringLength(50)]
        [Display(Name = "Tên danh mục:")]
        public string TenDanhMuc { get; set; }

        [Column(TypeName = "text")]
        [Display(Name = "Hình ảnh:")]
        public string Hinh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LoaiSanPham> LoaiSanPhams { get; set; }
    }
}
