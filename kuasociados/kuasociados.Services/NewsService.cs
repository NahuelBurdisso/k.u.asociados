using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kuasociados.Contract.Models;
using kuasociados.Contract;
using kuasociados.Data;
using System.Data.Entity.Validation;



namespace kuasociados.Services
{
    public class NewsService: INewsService
    {
        public KuasociadosEntities db { get; set; }

        public NewsService() {
            this.db = new KuasociadosEntities();
        }

        public int getLastestId()
        {
            var result = db.News.ToList().LastOrDefault();
            if (result != null)
            {
                int id = result.Id;
                return id;
            }
            else {
                return 0;
            }
            
        }

        public NewsModel getNewsById(int? id)
        {
            var news = db.News.Where(x => (x.Id == id)).SingleOrDefault();
            NewsModel news1 = new NewsModel()
            {
                Id = news.Id,
                Title = news.Title,
                Subtitle = news.Subtitle,
                Body = news.Body,
                Author = news.Author,
                Img = news.Img,
                PublishDate = news.PublishDate,
            };
            return news1;
        }
        public List<NewsModel> getNews() {
            List<NewsModel> news1 = new List<NewsModel>();
            var newslist = db.News.ToList();
            foreach (News news in newslist)
            {
                NewsModel newsitem = new NewsModel()
                {
                    Id = news.Id,
                    Title = news.Title,
                    Subtitle = news.Subtitle,
                    Body = news.Body,
                    Author = news.Author,
                    Img = news.Img,
                    PublishDate = news.PublishDate,
                };

                news1.Add(newsitem);
            }
            return news1;
        }
        public void saveNews(NewsModel news) {

            News news1 = new News()
            {
                Id = news.Id,
                Title = news.Title,
                Subtitle = news.Subtitle,
                Body = news.Body,
                Author = news.Author,
                Img = news.Img,
                PublishDate = news.PublishDate,
            };
            db.News.Add(news1);
           
            db.SaveChanges();
        }

        public void deleteNews(int id)
        {
           News news = db.News.Where(x => (x.Id == id)).SingleOrDefault();
            db.News.Remove(news);
            db.SaveChanges();
        }

        public void editNews(NewsModel news){
            var result = db.News.SingleOrDefault(x => x.Id == news.Id);
            if (result != null)
            {
                result.Id = news.Id;
                result.Title = news.Title;
                result.Subtitle = news.Subtitle;
                result.Body = news.Body;
                result.Author = news.Author;
                result.Img = news.Img;
                result.PublishDate = news.PublishDate;
                db.SaveChanges();
            }
        }
    }
}
