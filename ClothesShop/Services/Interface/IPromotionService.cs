﻿using ClothesShop.Models;
using ClothesShop.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothesShop.Services.Interface
{
    /// <summary>
    /// promotion service interface
    /// </summary>
    public interface IPromotionService
    {
        /// <summary>
        /// get all promotion
        /// </summary>
        /// <returns></returns>
        IEnumerable<Promotion> getPromotion();

        /// <summary>
        /// get deleting promotion viewmodel
        /// </summary>
        /// <returns></returns>
        IEnumerable<DeletingPromotion> getDeletingPromotion();

        /// <summary>
        /// get promotion by id
        /// </summary>
        /// <param name="ProID"></param>
        /// <returns></returns>
        Promotion getPromotion(int ProID);

        /// <summary>
        /// save promotion
        /// </summary>
        /// <param name="promotion"></param>
        void save(Promotion promotion);

        /// <summary>
        /// update promotion
        /// </summary>
        /// <param name="promotion"></param>
        void update(Promotion promotion);

        /// <summary>
        /// delete promotion
        /// </summary>
        /// <param name="promotions"></param>
        void delete(IEnumerable<DeletingPromotion> promotions);
    }
}
