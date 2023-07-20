using Microsoft.AspNetCore.Http;
using Ranes.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ranes.Domain.Entities
{
    public class File : BaseEntity
    {
        public string FileName { get; set; }
        //public string Extension { get; set; }
        public Guid BuildingId { get; set; }
        public bool IsPrimary { get; set; }
    }
}
