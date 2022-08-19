using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Tickeo.Core.Entities;

namespace Tickeo.Repository
{
    public class TickeoDbContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public TickeoDbContext(DbContextOptions<TickeoDbContext> options) : base(options)
        {

        }
        public DbSet<User> User { get; set; }
      

        public class TickeoDbContextFactory : IDesignTimeDbContextFactory<TickeoDbContext>
        {
            TickeoDbContext IDesignTimeDbContextFactory<TickeoDbContext>.CreateDbContext(string[] args)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json").Build();

                var optionsBuilder = new DbContextOptionsBuilder<TickeoDbContext>();
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("TickeoDbContext"));

                return new TickeoDbContext(optionsBuilder.Options);
            }
        }
    }
}
