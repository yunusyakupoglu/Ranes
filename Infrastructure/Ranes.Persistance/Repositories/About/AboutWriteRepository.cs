﻿using Ranes.Application.Repositories.About;
using Ranes.Persistance.Contexts;
using Ranes.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ranes.Persistance.Repositories.About
{
    public class AboutWriteRepository : WriteRepository<Domain.Entities.About>, IAboutWriteRepository
    {
        public AboutWriteRepository(RanesDbContext context) : base(context)
        {
        }
    }
}
