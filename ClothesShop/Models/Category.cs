using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClothesShop.Models
{
    /// <summary>
    /// product's category
    /// </summary>
    public class Category
    {
        /// <summary>
        /// category id
        /// </summary>
        [Key]
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int CatID { get; set; }

        /// <summary>
        /// category name
        /// </summary>
        [Required(ErrorMessage="Vui lòng nhập tên.")]
        [MaxLength(100, ErrorMessage="Tên chỉ có độ dài tối đa 100 ký tự.")]
        public string CatName { get; set; }

        /// <summary>
        /// parent category id
        /// self join :)
        /// </summary>
        public int? ParentID { get; set; }

        /// <summary>
        /// parent category
        /// </summary>
        [ForeignKey("ParentID")]
        public virtual Category ParentCategory { get; set; }

        /// <summary>
        /// products list
        /// </summary>
        public virtual ICollection<Product> Products { get; set; }

        /// <summary>
        /// categories which are associate with this category
        /// </summary>
        public virtual ICollection<Category> Categories { get; set; }
    }
}