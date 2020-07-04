using QuanLiCuaHang.Areas.Manager.Data;
using QuanLiCuaHang.Areas.Manager.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLiCuaHang.Areas.Manager.Repository
{
    public class CT_PhieuDichVuRepository
    {

        private QUANLYCUAHANGEntity objQUANLYCUAHANG;

        public CT_PhieuDichVuRepository()
        {
            objQUANLYCUAHANG = new QUANLYCUAHANGEntity();
        }

        public bool AddCT_PhieuDichVu(PhieuDichVuViewModel phieuDichVuViewModel)
        {
            PHIEUDV phieudichvu = new PHIEUDV();
            phieudichvu.TenKH = phieuDichVuViewModel.TenKH;
            phieudichvu.NgayLap = phieuDichVuViewModel.NgayLap;
            phieudichvu.SDT = phieuDichVuViewModel.SDT;

            phieudichvu.TongTien = phieuDichVuViewModel.TongTien;
            phieudichvu.TongTienTraTruoc = phieuDichVuViewModel.TongTienTraTruoc;
            phieudichvu.TongTienConLai = phieuDichVuViewModel.TongTienConLai;
            phieudichvu.MaTinhTrangPDV = phieuDichVuViewModel.MaTinhTrangPDV;
            objQUANLYCUAHANG.PHIEUDVs.Add(phieudichvu);
            objQUANLYCUAHANG.SaveChanges();
            int maPDV = phieudichvu.MaPDV;

            foreach (var item in phieuDichVuViewModel.DSChiTiet)
            {
                CHITIET_PHIEUDV ct_phieudichvu = new CHITIET_PHIEUDV();
                ct_phieudichvu.MaPDV = maPDV;
                ct_phieudichvu.MaLoaiDV = item.MaLoaiDV;
                ct_phieudichvu.SoLuong = item.SoLuong;
                ct_phieudichvu.DonGiaDuocTinh = item.DonGiaDuocTinh;
                ct_phieudichvu.ThanhTien = item.ThanhTien;
                ct_phieudichvu.ThanhToanTraTruoc = item.ThanhToanTraTruoc;
                ct_phieudichvu.ThanhToanConLai = item.ThanhToanConLai;
                ct_phieudichvu.NgayGiao = item.NgayGiao;
                ct_phieudichvu.MaTinhTrangDV = item.MaTinhTrangDV;
                objQUANLYCUAHANG.CHITIET_PHIEUDV.Add(ct_phieudichvu);
                objQUANLYCUAHANG.SaveChanges();
            }
            return true;
        }

    
    }
}