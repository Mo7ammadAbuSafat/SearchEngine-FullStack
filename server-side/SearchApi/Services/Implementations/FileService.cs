﻿using SearchApi.Services.Interfaces;

namespace SearchApi.Services.Implementations
{
    public class FileService : IFileService
    {
        private readonly IWebHostEnvironment hostingEnvironment;
        public FileService(IWebHostEnvironment hostingEnvironment)
        {
            this.hostingEnvironment = hostingEnvironment;
        }

        public async Task<string> StoreImageToLocalFolder(IFormFile file)
        {
            string uploadsFolder = Path.Combine(hostingEnvironment.ContentRootPath, "Uploads");
            string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using var fileStream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(fileStream);
            return filePath;
        }

        public void DeleteFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
    }
}
