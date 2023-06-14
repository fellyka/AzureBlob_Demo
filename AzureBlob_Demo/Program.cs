using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Sas;

using System;
using System.Collections;
using System.Collections.Generic;

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
            BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);
            BlobContainerClient blobContainerClient = blobServiceClient.GetBlobContainerClient(containerName);
            BlobClient blobClient = blobContainerClient.GetBlobClient(blobName);

            //Get Blob properties
            BlobProperties properties = blobClient.GetProperties();
            Console.WriteLine($"The access tier of the blob is {properties.AccessTier}\n" +
                $"The size of the blob is {properties.ContentLength}");

            Console.WriteLine();
            //Get metadata
            IDictionary<string,string> metadata = properties.Metadata;
            foreach(var item in  metadata)
            {
                Console.WriteLine($"Item Key = {item.Key}\nItem Value = {item.Value}");
            }

            Console.ReadKey();
        }            
    }
}
