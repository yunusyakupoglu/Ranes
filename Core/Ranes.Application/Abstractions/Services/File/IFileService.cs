using Microsoft.AspNetCore.Http;
using Ranes.Application.DTOs.File;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ranes.Application.Abstractions.Services.File
{
    public interface IFileService
    {
        Task<IEnumerable<string>> UploadFiles(IEnumerable<IFormFile> files);

        Task<string> UploadFile(IFormFile file);

        Task<int> DeleteFile(string fileName);

    }
}
