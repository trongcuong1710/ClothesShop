using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClothesShop.Models
{
    /// <summary>
    /// product promotion
    /// </summary>
    public class Promotion
    {
        /// <summary>
        /// promotion id
        /// </summary>
        [Key]
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int ProID { get; set; }

        /// <summary>
        /// discount percentage
        /// </summary>
        [Range(1, 100, ErrorMessage="Discount percentage only in between 1 and 100 percent")]
        public int DisCount { get; set; }
    }
}