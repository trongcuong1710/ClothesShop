using ClothesShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothesShop.Repository.Interface
{
    /// <summary>
    /// promotion repository interface
    /// </summary>
    public interface IPromotionRepository
    {
        /// <summary>
        /// get all promotion
        /// </summary>
        /// <returns></returns>
        IEnumerable<Promotion> getPromotion();

        /// <summary>
        /// get promotion by id
        /// </summary>
        /// <param name="ProID"></param>
        /// <returns></returns>
        Promotion getPromotion(int ProID);

        /// <summary>
        /// save new promotion
        /// </summary>
        /// <param name="promotion"></param>
        void save(Promotion promotion);

        /// <summary>
        /// update existed promotion
        /// </summary>
        /// <param name="promotion"></param>
        void update(Promotion promotion);

        /// <summary>
        /// delete promotion
        /// </summary>
        /// <param name="promotion"></param>
        void delete(Promotion promotion);
    }
}
