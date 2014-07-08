using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothesShop.ViewModel
{
    /// <summary>
    /// category with Deleted property 
    /// to determine which category will be deleted
    /// </summary>
    public class DeletingCategory
    {
        /// <summary>
        /// category id
        /// </summary>
        public int CatID { get; set; }

        /// <summary>
        /// category name
        /// </summary>
        public string CatName { get; set; }

        /// <summary>
        /// parent category
        /// </summary>
        public string ParentName { get; set; }

        /// <summary>
        /// determine whether this category can delete
        /// </summary>
        public bool CanDelete { get; set; }

        /// <summary>
        /// determine whether this category is queue for delete
        /// </summary>
        public bool IsDelete { get; set; }
    }
}