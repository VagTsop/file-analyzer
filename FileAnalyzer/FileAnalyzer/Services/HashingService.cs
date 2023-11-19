using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

public class HashingService
{
    public static string CalculateMd5Hash(string filePath)
    {
        using (MD5 md5 = MD5.Create())
        using (FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
        {
            byte[] hashBytes;

            try
            {
                hashBytes = md5.ComputeHash(stream);
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine($"Error: The directory containing '{filePath}' does not exist.");
                return string.Empty;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error calculating MD5 hash for '{filePath}'. {ex.Message}");
                return string.Empty;
            }

            StringBuilder sb = new StringBuilder();

            foreach (byte b in hashBytes)
            {
                sb.Append(b.ToString("x2"));
            }

            return sb.ToString();
        }
    }
}
