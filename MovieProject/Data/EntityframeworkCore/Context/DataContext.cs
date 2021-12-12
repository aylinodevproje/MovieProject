using Microsoft.EntityFrameworkCore;
using MovieProject.Data.EntityframeworkCore.Models;
using System;

namespace MovieProject.Data.EntityframeworkCore.Context
{
    public class DataContext : DbContext//EntityFramework üzerinden inheritenca ile bu sınıf özelleştirildi.
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)//StartUp üzerinden DbContext ile configurasyonu sağlandı.
        {
            Database.EnsureCreated();//Veritabanı yoksa appsettings.json üzerinden alınan connectionstringe göre otomatik oluşturmak
        }

        //Veritabanı tablolarına eş değer Modeller aşağıda belirtildi.
        public virtual DbSet<User> User { get; set; }

        public virtual DbSet<Language> Language { get; set; }
        public virtual DbSet<MovieType> MovieType { get; set; }
        public virtual DbSet<Movie> Movie { get; set; }
        public virtual DbSet<MovieComment> MovieComment { get; set; }
        public virtual DbSet<Translate> Translate { get; set; }

        //Veritabanına otomatik olarak başlangıç verileri (SeedData) eklenmesi.
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
                     Culture = "en"
                 });

            modelBuilder.Entity<MovieType>().HasData(
            new MovieType()
            {
                ID = 1,
                Name = "Aile",
                Slug = "aile",
                LanguageID = 1
            },
            new MovieType()
            {
                ID = 2,
                Slug = "aksiyon",
                Name = "Aksiyon",
                LanguageID = 1
            },
            new MovieType()
            {
                ID = 3,
                Slug = "bilim-kurgu",
                Name = "Bilim Kurgu",
                LanguageID = 1
            },
            new MovieType()
            {
                ID = 4,
                Slug = "animasyon",
                Name = "Animasyon",
                LanguageID = 1
            },
            new MovieType()
            {
                ID = 5,
                Slug = "fantastik",
                Name = "Fantastik",
                LanguageID = 1
            },
            new MovieType()
            {
                ID = 6,
                Slug = "dram",
                Name = "Dram",
                LanguageID = 1
            },
            new MovieType()
            {
                ID = 7,
                Slug = "genclik",
                Name = "Gençlik",
                LanguageID = 1
            },
            new MovieType()
            {
                ID = 8,
                Slug = "gerilim",
                Name = "Gerilim",
                LanguageID = 1
            },
            new MovieType()
            {
                ID = 9,
                Slug = "gizem",
                Name = "Gizem",
                LanguageID = 1
            },
            new MovieType()
            {
                ID = 10,
                Slug = "komedi",
                Name = "Komedi",
                LanguageID = 1
            },
            new MovieType()
            {
                ID = 11,
                Slug = "korku",
                Name = "Korku",
                LanguageID = 1
            },
            new MovieType()
            {
                ID = 12,
                Slug = "macera",
                Name = "Macera",
                LanguageID = 1
            },
            new MovieType()
            {
                ID = 13,
                Slug = "muzikal",
                Name = "Müzikal",
                LanguageID = 1
            },

            new MovieType()
            {
                ID = 14,
                Slug = "western",
                Name = "Western",
                LanguageID = 1
            }
             );

            modelBuilder.Entity<Translate>().HasData(
           new Translate()
           {
               ID = 1,
               Key = "Home",
               Value = "Anasayfa",
               LanguageID = 1
           },
              new Translate()
              {
                  ID = 2,
                  Key = "Home",
                  Value = "Home",
                  LanguageID = 2
              },
                 new Translate()
                 {
                     ID = 3,
                     Key = "Register",
                     Value = "Üye Ol",
                     LanguageID = 1
                 },
                   new Translate()
                   {
                       ID = 4,
                       Key = "Login",
                       Value = "Giriş Yap",
                       LanguageID = 1
                   },
                      new Translate()
                      {
                          ID = 5,
                          Key = "Login",
                          Value = "Login",
                          LanguageID = 2
                      },
                         new Translate()
                         {
                             ID = 6,
                             Key = "tr",
                             Value = "Türkçe",
                             LanguageID = 1
                         },
                          new Translate()
                          {
                              ID = 7,
                              Key = "tr",
                              Value = "Turkey",
                              LanguageID = 2
                          },
                          new Translate()
                          {
                              ID = 8,
                              Key = "en",
                              Value = "İngilizce",
                              LanguageID = 1
                          },
                          new Translate()
                          {
                              ID = 9,
                              Key = "en",
                              Value = "English",
                              LanguageID = 2
                          },
                          new Translate()
                          {
                              ID = 10,
                              Key = "Logout",
                              Value = "Çıkış Yap",
                              LanguageID = 1
                          },
                          new Translate()
                          {
                              ID = 11,
                              Key = "Logout",
                              Value = "Log Out",
                              LanguageID = 2
                          },
                          new Translate()
                          {
                              ID = 12,
                              Key = "Register",
                              Value = "Register",
                              LanguageID = 2
                          }
                          ,
                          new Translate()
                          {
                              ID = 13,
                              Key = "LoginLink",
                              Value = "/tr/giris-yap",
                              LanguageID = 1
                          },
                          new Translate()
                          {
                              ID = 14,
                              Key = "LoginLink",
                              Value = "/en/login",
                              LanguageID = 2
                          },
                           new Translate()
                           {
                               ID = 15,
                               Key = "RegisterLink",
                               Value = "/tr/kayit-ol",
                               LanguageID = 1
                           },
                          new Translate()
                          {
                              ID = 16,
                              Key = "RegisterLink",
                              Value = "/en/register",
                              LanguageID = 2
                          }
                          ,
                           new Translate()
                           {
                               ID = 17,
                               Key = "LogoutLink",
                               Value = "/tr/cikis-yap",
                               LanguageID = 1
                           },
                          new Translate()
                          {
                              ID = 18,
                              Key = "LogoutLink",
                              Value = "/en/logout",
                              LanguageID = 2
                          }
                          ,
                           new Translate()
                           {
                               ID = 19,
                               Key = "RegisterText",
                               Value = "Üyelik oluşturmak için aşağıda bulunan alanları doldurunuz ve kayıt ol tuşuna basınız.",
                               LanguageID = 1
                           },
                          new Translate()
                          {
                              ID = 20,
                              Key = "RegisterText",
                              Value = "To create a membership, fill in the fields below and press the register button.",
                              LanguageID = 2
                          }
                           ,
                           new Translate()
                           {
                               ID = 21,
                               Key = "FullName",
                               Value = "Adı Soyadı",
                               LanguageID = 1
                           },

                           new Translate()
                           {
                               ID = 22,
                               Key = "UserName",
                               Value = "Kullanıcı Adı",
                               LanguageID = 1
                           },
                          new Translate()
                          {
                              ID = 23,
                              Key = "UserName",
                              Value = "User Name",
                              LanguageID = 2
                          }
                           ,
                           new Translate()
                           {
                               ID = 24,
                               Key = "Email",
                               Value = "E-posta",
                               LanguageID = 1
                           },
                          new Translate()
                          {
                              ID = 25,
                              Key = "Email",
                              Value = "Email Address",
                              LanguageID = 2
                          }
                           ,
                           new Translate()
                           {
                               ID = 26,
                               Key = "Password",
                               Value = "Şifre",
                               LanguageID = 1
                           },
                          new Translate()
                          {
                              ID = 27,
                              Key = "Password",
                              Value = "Password",
                              LanguageID = 2
                          }
                          ,
                           new Translate()
                           {
                               ID = 28,
                               Key = "EmailOrUserName",
                               Value = "Kulanıcı Adı veya E-posta",
                               LanguageID = 1
                           },
                          new Translate()
                          {
                              ID = 29,
                              Key = "EmailOrUserName",
                              Value = "Username or email",
                              LanguageID = 2
                          }
                            ,
                           new Translate()
                           {
                               ID = 30,
                               Key = "LoginText",
                               Value = "Üyelik bilgilerinizi kullanarak portala giriş yapınız.",
                               LanguageID = 1
                           },
                          new Translate()
                          {
                              ID = 31,
                              Key = "LoginText",
                              Value = "Log in to the portal using your membership information.",
                              LanguageID = 2
                          }
                          , new Translate()
                          {
                              ID = 32,
                              Key = "FullName",
                              Value = "Name Surname",
                              LanguageID = 2
                          }
                          ,
                          new Translate()
                          {
                              ID = 33,
                              Key = "Type",
                              Value = "Tür",
                              LanguageID = 1
                          }
                          , new Translate()
                          {
                              ID = 34,
                              Key = "Type",
                              Value = "Type",
                              LanguageID = 2
                          }
                           ,
                          new Translate()
                          {
                              ID = 35,
                              Key = "Director",
                              Value = "Yönetmen",
                              LanguageID = 1
                          }
                          , new Translate()
                          {
                              ID = 36,
                              Key = "Director",
                              Value = "Director",
                              LanguageID = 2
                          }
                           ,
                          new Translate()
                          {
                              ID = 37,
                              Key = "Players",
                              Value = "Oyuncular",
                              LanguageID = 1
                          }
                          , new Translate()
                          {
                              ID = 38,
                              Key = "Players",
                              Value = "Players",
                              LanguageID = 2
                          }
                            ,
                          new Translate()
                          {
                              ID = 39,
                              Key = "Duration",
                              Value = "Süresi",
                              LanguageID = 1
                          }
                          , new Translate()
                          {
                              ID = 40,
                              Key = "Duration",
                              Value = "Duration",
                              LanguageID = 2
                          }
                            ,
                          new Translate()
                          {
                              ID = 41,
                              Key = "Comment",
                              Value = "YORUMLAR",
                              LanguageID = 1
                          }
                          , new Translate()
                          {
                              ID = 42,
                              Key = "Comment",
                              Value = "COMMENTS",
                              LanguageID = 2
                          }
                          ,
                          new Translate()
                          {
                              ID = 43,
                              Key = "AddSubjectComment",
                              Value = "SENDE, YORUM YAP!",
                              LanguageID = 1
                          }
                          , new Translate()
                          {
                              ID = 44,
                              Key = "AddSubjectComment",
                              Value = "YOU HAVE COMMENT!",
                              LanguageID = 2
                          }
                            ,
                          new Translate()
                          {
                              ID = 45,
                              Key = "AddCommentButton",
                              Value = "Yorum Yap",
                              LanguageID = 1
                          }
                          , new Translate()
                          {
                              ID = 46,
                              Key = "AddCommentButton",
                              Value = "Comment",
                              LanguageID = 2
                          }
                             ,
                          new Translate()
                          {
                              ID = 47,
                              Key = "CommentLoginText",
                              Value = "Yorum yapmak için üye girişi yapmalısınız. Üye girişi yapmak için",
                              LanguageID = 1
                          }
                          , new Translate()
                          {
                              ID = 48,
                              Key = "CommentLoginText",
                              Value = "You must be logged in to post a comment. To login",
                              LanguageID = 2
                          }
                            ,
                          new Translate()
                          {
                              ID = 49,
                              Key = "Click",
                              Value = "TIKLA",
                              LanguageID = 1
                          }
                          , new Translate()
                          {
                              ID = 50,
                              Key = "Click",
                              Value = "CLICK",
                              LanguageID = 2
                          }
                               ,
                          new Translate()
                          {
                              ID = 51,
                              Key = "CommentError",
                              Value = "Lütfen mesaj alanını kontrol ederek tekrar deneyiniz!",
                              LanguageID = 1
                          }
                          , new Translate()
                          {
                              ID = 52,
                              Key = "CommentError",
                              Value = "Let's try an important question experiment!",
                              LanguageID = 2
                          }
                           ,
                          new Translate()
                          {
                              ID = 53,
                              Key = "IsLoginError",
                              Value = "Kullanıcı bilgileriniz doğru değil!",
                              LanguageID = 1
                          }
                          , new Translate()
                          {
                              ID = 54,
                              Key = "IsLoginError",
                              Value = "Your user information is not correct!",
                              LanguageID = 2
                          }
                            ,
                          new Translate()
                          {
                              ID = 55,
                              Key = "AnyUserError",
                              Value = "Bu bilgilerle daha önceden üyelik oluşturulmuş!",
                              LanguageID = 1
                          }
                          , new Translate()
                          {
                              ID = 56,
                              Key = "AnyUserError",
                              Value = "With this information, a membership has already been created!",
                              LanguageID = 2
                          }
                            ,
                          new Translate()
                          {
                              ID = 57,
                              Key = "FormError",
                              Value = "Lütfen alanları kontrol ederek tekrar deneyiniz!",
                              LanguageID = 1
                          }
                          , new Translate()
                          {
                              ID = 58,
                              Key = "FormError",
                              Value = "Please check the fields and try again!",
                              LanguageID = 2
                          }
                             ,
                          new Translate()
                          {
                              ID = 59,
                              Key = "InputErrorMessage",
                              Value = "Lütfen bu alanı doldurunuz!",
                              LanguageID = 1
                          }
                          , new Translate()
                          {
                              ID = 60,
                              Key = "InputErrorMessage",
                              Value = "Please fill this field!",
                              LanguageID = 2
                          }
            );

            modelBuilder.Entity<Movie>().HasData(
                new Movie()
                {
                    ID = 1,
                    Name = "David ve Elfler",
                    Slug = "david-ve-elfler",
                    Photo = "/images/dawid-i-elfy.jpg",
                    Imdb = "6.1",
                    Director = "Michal Rogalski",
                    Duration = "1 saat 45 dakika",
                    MovieTypeID = 1,
                    Subject = "Sürekli durmadan çalışmaktan dolayı yorgun düşmüş bir elf, yeni tanıştığı küçük bir çocuk sayesinde noel büyüsünü yaşamak için gerçek dünyaya kaçar…",
                    Players = "Cezary Zak, Cyprian Grabowski, Jakub Zajac",
                    VideoLink = "https://www.youtube.com/embed/pITv-pni8rM",
                });

            modelBuilder.Entity<MovieComment>().HasData(
                new MovieComment()
                {
                    ID = 1,
                    CreatedDate = DateTime.Now,
                    CommentText = "Muhteşem bir fildim. Teşekkürler admin!",
                    MovieID = 1,
                    UserID = 1
                });
            modelBuilder.Entity<MovieComment>().HasData(
               new MovieComment()
               {
                   ID = 2,
                   CreatedDate = DateTime.Now,
                   CommentText = "Kesinlikle bu filmi izleyin.",
                   MovieID = 1,
                   UserID = 2
               });

            base.OnModelCreating(modelBuilder);
        }
    }
}