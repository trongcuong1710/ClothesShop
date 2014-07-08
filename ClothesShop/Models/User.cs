using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ClothesShop.Models
{
    /// <summary>
    /// user class
    /// </summary>
    public class User
    {
        /// <summary>
        /// user id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]        
        public string UserID { get; set; }

        /// <summary>
        /// login name
        /// </summary>
        [Required(ErrorMessage="Vui lòng nhập tên truy cập.")]
        [MaxLength(20, ErrorMessage="Tên truy cập chỉ có tối đa 20 ký tự.")]
        [Display(Name="Tên truy cập:")]
        public string LoginName { get; set; }

        /// <summary>
        /// password
        /// </summary>
        [Required(ErrorMessage="Vui lòng nhập password.")]
        [MaxLength(50, ErrorMessage="Mật khẩu chỉ có tối đa 50 ký tự")]
        [Display(Name="Mật khẩu.")]
        public string Password { get; set; }
    }
}