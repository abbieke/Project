using Project.Repository;
using Project.Repository.Models;
using Project.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Project.Service
{
    /// <summary>
    /// 會員服務
    /// </summary>
    public class MemberService : IMemberService
    {
        /// <summary>
        /// 會員儲存庫
        /// </summary>
        private readonly IMemberRepository MemberRepository;

        /// <summary>
        /// 建構子
        /// </summary>
        /// <param name="memberRepository">會員儲存庫</param>
        public MemberService(IMemberRepository memberRepository)
        {
            this.MemberRepository = memberRepository;
        }

        /// <summary>
        /// 會員登入
        /// </summary>
        /// <param name="login">登入 ViewModel</param>
        /// <returns>帳密是否正確</returns>
        public (bool, int?) Login(LoginViewModel login)
        {
            MemberQueryBuilder builder = new MemberQueryBuilder();
            string sql = builder.GetCheckMemberLoginSql();

            login.Phone = this.Encrypt(login.Phone, this.SecurityKey1());
            login.Password = this.Encrypt(login.Password, this.SecurityKey1());

            List<Member> members = this.MemberRepository.Query<Member>(sql, new { Phone = login.Phone, Password = login.Password }).ToList();

            if (members == null || members.Count == 0 || members.Count > 1)
            {
                return (false, null);
            }

            return (true, members.First().Id);
        }

        /// <summary>
        /// AES金鑰
        /// </summary>
        protected string SecurityKey1() 
        {
            return System.Web.Configuration.WebConfigurationManager.AppSettings["securityKey1"];
        }

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="content">欲加密字串</param>
        /// <param name="key">金鑰</param>
        /// <returns></returns>
        private string Encrypt(string content, string key)
        {
            MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();

            // 金鑰用UTF8格式再用MD5計算Hash
            byte[] keyArray = md5Hasher.ComputeHash(Encoding.UTF8.GetBytes(key));

            // IV預設16 byte都是0
            byte[] initializationVector = new byte[16];

            // 先將內容轉為UTF8格式
            byte[] encryptionContent = UTF8Encoding.UTF8.GetBytes(content);

            // RijndaelManaged：.Net的常用AES加解密模組
            RijndaelManaged rijndaelManaged = new RijndaelManaged
            {
                Key = keyArray, // 設定金鑰
                IV = initializationVector, // 設定IV
                Mode = CipherMode.CBC, // 使用CBC模式
                Padding = PaddingMode.PKCS7 // Padding用PKCS7,註Java是PKCS5
            };

            // 使用RijndaelManaged的加密模組
            ICryptoTransform cryptoTransform = rijndaelManaged.CreateEncryptor(rijndaelManaged.Key, rijndaelManaged.IV);
            byte[] resultArray = cryptoTransform.TransformFinalBlock(encryptionContent, 0, encryptionContent.Length);

            // 最後用Base64加密
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="content">欲解密字串</param>
        /// <param name="key">金鑰</param>
        /// <returns></returns>
        private string Decrypt(string content, string key)
        {
            MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();

            // 金鑰用UTF8格式再用MD5計算Hash
            byte[] keyArray = md5Hasher.ComputeHash(Encoding.UTF8.GetBytes(key));

            // IV預設16 byte都是0
            byte[] initializationVector = new byte[16];

            // 密文用Base64解密
            byte[] base64DecryptionContent = Convert.FromBase64String(content);

            // RijndaelManaged：.Net的常用AE加S解密模組
            RijndaelManaged rijndaelManaged = new RijndaelManaged
            {
                Key = keyArray, // 設定金鑰
                IV = initializationVector, // 設定IV
                Mode = CipherMode.CBC, // 使用CBC模式
                Padding = PaddingMode.PKCS7 // Padding用PKCS7,註Java是PKCS5
            };

            // 使用RijndaelManaged的解密模組
            ICryptoTransform cryptoTransform = rijndaelManaged.CreateDecryptor(rijndaelManaged.Key, rijndaelManaged.IV);
            byte[] resultArray = cryptoTransform.TransformFinalBlock(base64DecryptionContent, 0, base64DecryptionContent.Length);

            return UTF8Encoding.UTF8.GetString(resultArray);
        }
    }
}