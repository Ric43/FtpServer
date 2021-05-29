using System.IO;

namespace FubarDev.FtpServer.FileSystem.AzureBlob
{
    internal class AzureBlobDirectoryEntry : AzureBlobFileSystemEntry, IUnixDirectoryEntry
    {
        public AzureBlobDirectoryEntry(string key, bool isRoot = false)
            : base(key.EndsWith("/") || isRoot ? key : key + "/", Path.GetFileName(key.TrimEnd('/')))
        {
            IsRoot = isRoot;
        }

        public bool IsRoot { get; }

        public bool IsDeletable => !IsRoot;
    }
}
