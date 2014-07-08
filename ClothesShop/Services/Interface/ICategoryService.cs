using ClothesShop.Models;
using ClothesShop.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothesShop.Services.Interface
{
    /// <summary>
    /// category service interface
    /// </summary>
    public interface ICategoryService
    {
        /// <summary>
        /// get all deleting category view model
        /// </summary>
        /// <returns></returns>
        IEnumerable<Category> getCategory();

        /// <summary>
        /// get all category which are does not has any child
        /// </summary>
        /// <returns></returns>
        IEnumerable<Category> getChildCategory();

        /// <summary>
        /// get category by id
        /// </summary>
        /// <param name="CatID"></param>
        /// <returns></returns>
        Category getCategory(int CatID);

        /// <summary>
        /// get deleting category view model
        /// </summary>
        /// <returns></returns>
        IEnumerable<DeletingCategory> getDeletingCategory();

        /// <summary>
        /// determine whether a category can be deleted
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        bool canDelete(Category category);

        /// <summary>
        /// save category
        /// </summary>
        /// <param name="category"></param>
        void save(Category category);

        /// <summary>
        /// update category
        /// </summary>
        /// <param name="category"></param>
        void update(Category category);

        /// <summary>
        /// delete category
        /// </summary>
        /// <param name="category"></param>
        void delete(IEnumerable<DeletingCategory> categories);
    }
}
