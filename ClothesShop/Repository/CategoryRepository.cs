using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClothesShop.Models;
using ClothesShop.Repository.Interface;
using ClothesShop.Repository.Base;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;

namespace ClothesShop.Repository
{
    /// <summary>
    /// category repository
    /// </summary>
    public class CategoryRepository : RepositoryBase, ICategoryRepository
    {
        /// <summary>
        /// constructor
        /// </summary>
        public CategoryRepository() 
            : base()
        {            
        }

        /// <summary>
        /// get categories
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Category> getCategory()
        {
            try
            {
                var categories = this.context.Category.Include(x => x.Categories);

                return categories;
            }
            catch (Exception)
            {                
                throw;
            }
        }

        /// <summary>
        /// get category by ID
        /// </summary>
        /// <param name="CatID"></param>
        /// <returns></returns>
        public Category getCategory(int CatID)
        {
            try
            {
                Category category = this.context.Category.Find(CatID);

                return category;
            }
            catch (Exception)
            {                
                throw;
            }
        }

        /// <summary>
        /// save category
        /// </summary>
        /// <param name="category"></param>
        public void Save(Category category)
        {
            try
            {
                using (var transaction = this.context.BeginTransaction())
                {
                    this.context.Category.Add(category);
                    this.context.SaveChanges();

                    transaction.Commit();
                }
            }
            catch (Exception)
            {                
                throw;
            }
        }

        /// <summary>
        /// delete category
        /// </summary>
        /// <param name="category"></param>
        public void Delete(Category category)
        {
            try
            {
                using (var transaction = this.context.BeginTransaction())
                {
                    this.context.Category.Remove(category);
                    this.context.SaveChanges();

                    transaction.Commit();
                }
            }
            catch (Exception)
            {                
                throw;
            }
        }

        /// <summary>
        /// update category
        /// </summary>
        /// <param name="category"></param>
        public void Update(Category category)
        {
            try
            {
                using (var transaction = this.context.BeginTransaction())
                {
                    this.context.Entry<Category>(category).State = System.Data.EntityState.Modified;
                    this.context.SaveChanges();

                    transaction.Commit();
                }
            }
            catch (Exception)
            {                
                throw;
            }
        }
    }
}