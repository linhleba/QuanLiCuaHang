
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
    
public partial class CHITIET_PMH
{

    public int MaPMH { get; set; }

    public int MaSP { get; set; }

    public int SoLuong { get; set; }

    public decimal DonGia { get; set; }

    public decimal ThanhTien { get; set; }



    public virtual PHIEUMUAHANG PHIEUMUAHANG { get; set; }

    public virtual SANPHAM SANPHAM { get; set; }

}

}
