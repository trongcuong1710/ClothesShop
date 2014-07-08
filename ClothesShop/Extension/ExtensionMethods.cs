using ClothesShop.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity.Infrastructure;
using System.Data.Objects;
using System.Linq;
using System.Web;

namespace ClothesShop
{
    /// <summary>
    /// custom extension method
    /// </summary>
    public static class ExtensionMethods
    {
        /// <summary>
        /// begin transaction on model context
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static DbTransaction BeginTransaction(this ModelContext context)
        {
            try
            {
                ObjectContext objContext = ((IObjectContextAdapter) context).ObjectContext;

                if (objContext.Connection.State != System.Data.ConnectionState.Open)
                {
                    objContext.Connection.Open();
                }

                return objContext.Connection.BeginTransaction();
            }
            catch (Exception)
            {                
                throw;
            }
        }
    }
}