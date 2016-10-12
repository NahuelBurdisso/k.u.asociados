using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kuasociados.Contract.Models;

namespace kuasociados.Contract
{
    public interface INewsService
    {
        int getLastestId();
        NewsModel getNewsById(int? id);
        List<NewsModel> getNews();
        void saveNews(NewsModel news);

        void deleteNews(int id);

        void editNews(NewsModel news);
    }
}
