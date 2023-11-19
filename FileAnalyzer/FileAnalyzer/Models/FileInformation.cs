public class FileInformation
{
    public string FilePath { get; set; }
    public string FileType { get; set; }
    public string Md5Hash { get; set; }
    public long FileSizeBytes { get; set; }
    public double FileSizeKilobytes { get; set; }
    public double FileSizeMegabytes { get; set; }
    public string LastModifiedTimestamp { get; set; }
}
