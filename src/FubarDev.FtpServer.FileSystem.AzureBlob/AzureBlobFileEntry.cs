using System.IO;

namespace FubarDev.FtpServer.FileSystem.AzureBlob
{
    internal class AzureBlobFileEntry : AzureBlobFileSystemEntry, IUnixFileEntry
    {
        public AzureBlobFileEntry(string key, long size)
            : base(key, Path.GetFileName(key))
        {
            Size = size;
        }

        public long Size { get; }
    }
}
