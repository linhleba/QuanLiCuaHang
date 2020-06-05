using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using QuanLiCuaHang.Models;

namespace QuanLiCuaHang.Areas.Manager.Controllers
{
 
    public class LoaiSanPhamController : Controller
    {
        // GET: Manager/LoaiSanPham

        public ActionResult ChiTiet(int id)
        {
            LoaiSanPhamContext loaisanphamContext = new LoaiSanPhamContext();
            LoaiSanPham loaiSanPham = loaisanphamContext.LoaiSanPham.Single(lsp => lsp.MaLoaiSP == id);
            //LoaiSanPham loaiSanPham = loaisanphamContext.LoaiSanPham.Single(lsp => lsp.MaLoaiSanPham == MaLoaiSanPham);
            return View(loaiSanPham);
        }

        public ActionResult Test()
        {
            LoaiSanPhamContext loaisanphamContext = new LoaiSanPhamContext();
            List<LoaiSanPham> loaiSanPham = loaisanphamContext.LoaiSanPham.ToList();
            //LoaiSanPham loaiSanPham = loaisanphamContext.LoaiSanPham.Single(lsp => lsp.MaLoaiSanPham == MaLoaiSanPham);
            return View(loaiSanPham);
        }
    }
}