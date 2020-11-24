using System;
using Database.EFCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Database.EFCore
{
    public partial class ExampleContext : DbContext
    {
        public DbSet<SummaryEntity> Summaries { get; set; }
        public DbSet<WeatherEntity> Weathers { get; set; }
        
        public DbSet<UserEntity> Users { get; set; }
        
        public DbSet<RoleEntity> Role { get; set; }
        
        public ExampleContext()
        {
        }

        public ExampleContext(DbContextOptions<ExampleContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=postgres;User ID=postgres;Password=root;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);

            modelBuilder.Entity<WeatherEntity>(entity =>
            {
                entity.ToTable("Weather");
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Id).UseIdentityColumn();
                entity.HasOne(d => d.Summary);
            });

            modelBuilder.Entity<SummaryEntity>(entity =>
            {
                entity.ToTable("Summary");
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Id).UseIdentityColumn();
            });
            
            modelBuilder.Entity<SummaryEntity>().HasData(new SummaryEntity { Id = 1, Code = "Freezing" });
            modelBuilder.Entity<SummaryEntity>().HasData(new SummaryEntity { Id = 2, Code = "Bracing" });
            modelBuilder.Entity<SummaryEntity>().HasData(new SummaryEntity { Id = 3, Code = "Chilly" });
            modelBuilder.Entity<SummaryEntity>().HasData(new SummaryEntity { Id = 4, Code = "Cool" });
            modelBuilder.Entity<SummaryEntity>().HasData(new SummaryEntity { Id = 5, Code = "Mild" });
            modelBuilder.Entity<SummaryEntity>().HasData(new SummaryEntity { Id = 6, Code = "Warm" });
            modelBuilder.Entity<SummaryEntity>().HasData(new SummaryEntity { Id = 7, Code = "Balmy" });
            modelBuilder.Entity<SummaryEntity>().HasData(new SummaryEntity { Id = 8, Code = "Hot" });
            modelBuilder.Entity<SummaryEntity>().HasData(new SummaryEntity { Id = 9, Code = "Sweltering" });
            modelBuilder.Entity<SummaryEntity>().HasData(new SummaryEntity { Id = 10, Code = "Scorching" });
            
            modelBuilder.Entity<WeatherEntity>().HasData(new
            {
                Id = 1, 
                TimeStamp = new DateTime(2020, 1, 1),
                Temperature = -1.3m,
                SummaryId = 3
            });
            
            modelBuilder.Entity<WeatherEntity>().HasData(new
            {
                Id = 2, 
                TimeStamp = new DateTime(2020, 1, 2),
                Temperature = 5.1m,
                SummaryId = 5
            });
            
            modelBuilder.Entity<WeatherEntity>().HasData(new
            {
                Id = 3, 
                TimeStamp = new DateTime(2020, 1, 3),
                Temperature = -10m,
                SummaryId = 1
            });
            
            //modelBuilder.Entity<WeatherEntity>().OwnsOne(p => p.Summary).HasData(new { Date = new DateTime(2020, 1, 1), Temperature = -1, Code = "Chill" });
            
            modelBuilder.Entity<UserEntity>(entity =>
            {
                entity.ToTable("User");
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Id).UseIdentityColumn();
                entity.HasOne(d => d.Role);
            });

            modelBuilder.Entity<RoleEntity>(entity =>
            {
                entity.ToTable("Role");
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Id).UseIdentityColumn();
            });
            
            modelBuilder.Entity<RoleEntity>().HasData(new RoleEntity { Id = 1, RoleName = "Admin" });
            modelBuilder.Entity<RoleEntity>().HasData(new RoleEntity { Id = 2, RoleName = "PM" });
            modelBuilder.Entity<RoleEntity>().HasData(new RoleEntity { Id = 3, RoleName = "QA" });
            modelBuilder.Entity<RoleEntity>().HasData(new RoleEntity { Id = 4, RoleName = "Programmer" });
            
            modelBuilder.Entity<UserEntity>().HasData(new
            {
                Id = 1,
                RoleId = 1,
                UserName = "Pupkin Vasiliy"
            });


            modelBuilder.Entity<UserEntity>().HasData(new
            {
                Id = 2,
                RoleId = 3,
                UserName = "Sidorov Saveliy"
            });
            
            modelBuilder.Entity<UserEntity>().HasData(new
            {
                Id = 3,
                RoleId = 4,
                UserName = "Petrov Mark"
            });
            modelBuilder.Entity<UserEntity>().HasData(new
            {
                Id = 4,
                RoleId = 2,
                UserName = "Ivanov Ivan"
            });
            
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
