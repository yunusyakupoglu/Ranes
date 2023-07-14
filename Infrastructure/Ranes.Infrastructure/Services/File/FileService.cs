using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
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

        public FileService()
        {
        }

        public async Task<FileModel> Upload(FileModel model)
        {
            List<IFormFile> files = new List<IFormFile>
    {
        model.ImgPrimary,
        model.ImgOne,
        model.ImgTwo,
        model.ImgThree,
        model.ImgFour,
        model.ImgFive,
        model.ImgSix,
        model.ImgSeven,
        model.ImgEight,
        model.ImgNine,
        model.ImgTen
    };

            List<string> uploadedFilePaths = new List<string>();

            // Yüklenen dosyaların kaydedileceği klasörün yolu
            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "uploads");

            // Eğer "uploads" klasörü yoksa, oluşturulması
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            for (int i = 0; i < files.Count; i++)
            {
                var file = files[i];
                if (file != null && file.Length > 0)
                {
                    // Dosya adı için GUID oluşturma
                    var fileName = $"{Guid.NewGuid()}_{file.FileName}";

                    // Dosyanın kaydedileceği tam yol
                    var filePath = Path.Combine(uploadsFolder, fileName);

                    // Dosyayı kopyalama
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                    // Yüklenen dosyanın tam yolunu listeye ekleme
                    uploadedFilePaths.Add(filePath);

                    // Dosya adını string property'ye ata
                    switch (i)
                    {
                        case 0:
                            model.ImgPrimaryPath = fileName;
                            break;
                        case 1:
                            model.ImgOnePath = fileName;
                            break;
                        case 2:
                            model.ImgTwoPath = fileName;
                            break;
                        case 3:
                            model.ImgThreePath = fileName;
                            break;
                        case 4:
                            model.ImgFourPath = fileName;
                            break;
                        case 5:
                            model.ImgFivePath = fileName;
                            break;
                        case 6:
                            model.ImgSixPath = fileName;
                            break;
                        case 7:
                            model.ImgSevenPath = fileName;
                            break;
                        case 8:
                            model.ImgEightPath = fileName;
                            break;
                        case 9:
                            model.ImgNinePath = fileName;
                            break;
                        case 10:
                            model.ImgTenPath = fileName;
                            break;
                        default:
                            break;
                    }
                }
            }

            return model;
        }

    }
}
