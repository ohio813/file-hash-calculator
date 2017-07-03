using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace FileHashCalculator
{
    class Utilities
    {
        public static string Md5Hash(string fileName)
        {
            using (MD5 md5 = new MD5CryptoServiceProvider())
            {
                using (FileStream file = new FileStream(fileName, FileMode.Open))
                {
                    byte[] retVal = md5.ComputeHash(file);
                    return BitConverter.ToString(retVal).Replace("-", ""); // hex string
                }
            }
        }
    }
}
