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

        public ActionResult DanhSach()
        {
            LoaiSanPhamContext loaisanphamContext = new LoaiSanPhamContext();
            List<LoaiSanPham> loaiSanPham = loaisanphamContext.LoaiSanPham.ToList();
            //LoaiSanPham loaiSanPham = loaisanphamContext.LoaiSanPham.Single(lsp => lsp.MaLoaiSanPham == MaLoaiSanPham);
            return View(loaiSanPham);
        }

        [HttpGet]
        [ActionName("Tao")]
        public ActionResult Tao_Get()
        {
            return View();
        }


        [HttpPost]
        [ActionName("Tao")]
        public ActionResult Tao_Post(LoaiSanPham loaisanpham)
        {

            //LoaiSanPham loaisanpham = new LoaiSanPham();
            //loaisanpham.TenLoaiSP = formCollection["TenLoaiSP"];
            //loaisanpham.PhanTramLoiNhuan = Int32.Parse(formCollection["PhanTramLoiNhuan"]);
            //loaisanpham.MaDVT = Int32.Parse(formCollection["MaDVT"]);

            if (ModelState.IsValid)
            {


                LoaiSanPhamContext loaiSanPhamContext = new LoaiSanPhamContext();
                loaiSanPhamContext.AddLoaiSanPham(loaisanpham);
                RedirectToAction("Danhsach");

            }
            return View();
        }

        // Hàm sửa loại sản phẩm
        [HttpGet]
        [ActionName("Sua")]
        public ActionResult Sua_Get(int id)
        {
            LoaiSanPhamContext loaiSanPhamContext = new LoaiSanPhamContext();
            LoaiSanPham loaisanpham = loaiSanPhamContext.LoaiSanPham.Single(lsp => lsp.MaLoaiSP == id);

            return View(loaisanpham);

        }

        [HttpPost]
        [ActionName("Sua")]
        public ActionResult Sua_Post(int id)
        {
            LoaiSanPhamContext loaiSanPhamContext = new LoaiSanPhamContext();
            LoaiSanPham loaisanpham = loaiSanPhamContext.LoaiSanPham.Single(x => x.MaLoaiSP == id);
            UpdateModel(loaisanpham, new string[] { "TenLoaiSP", "PhanTramLoiNhuan", "MaDVT" });
            if (ModelState.IsValid)
            {
     
                loaiSanPhamContext.SaveLoaiSanPham(loaisanpham);
                return RedirectToAction("Danhsach");
            }
            return View(loaisanpham);

        }

        // Ham xoa loai san pham
        
       
        public ActionResult Xoa(int id)
        { 
            LoaiSanPhamContext loaiSanPhamContext = new LoaiSanPhamContext();
            loaiSanPhamContext.DeleteLoaiSanPham(id);
            return RedirectToAction("Danhsach");

        }
    }
}