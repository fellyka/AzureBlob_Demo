using Azure.Storage.Blobs;
using System;

namespace AzureBlob_Demo
{
    public static class Program
    {
        
        private static string connectionString = "DefaultEndpointsProtocol=https;AccountName=stsollersaccount;AccountKey=ajQ5sGYUVY5cVjpANpHeWxWkvF8cU7cO5OLn3Fao4kxdhJ9PNLgEYW+2ghSwIJ6O/QeXr9YADFrq+ASt3FYNYw==;EndpointSuffix=core.windows.net";
        private static string containerName = "vscontainer";
        static void Main(string[] args)
        {
            BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);
            blobServiceClient.CreateBlobContainer(containerName);
            Console.WriteLine("Container created !");
            Console.ReadKey();
        }
    }
}
