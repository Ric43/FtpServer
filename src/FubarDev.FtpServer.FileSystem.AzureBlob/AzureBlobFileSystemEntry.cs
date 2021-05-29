using System;

using FubarDev.FtpServer.FileSystem.Generic;

namespace FubarDev.FtpServer.FileSystem.AzureBlob
{
    internal class AzureBlobFileSystemEntry : IUnixFileSystemEntry
    {
        public AzureBlobFileSystemEntry(string key, string name)
        {
            Key = key;
            Name = name;
            Permissions = new GenericUnixPermissions(
                new GenericAccessMode(true, true, false),
                new GenericAccessMode(true, true, false),
                new GenericAccessMode(true, true, false));
        }

        public string Key { get; }

        public string Name { get; }

        public IUnixPermissions Permissions { get; }

        public DateTimeOffset? LastWriteTime { get; set; }

        public DateTimeOffset? CreatedTime => null;

        public long NumberOfLinks => 1;

        public string Owner => "owner";

        public string Group => "group";
    }
}
