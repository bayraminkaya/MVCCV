using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCCV.Models.Entity;
namespace MVCCV.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        // GET: Default
        DbCvEntities1 db = new DbCvEntities1();
        public ActionResult Index()
        {
            var degerler = db.TblHakkimda.ToList();
            return View(degerler);
        }
        public PartialViewResult SosyalMedya()
        {
            var sosyalmedya = db.TblSosyalMedya.Where(x=>x.Durum==true).ToList();
            return PartialView(sosyalmedya);
        }
        public PartialViewResult Deneyim()
        {
            var deneyimler = db.TblDeneyimlerim.ToList();
            return PartialView(deneyimler);
        }
        public PartialViewResult Egitimlerim()
        {
            var deneyimler = db.TblEgitimlerim.ToList();
            return PartialView(deneyimler);
        }
        public PartialViewResult Yeteneklerim()
        {
            var deneyimler = db.TblYeteneklerim.ToList();
            return PartialView(deneyimler);
        }
        public PartialViewResult Hobilerim()
        {
            var deneyimler = db.TblHobilerim.ToList();
            return PartialView(deneyimler);
        }
        public PartialViewResult Sertifikalar()
        {
            var deneyimler = db.TblSertifikalarim.ToList();
            return PartialView(deneyimler);
        }
        [HttpPost]
        public JsonResult Iletisim(Tbliletisim t)
        {
            try
            {
                t.Tarih = DateTime.Now;
                db.Tbliletisim.Add(t);
                db.SaveChanges();

                return Json(new { success = true, message = "Mesaj başarıyla gönderildi." });
            }
            catch (Exception ex)
            {
                
                return Json(new { success = false, message = "Mesaj gönderilirken bir hata oluştu." });
            }
        }


    }
}