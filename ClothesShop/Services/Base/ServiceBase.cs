using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothesShop.Services.Base
{
    /// <summary>
    /// service base class
    /// </summary>
    public class ServiceBase
    {
        /// <summary>
        /// transaction manager
        /// </summary>
        protected TransactionManager.TransactionManager transaction;

        /// <summary>
        /// constructor
        /// </summary>
        public ServiceBase()
        {
            this.transaction = TransactionManager.TransactionManager.Instance;
        }
    }
}