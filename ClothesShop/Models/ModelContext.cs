using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ClothesShop.Models
{
    /// <summary>
    /// model context
    /// </summary>
    public class ModelContext : System.Data.Entity.DbContext
    {
        /// <summary>
        /// constructor
        /// </summary>
        public ModelContext()
            : base("DefaultConnection")
        {
            //try
            //{
            //    Database.SetInitializer<ModelContext>(new DropCreateDatabaseIfModelChanges<ModelContext>());
            //}
            //catch (Exception)
            //{                
            //    throw;
            //}
        }

        /// <summary>
        /// News
        /// </summary>
        public DbSet<News> News { get; set; }

        /// <summary>
        /// category
        /// </summary>
        public DbSet<Category> Category { get; set; }

        /// <summary>
        /// product
        /// </summary>
        public DbSet<Product> Product { get; set; }

        /// <summary>
        /// promotion
        /// </summary>
        public DbSet<Promotion> Promotion { get; set; }

        /// <summary>
        /// product images
        /// </summary>
        public DbSet<ProductImages> ProductImages { get; set; }

        /// <summary>
        /// user
        /// </summary>
        public DbSet<User> User { get; set; }
    }
}