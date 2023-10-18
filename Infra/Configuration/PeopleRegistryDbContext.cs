using Entities.Models;
using Infrastructure.Map;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configuration
{
    public class PeopleRegistryDbContext : DbContext
    {
        public PeopleRegistryDbContext(DbContextOptions<PeopleRegistryDbContext> options) : base(options)
        {
        }

        public DbSet<Person> Person { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PersonMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}