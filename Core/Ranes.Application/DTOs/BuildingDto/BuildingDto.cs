using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ranes.Application.DTOs.BuildingDto
{
    public class BuildingDto
    {
        public Guid Id { get; set; }
        public string CategoryName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public float m2 { get; set; }
        public Guid CategoryId { get; set; }
        public bool Investment { get; set; }
        public bool CompletedProject { get; set; }
    }
}
