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
        public Guid CategoryId { get; set; }
        public bool Investment { get; set; }
        public bool CompletedProject { get; set; }

    }
}
