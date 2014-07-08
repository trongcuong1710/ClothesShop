using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Web.Mvc;

namespace ClothesShop.Models
{
    /// <summary>
    /// product
    /// </summary>
    public class Product
    {
        /// <summary>
        /// product id
        /// </summary>
        [Key]
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int ProductID { get; set; }

        /// <summary>
        /// product code
        /// </summary>
        [Required(ErrorMessage="Vui lòng nhập mã sản phẩm.")]
        [MaxLength(10, ErrorMessage="Mã sản phẩm chỉ có độ dài tối đa 10 ký tự.")]        
        public string ProductCode { get; set; }

        /// <summary>
        /// product name
        /// </summary>
        [Required(ErrorMessage="Vui lòng nhập tên.")]
        [MaxLength(100, ErrorMessage="Tên sản phẩm chỉ có độ dài tối đa 100 ký tự.")]
        public string ProductName { get; set; }

        [Required(ErrorMessage="Vui lòng nhập giá sản phẩm.")]
        public decimal ProductPrice { get; set; }

        /// <summary>
        /// product description
        /// </summary>
        [MaxLength(500, ErrorMessage="Mô tả sản phẩm chỉ có độ dài tối đa 500 ký tự.")]
        public string Description { get; set; }

        /// <summary>
        /// category id
        /// </summary>
        public int CatID { get; set; }

        /// <summary>
        /// promotion id
        /// </summary>
        public int? ProID { get; set; }

        /// <summary>
        /// create date
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// product's images
        /// </summary>
        public virtual IEnumerable<ProductImages> Images { get; set; }

        /// <summary>
        /// category 
        /// </summary>
        [ForeignKey("CatID")]
        public virtual Category Category { get; set; }

        /// <summary>
        /// promotion
        /// </summary>
        [ForeignKey("ProID")]
        public virtual Promotion Promotion { get; set; }
    }
}