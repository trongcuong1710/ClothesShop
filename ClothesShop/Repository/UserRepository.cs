using ClothesShop.Models;
using ClothesShop.Repository.Base;
using ClothesShop.Repository.Interface;
using ClothesShop.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothesShop.Repository
{
    /// <summary>
    /// user repository
    /// </summary>
    public class UserRepository : RepositoryBase, IUserRepository
    {
        /// <summary>
        /// constructor
        /// </summary>
        public UserRepository()
            : base()
        {
        }

        /// <summary>
        /// get all user
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Models.User> getUser()
        {
            try
            {
                return from user in this.context.User
                       select user;
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
                return this.context.User.Find(UserID);
            }
            catch (Exception)
            {                
                throw;
            }
        }

        /// <summary>
        /// get user by login name and password
        /// </summary>
        /// <param name="LoginName"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public Models.User getUser(string LoginName, string Password)
        {
            try
            {
                User user = (from item in this.context.User
                             where item.LoginName == LoginName && item.Password == Password
                             select item).FirstOrDefault();

                return user;
            }
            catch (Exception)
            {                
                throw;
            }
        }

        /// <summary>
        /// save new user
        /// </summary>
        /// <param name="user"></param>
        public void save(Models.User user)
        {
            try
            {
                if (user == null)
                {
                    throw new ArgumentNullException();
                }

                user.Password = CryptoUti.Encrypt(user.Password);
                this.context.User.Add(user);
                this.context.SaveChanges();
            }
            catch (Exception)
            {                
                throw;
            }
        }

        /// <summary>
        /// delete user
        /// </summary>
        /// <param name="user"></param>
        public void delete(Models.User user)
        {
            try
            {
                if (user == null)
                {
                    throw new ArgumentNullException();
                }

                this.context.User.Remove(user);
                this.context.SaveChanges();
            }
            catch (Exception)
            {                
                throw;
            }
        }
    }
}