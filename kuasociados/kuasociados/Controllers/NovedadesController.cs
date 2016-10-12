using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using kuasociados.Contract.Models;
using kuasociados.Contract;
using System.Net;

namespace kuasociados.Controllers
{
    public class NovedadesController : Controller
    {
        public INewsService service;
        public NovedadesController(INewsService service) {
            this.service = service;
        }
    
        // GET: Novedades
        public ActionResult Index()
        {
            var news = new List<NewsModel>();

            news = this.service.getNews();

            return View(news);
        }

        public ActionResult CreateNovedad()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateNovedad(NewsModel news)
        {
            int newid = this.service.getLastestId() + 1;
            //../ Content / img / background - 10.jpg
            news.Id = newid;

            if (ModelState.IsValid)
            {
                this.service.saveNews(news);
                return RedirectToAction("Index");
            }
            else
            {
                return View(news);
            }
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsModel news = this.service.getNewsById(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

      
        public ActionResult DeleteConfirmed(int id)
        {
            this.service.deleteNews(id);
            return RedirectToAction("Index");
        }

    }
}