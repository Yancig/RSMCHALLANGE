using Microsoft.EntityFrameworkCore;
using RSMCHALLANGE.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RSMCHALLANGE.Infrastructure
{
    public class AdvWorksDbContext : DbContext
    {
        public AdvWorksDbContext()
        {

        }
        public AdvWorksDbContext(DbContextOptions<AdvWorksDbContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
                }
    }
}