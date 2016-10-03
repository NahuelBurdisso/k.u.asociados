using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using kuasociados.Models;

namespace kuasociados.Controllers
{
    public class NovedadesController : Controller
    {
        // GET: Novedades
        public ActionResult Index()
        {
            //var newsList = new List<News>();
            //for (int i = 0; i < length; i++)
            //{
            //    newsList.Add();
            //}
            var news = new News();
            news.author = "Pedro Olivar";
            news.idNews = 1;
            news.publishDate = new DateTime(2015, 01, 02);
            news.title = "Lucha contra el narcotrafico";
            news.title = "La lucha contra el narcotrafico en Rafaela aumenta considerablemente";
            news.img = "";
            return View(news);
        }

        public ActionResult Create(){
            return View();
        }

        [HttpPost]
        public ActionResult CreateNovedad(News news)
        {

            if (ModelState.IsValid)
            {
                //db.AddToMovies(newMovie);
                //db.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return View(news);
            }
        }
    }
}