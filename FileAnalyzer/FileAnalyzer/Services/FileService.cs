using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

public class FileService
{
    public static List<string> GetFilesToProcess(string directory, bool includeSubdirectories)
    {
        SearchOption searchOption = includeSubdirectories ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;
        List<string> files = new List<string>();

        try
        {
            if (Directory.Exists(directory)) // Check if the directory exists
            {
                files = Directory.GetFiles(directory, "*", searchOption).ToList();
            }
            else
            {
                Console.WriteLine($"Warning: Directory '{directory}' does not exist. No files will be processed from this directory.");
            }
        }
        catch (UnauthorizedAccessException ex)
        {
            Console.WriteLine($"Error: Access to directory '{directory}' is denied. {ex.Message}");
            // Continue processing other directories or files
        }
        catch (DirectoryNotFoundException ex)
        {
            Console.WriteLine($"Error: Directory '{directory}' not found. {ex.Message}");
            // Continue processing other directories or files
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: An unexpected error occurred while retrieving files. {ex.Message}");
            // Continue processing other directories or files
        }

        return files;
    }

    public static List<FileInformation> ProcessFiles(List<string> files, string sortBy)
    {
        List<FileInformation> processedFiles = new List<FileInformation>();

        int totalCount = files.Count;
        int currentCount = 0;

        Parallel.ForEach(files, file =>
        {
            if (File.Exists(file)) // Check if the file exists
            {
                string ext = Path.GetExtension(file);

                FileInfo fileInfo = new FileInfo(file);

                processedFiles.Add(new FileInformation
                {
                    FilePath = file,
                    FileType = !string.IsNullOrEmpty(ext) ? ext.Substring(1) : "Unknown",
                    Md5Hash = HashingService.CalculateMd5Hash(file),
                    FileSizeBytes = fileInfo.Length,
                    FileSizeKilobytes = fileInfo.Length / 1024.0,
                    FileSizeMegabytes = fileInfo.Length / 1024.0 / 1024.0,
                    LastModifiedTimestamp = fileInfo.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss")
                });
            }
            else
            {
                Console.WriteLine($"Warning: File '{file}' does not exist. Skipping this file.");
            }

            int count = Interlocked.Increment(ref currentCount);
            DisplayProgress(count, totalCount);
        });

        // Check if any files were processed before attempting to sort
        if (processedFiles != null && processedFiles.Any())
        {
            // Sort the processedFiles based on the user-specified sortBy criteria.
            switch (sortBy.ToLower())
            {
                case "filesize":
                    processedFiles = processedFiles.OrderBy(f => f.FileSizeBytes).ToList();
                    break;
                case "filetype":
                    processedFiles = processedFiles.OrderBy(f => f.FileType ?? "").ToList();
                    break;
                case "lastmodifiedtimestamp":
                    processedFiles = processedFiles
                        .Where(f => f != null && f.LastModifiedTimestamp != null)
        .OrderBy(f => f.LastModifiedTimestamp)
        .ToList();
                    break;
                default:
                    break;
            }
        }

        return processedFiles;
    }

  public static void DisplayProgress(int currentCount, int totalCount)
    {
        Console.CursorLeft = 0;
        Console.Write($"Progress: {currentCount}/{totalCount} files processed ({(double)currentCount / totalCount:P2})");
    }
}