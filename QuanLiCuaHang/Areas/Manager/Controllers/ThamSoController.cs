using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuanLiCuaHang.Areas.Manager.Data;
using QuanLiCuaHang.Areas.Manager.Repository;
using QuanLiCuaHang.Areas.Manager.ViewModel;

namespace QuanLiCuaHang.Areas.Manager.Controllers
{
    public class ThamSoController : Controller
    {
        private QUANLYCUAHANGEntity db = new QUANLYCUAHANGEntity();

        // GET: Manager/ThamSo
        public JsonResult GetPhanTramTraTruoc()
        {
            decimal phanTramTraTruoc = db.THAMSOes.FirstOrDefault().PhanTramTraTruoc;

            return Json(phanTramTraTruoc, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index()
        {
            
            //if (tHAMSO == null)
            //{
            //    return HttpNotFound();
            //}
            return View();
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Index([Bind(Include = "PhanTramTraTruoc")] THAMSO tHAMSO)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(tHAMSO).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(tHAMSO);
        //}

        [HttpPost]
        public JsonResult Index([System.Web.Http.FromBody] ThamSoViewModel thamso)
        {
            ThamSoRepository thamSoRepository = new ThamSoRepository();
            thamSoRepository.AddThamSo(thamso);

            return Json(data: "", JsonRequestBehavior.AllowGet);
        }
        // GET: Manager/ThamSo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THAMSO tHAMSO = db.THAMSOes.Find(id);
            if (tHAMSO == null)
            {
                return HttpNotFound();
            }
            return View(tHAMSO);
        }

        // GET: Manager/ThamSo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Manager/ThamSo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PhanTramTraTruoc")] THAMSO tHAMSO)
        {
            if (ModelState.IsValid)
            {
                db.THAMSOes.Add(tHAMSO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tHAMSO);
        }

        // GET: Manager/ThamSo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THAMSO tHAMSO = db.THAMSOes.Find(id);
            if (tHAMSO == null)
            {
                return HttpNotFound();
            }
            return View(tHAMSO);
        }

        // POST: Manager/ThamSo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PhanTramTraTruoc")] THAMSO tHAMSO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tHAMSO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tHAMSO);
        }

        // GET: Manager/ThamSo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THAMSO tHAMSO = db.THAMSOes.Find(id);
            if (tHAMSO == null)
            {
                return HttpNotFound();
            }
            return View(tHAMSO);
        }

        // POST: Manager/ThamSo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            THAMSO tHAMSO = db.THAMSOes.Find(id);
            db.THAMSOes.Remove(tHAMSO);
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
