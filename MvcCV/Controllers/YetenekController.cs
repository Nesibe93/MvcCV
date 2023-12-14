using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCV.Models.Entity;
using MvcCV.Repositories;

namespace MvcCV.Controllers
{
    public class YetenekController : Controller
    {
        // GET: Yetenek
        GenericRepository<TblYetenekler> repo= new GenericRepository<TblYetenekler> ();
        public ActionResult Index()
        {
            var yetenekler = repo.List();
            return View(yetenekler);
        }
        [HttpGet]
        public ActionResult YeniYetenek()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniYetenek(TblYetenekler p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");   
        }
        public ActionResult YetenekSil(int id)
        {
            var yetenek = repo.Find(x => x.Id == id);
            repo.TRemove(yetenek);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult YetenekDüzenle(int id)
        {
            var yetenek = repo.Find(x => x.Id == id);
            return View(yetenek);
        }
        [HttpPost]
        public ActionResult YetenekDüzenle(TblYetenekler t)
        {
            var y = repo.Find(x => x.Id == t.Id);
            y.Yetenek = t.Yetenek;
            y.Oran = t.Oran;
            repo.TUpdate(y);
            return RedirectToAction("Index");
        }
    }
}