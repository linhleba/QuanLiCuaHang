﻿//------------------------------------------------------------------------------
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
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public partial class LOAISANPHAM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LOAISANPHAM()
        {
            this.SANPHAMs = new HashSet<SANPHAM>();
        }

       
        [Key]
    
        public int MaLoaiSP { get; set; }
        [DisplayName("Tên loại sản phẩm")]
        [Required(ErrorMessage = "Tên loại sản phẩm không được phép rỗng")]
        [StringLength(30,ErrorMessage = "Tên loại sản phẩm không quá 30 kí tự")]
        public string TenLoaiSP { get; set; }

        [DisplayName("Phần trăm lợi nhuận")]
        [Required(ErrorMessage = "Phần trăm lợi nhuận không được phép rỗng")]
        [Range(0,100, ErrorMessage = "Phần trăm lợi nhuận trong khoảng từ 0 đến 100")]
        public double PhanTramLoiNhuan { get; set; }

        [DisplayName("Mã đơn vị tinh")]
        public int MaDVT { get; set; }
        [DisplayName("Tên đơn vị tính")]
        public virtual DONVITINH DONVITINH { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SANPHAM> SANPHAMs { get; set; }
    }
}