using ClothesShop.Models;
using ClothesShop.Repository.Interface;
using ClothesShop.Services.Base;
using ClothesShop.Services.Interface;
using ClothesShop.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothesShop.Services
{
    /// <summary>
    /// user service
    /// </summary>
    public class UserService : ServiceBase, IUserService
    {
        /// <summary>
        /// user rpository
        /// </summary>
        private IUserRepository repository;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="repository">
        /// will be populate by ninject
        /// </param>
        public UserService(IUserRepository repository)
            : base()
        {
            this.repository = repository;
        }

        /// <summary>
        /// get all user
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Models.User> getUser()
        {
            try
            {
                return this.repository.getUser();
            }
            catch (Exception)
            {                
                throw;
            }
        }

        /// <summary>
        /// get user by id
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public Models.User getUser(int UserID)
        {
            try
            {
                return this.repository.getUser(UserID);
            }
            catch (Exception)
            {                
                throw;
            }
        }

        /// <summary>
        /// check login
        /// </summary>
        /// <param name="LoginName"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public bool Login(string LoginName, string Password)
        {
            try
            {
                User user = this.repository.getUser(LoginName, CryptoUti.Encrypt(Password));

                return user != null;
            }
            catch (Exception)
            {                
                throw;
            }
        }

        /// <summary>
        /// create new user
        /// </summary>
        /// <param name="user"></param>
        public void Create(Models.User user)
        {
            try
            {
                this.repository.save(user);
            }
            catch (Exception)
            {                
                throw;
            }
        }

        /// <summary>
        /// delete existed user
        /// </summary>
        /// <param name="user"></param>
        public void Delete(Models.User user)
        {
            try
            {
                this.repository.delete(user);
            }
            catch (Exception)
            {                
                throw;
            }
        }
    }
}