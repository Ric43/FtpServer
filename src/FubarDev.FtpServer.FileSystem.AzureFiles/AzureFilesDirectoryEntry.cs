using System;
using System.Collections.Generic;
using System.Text;

namespace FubarDev.FtpServer.FileSystem.AzureFiles
{
    public class AzureFilesDirectoryEntry : IUnixDirectoryEntry
    {
        public bool IsRoot => throw new NotImplementedException();

        public bool IsDeletable => throw new NotImplementedException();

        public string Name => throw new NotImplementedException();

        public IUnixPermissions Permissions => throw new NotImplementedException();

        public DateTimeOffset? LastWriteTime => throw new NotImplementedException();

        public DateTimeOffset? CreatedTime => throw new NotImplementedException();

        public long NumberOfLinks => throw new NotImplementedException();

        public string Owner => throw new NotImplementedException();

        public string Group => throw new NotImplementedException();
    }
}
