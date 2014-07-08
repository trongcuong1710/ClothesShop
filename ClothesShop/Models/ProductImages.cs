using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace ClothesShop.Models
{
    /// <summary>
    /// product's images
    /// </summary>
    public class ProductImages
    {
        /// <summary>
        /// image id
        /// </summary>
        [Key]
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int ImageID { get; set; }

        /// <summary>
        /// product id
        /// </summary>
        public int ProductID { get; set; }

        /// <summary>
        /// image
        /// </summary>        
        public string Image { get; set; }

        /// <summary>
        /// product
        /// </summary>
        [ForeignKey("ProductID")]
        public virtual Product Product { get; set; }
    }
}