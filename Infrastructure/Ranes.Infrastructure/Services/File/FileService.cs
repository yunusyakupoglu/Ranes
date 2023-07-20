using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Ranes.Application.Abstractions.Services.File;
using Ranes.Application.DTOs.File;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Ranes.Infrastructure.Services.File
{
    public class FileService : IFileService
    {
        private readonly string _uploadDirectory;

        public FileService(IWebHostEnvironment webHostEnvironment)
        {
            _uploadDirectory = Path.Combine(webHostEnvironment.ContentRootPath, "uploads");
        }

        public async Task<int> DeleteFile(string fileName)
        {
                string filePath = Path.Combine(_uploadDirectory, fileName);

                if (!System.IO.File.Exists(filePath))
                {
                    return 0;
                }

                System.IO.File.Delete(filePath);

                return 1;
        }

        public async Task<string> UploadFile(IFormFile file)
        {
            if (file == null || file.Length <= 0)
            {
                throw new ArgumentException("Invalid file.");
            }

            if (!Directory.Exists(_uploadDirectory))
            {
                Directory.CreateDirectory(_uploadDirectory);
            }

            var fileName = Path.GetFileName(file.FileName);
            var filePath = Path.Combine(_uploadDirectory, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return fileName;
        }

        public async Task<IEnumerable<string>> UploadFiles(IEnumerable<IFormFile> files)
        {
            List<string> fileNames = new List<string>();

            if (!Directory.Exists(_uploadDirectory))
            {
                Directory.CreateDirectory(_uploadDirectory);
            }

            foreach (var file in files)
            {
                if (file.Length <= 0)
                    continue;

                var fileName = Path.GetFileName(file.FileName);
                var filePath = Path.Combine(_uploadDirectory, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                fileNames.Add(fileName);
            }

            return fileNames;
        }
    }
}
