using Ranes.Application.Abstractions.Services.Authentications;
using Ranes.Application.Abstractions.Services;
using Ranes.Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Ranes.Persistance.Contexts;
using Ranes.Persistence.Services;
using Ranes.Persistance.Repositories.Building;
using Ranes.Application.Repositories.Building;
using Ranes.Application.Repositories.Category;
using Ranes.Persistance.Repositories.Category;
using Ranes.Persistance.Repositories.About;
using Ranes.Application.Repositories.About;
using Ranes.Application.Repositories.Contact;
using Ranes.Persistance.Repositories.Contact;
using Ranes.Persistance.Repositories.File;
using Ranes.Application.Repositories.File;

namespace Ranes.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<RanesDbContext>(opt => opt.UseNpgsql(Configuration.ConnectionString));

            services.AddTransient<ICategoryReadRepository, CategoryReadRepository>();
            services.AddTransient<ICategoryWriteRepository, CategoryWriteRepository>();
            services.AddTransient<IBuildingReadRepository, BuildingReadRepository>();
            services.AddTransient<IBuildingWriteRepository, BuildingWriteRepository>();
            services.AddTransient<IAboutReadRepository, AboutReadRepository>();
            services.AddTransient<IAboutWriteRepository, AboutWriteRepository>();
            services.AddTransient<IContactReadRepository, ContactReadRepository>();
            services.AddTransient<IContactWriteRepository, ContactWriteRepository>();
            services.AddTransient<IFileWriteRepository, FileWriteRepository>();
            services.AddTransient<IFileReadRepository, FileReadRepository>();


            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IExternalAuthentication, AuthService>();
            services.AddScoped<IInternalAuthentication, AuthService>();
            services.AddScoped<IRoleService, RoleService>();

            services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredUniqueChars = 0;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireDigit = false;
                options.User.RequireUniqueEmail = true;
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = false;
                options.SignIn.RequireConfirmedEmail = true;
            })
            .AddEntityFrameworkStores<RanesDbContext>()
            .AddDefaultTokenProviders();
            



        }
    }
}
