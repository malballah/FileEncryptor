using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace FileEncryptor
{
    internal class Encryptor
    {
        private const int Iterations = 1042; // Recommendation is >= 1000

        public static void EncryptFile(string srcFilename, string destFilename,string skey)
        {
            var aes = new AesManaged();
            aes.BlockSize = aes.LegalBlockSizes[0].MaxSize;
            aes.KeySize = aes.LegalKeySizes[0].MaxSize;
            var salt = Encoding.ASCII.GetBytes(skey);
            var key = new Rfc2898DeriveBytes(string.Join("",skey.Reverse()), salt, Iterations);
            aes.Key = key.GetBytes(aes.KeySize / 8);
            aes.IV = key.GetBytes(aes.BlockSize / 8);
            aes.Mode = CipherMode.CBC;
            ICryptoTransform transform = aes.CreateEncryptor(aes.Key, aes.IV);
            using (var dest = new FileStream(destFilename, FileMode.CreateNew, FileAccess.Write, FileShare.None))
            {
                using (var cryptoStream = new CryptoStream(dest, transform, CryptoStreamMode.Write))
                {
                    using (var source = new FileStream(srcFilename, FileMode.Open, FileAccess.Read, FileShare.Read))
                    {
                        source.CopyTo(cryptoStream);
                    }
                }
            }
        }


        public static void DecryptFile(string srcFilename, string destFilename,string skey)
        {
            var aes = new AesManaged();
            aes.BlockSize = aes.LegalBlockSizes[0].MaxSize;
            aes.KeySize = aes.LegalKeySizes[0].MaxSize;
            var salt = Encoding.ASCII.GetBytes(skey);
            var key = new Rfc2898DeriveBytes(string.Join("", skey.Reverse()), salt, Iterations);
            aes.Key = key.GetBytes(aes.KeySize / 8);
            aes.IV = key.GetBytes(aes.BlockSize / 8);
            aes.Mode = CipherMode.CBC;
            ICryptoTransform transform = aes.CreateDecryptor(aes.Key, aes.IV);

            using (var dest = new FileStream(destFilename, FileMode.CreateNew, FileAccess.Write, FileShare.None))
            {
                using (var cryptoStream = new CryptoStream(dest, transform, CryptoStreamMode.Write))
                {
                    try
                    {
                        using (var source = new FileStream(srcFilename, FileMode.Open, FileAccess.Read, FileShare.Read))
                        {
                            source.CopyTo(cryptoStream);
                        }
                    }
                    catch (CryptographicException exception)
                    {
                        throw new ApplicationException("Decryption failed.", exception);
                    }
                }
            }
        }
    }
}