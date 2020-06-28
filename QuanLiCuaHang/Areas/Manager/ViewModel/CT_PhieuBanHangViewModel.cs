using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuanLiCuaHang.Areas.Manager.ViewModel
{
    public class CT_PhieuBanHangViewModel
    {
        public int MaPBH { get; set; }

        public int MaSP { get; set; }

        public int SoLuong { get; set; }

   
        public decimal DonGia { get; set; }

       
        public decimal ThanhTien { get; set; }
        public int SoLuongTon { get; set; }
    }
}