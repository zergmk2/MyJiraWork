using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WorkTracker.Utils
{
    public class CryptographyUtils
    {
        public static void EncryptFile(string sInputFilename,
        string sOutputFilename,
        string sKey)
        {
            if (File.Exists(sInputFilename))
            {
                using (var fsInput = new FileStream(sInputFilename, FileMode.Open, FileAccess.Read))
                {
                    using (var outStream = File.Create(sOutputFilename))
                    {
                        using (var cryptoStream = new CryptoStream(outStream, GetRijndael(sKey).CreateEncryptor(), CryptoStreamMode.Write))
                        {
                            byte[] bytearray = new byte[fsInput.Length];
                            fsInput.Read(bytearray, 0, bytearray.Length);
                            cryptoStream.Write(bytearray, 0, bytearray.Length);
                            cryptoStream.FlushFinalBlock();
                        }
                    }
                }
            }
        }

        public static void EncryptStreamtoFile(Stream inputStream,
              string sOutputFilename,
              string sKey)
        {
            inputStream.Position = 0;
            using (var outStream = File.Create(sOutputFilename))
            {
                using (var cryptoStream = new CryptoStream(outStream, GetRijndael(sKey).CreateEncryptor(), CryptoStreamMode.Write))
                {
                    byte[] bytearray = new byte[inputStream.Length];
                    inputStream.Read(bytearray, 0, bytearray.Length);
                    cryptoStream.Write(bytearray, 0, bytearray.Length);
                    cryptoStream.FlushFinalBlock();
                }
            }
        }

        public static void DecryptFile(string sInputFilename,
                    string sOutputFilename,
                    string sKey)
        {
            if (File.Exists(sInputFilename))
            {
                using (var inStream = File.OpenRead(sInputFilename))
                {
                    using (var outStream = File.Create(sOutputFilename))
                    {
                        using (var cryptoStream = new CryptoStream(inStream, GetRijndael(sKey).CreateDecryptor(), CryptoStreamMode.Read))
                        {
                            cryptoStream.CopyTo(outStream);
                            outStream.Flush();
                        }
                    }
                }
            }
        }

        public static void DecryptFiletoStream(string sInputFilename,
                    Stream OutputStream,
                    string sKey)
        {
            if (File.Exists(sInputFilename))
            {
                using (var inStream = File.OpenRead(sInputFilename))
                {
                    CryptoStream cryptostreamDecr = new CryptoStream(inStream,
                                                                 GetRijndael(sKey).CreateDecryptor(),
                                                                 CryptoStreamMode.Read);
                    cryptostreamDecr.CopyTo(OutputStream);
                    OutputStream.Flush();
                }
            }
        }

        private static DESCryptoServiceProvider CreateDESprovider(string sKey)
        {
            MD5 md5 = MD5.Create();
            byte[] key = CreateKey(GetMd5Hash(md5, sKey), 8);
            DESCryptoServiceProvider DES = new DESCryptoServiceProvider();
            DES.Key = key;
            DES.IV = key;
            return DES;
        }

        private static readonly byte[] Salt = new byte[] { 10, 20, 30, 40, 50, 60, 70, 80 };



        private static byte[] CreateKey(string password, int keyBytes = 32)
        {
            //const int Iterations = 300;
            //var keyGenerator = new Rfc2898DeriveBytes(password, Salt, Iterations);
            var keyGenerator = new Rfc2898DeriveBytes(password, Salt);
            return keyGenerator.GetBytes(keyBytes);
        }

        static string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        private static string SaltArray = "{E4E66F59-CAF2-4C39-A7F8-46097B1C461B}";
        private static Rijndael GetRijndael(string secret)
        {
            Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(secret, Encoding.UTF8.GetBytes(SaltArray), 10000);

            Rijndael alg = Rijndael.Create();
            alg.Key = pbkdf2.GetBytes(32);
            alg.IV = pbkdf2.GetBytes(16);

            return alg;
        }
    }
}
