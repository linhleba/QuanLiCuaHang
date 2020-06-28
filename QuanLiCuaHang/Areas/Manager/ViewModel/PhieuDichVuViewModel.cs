using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLiCuaHang.Areas.Manager.ViewModel
{
    public class PhieuDichVuViewModel
    {
        public int MaPDV { get; set; }

        public string TenKH { get; set; }

        public DateTime NgayLap { get; set; }

        public string SDT { get; set; }

        public decimal TongTien { get; set; }

        public decimal TongTienTraTruoc { get; set; }

        public decimal TongTienConLai { get; set; }

        public int MaTinhTrangPDV { get; set; }

        public List<CT_PhieuDichVuViewModel> DSChiTiet { get; set; }
    }
}