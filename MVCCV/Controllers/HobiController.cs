using MVCCV.Models.Entity;
using MVCCV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCV.Controllers
{
    public class HobiController : Controller
    {
        // GET: Hobi
        GenericRepository<TblHobilerim> repo = new GenericRepository<TblHobilerim>();
        public ActionResult Index()
        {
            var hobi = repo.List();
            return View(hobi);
        }
        [HttpGet]
        public ActionResult YeniHobi()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniHobi(TblHobilerim p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult HobiSil(int id)
        {
            var hobi = repo.Find(x => x.ID == id);
            repo.TDelete(hobi);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult HobiGuncelle(int id)
        {
            var hobi = repo.Find(x => x.ID == id);
            return View(hobi);
        }
        [HttpPost]
        public ActionResult HobiGuncelle(TblHobilerim p)
        {
            var hobi = repo.Find(x => x.ID == p.ID);
            hobi.Aciklama1 = p.Aciklama1;
            hobi.Aciklama2 = p.Aciklama2;
            repo.TUpdate(hobi);
            return RedirectToAction("Index");
        }
    }
}