using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Asim.Models;

namespace Asim.Controllers
{
    public class KaloriController : Controller
    {

        private odevContext db = new odevContext();
        // GET: Kalori
        public ActionResult Index()
        {
            return View(db.kalorilerr.ToList());
        }

        // GET: Kalori/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kalori kalori = db.kalorilerr.Find(id);
            if (kalori == null)
            {
                return HttpNotFound();
            }
            return View(kalori);
        }

        // GET: Kalori/Create
        public ActionResult Tabak(int ?Id)
        {
            return View();
        }

        // POST: Kalori/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,BesinAdı,Resimler,Miktar,KaloriDegeri,açıklamsı")] Kalori kalori)
        {
            if (ModelState.IsValid)
            {
                db.kalorilerr.Add(kalori);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kalori);
        }

        // GET: Kalori/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kalori kalori = db.kalorilerr.Find(id);
            if (kalori == null)
            {
                return HttpNotFound();
            }
            return View(kalori);
        }

        // POST: Kalori/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,BesinAdı,Resimler,Miktar,KaloriDegeri,açıklamsı")] Kalori kalori)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kalori).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kalori);
        }

        // GET: Kalori/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kalori kalori = db.kalorilerr.Find(id);
            if (kalori == null)
            {
                return HttpNotFound();
            }
            return View(kalori);
        }

        // POST: Kalori/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kalori kalori = db.kalorilerr.Find(id);
            db.kalorilerr.Remove(kalori);
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
