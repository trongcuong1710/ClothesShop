using ClothesShop.Models;
using ClothesShop.Repository.Base;
using ClothesShop.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothesShop.Repository
{
    /// <summary>
    /// promotion repository
    /// </summary>
    public class PromotionRepository : RepositoryBase, IPromotionRepository
    {
        /// <summary>
        /// constructor
        /// </summary>
        public PromotionRepository()
            : base()
        {
        }

        /// <summary>
        /// get all promotion
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Models.Promotion> getPromotion()
        {
            try
            {
                var promotions = from promotion in this.context.Promotion
                                 orderby promotion.DisCount ascending
                                 select promotion;

                return promotions;
            }
            catch (Exception)
            {                
                throw;
            }
        }

        /// <summary>
        /// get promotion by id
        /// </summary>
        /// <param name="ProID"></param>
        /// <returns></returns>
        public Promotion getPromotion(int ProID)
        {
            try
            {
                return this.context.Promotion.Find(ProID);
            }
            catch (Exception)
            {                
                throw;
            }
        }

        /// <summary>
        /// save new promotion
        /// </summary>
        /// <param name="promotion"></param>
        public void save(Models.Promotion promotion)
        {
            try
            {
                this.context.Promotion.Add(promotion);
                this.context.SaveChanges();
            }
            catch (Exception)
            {                
                throw;
            }
        }

        /// <summary>
        /// update existed promotion
        /// </summary>
        /// <param name="promotion"></param>
        public void update(Models.Promotion promotion)
        {
            try
            {
                this.context.Entry<Promotion>(promotion).State = System.Data.EntityState.Modified;
                this.context.SaveChanges();
            }
            catch (Exception)
            {                
                throw;
            }
        }

        /// <summary>
        /// delete promotion
        /// </summary>
        /// <param name="promotion"></param>
        public void delete(Models.Promotion promotion)
        {
            try
            {
                this.context.Promotion.Remove(promotion);
                this.context.SaveChanges();
            }
            catch (Exception)
            {                
                throw;
            }
        }
    }
}