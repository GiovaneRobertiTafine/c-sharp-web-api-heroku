using c_sharp_web_api_heorku.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace c_sharp_web_api_heorku.Context
{
    public class DataContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
            //.SetBasePath("path here") //<--You would need to set the path
            .AddJsonFile("appsettings.json"); //or what ever file you have the settings

            IConfiguration configuration = builder.Build();

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql(configuration.GetConnectionString("DefaultConnection"), ServerVersion.AutoDetect(configuration.GetConnectionString("DefaultConnection")), options => options.EnableRetryOnFailure());
            }
        }

        public DbSet<Empresas> Empresas { get; set; }
    }
}
