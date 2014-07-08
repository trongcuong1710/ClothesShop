using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClothesShop.Models;

namespace ClothesShop.Repository.Interface
{
    /// <summary>
    /// category repository interface
    /// </summary>
    public interface ICategoryRepository
    {
        /// <summary>
        /// get all categories
        /// </summary>
        /// <returns></returns>
        IEnumerable<Category> getCategory();

        /// <summary>
        /// get category by ID
        /// </summary>
        /// <param name="CatID"></param>
        /// <returns></returns>
        Category getCategory(int CatID);

        /// <summary>
        /// save category
        /// </summary>
        /// <param name="category"></param>
        void Save(Category category);

        /// <summary>
        /// delete category
        /// </summary>
        /// <param name="category"></param>
        void Delete(Category category);

        /// <summary>
        /// update category
        /// </summary>
        /// <param name="category"></param>
        void Update(Category category);
    }
}
