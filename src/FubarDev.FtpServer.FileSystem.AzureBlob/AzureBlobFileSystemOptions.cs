namespace FubarDev.FtpServer.FileSystem.AzureBlob
{
    public class AzureBlobFileSystemOptions
    {
        // Connect with a connection string
        public string ConnectionString { get; set; }

        // Connect with a Shared Access Signature
        public string SharedAccessSignature { get; set; }

        // Connect with a Shared Key
        public string AccountName { get; set; }
        public string AccountKey { get; set; }
        public string BlobServiceUri { get; set; }
    }
}
