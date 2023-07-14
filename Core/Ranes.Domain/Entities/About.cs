using Ranes.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ranes.Domain.Entities
{
    public class About : BaseEntity
    {
        public string AboutUs { get; set; }
        public string OurHistory { get; set; }
        public string OurVision { get; set; }
        public string OurMission { get; set; }
    }
}
