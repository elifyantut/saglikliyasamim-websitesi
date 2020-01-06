using Asim.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Asim.Controllers
{
    [Authorize]
    public class bazalController : Controller
    {
        // GET: bazal
     
             [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(bazal model, string command)
        {
            if (command == "kadın")
            {
                model.C = model.Kilo * 24;
                model.D = model.C * 0.95;



            }
            if (command == "erkek")
            {
                model.C = model.Kilo * 24;
                model.D = model.C * 1;

            }
            return View(model);
        }

    }
 }