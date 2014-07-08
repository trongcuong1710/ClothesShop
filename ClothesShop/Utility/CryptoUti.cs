using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace ClothesShop.Utility
{
    /// <summary>
    /// ultility to encrypt and decrypt message
    /// </summary>
    public static class CryptoUti
    {
        /// <summary>
        /// key to encrypt or decrypt message
        /// </summary>
        public const string key = "5259E7892C4A4FB38080E7BFC19D039E";

        /// <summary>
        /// initialize vector
        /// </summary>
        public const string IV = "82A253A03DDB4310";

        /// <summary>
        /// encrypt message
        /// </summary>
        /// <param name="plainText"></param>
        /// <returns></returns>
        public static string Encrypt(string plainText)
        {
            try
            {
                if (string.IsNullOrEmpty(plainText) || string.IsNullOrWhiteSpace(plainText))
                {
                    throw new ArgumentNullException();
                }

                byte[] keyBytes = Encoding.ASCII.GetBytes(key);
                byte[] IVBytes = Encoding.ASCII.GetBytes(IV);

                string encrypted = "";

                using (RijndaelManaged manage = new RijndaelManaged())
                {
                    manage.IV = IVBytes;
                    manage.Key = keyBytes;

                    //create crypto transform
                    ICryptoTransform transform = manage.CreateEncryptor(manage.Key, manage.IV);

                    using (MemoryStream memStream = new MemoryStream())
                    {
                        using (CryptoStream crypStream = new CryptoStream(memStream, transform, CryptoStreamMode.Write))
                        {
                            using (StreamWriter writer = new StreamWriter(crypStream))
                            {
                                writer.Write(plainText);
                            }

                            encrypted = Convert.ToBase64String(memStream.ToArray());
                        }
                    }
                }

                return encrypted;
            }
            catch (Exception)
            {                
                throw;
            }
        }

        /// <summary>
        /// decrypt message
        /// </summary>
        /// <param name="cipherText"></param>
        /// <returns></returns>
        public static string Decrypt(string cipherText)
        {
            try
            {
                if (string.IsNullOrEmpty(cipherText) || string.IsNullOrWhiteSpace(cipherText))
                {
                    throw new ArgumentNullException();
                }

                byte[] keyBytes = Encoding.ASCII.GetBytes(key);
                byte[] IVBytes = Encoding.ASCII.GetBytes(IV);
                byte[] cipherBytes = Convert.FromBase64String(cipherText);
                string plainText = "";

                using (RijndaelManaged manage = new RijndaelManaged())
                {
                    manage.Key = keyBytes;
                    manage.IV = IVBytes;

                    ICryptoTransform transform = manage.CreateDecryptor(manage.Key, manage.IV);

                    using (MemoryStream memStream = new MemoryStream(cipherBytes))
                    {
                        using (CryptoStream cryptStream = new CryptoStream(memStream, transform, CryptoStreamMode.Read))
                        {
                            using (StreamReader reader = new StreamReader(cryptStream))
                            {
                                plainText = reader.ReadToEnd();
                            }
                        }
                    }
                }

                return plainText;
            }
            catch (Exception)
            {                
                throw;
            }
        }
    }
}