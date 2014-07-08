using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClothesShop.Models;
using ClothesShop.DbContext;
using System.Data.Objects;
using System.Data.Common;
using System.Data.Entity.Infrastructure;

namespace ClothesShop.TransactionManager
{
    /// <summary>
    /// manage request transaction
    /// singleton per request
    /// </summary>
    public class TransactionManager : IDisposable 
    {
        /// <summary>
        /// static instance to implement singleton
        /// </summary>
        private static TransactionManager instance = new TransactionManager();

        /// <summary>
        /// model context
        /// </summary>
        private ObjectContext context;

        /// <summary>
        /// transaction on current context
        /// </summary>
        private DbTransaction transaction;

        /// <summary>
        /// static instance to implement singleton
        /// </summary>
        public static TransactionManager Instance
        {
            get 
            { 
                return TransactionManager.instance; 
            }            
        }

        /// <summary>
        /// private constructor
        /// </summary>
        private TransactionManager()
        {
            try
            {
                this.context = ((IObjectContextAdapter)ContextPerRequest.ModelContext).ObjectContext;
            }
            catch (Exception)
            {                
                throw;
            }
        }

        /// <summary>
        /// begin transaction on current context
        /// </summary>
        public void BeginTransaction()
        {
            try
            {
                //open connection
                if (this.context.Connection.State == System.Data.ConnectionState.Closed)
                {
                    this.context.Connection.Open();
                }

                //throw exception if current transaction is active
                if (this.transaction != null)
                {
                    throw new InvalidOperationException();
                }

                this.transaction = this.context.Connection.BeginTransaction();
            }
            catch (Exception)
            {                
                throw;
            }
        }

        /// <summary>
        /// commit current transaction
        /// </summary>
        public void CommitTransaction()
        {
            try
            {                
                //throw exception if current transaction is not active
                if (this.transaction == null)
                {
                    throw new InvalidOperationException();
                }

                this.transaction.Commit();
                this.transaction.Dispose();
            }
            catch (Exception)
            {
                //roll back transaction if error occur
                this.RollBackTransaction();
            }
        }

        /// <summary>
        /// roll back transaction
        /// </summary>
        public void RollBackTransaction()
        {
            try
            {
                if (this.transaction == null)
                {
                    throw new InvalidOperationException();
                }

                this.transaction.Rollback();
                this.transaction.Dispose();
            }
            catch (Exception)
            {                
                throw;
            }
        }

        /// <summary>
        /// dispose current object
        /// </summary>
        public void Dispose()
        {
            try
            {
                //roll back transaction if it's active
                if (this.transaction != null)
                {
                    this.transaction = null;
                }
            }
            catch (Exception)
            {                
                throw;
            }           
        }
    }
}