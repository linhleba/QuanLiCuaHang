//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QuanLiCuaHang.Areas.Manager.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class SANPHAM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SANPHAM()
        {
            this.BCTONKHOes = new HashSet<BCTONKHO>();
            this.CHITIET_PMH = new HashSet<CHITIET_PMH>();
            this.CT_PHIEUBANHANG = new HashSet<CT_PHIEUBANHANG>();
        }
    
        public int MaSP { get; set; }
        public string TenSanPham { get; set; }
        public decimal GiaMuaVao { get; set; }
        public decimal GiaBanRa { get; set; }
        public int SoLuongTon { get; set; }
        public int MaLoaiSP { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BCTONKHO> BCTONKHOes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIET_PMH> CHITIET_PMH { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_PHIEUBANHANG> CT_PHIEUBANHANG { get; set; }
        public virtual LOAISANPHAM LOAISANPHAM { get; set; }
    }
}
