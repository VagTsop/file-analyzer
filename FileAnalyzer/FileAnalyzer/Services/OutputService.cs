using System.Collections.Generic;
using System.IO;
using System.Linq;

public class OutputService
{
    public static void CreateCsvFile(string outputPath, List<FileInformation> data)
    {
        using (StreamWriter writer = new StreamWriter(outputPath))
        {
            writer.WriteLine("FilePath,FileType,MD5Hash,FileSizeBytes,FileSizeKilobytes,FileSizeMegabytes,LastModifiedTimestamp");

            foreach (FileInformation info in data)
            {
                writer.WriteLine($"{info.FilePath},{info.FileType},{info.Md5Hash},{info.FileSizeBytes},{info.FileSizeKilobytes},{info.FileSizeMegabytes},{info.LastModifiedTimestamp}");
            }

            // Calculate and include summary statistics
            long totalSizeBytes = data.Sum(f => f.FileSizeBytes);
            double totalSizeKilobytes = data.Sum(f => f.FileSizeKilobytes);
            double totalSizeMegabytes = data.Sum(f => f.FileSizeMegabytes);

            writer.WriteLine(); // Blank line
            writer.WriteLine("Summary Statistics");
            writer.WriteLine($"Total Number of Files Analyzed: {data.Count}");
            writer.WriteLine($"Total Size of All Files (Bytes): {totalSizeBytes}");
            writer.WriteLine($"Total Size of All Files (Kilobytes): {totalSizeKilobytes:N2} KB");
            writer.WriteLine($"Total Size of All Files (Megabytes): {totalSizeMegabytes:N2} MB");
        }
    }
}