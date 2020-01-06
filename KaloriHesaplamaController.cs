using Asim.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Asim.Controllers
{
    [Authorize]
    public class KaloriHesaplamaController : Controller
    {
        private odevContext db = new odevContext();
        // GET: KaloriHesaplama
        public ActionResult Index()
        {
            return View(GetCart());
        }
        public ActionResult SepeteEkle(int id)
        {
            var kaloriler = db.kalorilerr.FirstOrDefault(i => i.Id == id);
            if (kaloriler != null)
            {
                GetCart().AddProduct(kaloriler, 1);
            }

            return RedirectToAction("Index");
        }
        public ActionResult SepettenSil(int id)
        {
            var product = db.kalorilerr.FirstOrDefault(i => i.Id == id);
            if (product != null)
            {
                GetCart().DeleteProduct(product);

            }

            return RedirectToAction("Index");
        }


        public KaloriListesi GetCart()
        {

            var egzersiz = (KaloriListesi)Session["KaloriListesi"];
            if (egzersiz == null)
            {
                egzersiz = new KaloriListesi();
                Session["KaloriListesi"] = egzersiz;



            }
            return egzersiz;

        }
    }
}