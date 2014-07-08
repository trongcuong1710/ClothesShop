using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClothesShop.Models;
using ClothesShop.Repository.Base;
using ClothesShop.Repository.Interface;

namespace ClothesShop.Repository
{
    /// <summary>
    /// product repository
    /// </summary>
    public class ProductRepository  : RepositoryBase, IProductRepository
    {
        /// <summary>
        /// constructor
        /// </summary>
        public ProductRepository()
            : base()
        {
        }

        /// <summary>
        /// get all product
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Product> getProduct()
        {
            try
            {
                var products = from product in this.context.Product
                               orderby product.CreateDate descending
                               select product;

                return products;
            }
            catch (Exception)
            {                
                throw;
            }
        }

        /// <summary>
        /// get products for a category
        /// </summary>
        /// <param name="CatID"></param>
        /// <returns></returns>
        public IEnumerable<Product> getProductByCategory(int CatID)
        {
            try
            {
                var products = from product in this.context.Product
                               where product.CatID == CatID
                               orderby product.CreateDate descending
                               select product;

                return products;
            }
            catch (Exception)
            {                
                throw;
            }
        }

        /// <summary>
        /// get latest product
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public IEnumerable<Product> getLatestProduct(int count)
        {
            try
            {
                var products = this.getProduct();

                return products.Take(count);
            }
            catch (Exception)
            {                
                throw;
            }
        }

        /// <summary>
        /// get product by product id
        /// </summary>
        /// <param name="ProID"></param>
        /// <returns></returns>
        Product IProductRepository.getProduct(int ProID)
        {
            try
            {
                var product = this.context.Product.Find(ProID);

                return product;
            }
            catch (Exception)
            {                
                throw;
            }
        }

        /// <summary>
        /// save new product
        /// </summary>
        /// <param name="product"></param>
        public void save(Product product)
        {
            try
            {
                if (product == null)
                {
                    throw new ArgumentNullException();
                }

                this.context.Product.Add(product);
                this.context.SaveChanges();
            }
            catch (Exception)
            {                
                throw;
            }
        }

        /// <summary>
        /// update existed product
        /// </summary>
        /// <param name="product"></param>
        public void update(Product product)
        {
            try
            {
                if (product == null)
                {
                    throw new ArgumentNullException();
                }

                this.context.Entry(product).State = System.Data.EntityState.Modified;
                this.context.SaveChanges();
            }
            catch (Exception)
            {                
                throw;
            }
        }

        /// <summary>
        /// delete product
        /// </summary>
        /// <param name="product"></param>
        public void delete(Product product)
        {
            try
            {
                if (product == null)
                {
                    throw new ArgumentNullException();
                }

                this.context.Product.Remove(product);
                this.context.SaveChanges();
            }
            catch (Exception)
            {                
                throw;
            }
        }
    }
}