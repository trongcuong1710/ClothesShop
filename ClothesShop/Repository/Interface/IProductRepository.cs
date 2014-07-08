using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClothesShop.Models;

namespace ClothesShop.Repository.Interface
{
    /// <summary>
    /// product repository's interface
    /// </summary>
    public interface IProductRepository
    {
        /// <summary>
        /// get all product
        /// </summary>
        /// <returns></returns>
        IEnumerable<Product> getProduct();

        /// <summary>
        /// get product by category
        /// </summary>
        /// <param name="CatID"></param>
        /// <returns></returns>
        IEnumerable<Product> getProductByCategory(int CatID);

        /// <summary>
        /// get latest product
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        IEnumerable<Product> getLatestProduct(int count);

        /// <summary>
        /// get product by id
        /// </summary>
        /// <param name="ProID"></param>
        /// <returns></returns>
        Product getProduct(int ProID);

        /// <summary>
        /// save product
        /// </summary>
        /// <param name="product"></param>
        void save(Product product);

        /// <summary>
        /// update existed product
        /// </summary>
        /// <param name="product"></param>
        void update(Product product);

        /// <summary>
        /// delete product
        /// </summary>
        /// <param name="product"></param>
        void delete(Product product);
    }
}
