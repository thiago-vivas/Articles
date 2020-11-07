using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Drawing;
using System.Linq;

namespace AzureBlobStorage
{
    class Program
    {
        private static readonly string connectionString = "DefaultEndpointsProtocol=https;AccountName=samplestorageaccountblob;AccountKey=FyJw8U6tORM7DVBxw4G5nxUlbTy8l5so8lAGfsr1AEf6fSN63A6llM8kQfQO9bF1qABHkNHfCWtL/l/j9zk/WQ==;EndpointSuffix=core.windows.net";
        private static readonly string containerName = "sampleblobcontainer";
        private static readonly string imagesPath = @"~~~~~~~~\AzureBlobStorage\AzureBlobStorage\Pictures\";
        static async Task Main(string[] args)
        {

            Console.WriteLine("Program started. Connecting to Blob Client");
            BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);
            BlobContainerClient containerClient = null;

            if (blobServiceClient.GetBlobContainers().Where(x => x.Name == containerName).Any())
            {
                Console.WriteLine("Blob Container Client found.");
                containerClient = blobServiceClient.GetBlobContainerClient(containerName);
            }
            else
            {
                Console.WriteLine("Blob Container Client not found, creating a new one.");
                containerClient = await blobServiceClient.CreateBlobContainerAsync(containerName);// Create the container and return a container client object
                Console.WriteLine("Blob Container Client created.");
            }

            Console.WriteLine("Creating Blobs.");

            await Task.WhenAll(UploadBlob(containerClient, "frequent.jpg"),
                       UploadBlob(containerClient, "not so frequent.png"),
                       UploadBlob(containerClient, "rare.jpg"));

            await ListBlobFiles(containerClient);

        }
        private static async Task UploadBlob(BlobContainerClient containerClient, string filename)
        {

            Console.WriteLine($"Creating Blob named {filename}.");

            // Get a reference to a blob
            BlobClient blobClient = containerClient.GetBlobClient(filename);

            Console.WriteLine("Uploading to Blob storage as blob:\n\t {0}\n", blobClient.Uri);

            // Open the file and upload its data
            using FileStream uploadFileStream = File.OpenRead(Path.Combine(imagesPath, filename));
            await blobClient.UploadAsync(uploadFileStream, true);
            uploadFileStream.Close();

            Console.WriteLine($"Created Blob named {filename}.");
        }
        private static async Task ListBlobFiles(BlobContainerClient containerClient)
        {
            Console.WriteLine("Listing blobs...");

            // List all blobs in the container
            await foreach (BlobItem blobItem in containerClient.GetBlobsAsync())
            {
                Console.WriteLine("\t" + blobItem.Name);
            }
        }
    }
}
