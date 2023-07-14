using Ranes.Application.Abstractions.Token;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ranes.Infrastructure.Services.Token;
using Azure.Storage.Blobs;
using Ranes.Infrastructure.Services.File;
using Ranes.Application.Abstractions.Services.File;

namespace Ranes.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection serviceCollection)
        {
           
            serviceCollection.AddScoped<ITokenHandler, TokenHandler>();
            serviceCollection.AddScoped(_ =>
            {
                return new BlobServiceClient(Configuration.ConnectionString);
            });
            serviceCollection.AddScoped<IFileService,FileService>();
        }
       
      
    }
}
