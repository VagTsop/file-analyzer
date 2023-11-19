# Features of the Console App: File Analyzer

## User-Friendly Interface:

- The app provides a user-friendly command-line interface, making it accessible to both novice and experienced users.

## File Analysis:

- Allows users to specify a directory path for analysis, including the option to include subdirectories.
- Scans and collects information about files within the specified directory, such as file type, MD5 hash, file size, and last modified timestamp.

## Custom Sorting:

- Provides the flexibility to sort the analyzed files based on user-defined criteria, including file size, file type, and last modified timestamp.

## Error Logging:

- Logs detailed error messages to an application log file (./application.log) for troubleshooting purposes.
- Ensures robust error handling to handle various file system-related issues gracefully.

## Progress Tracking:

- Displays real-time progress information, including the number of files processed and the overall completion percentage.
- Keeps users informed about the app's progress during file analysis.

## Output Generation:

- Generates a CSV output file containing comprehensive file information, including file paths, file types, MD5 hashes, file sizes (in bytes, kilobytes, and megabytes), and last modified timestamps.
- Includes summary statistics about the analyzed files, such as the total number of files and the total size in bytes, kilobytes, and megabytes.

## Dependency Separation:

- Implements a modular design with separate service classes for key functionalities, such as file operations, hashing, user input, error logging, and output generation.
- Promotes clean and maintainable code by separating concerns and responsibilities.

## Input Validation:

- Validates user input to ensure the provided directory paths and options are valid and understandable.
- Provides clear warnings and error messages for any input-related issues.

## Parallel Processing:

- Utilizes parallel processing to analyze files concurrently, improving the efficiency of the file analysis process for directories with a large number of files.

## Flexibility and Extensibility:

- The app is designed to be extensible, allowing for future enhancements and additional features.
- Users can easily adapt the app to suit their specific file analysis requirements.

## Documentation and Code Structure:

- Includes well-structured code with clear comments for easy comprehension and future maintenance.
- Demonstrates an understanding of software development best practices, such as modularization and error handling.

## Consistent Logging and Reporting:

- Ensures consistent logging and reporting of errors and warnings to both the console and the log file for comprehensive issue tracking.

## Hashing for Data Integrity:

- Calculates MD5 hashes for each file to verify data integrity and detect any potential file alterations.

## Clear Exit and Exception Handling:

- Provides a graceful exit mechanism, allowing users to review results before closing the application.
- Handles exceptions robustly to prevent crashes and ensure a smooth user experience.

## Customizable Output File:

- Allows users to specify the output file path, enabling flexibility in where the analysis results are saved.

This File Analyzer Console App demonstrates effective coding practices and encapsulation of functionalities into modular services, enhancing code readability, maintainability, and extensibility.
