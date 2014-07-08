using ClothesShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClothesShop.DbContext;

namespace ClothesShop.Repository.Base
{
    /// <summary>
    /// repository base
    /// </summary>
    public class RepositoryBase
    {
        /// <summary>
        /// model context
        /// </summary>
        protected ModelContext context;

        /// <summary>
        /// constructor
        /// </summary>
        public RepositoryBase()
        {
            try
            {
                this.context = ContextPerRequest.ModelContext;
            }
            catch (Exception)
            {                
                throw;
            }
        }
    }
}