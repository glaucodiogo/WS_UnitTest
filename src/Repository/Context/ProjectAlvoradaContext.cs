using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context
{
    public class ProjectAlvoradaContext : DbContext
    {
        public ProjectAlvoradaContext() 
        {

        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<Resource> Resources { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var foreignKey in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Cascade;
            }

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProjectAlvoradaContext).Assembly);            

        }
    }
}
