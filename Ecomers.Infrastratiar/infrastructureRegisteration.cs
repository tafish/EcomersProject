using Ecom.Cor.Interfis;
using Ecom.Cor.Interfis;
using Ecom.Infrastratiar.Data;
using Ecomers.Cor.Service;
using Ecomers.Infrastratiar.Riposatre.serves;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Infrastratiar.Riposatre
{
    public static class infrastructureRegisteration
    {
        public static IServiceCollection infrastructureConfigration(this IServiceCollection Services, IConfiguration configuration)
        {
            Services.AddScoped(typeof(IGenericRepositry<>), typeof(GenericRepositry<>));
            Services.AddSingleton<IImagemanagenentService,ImagemanagenentService>();
            Services.AddSingleton<IFileProvider>(new PhysicalFileProvider(
                Path.Combine(Directory.GetCurrentDirectory(),"wwwroot")));
            Services.AddScoped<IUnitOfWork, UnitOfWork>();
            Services.AddDbContext<AppDbContext>(op =>
            {
                op.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

            });

            return Services;
        }
    }
}
