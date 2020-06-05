using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace QuanLiCuaHang.Models
{
    public class LoaiSanPhamContext : DbContext 
    {
        public DbSet<LoaiSanPham> LoaiSanPham { get; set; }
    }
}