using System;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace TheaterAPI.Models
{
	public class ProjectDBContext : DbContext
    {

            protected readonly IConfiguration Configuration;
            public ProjectDBContext(DbContextOptions<ProjectDBContext> options, IConfiguration configuration) : base(options)
            {
                Configuration = configuration;

            }
            protected override void OnConfiguring(DbContextOptionsBuilder options)
            {
                var connectionString = Configuration.GetConnectionString("project");
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

            }
            public DbSet<Movie> Movies { get; set; } = null;
            public DbSet<Theatre> Theatres { get; set; } = null;

        
    }
 


}


