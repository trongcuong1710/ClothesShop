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
    /// promotion service
    /// </summary>
    public class PromotionService : ServiceBase, IPromotionService
    {
        /// <summary>
        /// promotion repository
        /// </summary>
        private IPromotionRepository repository;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="repository">
        /// will be populated by ninject
        /// </param>
        public PromotionService(IPromotionRepository repository)
            : base()
        {
            this.repository = repository;
        }

        /// <summary>
        /// get all promotion
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ViewModel.DeletingPromotion> getPromotion()
        {
            try
            {
                var promotions = this.repository.getPromotion();

                var viewmodel = from promotion in promotions
                                select new DeletingPromotion()
                                {
                                    ProID = promotion.ProID,
                                    DisCount = promotion.DisCount,
                                    IsDelete = false
                                };

                return viewmodel;
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
        public Models.Promotion getPromotion(int ProID)
        {
            try
            {
                return this.repository.getPromotion(ProID);
            }
            catch (Exception)
            {                
                throw;
            }
        }

        /// <summary>
        /// save promotion
        /// </summary>
        /// <param name="promotion"></param>
        public void save(Models.Promotion promotion)
        {
            try
            {
                //begin transaction on current db context
                this.transaction.BeginTransaction();

                this.repository.save(promotion);

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
        /// update promotion
        /// </summary>
        /// <param name="promotion"></param>
        public void update(Models.Promotion promotion)
        {
            try
            {
                //begin transaction on current db context
                this.transaction.BeginTransaction();

                this.repository.update(promotion);

                //commit transaction
                this.transaction.CommitTransaction();
            }
            catch (Exception)
            {                
                //roll back transaction when error occu
                this.transaction.RollBackTransaction();
                throw;
            }
        }

        /// <summary>
        /// delete promotion
        /// </summary>
        /// <param name="promotions"></param>
        public void delete(IEnumerable<ViewModel.DeletingPromotion> promotions)
        {
            try
            {
                //begin transaction on current db context
                this.transaction.BeginTransaction();

                promotions.Where(item => item.IsDelete).ToList()
                    .ForEach(item =>
                    {
                        Promotion promotion = this.getPromotion(item.ProID);
                        this.repository.delete(promotion);
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