using QuanLiCuaHang.Areas.Manager.Data;
using QuanLiCuaHang.Areas.Manager.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace QuanLiCuaHang.Areas.Manager.Repository
{
    public class CT_PhieuBanHangRepository
    {
        private QUANLYCUAHANGEntity objQUANLYCUAHANGEntity;

        public CT_PhieuBanHangRepository()
        {
            objQUANLYCUAHANGEntity = new QUANLYCUAHANGEntity();
        }

        public bool AddCT_PhieuBanHang(PhieuBanHangViewModel phieuBanHangViewModel)
        {
            PHIEUBANHANG phieubanhang = new PHIEUBANHANG();
            phieubanhang.TenKH = phieuBanHangViewModel.TenKH;
            phieubanhang.NgayLap = phieuBanHangViewModel.NgayLap;
            phieubanhang.TongTien = phieuBanHangViewModel.TongTien;
            objQUANLYCUAHANGEntity.PHIEUBANHANGs.Add(phieubanhang);
            objQUANLYCUAHANGEntity.SaveChanges();
            int maPBH = phieubanhang.MaPBH;

            foreach (var item in phieuBanHangViewModel.DSChiTiet)
            {
                CT_PHIEUBANHANG ct_phieubanhang = new CT_PHIEUBANHANG();
                SANPHAM sanpham = objQUANLYCUAHANGEntity.SANPHAMs.Find(item.MaSP);

                ct_phieubanhang.MaPBH = maPBH;
                ct_phieubanhang.MaSP = item.MaSP;
                ct_phieubanhang.SoLuong = item.SoLuong;
                ct_phieubanhang.DonGia = item.DonGia;
                ct_phieubanhang.ThanhTien = item.ThanhTien;

                sanpham.SoLuongTon = (item.SoLuongTon - item.SoLuong);
                objQUANLYCUAHANGEntity.CT_PHIEUBANHANG.Add(ct_phieubanhang);
                objQUANLYCUAHANGEntity.SaveChanges();
            }
            return true;
        }
    }
}