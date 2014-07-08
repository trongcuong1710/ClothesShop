using ClothesShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClothesShop.Repository.Interface
{
    /// <summary>
    /// user repository interface
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// get all user
        /// </summary>
        /// <returns></returns>
        IEnumerable<User> getUser();

        /// <summary>
        /// get user by id
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        User getUser(int UserID);

        /// <summary>
        /// get user by login name and password
        /// </summary>
        /// <param name="LoginName"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        User getUser(string LoginName, string Password);

        /// <summary>
        /// save new user
        /// </summary>
        /// <param name="user"></param>
        void save(User user);

        /// <summary>
        /// delete user
        /// </summary>
        /// <param name="user"></param>
        void delete(User user);
    }
}
