using Microsoft.EntityFrameworkCore;
using MovieProject.Data.EntityframeworkCore.Models;

namespace MovieProject.Data.EntityframeworkCore.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Language> Language { get; set; }
        public virtual DbSet<MovieType> MovieType{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User()
                {
                    ID = 1,
                    FullName = "Alpay Gürel",
                    Email = "alpay.gurel",
                    IsAdmin = true,
                    Password = "weasd123",
                    UserName = "alpay.gurel"
                },
                 new User()
                 {
                     ID = 2,
                     FullName = "Alpay Gürel2",
                     Email = "alpay.gurel2",
                     IsAdmin = true,
                     Password = "weasd123",
                     UserName = "alpay.gurel2"
                 });

            modelBuilder.Entity<Language>().HasData(
                new Language()
                {
                    ID = 1,
                    Name = "Türkçe",
                    Culture = "tr"
                },
                 new Language()
                 {
                     ID = 2,
                     Name = "İngilizce",
                     Culture = "tr"
                 });

            modelBuilder.Entity<MovieType>().HasData(
            new MovieType()
            {
                ID = 1,
                Name = "Aile",
                LanguageID = 1
            },
            new MovieType()
            {
                ID = 2,
                Name = "Aksiyon",
                LanguageID = 1
            },
            new MovieType()
            {
                ID = 3,
                Name = "Bilim Kurgu",
                LanguageID = 1
            },
            new MovieType()
            {
                ID = 4,
                Name = "Animasyon",
                LanguageID = 1
            },
            new MovieType()
            {
                ID = 5,
                Name = "Fantastik",
                LanguageID = 1
            },
            new MovieType()
            {
                ID = 6,
                Name = "Dram",
                LanguageID = 1
            },
            new MovieType()
            {
                ID = 7,
                Name = "Gençlik",
                LanguageID = 1
            },
            new MovieType()
            {
                ID = 8,
                Name = "Gerilim",
                LanguageID = 1
            },
            new MovieType()
            {
                ID = 9,
                Name = "Gizem",
                LanguageID = 1
            },
            new MovieType()
            {
                ID = 10,
                Name = "Komedi",
                LanguageID = 1
            },
            new MovieType()
            {
                ID = 11,
                Name = "Korku",
                LanguageID = 1
            },
            new MovieType()
            {
                ID = 12,
                Name = "Macera",
                LanguageID = 1
            },
            new MovieType()
            {
                ID = 13,
                Name = "Müzikal",
                LanguageID = 1
            },

            new MovieType()
            {
                ID = 14,
                Name = "Western",
                LanguageID = 1
            }
             );


            base.OnModelCreating(modelBuilder);
        }
    }
}
