using System.IO;

namespace FubarDev.FtpServer.FileSystem.AzureFiles
{
    internal class AzureFilesFileEntry : AzureFilesFileSystemEntry, IUnixFileEntry
    {
        public AzureFilesFileEntry(string key, long size)
            : base(key, Path.GetFileName(key))
        {
            Size = size;
        }

        public long Size { get; }
    }
}
