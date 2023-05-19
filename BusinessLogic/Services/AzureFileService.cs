﻿using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class AzureFileService : IFileService
    {
        private readonly IFileStorageService storageService;
        private const string containerName = "products-images";

        public AzureFileService(IFileStorageService storageService)
        {
            this.storageService = storageService;
        }
        public async Task DeleteProductImage(string path)
        {
            await storageService.DeleteFile(containerName, path);
        }

        public async Task<string> SaveProductImage(IFormFile file)
        {
            return await storageService.UploadFile(containerName, file);
        }
    }
}
