using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataStreaming.utils
{
    public class MD5Checksum
    {

        // File MD5 Hash methods 
        public static string GetMD5Hash(string pathName)
        {
            string strResult = "";
            string strHashData = "";

            byte[] arrbytHashValue;
            System.IO.FileStream oFileStream = null;

            System.Security.Cryptography.MD5CryptoServiceProvider oMD5Hasher =
                       new System.Security.Cryptography.MD5CryptoServiceProvider();

            try
            {
                oFileStream = GetFileStream(pathName);
                arrbytHashValue = oMD5Hasher.ComputeHash(oFileStream);
                oFileStream.Close();

                strHashData = System.BitConverter.ToString(arrbytHashValue);
                strHashData = strHashData.Replace("-", "");
                strResult = strHashData;
            }
            catch (System.Exception ex)
            {
               
            }

            return (strResult);
        }
        private static System.IO.FileStream GetFileStream(string pathName)
        {
            return (new System.IO.FileStream(pathName, System.IO.FileMode.Open,
                      System.IO.FileAccess.Read, System.IO.FileShare.ReadWrite));
        }
        public static string GetMD5HashFromFile(Stream file)
        {
            byte[] retVal = { };

            //using (FileStream file = new FileStream(fileName, FileMode.Open))
            using (MD5 md5 = new MD5CryptoServiceProvider())
            {
                retVal = md5.ComputeHash(file);
            }

            if (retVal.Length > 0)
            {
                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < retVal.Length; i++)
                {
                    sb.Append(retVal[i].ToString("x2"));
                }

                return sb.ToString();
            }
            else
            {
                return string.Empty;
            }
        }
       
        // String MD5 Hash methods
        public static string StringMD5Hash(string input, int valueLength = 32)
        {
            byte[] b = new System.Security.Cryptography.MD5CryptoServiceProvider().ComputeHash(UnicodeEncoding.UTF8.GetBytes(input));
            return Convert.ToBase64String(b.Take(valueLength).ToArray());
        }
    }
}
