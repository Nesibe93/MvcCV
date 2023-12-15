using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCV.Models.Entity;
namespace MvcCV.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        DbCVEntities db = new DbCVEntities();
        public ActionResult Index()
        {
            var degerler = db.TblHakkimda.ToList();
            return View(degerler);
        }
        public PartialViewResult SosyalMedya()
        {
            var sosyalmedya = db.TblSosyalMedya.ToList();
            return PartialView(sosyalmedya);
        }
        public PartialViewResult Deneyim()
        {
            var deneyimler = db.TblDeneyimlerim.ToList();
            return PartialView(deneyimler);
        }
        public PartialViewResult Egitimlerim()
        {
            var egitimler = db.TblEgitim.ToList();
            return PartialView(egitimler);
        }   
        public PartialViewResult Yeteneklerim()
        {
            var yetenekler = db.TblYetenekler.ToList();
            return PartialView(yetenekler);
        } 
        public PartialViewResult Hobilerim()
        {
            var hobiler = db.TblHobilerim.ToList();
            return PartialView(hobiler);
        }
        public PartialViewResult KurslarSertifikalar()
        {
            var kurslarSertifikalar = db.TblSertifikalarim.ToList();
            return PartialView(kurslarSertifikalar);
        }
        [HttpGet]
        public PartialViewResult İletişim()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult İletişim(Tblİletisim t)
        {
            t.Tarih =DateTime.Parse(DateTime.Now.ToShortDateString());
            db.Tblİletisim.Add(t);
            db.SaveChanges();
            return PartialView();
        }
    }
}