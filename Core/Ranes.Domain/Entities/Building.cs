using Ranes.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ranes.Domain.Entities
{
    public class Building : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public float m2 { get; set; }
        public string ImgPrimary { get; set; }
        public string? ImgOne { get; set; }
        public string? ImgTwo { get; set; }
        public string? ImgThree { get; set; }
        public string? ImgFour { get; set; }
        public string? ImgFive { get; set; }
        public string? ImgSix { get; set; }
        public string? ImgSeven { get; set; }
        public string ImgEight { get; set; }
        public string? ImgNine { get; set; }
        public string? ImgTen { get; set; }
        public Guid CategoryId { get; set; }
        public bool Investment { get; set; }
        public bool CompletedProject { get; set; }

    }
}
