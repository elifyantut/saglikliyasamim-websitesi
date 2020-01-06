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
    public class MuziksController : Controller
    {
        private odevContext db = new odevContext();

        // GET: Muziks
        public ActionResult Index()
        {
            return View(db.muzikler.ToList());
        }

        // GET: Muziks/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Muzik muzik = db.muzikler.Find(id);
            if (muzik == null)
            {
                return HttpNotFound();
            }
            return View(muzik);
        }

        // GET: Muziks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Muziks/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "link")] Muzik muzik)
        {
            if (ModelState.IsValid)
            {
                db.muzikler.Add(muzik);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(muzik);
        }

        // GET: Muziks/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Muzik muzik = db.muzikler.Find(id);
            if (muzik == null)
            {
                return HttpNotFound();
            }
            return View(muzik);
        }

        // POST: Muziks/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "link")] Muzik muzik)
        {
            if (ModelState.IsValid)
            {
                db.Entry(muzik).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(muzik);
        }

        // GET: Muziks/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Muzik muzik = db.muzikler.Find(id);
            if (muzik == null)
            {
                return HttpNotFound();
            }
            return View(muzik);
        }

        // POST: Muziks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Muzik muzik = db.muzikler.Find(id);
            db.muzikler.Remove(muzik);
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
