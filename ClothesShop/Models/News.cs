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
    /// news
    /// </summary>
    public class News
    {
        /// <summary>
        /// news id
        /// </summary>
        [Key]
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int NewsID { get; set; }

        /// <summary>
        /// news title
        /// </summary>
        [Required(ErrorMessage="Vui lòng nhập tiêu đề tin tức.")]
        [MaxLength(500, ErrorMessage="Tiêu đề tin tức chỉ có tối đa 500 ký tự.")]
        public string NewsTitle { get; set; }

        /// <summary>
        /// new image
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// news content
        /// </summary>
        [Required(ErrorMessage="Vui lòng nhập nội dung tin tức.")]
        [MaxLength]
        public string Content { get; set; }

        /// <summary>
        /// create date
        /// </summary>
        public DateTime CreateDate { get; set; }
    }
}