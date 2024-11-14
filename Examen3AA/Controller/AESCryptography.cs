using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Linq;
using System.IO;
using System.Web;

namespace Examen3AA.Controller
{
    public class AESCryptography
    {
        private static readonly string encryptionKey = "YourKey123456789"; // 16 caracteres para AES-128

        public string Decrypt(string encryptedText)
        {
            byte[] combinedBytes = Convert.FromBase64String(encryptedText);  // Convertir la cadena Base64 en bytes
            byte[] keyBytes = Encoding.UTF8.GetBytes(encryptionKey);  // Convertir la clave en bytes

            // Verificación del tamaño de la clave
            if (keyBytes.Length != 16 && keyBytes.Length != 32)
            {
                throw new ArgumentException("La clave debe tener 16 o 32 caracteres.");
            }

            using (Aes aes = Aes.Create())
            {
                aes.Key = keyBytes;
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

                // Extraer el IV de los primeros 16 bytes
                byte[] iv = new byte[16];
                Array.Copy(combinedBytes, 0, iv, 0, iv.Length);  // Copiar el IV desde la cadena encriptada
                aes.IV = iv;

                // Extraer los datos encriptados (después del IV)
                byte[] encryptedBytes = new byte[combinedBytes.Length - iv.Length];
                Array.Copy(combinedBytes, iv.Length, encryptedBytes, 0, encryptedBytes.Length);  // Extraer los datos encriptados

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(encryptedBytes, 0, encryptedBytes.Length);  // Escribir los datos encriptados en el stream
                        cryptoStream.FlushFinalBlock();
                        return Encoding.UTF8.GetString(ms.ToArray());  // Devolver la cadena desencriptada
                    }
                }
            }
        }
    }
}