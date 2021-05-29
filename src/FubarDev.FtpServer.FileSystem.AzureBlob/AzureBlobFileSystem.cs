using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

using Azure.Storage;
using Azure.Storage.Blobs;

using FubarDev.FtpServer.BackgroundTransfer;

namespace FubarDev.FtpServer.FileSystem.AzureBlob
{
    public class AzureBlobFileSystem : IUnixFileSystem
    {
        private readonly AzureBlobFileSystemOptions _options;
        private readonly BlobServiceClient _client;

        public AzureBlobFileSystem(AzureBlobFileSystemOptions options, string rootDirectory)
        {
            _options = options;
            if (!string.IsNullOrWhiteSpace(options.ConnectionString))
            {
                _client = new BlobServiceClient(options.ConnectionString);
            }
            else if (!string.IsNullOrWhiteSpace(options.SharedAccessSignature))
            {
                _client = new BlobServiceClient(new Uri(options.SharedAccessSignature));
            }
            else if (string.IsNullOrWhiteSpace(options.AccountName) || string.IsNullOrWhiteSpace(options.AccountKey) || string.IsNullOrWhiteSpace(options.BlobServiceUri))
            {
                throw new InvalidOperationException("At least one method of connecting to the storage account must be provided and anonymous access is not supported");
            }

            StorageSharedKeyCredential credential = new StorageSharedKeyCredential(options.AccountName, options.AccountKey);
            _client = new BlobServiceClient(new Uri(options.BlobServiceUri), credential);
        }

        public bool SupportsAppend => false;

        public bool SupportsNonEmptyDirectoryDelete => false;

        public StringComparer FileSystemEntryComparer => throw new NotImplementedException();

        public IUnixDirectoryEntry Root => throw new NotImplementedException();

        public Task<IBackgroundTransfer?> AppendAsync(IUnixFileEntry fileEntry, long? startPosition, Stream data, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IBackgroundTransfer?> CreateAsync(IUnixDirectoryEntry targetDirectory, string fileName, Stream data, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IUnixDirectoryEntry> CreateDirectoryAsync(IUnixDirectoryEntry targetDirectory, string directoryName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<IUnixFileSystemEntry>> GetEntriesAsync(IUnixDirectoryEntry directoryEntry, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IUnixFileSystemEntry?> GetEntryByNameAsync(IUnixDirectoryEntry directoryEntry, string name, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IUnixFileSystemEntry> MoveAsync(IUnixDirectoryEntry parent, IUnixFileSystemEntry source, IUnixDirectoryEntry target, string fileName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Stream> OpenReadAsync(IUnixFileEntry fileEntry, long startPosition, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IBackgroundTransfer?> ReplaceAsync(IUnixFileEntry fileEntry, Stream data, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IUnixFileSystemEntry> SetMacTimeAsync(IUnixFileSystemEntry entry, DateTimeOffset? modify, DateTimeOffset? access, DateTimeOffset? create, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task UnlinkAsync(IUnixFileSystemEntry entry, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
