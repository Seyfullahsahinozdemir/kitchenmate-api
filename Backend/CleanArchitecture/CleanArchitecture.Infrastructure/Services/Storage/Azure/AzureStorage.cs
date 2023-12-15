using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using CleanArchitecture.Core.Interfaces.Storage;
using CleanArchitecture.Core.Interfaces.Storage.Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace CleanArchitecture.Infrastructure.Services.Storage.Azure
{
    public class AzureStorage : Storage, IAzureStorage
    {
        readonly BlobServiceClient _blobServiceClient;
        BlobContainerClient _blobContainerClient;

        public AzureStorage(IConfiguration configuration)
        {
            _blobServiceClient = new(configuration["Storage:Azure"]);
        }

        public async Task DeleteAsync(string pathOrContainerName, string fileName)
        {
            _blobContainerClient = _blobServiceClient.GetBlobContainerClient(pathOrContainerName);
            BlobClient blobClient = _blobContainerClient.GetBlobClient(fileName);
            await blobClient.DeleteAsync();
        }

        public List<string> GetFiles(string pathOrContainerName)
        {
            _blobContainerClient = _blobServiceClient.GetBlobContainerClient(pathOrContainerName);
            return _blobContainerClient.GetBlobs().Select(b => b.Name).ToList();
        }

        public async Task<(string fileName, string pathOrContainerName)> UploadAsync(string pathOrContainerName, IFormFile file)
        {
            _blobContainerClient = _blobServiceClient.GetBlobContainerClient(pathOrContainerName);
            await _blobContainerClient.CreateIfNotExistsAsync();
            await _blobContainerClient.SetAccessPolicyAsync(PublicAccessType.BlobContainer);

            (string fileName, string pathOrContainerName) data = new();
            string fileNewName = await FileRenameAsync(pathOrContainerName, file.Name, HasFile);

            BlobClient blobClient = _blobContainerClient.GetBlobClient(fileNewName);
            await blobClient.UploadAsync(file.OpenReadStream());
            data = (fileNewName, $"{pathOrContainerName}/{fileNewName}");

            return data;
        }

        //public async Task<List<(string fileName, string pathOrContainerName)>> UploadAsync(string pathOrContainerName, IFormFileCollection files)
        //{
        //    _blobContainerClient = _blobServiceClient.GetBlobContainerClient(pathOrContainerName);
        //    await _blobContainerClient.CreateIfNotExistsAsync();
        //    await _blobContainerClient.SetAccessPolicyAsync(PublicAccessType.BlobContainer);

        //    List<(string fileName, string pathOrContainerName)> datas = new();
        //    foreach (IFormFile file in files)
        //    {
        //        string fileNewName = await FileRenameAsync(pathOrContainerName, file.Name, HasFile);

        //        BlobClient blobClient = _blobContainerClient.GetBlobClient(fileNewName);
        //        await blobClient.UploadAsync(file.OpenReadStream());
        //        datas.Add((fileNewName, $"{pathOrContainerName}/{fileNewName}"));
        //    }
        //    return datas;
        //}

        public bool HasFile(string pathOrContainerName, string fileName)
        {
            _blobContainerClient = _blobServiceClient.GetBlobContainerClient(pathOrContainerName);
            return _blobContainerClient.GetBlobs().Any(b => b.Name == fileName);
        }


    }
}
