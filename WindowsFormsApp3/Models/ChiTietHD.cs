namespace WindowsFormsApp3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietHD")]
    public partial class ChiTietHD
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string MaHD { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string MaHang { get; set; }

        public int? SoLuong { get; set; }

        public double? DonGia { get; set; }

        public virtual HangHoa HangHoa { get; set; }

        public virtual HoaDon HoaDon { get; set; }
    }
}
