using System;
using System.Security.Cryptography;
using System.Text;

namespace OGE_Tests
{
    class Encryptor
    {
        private static string seal = "code";

        public static string GetHash(string str)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                return GetMd5Hash(md5Hash, str);
            }
        }

        private static string GetStrWithSeal(string str)
        {
            return seal + str + seal;
        }

        public bool VerifyHash(string input, string hash)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                return VerifyMd5Hash(md5Hash, GetStrWithSeal(input), hash);
            }
        }

        private static string GetMd5Hash(MD5 md5Hash, string input)
        {
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }

        private static bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
        {
            string hashOfInput = GetMd5Hash(md5Hash, input);
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
