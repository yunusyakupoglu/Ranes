using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ranes.Application.DTOs.File
{
    public class FileModel
    {
        public IFormFile ImgPrimary { get; set; }
        public string ImgPrimaryPath { get; set; }

        public IFormFile ImgOne { get; set; }
        public string ImgOnePath { get; set; }

        public IFormFile ImgTwo { get; set; }
        public string ImgTwoPath { get; set; }

        public IFormFile ImgThree { get; set; }
        public string ImgThreePath { get; set; }

        public IFormFile ImgFour { get; set; }
        public string ImgFourPath { get; set; }

        public IFormFile ImgFive { get; set; }
        public string ImgFivePath { get; set; }

        public IFormFile ImgSix { get; set; }
        public string ImgSixPath { get; set; }

        public IFormFile ImgSeven { get; set; }
        public string ImgSevenPath { get; set; }

        public IFormFile ImgEight { get; set; }
        public string ImgEightPath { get; set; }

        public IFormFile ImgNine { get; set; }
        public string ImgNinePath { get; set; }

        public IFormFile ImgTen { get; set; }
        public string ImgTenPath { get; set; }
    }
}
