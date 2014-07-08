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
    /// product service
    /// </summary>
    public class ProductService : ServiceBase, IProductService
    {
        /// <summary>
        /// product repository
        /// </summary>
        private IProductRepository repository;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="repository">
        /// will be populated by ninject
        /// </param>
        public ProductService(IProductRepository repository)
            : base()
        {
            this.repository = repository;
        }

        /// <summary>
        /// get product
        /// </summary>
        /// <param name="count">
        /// optional parameter
        /// determine number of product to get
        /// get all when null
        /// </param>
        /// <returns></returns>
        public IEnumerable<Models.Product> getProduct(int? count = null)
        {
            try
            {
                if (!count.HasValue)
                {
                    return this.repository.getProduct();
                }
                else
                {
                    return this.repository.getLatestProduct(count.Value);
                }
            }
            catch (Exception)
            {                
                throw;
            }
        }

        /// <summary>
        /// get product by category
        /// </summary>
        /// <param name="CatID"></param>
        /// <returns></returns>
        public IEnumerable<Models.Product> getProductByCategory(int CatID)
        {
            try
            {
                return this.repository.getProductByCategory(CatID);
            }
            catch (Exception)
            {                
                throw;
            }
        }

        /// <summary>
        /// get product view model
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ViewModel.ProductViewModel> getProductViewModel()
        {
            try
            {
                IEnumerable<Product> products = this.getProduct();

                IEnumerable<ProductViewModel> viewmodel = from product in products
                                                          select new ProductViewModel()
                                                          {
                                                              Category = product.Category.CatName,
                                                              Code = product.ProductCode,
                                                              IsDelete = false,
                                                              Name = product.ProductName,
                                                              ProID = product.ProductID,
                                                              PromotionID = product.ProID
                                                          };

                return viewmodel;
            }
            catch (Exception)
            {                
                throw;
            }
        }

        /// <summary>
        /// get product by id
        /// </summary>
        /// <param name="ProID"></param>
        /// <returns></returns>
        public Models.Product getProduct(int ProID)
        {
            try
            {
                return this.repository.getProduct(ProID);
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
        public void save(Models.Product product)
        {
            try
            {
                //begin transaction on current db context
                this.transaction.BeginTransaction();

                this.repository.save(product);

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
        /// update product
        /// </summary>
        /// <param name="products"></param>
        public void update(IEnumerable<ProductViewModel> products)
        {
            try
            {
                //begin transaction on current db context
                this.transaction.BeginTransaction();

                products.ToList().ForEach(item =>
                    {
                        Product product = this.getProduct(item.ProID);
                        product.ProID = item.PromotionID;

                        this.repository.update(product);
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

        /// <summary>
        /// update existed product
        /// </summary>
        /// <param name="product"></param>
        public void update(Models.Product product)
        {
            try
            {
                //begin transaction on current db context
                this.transaction.BeginTransaction();

                this.repository.update(product);

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
        /// delete procduct
        /// </summary>
        /// <param name="products"></param>
        public void delete(IEnumerable<ViewModel.ProductViewModel> products)
        {
            try
            {
                //begin transaction on current db context
                this.transaction.BeginTransaction();

                products.Where(product => product.IsDelete).ToList()
                    .ForEach(product =>
                    {
                        Product deleted = this.getProduct(product.ProID);
                        this.repository.delete(deleted);
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