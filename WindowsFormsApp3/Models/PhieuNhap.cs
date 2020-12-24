namespace WindowsFormsApp3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhieuNhap")]
    public partial class PhieuNhap
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PhieuNhap()
        {
            ChiTietPNs = new HashSet<ChiTietPN>();
        }

        [Key]
        [StringLength(10)]
        public string MaPN { get; set; }

        [Required]
        [StringLength(10)]
        public string MaNCC { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayNhap { get; set; }

        [Required]
        [StringLength(50)]
        public string TenDangNhap { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietPN> ChiTietPNs { get; set; }

        public virtual NhaCungCap NhaCungCap { get; set; }
    }
}
