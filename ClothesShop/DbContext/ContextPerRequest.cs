using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ClothesShop.Models;

namespace ClothesShop.DbContext
{
    /// <summary>
    /// manage DbContext per request
    /// </summary>
    public static class ContextPerRequest
    {
        /// <summary>
        /// DbContext will be save in HttpContext in key/value pair
        /// this field hosld the key to access value in HttpContext
        /// </summary>
        private const string key = "context";

        /// <summary>
        /// get model context for this request
        /// </summary>
        public static ModelContext ModelContext
        {
            get
            {
                //initialize model context if not exist in current request
                if (!HttpContext.Current.Items.Contains(key))
                {
                    HttpContext.Current.Items.Add(key, new ModelContext());
                }

                return HttpContext.Current.Items[key] as ModelContext;
            }
        }

        /// <summary>
        /// dispose model context on current request
        /// </summary>
        public static void Dispose()
        {
            try
            {
                ModelContext context = HttpContext.Current.Items[key] as ModelContext;

                if (context != null)
                {
                    context.Dispose();
                    HttpContext.Current.Items.Remove(key);
                }
            }
            catch (Exception)
            {                
                throw;
            }
        }
    }
}