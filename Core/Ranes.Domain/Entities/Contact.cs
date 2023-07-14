using Ranes.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ranes.Domain.Entities
{
    public class Contact : BaseEntity
    {
        public string Tel { get; set; }
        public string Fax { get; set; }
        public string PrimaryMail { get; set; }
        public string? SecondaryMail { get; set; }
        public string PrimaryAddress { get; set; }
        public string? SecondaryAddress { get; set; }
        public string? Location { get; set; }
        public string? Lat { get; set; }
        public string? Long { get; set; }
    }
}
