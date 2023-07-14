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
        Task<FileModel> Upload(FileModel model);
    }
}
