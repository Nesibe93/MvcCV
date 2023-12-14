using MvcCV.Models.Entity;
using MvcCV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCV.Controllers
{
    public class EğitimController : Controller
    {
        // GET: Eğitim
        GenericRepository<TblEgitim> repo = new GenericRepository<TblEgitim>();
        public ActionResult Index()
        {
            var egitim = repo.List();
            return View(egitim);
        }
        [HttpGet]
        public ActionResult EğitimEkle() 
        { 
            return View(); 
        }
        [HttpPost]
        public ActionResult EğitimEkle(TblEgitim p)
        {
            if(!ModelState.IsValid)
            {
                return View("EğitimEkle");
            }
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult EğitimSil(int id)
        {
            var egitim =repo.Find(x=>x.Id == id);
            repo.TRemove(egitim);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EğitimDüzenle(int id)
        {
            var egitim = repo.Find(x => x.Id == id);
            return View(egitim);
        }
        [HttpPost]
        public ActionResult EğitimDüzenle(TblEgitim t)
        {

            if (!ModelState.IsValid)
            {
                return View("EğitimDüzenle");
            }

            var egitim = repo.Find(x => x.Id == t.Id);
            egitim.Baslik=t.Baslik;
            egitim.AltBaslik=t.AltBaslik;
            egitim.AltBaslik2 = t.AltBaslik2;
            egitim.GNO= t.GNO;
            egitim.Tarih=t.Tarih;
            repo.TUpdate(egitim);
            return RedirectToAction("Index");
        }
    }
}