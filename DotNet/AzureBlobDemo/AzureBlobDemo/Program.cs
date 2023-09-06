﻿using Azure.Storage.Blobs;

Console.WriteLine("Aloitetaan Azure Blob Storagen käyttö.");

// TODO: Replace <storage-account-name> with your actual storage account name
var blobServiceClient = new BlobServiceClient(
    "DefaultEndpointsProtocol=https;AccountName=integraatioakatemia2023;AccountKey=wEkppeQdWulD912jyoheen/tTSSxs+/zRrUzd5KCIxu1JxYI3BACEzFUKG6iAZInQ80ir0qG/EFC+AStRPibNA==;EndpointSuffix=core.windows.net");

//Create a unique name for the container
string containerName = "akatemia";

// Create the container and return a container client object
BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(containerName);

// Create a local file in the ./data/ directory for uploading and downloading
string localPath = "data";
Directory.CreateDirectory(localPath);
string fileName = "Janin testi.txt";
string localFilePath = Path.Combine(localPath, fileName);

// Write text to the file
await File.WriteAllTextAsync(localFilePath, "Moi maailma!");

// Get a reference to a blob
BlobClient blobClient = containerClient.GetBlobClient(fileName);

Console.WriteLine("Uploading to Blob storage as blob:\n\t {0}\n", blobClient.Uri);

// Upload data from the local file
await blobClient.UploadAsync(localFilePath, true);

/*
Console.WriteLine("Listing blobs...");

// List all blobs in the container
await foreach (BlobItem blobItem in containerClient.GetBlobsAsync())
{
    Console.WriteLine("\t" + blobItem.Name);
}

// Download the blob to a local file
// Append the string "DOWNLOADED" before the .txt extension 
// so you can compare the files in the data directory
string downloadFilePath = localFilePath.Replace(".txt", "DOWNLOADED.txt");

Console.WriteLine("\nDownloading blob to\n\t{0}\n", downloadFilePath);

// Download the blob's contents and save it to a file
await blobClient.DownloadToAsync(downloadFilePath);

// Clean up
Console.Write("Press any key to begin clean up");
Console.ReadLine();

Console.WriteLine("Deleting blob container...");
await containerClient.DeleteAsync();

Console.WriteLine("Deleting the local source and downloaded files...");
File.Delete(localFilePath);
File.Delete(downloadFilePath);
*/

Console.WriteLine("Valmis!");
