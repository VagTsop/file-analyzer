using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the File Analyzer App!");

        string inputDirectory = InputService.GetUserInput("Enter the directory path to analyze: ");
        string outputPath = InputService.GetUserInput("Enter the output file path (including file name and extension): ");
        bool includeSubdirectories = InputService.GetUserInput("Include subdirectories? (Y/N): ").Equals("Y", StringComparison.OrdinalIgnoreCase);
        string sortBy = InputService.GetUserInput("Sort by (FileSize/FileType/LastModifiedTimestamp): ");

        // Specify the log file path
        string logFilePath = "./application.log";
        LogService logger = new LogService(logFilePath);

        try
        {
            List<string> filesToProcess = FileService.GetFilesToProcess(inputDirectory, includeSubdirectories);
            List<FileInformation> processedFiles = FileService.ProcessFiles(filesToProcess, sortBy);

            if (processedFiles != null) // Check if the processedFiles list is not null
            {
                OutputService.CreateCsvFile(outputPath, processedFiles);

                Console.WriteLine("Analysis completed. Results are saved to the output file.");
            }
            else
            {
                Console.WriteLine("No files were processed, so no output file was created.");
            }
        }
        catch (Exception ex)
        {
            logger.LogError($"An error occurred: {ex.Message}");
        }
        finally
        {
            Console.ReadLine();
        }

    }
}

