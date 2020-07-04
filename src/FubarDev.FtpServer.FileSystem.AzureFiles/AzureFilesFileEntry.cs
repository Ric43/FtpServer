using System;
using System.Collections.Generic;
using System.Text;

namespace FubarDev.FtpServer.FileSystem.AzureFiles
{
    internal class AzureFilesFileEntry : AzureFilesFileSystemEntry, IUnixFileEntry
    {
        public AzureFilesFileEntry(string key, string name) : base(key, name)
        {
        }

        public long Size => throw new NotImplementedException();
    }
}
