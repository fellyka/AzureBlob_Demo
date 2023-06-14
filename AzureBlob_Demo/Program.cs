using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Sas;

using System;

namespace AzureBlob_Demo
{
    public static class Program
    {
        
        private static string connectionString = "DefaultEndpointsProtocol=https;AccountName=stsollersaccount;AccountKey=ajQ5sGYUVY5cVjpANpHeWxWkvF8cU7cO5OLn3Fao4kxdhJ9PNLgEYW+2ghSwIJ6O/QeXr9YADFrq+ASt3FYNYw==;EndpointSuffix=core.windows.net";
        private static string containerName = "vscontainer";
        private static string blobName = "createdfromvs";
        private static string location = @"C:\Users\felly\OneDrive\Desktop\AZ-900-Certificate.pdf";
        private static string downloadToLocation = @"C:\Users\felly\OneDrive\Desktop\BlobDownload";
        static void Main(string[] args)
        {
            //Generate a Shared Access Signature
           // GenerateSAS();
            ReadBlob();
            Console.WriteLine($"Shared Access Signature Uri generated and resource downloaded in {downloadToLocation}");


            Console.ReadKey();
        }

        public static Uri GenerateSAS()
        {
            BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);
            BlobContainerClient blobContainerClient = blobServiceClient.GetBlobContainerClient(containerName);
            BlobClient blobClient = blobContainerClient.GetBlobClient(blobName);

            BlobSasBuilder builder = new BlobSasBuilder()
            {
                BlobContainerName = containerName,
                BlobName = blobName,
                //b for Blob
                Resource = "b" 
            };

            builder.SetPermissions(BlobSasPermissions.Read | BlobSasPermissions.List);
            builder.ExpiresOn = DateTimeOffset.UtcNow.AddHours(1);

            return blobClient.GenerateSasUri(builder);
        }//end of GenerateSAS() method 

        public static void ReadBlob()
        {
            Uri blobUri = GenerateSAS();
            BlobClient client = new BlobClient(blobUri);
            client.DownloadTo(downloadToLocation);

        }
    }
}
