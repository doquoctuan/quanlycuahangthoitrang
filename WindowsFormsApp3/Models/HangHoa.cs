namespace WindowsFormsApp3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data;
    using System.Data.Entity.Spatial;

    [Table("HangHoa")]
    public partial class HangHoa
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HangHoa()
        {
            ChiTietHDs = new HashSet<ChiTietHD>();
            ChiTietPNs = new HashSet<ChiTietPN>();
        }

        [Key]
        [StringLength(50)]
        public string MaHang { get; set; }

        [StringLength(50)]
        public string TenHang { get; set; }

        [StringLength(20)]
        public string DonVi { get; set; }

        public int? GiaBan { get; set; }

        public int? SoLuong { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietHD> ChiTietHDs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietPN> ChiTietPNs { get; set; }

        public HangHoa(DataRow row)
        {
            this.MaHang = row["MaHang"].ToString();
            this.TenHang = row["TenHang"].ToString();
            this.SoLuong = (int)row["SoLuong"];
            this.GiaBan = (int)row["GiaBan"];
            this.DonVi = row["DonVi"].ToString();
        }
    }
}
