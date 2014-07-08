using ClothesShop.Models;
using ClothesShop.Repository.Base;
using ClothesShop.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothesShop.Repository
{
    public class NewsRepository : RepositoryBase, INewsRepository
    {
        /// <summary>
        /// constructor
        /// </summary>
        public NewsRepository()
            : base()
        {
        }

        /// <summary>
        /// get all news
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Models.News> getNews()
        {
            try
            {
                var items = from news in this.context.News
                            orderby news.CreateDate descending
                            select news;

                return items;
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
                var news = this.context.News.Find(NewsID);

                return news;
            }
            catch (Exception)
            {                
                throw;
            }
        }

        /// <summary>
        /// get latest news
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public IEnumerable<Models.News> getLatestNews(int count)
        {
            try
            {
                var news = this.getNews();

                return news.Take(count);
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
        public void save(News news)
        {
            try
            {
                if (news == null)
                {
                    throw new ArgumentNullException();
                }

                this.context.News.Add(news);
                this.context.SaveChanges();
            }
            catch (Exception)
            {                
                throw;
            }
        }

        /// <summary>
        /// update existed news
        /// </summary>
        /// <param name="news"></param>
        public void update(News news)
        {
            try
            {
                if (news == null)
                {
                    throw new ArgumentNullException();
                }

                this.context.Entry<News>(news).State = System.Data.EntityState.Modified;
                this.context.SaveChanges();
            }
            catch (Exception)
            {                
                throw;
            }
        }

        /// <summary>
        /// delete news
        /// </summary>
        /// <param name="news"></param>
        public void delete(News news)
        {
            try
            {
                if (news == null)
                {
                    throw new ArgumentNullException();
                }

                this.context.News.Remove(news);
                this.context.SaveChanges();
            }
            catch (Exception)
            {                
                throw;
            }
        }
    }
}