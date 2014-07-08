using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothesShop.ViewModel
{
    /// <summary>
    /// news view model with IsDelete property
    /// to determine whether this news will be deleted
    /// </summary>
    public class DeletingNews
    {
        /// <summary>
        /// news id
        /// </summary>
        public int NewsID { get; set; }

        /// <summary>
        /// news title
        /// </summary>
        public string NewsTitle { get; set; }

        /// <summary>
        /// news description
        /// </summary>
        public string NewsDescription { get; set; }

        /// <summary>
        /// news image
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// is delete
        /// </summary>
        public bool IsDelete { get; set; }
    }
}