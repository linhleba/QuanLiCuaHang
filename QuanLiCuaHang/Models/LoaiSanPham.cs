using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QuanLiCuaHang.Models
{

    [Table("dbo.LOAISANPHAM")]
    public class LoaiSanPham
    {
        [Key]
        public int MaLoaiSP { get; set;}
        public string TenLoaiSP { get; set; }
        public double? PhanTramLoiNhuan { get; set; }
        public int MaDVT { get; set; }

    }
}