using System;
using System.Threading.Tasks;

using Microsoft.Extensions.Options;

namespace FubarDev.FtpServer.FileSystem.AzureBlob
{
    public class AzureBlobFileSystemProvider : IFileSystemClassFactory
    {
        /// <summary>
        /// The file system factory for an azure files-based file system via the API (not CIFS)
        /// </summary>
        private readonly AzureBlobFileSystemOptions _options;
        private readonly IAccountDirectoryQuery _accountDirectoryQuery;

        public AzureBlobFileSystemProvider(IOptions<AzureBlobFileSystemOptions> options, IAccountDirectoryQuery accountDirectoryQuery)
        {
            _options = options.Value;
            _accountDirectoryQuery = accountDirectoryQuery;
        }

        public Task<IUnixFileSystem> Create(IAccountInformation accountInformation)
        {
            throw new NotImplementedException();
        }
    }
}
