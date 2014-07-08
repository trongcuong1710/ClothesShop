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
    /// product service interface
    /// </summary>
    public interface IProductService
    {
        /// <summary>
        /// get product
        /// </summary>
        /// <param name="count">
        /// optional parameter
        /// determine number of product to get
        /// get all when null
        /// </param>
        /// <returns></returns>
        IEnumerable<Product> getProduct(int? count = null);

        /// <summary>
        /// get product by category id
        /// </summary>
        /// <param name="CatID"></param>
        /// <returns></returns>
        IEnumerable<Product> getProductByCategory(int CatID);

        /// <summary>
        /// get product view model
        /// </summary>
        /// <returns></returns>
        IEnumerable<ProductViewModel> getProductViewModel();

        /// <summary>
        /// get product by ID
        /// </summary>
        /// <param name="ProID"></param>
        /// <returns></returns>
        Product getProduct(int ProID);

        /// <summary>
        /// save new product
        /// </summary>
        /// <param name="product"></param>
        void save(Product product);

        /// <summary>
        /// update products
        /// </summary>
        /// <param name="products"></param>
        void update(IEnumerable<ProductViewModel> products);

        /// <summary>
        /// update existed product
        /// </summary>
        /// <param name="product"></param>
        void update(Product product);

        /// <summary>
        /// delete products
        /// </summary>
        /// <param name="products"></param>
        void delete(IEnumerable<ProductViewModel> products);
    }
}
