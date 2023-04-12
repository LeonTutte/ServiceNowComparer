using System.Security.Cryptography;
using System.Text;

using Org.BouncyCastle.Security;

namespace ServiceNowComparerLibrary.Modules.Static
{
    public static class CryptoModule
    {
        private static string? _storagePassword;
        public static string? StoragePassword
        {
            /// <summary>
            /// Checks if the Storagepassword is already set.
            /// If not it will return the default 000000 string.
            /// </summary>
            /// <value></value>
            /// <returns>string</returns>
            get
            { 
                if (String.IsNullOrEmpty(_storagePassword)) return "000000";
                if (String.IsNullOrWhiteSpace(_storagePassword)) return "000000";
                return _storagePassword;
            }
            set { _storagePassword = value;}
        }

        public static string CreateSHA512(string strData)
        {
            var message = Encoding.UTF8.GetBytes(strData);
            using var alg = SHA512.Create();

            var hashValue = alg.ComputeHash(message);
            return hashValue.Aggregate("", (current, x) => current + $"{x:x2}");
        }

        public static string CreateStoragePassword()
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < 4; i++)
            {
                builder.Append(RandomString(6, true));
                builder.Append(new SecureRandom().Next(1000, 9999));
                builder.Append(RandomString(2, false));
            }
            return builder.ToString();
        }

        /// <summary>
        /// Generate a random string with a given size and case.
        /// If second parameter is true, the return string is lowercase
        /// </summary>
        /// <param name="size">The final string size in characters</param>
        /// <param name="lowerCase">Set true if you want a full lower case string</param>
        /// <returns>string</returns>
        private static string RandomString(int size, bool lowerCase = false)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new SecureRandom();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase) return builder.ToString().ToLower();
            return builder.ToString();
        }
    }
}