using HexahedronIntersectionDomain;
using HexahedronIntersectionDomain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using static HexahedronIntersectionDomain.ValueObjects.Point3D;

namespace HexahedronIntersectionInfrastructure
{
    public class HexahedronDbContext:DbContext
    {
        public HexahedronDbContext(DbContextOptions<HexahedronDbContext> options):base(options)
        {

        }

        public DbSet<Hexahedron> Hexahedrons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Maps complex objects to fields into database
            modelBuilder.Entity<Hexahedron>(o => o.HasKey(x => x.Id));
            modelBuilder.Entity<Hexahedron>().OwnsOne(o => o.center, conf => conf.Property(x => x.value[Axis.x]).HasColumnName("CenterX"));
            modelBuilder.Entity<Hexahedron>().OwnsOne(o => o.center, conf => conf.Property(x => x.value[Axis.y]).HasColumnName("CenterY"));
            modelBuilder.Entity<Hexahedron>().OwnsOne(o => o.center, conf => conf.Property(x => x.value[Axis.x]).HasColumnName("CenterZ"));
            modelBuilder.Entity<Hexahedron>().OwnsOne(o => o.width, conf => conf.Property(x => x.value).HasColumnName("Width"));
            modelBuilder.Entity<Hexahedron>().OwnsOne(o => o.height, conf => conf.Property(x => x.value).HasColumnName("Height"));
            modelBuilder.Entity<Hexahedron>().OwnsOne(o => o.depth, conf => conf.Property(x => x.value).HasColumnName("Depth"));

            base.OnModelCreating(modelBuilder);
        }


    }
}
