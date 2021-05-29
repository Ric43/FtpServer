using System.IO;

namespace FubarDev.FtpServer.FileSystem.AzureFiles
{
    internal class AzureFilesDirectoryEntry : AzureFilesFileSystemEntry, IUnixDirectoryEntry
    {
        public AzureFilesDirectoryEntry(string key, bool isRoot = false)
            : base(key.EndsWith("/") || isRoot ? key : key + "/", Path.GetFileName(key.TrimEnd('/')))
        {
            IsRoot = isRoot;
        }

        public bool IsRoot { get; }

        public bool IsDeletable => !IsRoot;
    }
}
