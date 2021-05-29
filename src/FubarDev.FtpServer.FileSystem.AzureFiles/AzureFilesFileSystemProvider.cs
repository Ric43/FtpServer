using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Extensions.Options;

namespace FubarDev.FtpServer.FileSystem.AzureFiles
{
    public class AzureFilesFileSystemProvider : IFileSystemClassFactory
    {
        /// <summary>
        /// The file system factory for an azure files-based file system via the API (not CIFS)
        /// </summary>
        private readonly AzureFilesFileSystemOptions _options;
        private readonly IAccountDirectoryQuery _accountDirectoryQuery;

        public AzureFilesFileSystemProvider(IOptions<AzureFilesFileSystemOptions> options, IAccountDirectoryQuery accountDirectoryQuery)
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
