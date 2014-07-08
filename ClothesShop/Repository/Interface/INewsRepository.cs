using ClothesShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothesShop.Repository.Interface
{
    /// <summary>
    /// news repository interface
    /// </summary>
    public interface INewsRepository
    {
        /// <summary>
        /// get all news
        /// </summary>
        /// <returns></returns>
        IEnumerable<News> getNews();

        /// <summary>
        /// get news by id
        /// </summary>
        /// <param name="NewsID"></param>
        /// <returns></returns>
        News getNews(int NewsID);

        /// <summary>
        /// get 4 latest news
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        IEnumerable<News> getLatestNews(int count);

        /// <summary>
        /// save new news
        /// </summary>
        /// <param name="news"></param>
        void save(News news);

        /// <summary>
        /// update existed news
        /// </summary>
        /// <param name="news"></param>
        void update(News news);

        /// <summary>
        /// delete news
        /// </summary>
        /// <param name="news"></param>
        void delete(News news);
    }
}
