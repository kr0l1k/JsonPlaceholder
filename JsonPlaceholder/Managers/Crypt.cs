﻿using JsonPlaceholder.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace JsonPlaceholder.Managers
{
    public static class Crypt
    {
        private const string INIT_VECTOR = "pfobnf1jn4lt,bkf";
        private const int KEY_SIZE = 256;
        //Encrypt
        public static string EncryptString(string plainText, string passPhrase)
        {
            byte[] initVectorBytes = Encoding.UTF8.GetBytes(INIT_VECTOR);
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, null);
            byte[] keyBytes = password.GetBytes(KEY_SIZE / 8);
            RijndaelManaged symmetricKey = new RijndaelManaged();
            symmetricKey.Mode = CipherMode.CBC;
            ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes);
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
            cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
            cryptoStream.FlushFinalBlock();
            byte[] cipherTextBytes = memoryStream.ToArray();
            memoryStream.Close();
            cryptoStream.Close();
            return Convert.ToBase64String(cipherTextBytes);
        }
        //Decrypt
        public static string DecryptString(string cipherText, string passPhrase)
        {
            byte[] initVectorBytes = Encoding.UTF8.GetBytes(INIT_VECTOR);
            byte[] cipherTextBytes = Convert.FromBase64String(cipherText);
            PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, null);
            byte[] keyBytes = password.GetBytes(KEY_SIZE / 8);
            RijndaelManaged symmetricKey = new RijndaelManaged();
            symmetricKey.Mode = CipherMode.CBC;
            ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes);
            MemoryStream memoryStream = new MemoryStream(cipherTextBytes);
            CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
            byte[] plainTextBytes = new byte[cipherTextBytes.Length];
            int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
            memoryStream.Close();
            cryptoStream.Close();
            return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
        }

        /// <summary>
        /// Encrypt Emails for Users collection
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        public static List<User> EncryptUsers(ref List<User> users)
        {
            for (int i = 0; i < users.Count; i++)
            {
                users[i].Email = Crypt.EncryptString(users[i].Email, users[i].Name + users[i].Phone.GetHashCode());
            }
            return users;
        }

        /// <summary>
        /// Encrypt user email
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static User EncryptUser(ref User user)
        {
            user.Email = Crypt.EncryptString(user.Email, user.Name + user.Phone.GetHashCode());
            return user;
        }

        /// <summary>
        /// Decrypt emails for Users collection
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        public static List<User> DecryptUsers(ref List<User> users)
        {
            for (int i = 0; i < users.Count; i++)
            {
                users[i].Email = Crypt.DecryptString(users[i].Email, users[i].Name + users[i].Phone.GetHashCode());
            }
            return users;
        }

        /// <summary>
        /// Decrypt user email
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static User DecryptUser(ref User user)
        {
            user.Email = Crypt.DecryptString(user.Email, user.Name + user.Phone.GetHashCode());
            return user;
        }
    }
}
