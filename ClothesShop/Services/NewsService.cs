using ClothesShop.Models;
using ClothesShop.Repository.Interface;
using ClothesShop.Services.Base;
using ClothesShop.Services.Interface;
using ClothesShop.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothesShop.Services
{
    /// <summary>
    /// news service
    /// </summary>
    public class NewsService : ServiceBase, INewsService
    {
        /// <summary>
        /// news repository
        /// </summary>
        private INewsRepository repository;

        /// <summary>
        /// contructor
        /// </summary>
        /// <param name="repository">
        /// will be populated by ninject
        /// </param>
        public NewsService(INewsRepository repository)
            : base()
        {
            this.repository = repository;
        }

        /// <summary>
        /// get news
        /// </summary>
        /// <param name="count">
        /// optional parameter
        /// determine number of news will be get
        /// get all if null
        /// </param>
        /// <returns></returns>
        public IEnumerable<Models.News> getNews(int? count = null)
        {
            try
            {
                if (!count.HasValue)
                {
                    return this.repository.getNews();
                }
                else
                {
                    return this.repository.getLatestNews(count.Value);
                }
            }
            catch (Exception)
            {                
                throw;
            }
        }

        /// <summary>
        /// get deleting news
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ViewModel.DeletingNews> getDeletingNews()
        {
            try
            {
                IEnumerable<News> news = this.getNews();

                IEnumerable<DeletingNews> deleting = from item in news
                                                     select new DeletingNews()
                                                     {
                                                         IsDelete = false,
                                                         NewsDescription = item.Content,
                                                         NewsID = item.NewsID,
                                                         NewsTitle = item.NewsTitle,
                                                         Image = item.Image
                                                     };

                return deleting;
            }
            catch (Exception)
            {                
                throw;
            }
        }

        /// <summary>
        /// get news by id
        /// </summary>
        /// <param name="NewsID"></param>
        /// <returns></returns>
        public Models.News getNews(int NewsID)
        {
            try
            {
                return this.repository.getNews(NewsID);
            }
            catch (Exception)
            {                
                throw;
            }
        }

        /// <summary>
        /// save new news
        /// </summary>
        /// <param name="news"></param>
        public void save(Models.News news)
        {
            try
            {
                //begin transaction on current db context
                this.transaction.BeginTransaction();

                this.repository.save(news);

                //commit transaction
                this.transaction.CommitTransaction();
            }
            catch (Exception)
            {                
                //roll back transaction when error occur
                this.transaction.RollBackTransaction();
                throw;
            }
        }

        /// <summary>
        /// update existed news
        /// </summary>
        /// <param name="news"></param>
        public void update(Models.News news)
        {
            try
            {
                //begin transaction on current db context
                this.transaction.BeginTransaction();

                this.repository.update(news);

                //commit transaction
                this.transaction.CommitTransaction();
            }
            catch (Exception)
            {                
                //roll back transaction when error occur
                this.transaction.RollBackTransaction();
                throw;
            }
        }

        /// <summary>
        /// delete list of news
        /// </summary>
        /// <param name="news"></param>
        public void delete(IEnumerable<ViewModel.DeletingNews> news)
        {
            try
            {
                //begin transaction on current db context
                this.transaction.BeginTransaction();

                news.Where(item => item.IsDelete).ToList()
                    .ForEach(item =>
                    {
                        News newsItem = this.getNews(item.NewsID);
                        this.repository.delete(newsItem);
                    });

                //commit transaction
                this.transaction.CommitTransaction();
            }
            catch (Exception)
            {                
                //roll back transaction when error occur
                this.transaction.RollBackTransaction();
                throw;
            }
        }        
    }
}