﻿

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
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

using System.Data.Entity.Core.Objects;
using System.Linq;


public partial class QUANLYCUAHANGEntity : DbContext
{
    public QUANLYCUAHANGEntity()
        : base("name=QUANLYCUAHANGEntity")
    {

    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        throw new UnintentionalCodeFirstException();
    }


    public virtual DbSet<CHITIET_PHIEUDV> CHITIET_PHIEUDV { get; set; }

    public virtual DbSet<CHITIET_PMH> CHITIET_PMH { get; set; }

    public virtual DbSet<CT_PHIEUBANHANG> CT_PHIEUBANHANG { get; set; }

    public virtual DbSet<DONVITINH> DONVITINHs { get; set; }

    public virtual DbSet<LOAIDV> LOAIDVs { get; set; }

    public virtual DbSet<LOAISANPHAM> LOAISANPHAMs { get; set; }

    public virtual DbSet<NHACUNGCAP> NHACUNGCAPs { get; set; }

    public virtual DbSet<PHIEUBANHANG> PHIEUBANHANGs { get; set; }

    public virtual DbSet<PHIEUDV> PHIEUDVs { get; set; }

    public virtual DbSet<PHIEUMUAHANG> PHIEUMUAHANGs { get; set; }

    public virtual DbSet<SANPHAM> SANPHAMs { get; set; }

    public virtual DbSet<TINHTRANGDV> TINHTRANGDVs { get; set; }

    public virtual DbSet<TINHTRANGPDV> TINHTRANGPDVs { get; set; }

    public virtual DbSet<THAMSO> THAMSOes { get; set; }

    public virtual DbSet<BCTONKHO> BCTONKHOes { get; set; }


    public virtual int TAO_BCTONKHO(Nullable<int> thang, Nullable<int> nam, Nullable<int> maSanPham, Nullable<int> tonDau, Nullable<int> tonCuoi, Nullable<int> sLMuaVao, Nullable<int> sLBanRa)
    {

        var thangParameter = thang.HasValue ?
            new ObjectParameter("Thang", thang) :
            new ObjectParameter("Thang", typeof(int));


        var namParameter = nam.HasValue ?
            new ObjectParameter("Nam", nam) :
            new ObjectParameter("Nam", typeof(int));


        var maSanPhamParameter = maSanPham.HasValue ?
            new ObjectParameter("MaSanPham", maSanPham) :
            new ObjectParameter("MaSanPham", typeof(int));


        var tonDauParameter = tonDau.HasValue ?
            new ObjectParameter("TonDau", tonDau) :
            new ObjectParameter("TonDau", typeof(int));


        var tonCuoiParameter = tonCuoi.HasValue ?
            new ObjectParameter("TonCuoi", tonCuoi) :
            new ObjectParameter("TonCuoi", typeof(int));


        var sLMuaVaoParameter = sLMuaVao.HasValue ?
            new ObjectParameter("SLMuaVao", sLMuaVao) :
            new ObjectParameter("SLMuaVao", typeof(int));


        var sLBanRaParameter = sLBanRa.HasValue ?
            new ObjectParameter("SLBanRa", sLBanRa) :
            new ObjectParameter("SLBanRa", typeof(int));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("TAO_BCTONKHO", thangParameter, namParameter, maSanPhamParameter, tonDauParameter, tonCuoiParameter, sLMuaVaoParameter, sLBanRaParameter);
    }

}

}

