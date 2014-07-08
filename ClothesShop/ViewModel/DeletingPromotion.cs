using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothesShop.ViewModel
{
    /// <summary>
    /// promotion view model which contain IsDelete property
    /// to determine whether this promotion will be deleted
    /// </summary>
    public class DeletingPromotion
    {
        /// <summary>
        /// promotion id
        /// </summary>
        public int ProID { get; set; }

        /// <summary>
        /// promotion discount
        /// </summary>
        public int DisCount { get; set; }

        /// <summary>
        /// is delete
        /// </summary>
        public bool IsDelete { get; set; }
    }
}