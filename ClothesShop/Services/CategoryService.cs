using ClothesShop.Models;
using ClothesShop.Repository.Interface;
using ClothesShop.Services.Base;
using ClothesShop.Services.Interface;
using ClothesShop.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothesShop.Services
{
    /// <summary>
    /// category service
    /// </summary>
    public class CategoryService : ServiceBase, ICategoryService
    {
        /// <summary>
        /// category repository
        /// </summary>
        private ICategoryRepository repository;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="repository">
        /// will be populated by ninject
        /// </param>
        public CategoryService(ICategoryRepository repository)
            : base()
        {
            this.repository = repository;
        }

        /// <summary>
        /// get all categories
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Category> getCategory()
        {
            try
            {
                IEnumerable<Category> categories = from category in this.repository.getCategory()
                                                   where category.ParentID == null
                                                   select category;

                return categories;
            }
            catch (Exception)
            {                
                throw;
            }
        }

        /// <summary>
        /// get all category which doesn't has any child
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Category> getChildCategory()
        {
            try
            {
                IEnumerable<Category> categories = from category in this.repository.getCategory()
                                                   where category.Categories == null || category.Categories.Count() == 0
                                                   select category;

                return categories;
            }
            catch (Exception)
            {                
                throw;
            }
        }

        /// <summary>
        /// get all deleting categories view model
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DeletingCategory> getDeletingCategory()
        {
            try
            {
                IEnumerable<Category> categories = this.repository.getCategory();

                IEnumerable<DeletingCategory> deletingCategories = from category in categories
                                                                   select new DeletingCategory()
                                                                   {
                                                                       CanDelete = this.canDelete(category),
                                                                       CatID = category.CatID,
                                                                       CatName = category.CatName,
                                                                       ParentName = category.ParentCategory == null ? "" : category.ParentCategory.CatName,
                                                                       IsDelete = false
                                                                   };

                return deletingCategories;
            }
            catch (Exception)
            {                
                throw;
            }
        }

        /// <summary>
        /// get category by id
        /// </summary>
        /// <param name="CatID"></param>
        /// <returns></returns>
        public Models.Category getCategory(int CatID)
        {
            try
            {
                return this.repository.getCategory(CatID);
            }
            catch (Exception)
            {                
                throw;
            }
        }

        /// <summary>
        /// determine whether a category can be deleted
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public bool canDelete(Category category)
        {
            try
            {
                //only category that doesn't has any associate child category and product 
                //can be deleted
                if ((category.Products == null || category.Products.Count() == 0)
                    && (category.Categories == null || category.Categories.Count() == 0))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {                
                throw;
            }
        }

        /// <summary>
        /// save new category
        /// </summary>
        /// <param name="category"></param>
        public void save(Models.Category category)
        {
            try
            {
                //begin transaction on current db context
                this.transaction.BeginTransaction();

                this.repository.Save(category);

                //commit transaction
                this.transaction.CommitTransaction();
            }
            catch (Exception)
            {
                //roll back transaction when error occur
                this.transaction.RollBackTransaction();
                throw;
            }
        }

        /// <summary>
        /// update existed category
        /// </summary>
        /// <param name="category"></param>
        public void update(Models.Category category)
        {
            try
            {
                //begin transaction on current db context
                this.transaction.BeginTransaction();

                this.repository.Update(category);

                //commit transaction
                this.transaction.CommitTransaction();
            }
            catch (Exception)
            {                
                //roll back transaction when error occur
                this.transaction.RollBackTransaction();
                throw;
            }
        }

        /// <summary>
        /// delete category
        /// </summary>
        /// <param name="category"></param>
        public void delete(IEnumerable<DeletingCategory> categories)
        {
            try
            {
                //begin transaction on current db context
                this.transaction.BeginTransaction();

                categories.Where(category => category.IsDelete).ToList()
                    .ForEach(category => 
                    {
                        Category deleted = this.getCategory(category.CatID);
                        this.repository.Delete(deleted);
                    });

                //commit transaction
                this.transaction.CommitTransaction();
            }
            catch (Exception)
            {                
                //roll back transaction when error occur
                this.transaction.RollBackTransaction();
                throw;
            }
        }
    }
}