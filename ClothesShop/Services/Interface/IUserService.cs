using ClothesShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClothesShop.Services.Interface
{
    /// <summary>
    /// user service
    /// </summary>
    public interface IUserService
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
        /// check login
        /// </summary>
        /// <param name="LoginName"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        bool Login(string LoginName, string Password);

        /// <summary>
        /// create user
        /// </summary>
        /// <param name="user"></param>
        void Create(User user);

        /// <summary>
        /// delete user
        /// </summary>
        /// <param name="user"></param>
        void Delete(User user);
    }
}
