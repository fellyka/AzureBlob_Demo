using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Sas;

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

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

            MemoryStream memory = new MemoryStream();
            blobClient.DownloadTo(memory);

            memory.Position = 0;
            StreamReader reader = new StreamReader(memory);
            Console.WriteLine(reader.ReadToEnd());

            Console.ReadKey();
        }            
    }
}
