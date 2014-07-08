using ClothesShop.Models;
using ClothesShop.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothesShop.Services.Interface
{
    /// <summary>
    /// news service interface
    /// </summary>
    public interface INewsService
    {
        /// <summary>
        /// get news
        /// </summary>
        /// <param name="count">
        /// optional parameter
        /// determine number of news will be get
        /// get all if null
        /// </param>
        /// <returns></returns>
        IEnumerable<News> getNews(int? count = null);

        /// <summary>
        /// get deleting news view model
        /// </summary>
        /// <returns></returns>
        IEnumerable<DeletingNews> getDeletingNews();

        /// <summary>
        /// get news by id
        /// </summary>
        /// <param name="NewsID"></param>
        /// <returns></returns>
        News getNews(int NewsID);

        /// <summary>
        /// save new nes
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
        void delete(IEnumerable<DeletingNews> news);
    }
}
