using MVCCV.Models.Entity;
using MVCCV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCV.Controllers
{
    public class EgitimController : Controller
    {
        // GET: Egitim
        GenericRepository<TblEgitimlerim> repo = new GenericRepository<TblEgitimlerim>();
        public ActionResult Index()
        {
            var egitim = repo.List();
            return View(egitim);
        }
        [HttpGet]
        public ActionResult EgitimEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EgitimEkle(TblEgitimlerim p)
        {
            if (!ModelState.IsValid) 
            {
                return View("EgitimEkle");
            }
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult EgitimSil(int id)
        {
            var egitim = repo.Find(x => x.ID == id);
            repo.TDelete(egitim);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EgitimGetir(int id)
        {
            var egitim = repo.Find(x => x.ID == id);
            return View(egitim);
        }
        [HttpPost]
        public ActionResult EgitimGetir(TblEgitimlerim p)
        {
            if (!ModelState.IsValid)
            {
                return View("EgitimGetir");
            }
            var egitim = repo.Find(x => x.ID == p.ID);
            egitim.Baslik = p.Baslik;
            egitim.AltBaslik1 = p.AltBaslik1;
            egitim.AltBaslik2 = p.AltBaslik2;
            egitim.Tarih = p.Tarih;
            egitim.GNO = p.GNO;
            repo.TUpdate(egitim);
            return RedirectToAction("Index");
        }
    }
}