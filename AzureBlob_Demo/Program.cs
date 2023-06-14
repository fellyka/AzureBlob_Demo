using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

using System;

namespace AzureBlob_Demo
{
    public static class Program
    {
        
        private static string connectionString = "DefaultEndpointsProtocol=https;AccountName=stsollersaccount;AccountKey=ajQ5sGYUVY5cVjpANpHeWxWkvF8cU7cO5OLn3Fao4kxdhJ9PNLgEYW+2ghSwIJ6O/QeXr9YADFrq+ASt3FYNYw==;EndpointSuffix=core.windows.net";
        private static string containerName = "vscontainer";
        private static string blobName = "createdfromvs";
        private static string location = @"C:\Users\felly\OneDrive\Desktop\AZ-900-Certificate.pdf";
        static void Main(string[] args)
        {
            BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);
            /* blobServiceClient.CreateBlobContainer(containerName);*/

            BlobContainerClient blobContainerClient = blobServiceClient.GetBlobContainerClient(containerName);
           /* BlobClient blobClient = blobContainerClient.GetBlobClient(blobName); */
           /* blobClient.Upload(location);*/


            //After having uploaded items from the Azure portal, let list them here with few of its properties
            foreach(BlobItem item in blobContainerClient.GetBlobs())
            {
                Console.WriteLine($"Item Name: {item.Name}\nItem Tags: {item.Tags}\nItem deleted? :{item.Deleted}");
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
