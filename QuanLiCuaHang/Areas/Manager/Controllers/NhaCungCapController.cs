using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuanLiCuaHang.Areas.Manager.Data;

namespace QuanLiCuaHang.Areas.Manager.Controllers
{
    public class NhaCungCapController : Controller
    {
        private QUANLYCUAHANGEntity db = new QUANLYCUAHANGEntity();

        // GET: Manager/NhaCungCap
        public ActionResult Index()
        {
            var nHACUNGCAP = new NHACUNGCAP();
            return View(nHACUNGCAP);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "MaNCC,TenNCC,DiaChi,SDT")] NHACUNGCAP nHACUNGCAP)
        {
            if (ModelState.IsValid)
            {
                db.NHACUNGCAPs.Add(nHACUNGCAP);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nHACUNGCAP);
        }





        // GET: Manager/NhaCungCap/Details/5
        public ActionResult Details()
        {
         
            return View(db.NHACUNGCAPs.ToList());
        }
        //CheckTenNhacungcap
        public JsonResult IsTenNhaCCavailable(string TenNCC)
        {
            return Json(!db.NHACUNGCAPs.Any(x => x.TenNCC == TenNCC), JsonRequestBehavior.AllowGet);
        }

        //CheckTenNhacungcap
        public JsonResult IsDiaChiavailable(string DiaChi)
        {
            return Json(!db.NHACUNGCAPs.Any(x => x.DiaChi == DiaChi), JsonRequestBehavior.AllowGet);
        }
        //CheckTenNhacungcap
        public JsonResult IsSDTavailable(string SDT)
        {
            return Json(!db.NHACUNGCAPs.Any(x => x.SDT == SDT), JsonRequestBehavior.AllowGet);
        }


        // POST: Manager/NhaCungCap/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
       

        // GET: Manager/NhaCungCap/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NHACUNGCAP nHACUNGCAP = db.NHACUNGCAPs.Find(id);
            if (nHACUNGCAP == null)
            {
                return HttpNotFound();
            }
            return View(nHACUNGCAP);
        }

        // POST: Manager/NhaCungCap/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaNCC,TenNCC,DiaChi,SDT")] NHACUNGCAP nHACUNGCAP)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nHACUNGCAP).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nHACUNGCAP);
        }

        // GET: Manager/NhaCungCap/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NHACUNGCAP nHACUNGCAP = db.NHACUNGCAPs.Find(id);
            if (nHACUNGCAP == null)
            {
                return HttpNotFound();
            }
            return View(nHACUNGCAP);
        }

        // POST: Manager/NhaCungCap/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NHACUNGCAP nHACUNGCAP = db.NHACUNGCAPs.Find(id);
            db.NHACUNGCAPs.Remove(nHACUNGCAP);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
