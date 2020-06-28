using QuanLiCuaHang.Areas.Manager.Data;
using QuanLiCuaHang.Areas.Manager.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLiCuaHang.Areas.Manager.Repository
{
    public class CT_PhieuMuaHangRepository
    {

        private QUANLYCUAHANGEntity objQUANLYCUAHANGEntity;

        public CT_PhieuMuaHangRepository()
        {
            objQUANLYCUAHANGEntity = new QUANLYCUAHANGEntity();
        }

        public bool AddCT_PhieuMuaHang(PhieuMuaHangViewModel phieuMuaHangViewModel)
        {
            PHIEUMUAHANG phieumuahang = new PHIEUMUAHANG();

            phieumuahang.MaNCC = phieuMuaHangViewModel.MaNCC;
            phieumuahang.NgayLap = phieuMuaHangViewModel.NgayLap;
            phieumuahang.TongTien = phieuMuaHangViewModel.TongTien;
            objQUANLYCUAHANGEntity.PHIEUMUAHANGs.Add(phieumuahang);
            objQUANLYCUAHANGEntity.SaveChanges();
            int maPMH = phieumuahang.MaPMH;

            foreach (var item in phieuMuaHangViewModel.DSChiTiet)
            {
                CHITIET_PMH ct_phieumuahang = new CHITIET_PMH();
                SANPHAM sanpham = objQUANLYCUAHANGEntity.SANPHAMs.Find(item.MaSP);
                ct_phieumuahang.MaPMH = maPMH;
                ct_phieumuahang.MaSP = item.MaSP;
                ct_phieumuahang.SoLuong = item.SoLuong;
                ct_phieumuahang.DonGia = item.DonGia;
                ct_phieumuahang.ThanhTien = item.ThanhTien;

                sanpham.SoLuongTon = (item.SoLuongTon + item.SoLuong);
                objQUANLYCUAHANGEntity.CHITIET_PMH.Add(ct_phieumuahang);
                objQUANLYCUAHANGEntity.SaveChanges();
            }
            return true;
        }
    }
}