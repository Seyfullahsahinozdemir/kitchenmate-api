using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Interfaces.Storage
{
    public interface IStorageService: IStorage
    {
        public string StorageName { get; }

        //Task<(string fileName, string pathOrContainerName)> UploadAsync(string v, IFormFile file);
    }
}
