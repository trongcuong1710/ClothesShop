using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothesShop.ViewModel
{
    /// <summary>
    /// product view model
    /// contain IsDelete property to determine whether this product will be deleted
    /// and PromotionID property to determine promotion associate with this product
    /// </summary>
    public class ProductViewModel
    {
        /// <summary>
        /// product id
        /// </summary>
        public int ProID { get; set; }

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
        /// description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// category name
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// promotion discount
        /// </summary>
        public int? PromotionID { get; set; }

        /// <summary>
        /// is delete
        /// </summary>
        public bool IsDelete { get; set; }
    }
}