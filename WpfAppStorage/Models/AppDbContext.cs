using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using WpfAppStorage.Models.Entities;

namespace WpfAppStorage.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Applicances> Applicances { get; set; }
        public DbSet<Provider> Providers { get; set; }  
        public DbSet <SectionsStorage> SectionsStorage { get; set; }
        public DbSet <TypeApplicances> TypeApplicances { get; set; }
        
        public AppDbContext ()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-OMG8DCU\\SQLEXPRESS;  Database=WpfAppStorageDB;  Persist Security Info =false; User='sa'; Password='sa'; MultipleActiveResultSets=True; Trusted_Connection=False;");       
        }

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            base.OnModelCreating (modelBuilder);

            modelBuilder.Entity<TypeApplicances>().HasData(new TypeApplicances
            {
                Id = 1,
                NameType = "Пылесос"
            });


            modelBuilder.Entity<SectionsStorage>().HasData(new SectionsStorage
            {
                Id = 1,
                NameSections = "Section A"
            });

            modelBuilder.Entity<Provider>().HasData(new Provider
            {
                Id = 1,
                NameCompany = "Company the beast",
                Country = "Belarus",
                City = "Minsk",
                Street = "Limonnaya",
                NumberHouse = 23,
                PhoneNumber = "+375299360451"
                
            });

            modelBuilder.Entity<Applicances>().HasData(new Applicances
            {
                Id = 1,
                Name = "Stiralca",
                TypeAplicancesid = 1,
                Price = 20,
                CountApplicances = 133,
                Providerid = 1,
                SectionsStorageid = 1,
                AddDate = DateTime.Now
            });
        }
    }
}
