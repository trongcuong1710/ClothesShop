using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothesShop.ViewModel
{
    /// <summary>
    /// product promotion
    /// </summary>
    public class ProductPromotion
    {
        /// <summary>
        /// product id
        /// </summary>
        public int ProdID { get; set; }

        /// <summary>
        /// product name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// product code
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// product price
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// promotion discount
        /// </summary>
        public int? Discount { get; set; }

        /// <summary>
        /// promotion price
        /// </summary>
        public decimal PromotionPrice
        {
            get
            {
                if (this.Discount.HasValue)
                {
                    return this.Price * this.Discount.Value / 100;
                }
                else
                {
                    return this.Price;
                }
            }
        }
    }
}