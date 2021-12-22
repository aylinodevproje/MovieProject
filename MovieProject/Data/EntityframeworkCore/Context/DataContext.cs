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
            #region User seed data
            modelBuilder.Entity<User>().HasData(
          new User()
          {
              ID = 1,
              FullName = "Aylin Aydın",
              Email = "u131210030@sakarya.edu.tr",
              IsAdmin = true,
              Password = "123",
              UserName = "u131210030@sakarya.edu.tr"
          });

            #endregion

            #region Language Seed Data
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
            #endregion

            #region MovieType seed data
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
                  Slug = "dram",
                  Name = "Dram",
                  LanguageID = 1
              },
              new MovieType()
              {
                  ID = 5,
                  Slug = "gerilim",
                  Name = "Gerilim",
                  LanguageID = 1
              },
              new MovieType()
              {
                  ID = 6,
                  Slug = "komedi",
                  Name = "Komedi",
                  LanguageID = 1
              },
              new MovieType()
              {
                  ID = 7,
                  Slug = "korku",
                  Name = "Korku",
                  LanguageID = 1
              },
              new MovieType()
              {
                  ID = 8,
                  Slug = "macera",
                  Name = "Macera",
                  LanguageID = 1
              },
              new MovieType()
              {
                  ID = 9,
                  Slug = "batili",
                  Name = "Batılı",
                  LanguageID = 1
              },
              new MovieType()
              {
                  ID = 10,
                  Name = "Family",
                  Slug = "family",
                  LanguageID = 2
              },
              new MovieType()
              {
                  ID = 11,
                  Slug = "actions",
                  Name = "Action",
                  LanguageID =2
              },
              new MovieType()
              {
                  ID = 12,
                  Slug = "sci-fi",
                  Name = "Sci-fi",
                  LanguageID = 2
              }, new MovieType()
              {
                  ID = 13,
                  Slug = "drama",
                  Name = "Drama ",
                  LanguageID =2
              }, new MovieType()
              {
                  ID = 14,
                  Slug = "tension",
                  Name = "Thriller",
                  LanguageID = 2
              },
              new MovieType()
              {
                  ID = 15,
                  Slug = "comedy",
                  Name = "Comedy",
                  LanguageID = 2
              }, new MovieType()
              {
                  ID = 16,
                  Slug = "horror",
                  Name = "Horror",
                  LanguageID = 2
              }, new MovieType()
              {
                  ID = 17,
                  Slug = "adventure",
                  Name = "Adventure",
                  LanguageID = 2
              }, new MovieType()
              {
                  ID = 18,
                  Slug = "western",
                  Name = "Western",
                  LanguageID = 2
              }

               );
            #endregion

            #region Translate Seed Data
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
            #endregion

            modelBuilder.Entity<Movie>().HasData(
            #region Türkçe
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
        }
                ,
                 new Movie()
                 {
                     ID = 2,
                     Name = "Kırık Kaset",
                     Slug = "kirik-kaset",
                     Photo = "/images/mixtape.jpg",
                     Imdb = "5.7",
                     Director = "Valerie Weiss",
                     Duration = "1 saat 33 dakika",
                     MovieTypeID = 1,
                     Subject = "12 yaşındaki Beverly, 1999 yılında ölen ebeveynleri tarafından kayıt edilmiş bir mixtape bulur ve bu şarkılardan yola çıkarak annesi ve babası hakkında daha fazla şey öğrenmeye çalışır…",
                     Players = "Jackson Rathbone, Julie Bowen, Nick Thune",
                     VideoLink = "https://www.youtube.com/embed/pITv-pni8rM",
                 }
                  ,
                 new Movie()
                 {
                     ID = 3,
                     Name = "Benim Güzel Noel Şatom",
                     Slug = "benim-guzel-noel-satom",
                     Photo = "/images/a-castle-for-christmas.jpg",
                     Imdb = "6.8",
                     Director = "Mary Lambert",
                     Duration = "1 saat 38 dakika",
                     MovieTypeID = 1,
                     Subject = "Kitapları çok satan bir yazar, bir skandaldan kaçmak için İskoçya’ya gider ve buradaki bir şatoyu çok beğenir. Ancak şatonun sahibi olan huysuz dükle anlaşmazlığa düşer.",
                     Players = "Brooke Shields, Cary Elwes, Suanne Braun",
                     VideoLink = "https://www.youtube.com/embed/pITv-pni8rM",
                 }
                   ,
                 new Movie()
                 {
                     ID = 4,
                     Name = "Honey Girls",
                     Slug = "honey-girls",
                     Photo = "/images/honey-girls.jpg",
                     Imdb = "8.5",
                     Director = "Trey Fanjoy",
                     Duration = "1 saat 30 dakika",
                     MovieTypeID = 1,
                     Subject = "Mega pop yıldızı Fancy G (Ashanti), bir sonraki büyük solo sanatçıyı bulmak için bir yarışma düzenler. Ancak genç yarışmacılar, “birlikte daha iyi” olduklarını fark ederler ve gizlice Honey Girls adlı bir grup kurarlar.",
                     Players = "Aliyah Mastin, Ashanti, Ava Grace",
                     VideoLink = "https://www.youtube.com/embed/pITv-pni8rM",
                 }
                  ,
                 new Movie()
                 {
                     ID = 5,
                     Name = "Kutup Macerası",
                     Slug = "kutup-macerasi",
                     Photo = "/images/Eight-Below-2006.jpg",
                     Imdb = "8.5",
                     Director = "Trey Fanjoy",
                     Duration = "1 saat 32 dakika",
                     MovieTypeID = 1,
                     Subject = "Paul Walker’ın yanı sıra Jason Biggs ve Bruce Greenwood gibi isimlerinde başrolde yer aldığı Kutup Macerası adlı yapım 2006 yılında Aile,Macera ve Dram tadında bir yapım olarak sinema severlere sunulduğunda oldukça kaliteli bir yapım olduğunu kanıtlayarak IMDB’de 7, 3 değerinde puanı kapmıştır.Yönetmenliğini Frank Marshall’ın yaptığı film 2 saatlik bir süre ile film severleri David DiGilio’nun yazdığı hikaye ile kutuplara doğru bir yolculuğa çıkarıyor…",
                     Players = "Bruce Greenwood, Jason Biggs, Paul Walker",
                     VideoLink = "https://www.youtube.com/embed/pITv-pni8rM",
                 }

                     ,
                 new Movie()
                 {
                     ID = 6,
                     Name = "Arınma Gecesi",
                     Slug = "arinma-gecesi",
                     Photo = "/images/The-Forever-Purge-2021.jpg",
                     Imdb = "7.7",
                     Director = "Everardo Gout",
                     Duration = "2 saat 32 dakika",
                     MovieTypeID = 2,
                     Subject = "Adela ve Juan gayet huzurlu bir çift olarak yaşamlarını sürdürürken, Anlamadıkları bir biçimde Texas’ta bir çiftlik evinde mahsur kalırlar. Bir uyuşturucu kartelinden kaçmakta olan çift için Arınma Gecesi zamanı da başlayacaktır…",
                     Players = "Ana de la Reguera, Josh Lucas, Tenoch Huerta",
                     VideoLink = "https://www.youtube.com/embed/pITv-pni8rM",
                 }
                    ,
                 new Movie()
                 {
                     ID = 7,
                     Name = "Black Widow",
                     Slug = "black-widow",
                     Photo = "/images/Black-Widow-2021.jpg",
                     Imdb = "7.8",
                     Director = "Everardo Gout",
                     Duration = "1 saat 33 dakika",
                     MovieTypeID = 2,
                     Subject = "Unutmak istediği geçmişinden çıka gelen ailesiyle büyük bir tehdide karşı iş birliği yapmak zorunda kalan Kara Dul’un geçmişiyle ilgili büyük bir komplo teorisi keşfeder. Bu yüzden hayatının en karanlık taraflarıyla yüzleşmek zorunda kalan Romanoff, henüz bir Avenger olmadan önce bozduğu ilişkilerinin üstesinden de gelmek zorunda kalacaktır…",
                     Players = "David Harbour, Florence Pugh, Rachel Weisz, Scarlett Johansson",
                     VideoLink = "https://www.youtube.com/embed/pITv-pni8rM",
                 },
                 new Movie()
                 {
                     ID = 8,
                     Name = "Son Düello",
                     Slug = "son-duello",
                     Photo = "/images/the-last-duel.jpg",
                     Imdb = "8.8",
                     Director = "Ridley Scott",
                     Duration = "1 saat 33 dakika",
                     MovieTypeID = 2,
                     Subject = "Norman (Normandiya’da yaşayan Frenk ve İskandinav kökenli halk) şövalyesi Jean de Carrouges ve Norman beyi Jacques le Gris eskiden çok yakın arkadaşlardır. Carrouges savaşa gider ve döndüğünde hiçbir şey eskisi gibi değildir. le Gris, Carrouges’in karısına tecavüz etmek suçundan yargılanıyordur. Ancak kimse Margerite’e inanmaz. Bunun üzerine asker, karara itiraz etmek üzere Fransa kralına kadar gider. Hakim açısından ise Le Gris avantajlı konumdadır. Mahkemenin yeni kararına göre iki adam düello yapacak ve bu düellonun sonucunca biri ölecektir. Hayatta kalan kişi Tanrı’nın isteğini yerine getirmiş olacak ve eğer ki Le Gris hayatta kalırsa da aklanacaktır. Ayrıca eğer ki Carrouges kaybederse karısı ceza olarak bir kazığa bağlanarak yakılacaktır.",
                     Players = "Adam Driver, Jodie Comer, Matt Damon",
                     VideoLink = "https://www.youtube.com/embed/pITv-pni8rM",
                 },
                 new Movie()
                 {
                     ID = 9,
                     Name = "Buz Yolu",
                     Slug = "buz-yolu",
                     Photo = "/images/The-Ice-Road-2021.jpg",
                     Imdb = "8.9",
                     Director = "Jonathan Hensleigh",
                     Duration = "1 saat 53 dakika",
                     MovieTypeID = 2,
                     Subject = "Bir nakliye şirketinin sahibi olan Goldenrod, karlarla kaplı tehlikeli bir yolculuk için Mike isimli bir şoför ile anlaşır. Kanada’nın kuzey bölgesinde bir elmas madeni çökmüştür ve insanlar burada mahsur kalmıştır. Yardım gelmesini bekleyen insanların imdadına Mike yetişecektir…",
                     Players = "Holt McCallany, Liam Neeson, Matt McCoy",
                     VideoLink = "https://www.youtube.com/embed/pITv-pni8rM",
                 },
                 new Movie()
                 {
                     ID = 10,
                     Name = "Finch",
                     Slug = "finch",
                     Photo = "/images/finch.jpg",
                     Imdb = "9.2",
                     Director = "Miguel Sapochnik",
                     Duration = "1 saat 53 dakika",
                     MovieTypeID = 3,
                     Subject = "Bilim kurgu türdeki Finch, post-apokaliptik bir dönemde geçiyor. Dünya’nın yıkıma uğramasının ardından ölmekte olan yaratıcısının köpeğini korumak için yapılan bir robot, sevgiyi, dostluğu ve insan olmanın ne demek olduğunu anlamaya başlar…",
                     Players = "Caleb Landry Jones, Lora Martinez-Cunningham, Tom Hanks",
                     VideoLink = "https://www.youtube.com/embed/pITv-pni8rM",
                 },
                 new Movie()
                 {
                     ID = 11,
                     Name = "Dune",
                     Slug = "dune",
                     Photo = "/images/dune.jpg",
                     Imdb = "9.8",
                     Director = "Miguel Sapochnik",
                     Duration = "1 saat 53 dakika",
                     MovieTypeID = 3,
                     Subject = "Yeniden uyarlama olarak karşımıza çıkan dram, bilim kurgu ve macera türdeki Duna Çöl Gezegeni filmi, Denis Villeneuve tarafından yönetilmiştir. Günümüzden çok uzak bir gelecekte geçen hikayede, ailesi çöl gezegeni Arrakis’in kontrolüne sahip olan Paul Atreides’in hikayesini izliyoruz…",
                     Players = "Rebecca Ferguson, Timothée Chalamet, Zendaya",
                     VideoLink = "https://www.youtube.com/embed/pITv-pni8rM",
                 }
                 ,
                 new Movie()
                 {
                     ID = 12,
                     Name = "Implant",
                     Slug = "implant",
                     Photo = "/images/implanted.jpg",
                     Imdb = "7.8",
                     Director = "Fabien Dufils",
                     Duration = "1 saat 55 dakika",
                     MovieTypeID = 3,
                     Subject = "Sarah, baş ağrılarıyla mücadele etmekten çok yorulmuştur ve deneysel bir tedavi için çip taktırmaya karar verir. Fakat çipin kontrolü altına girdiğinde hayatta kalmak için savaşmak zorunda kalacaktır…",
                     Players = "Michelle Girolami, Nader Boussandel, Scott Broughton",
                     VideoLink = "https://www.youtube.com/embed/pITv-pni8rM",
                 }
                  ,
                 new Movie()
                 {
                     ID = 13,
                     Name = "Koma",
                     Slug = "koma",
                     Photo = "/images/coma-2020-izle.jpg",
                     Imdb = "6.8",
                     Director = "Nikita Argunov",
                     Duration = "2 saat 55 dakika",
                     MovieTypeID = 3,
                     Subject = "Gizemli bir olay sonucunda genç ve yetenekli bir mimar gerçeği andıran bir dünyada gözlerini yeniden açar. Bu dünya içinde yaşayanların anılarına dayanmaktadır. Bu insanlar da genellikle uzun süre komada kalan insanlardır. Tüm fizik kuralları aşılacak, mimar ise hayatının aşkıyla tanışıp yaşam mücadelesi verecektir.",
                     Players = "Aleksey Serebryakov, Lyubov Aksyonova, Milos Bikovic, Rinal Mukhametov",
                     VideoLink = "https://www.youtube.com/embed/pITv-pni8rM",
                 }
                 ,
                 new Movie()
                 {
                     ID = 14,
                     Name = "Küçük Balık",
                     Slug = "kucuk-balik",
                     Photo = "/images/Little-Fish-2020-film.jpg",
                     Imdb = "6.2",
                     Director = "Chad Hartigan",
                     Duration = "2 saat 55 dakika",
                     MovieTypeID = 3,
                     Subject = "Dünya çapında etkisini gösteren bir pandemi, insanların hafızasını kaybetmesine sebep olur. Virüse maruz kalan insanlar nedeni bilinmeyen bir sebepten ötürü her şeyi unutmaktadır. Emma ve Jude çifti de henüz yeni evlenmiştir ve aradan çok zaman geçmeden bu dünyanın bir parçası haline gelirler. Jude’un hastalığa yakalanmasıyla aşklarını yaşatmak için her şeyi yapacaklardır…",
                     Players = "Jack O'Connell, Olivia Cooke, Raúl Castillo, Soko",
                     VideoLink = "https://www.youtube.com/embed/pITv-pni8rM",
                 }
                  ,
                 new Movie()
                 {
                     ID = 15,
                     Name = "Küçük Balık",
                     Slug = "kucuk-balik",
                     Photo = "/images/Little-Fish-2020-film.jpg",
                     Imdb = "6.2",
                     Director = "Chad Hartigan",
                     Duration = "2 saat 55 dakika",
                     MovieTypeID = 4,
                     Subject = "Dünya çapında etkisini gösteren bir pandemi, insanların hafızasını kaybetmesine sebep olur. Virüse maruz kalan insanlar nedeni bilinmeyen bir sebepten ötürü her şeyi unutmaktadır. Emma ve Jude çifti de henüz yeni evlenmiştir ve aradan çok zaman geçmeden bu dünyanın bir parçası haline gelirler. Jude’un hastalığa yakalanmasıyla aşklarını yaşatmak için her şeyi yapacaklardır…",
                     Players = "Jack O'Connell, Olivia Cooke, Raúl Castillo, Soko",
                     VideoLink = "https://www.youtube.com/embed/pITv-pni8rM",
                 }
                  ,
                 new Movie()
                 {
                     ID = 16,
                     Name = "Eternals",
                     Slug = "eternals",
                     Photo = "/images/eternals.jpg",
                     Imdb = "7.2",
                     Director = "Chloé Zhao",
                     Duration = "1 saat 45 dakika",
                     MovieTypeID = 4,
                     Subject = "Deviantlar’in tarihe karıştığı ve artık ortalıkta olmadıkları düşünülmektedir. Fakat insanlığın en eski ve en ezeli düşmanı Deviantlar beklenmedik bir şekilde geri döner. Böylece Eternals’ın insanlığı son bir kez daha kurtarması gerekecektir…",
                     Players = "Angelina Jolie, Gemma Chan, Richard Madden",
                     VideoLink = "https://www.youtube.com/embed/pITv-pni8rM",
                 }
                     ,
                 new Movie()
                 {
                     ID = 17,
                     Name = "Gizemli Delik",
                     Slug = "gizemli-delik",
                     Photo = "/images/the-whole-truth.jpg",
                     Imdb = "7.7",
                     Director = "Wisit Sasanatieng",
                     Duration = "1 saat 35 dakika",
                     MovieTypeID = 4,
                     Subject = "İki kardeşin dedeleriyle ninelerinin evinin duvarında tuhaf bir delik bulmasıyla başlayan korkunç olaylar, aileleriyle ilgili uğursuz sırları ortaya çıkarır.",
                     Players = "Sadanont Durongkaweroj, Sompob Benjathikul, Steven Isarapong",
                     VideoLink = "https://www.youtube.com/embed/pITv-pni8rM",
                 }
                  ,
                 new Movie()
                 {
                     ID = 18,
                     Name = "Relic",
                     Slug = "relic",
                     Photo = "/images/the-whole-truth.jpg",
                     Imdb = "7.7",
                     Director = "Natalie Erika James",
                     Duration = "1 saat 19 dakika",
                     MovieTypeID = 4,
                     Subject = "Edna’ nın kızı Kay ve torunu Sam, birlikte Edna’yı bulmak için eve geri dönerler. Edna, kısa bir süre önce ortadan kaybolup sonrasında hiçbir şey olmamış gibi geri dönmüştür. Ancak davranışlarında şiddet vardır ve eskisi gibi değildir. Çok geçmeden Kay ve Sam, Edna’da bir tuhaflık olduğunu ve evde doğaüstü güçlerin var olduğunu fark edeceklerdir.",
                     Players = "Bella Heathcote, Chris Bunton, Emily Mortimer, Robyn Nevin",
                     VideoLink = "https://www.youtube.com/embed/pITv-pni8rM",
                 }
                  ,
                 new Movie()
                 {
                     ID = 19,
                     Name = "Ölmek İçin Zaman Yok",
                     Slug = "olmek-icin-zaman-yok",
                     Photo = "/images/No-Time-to-Die-2021-film.jpg",
                     Imdb = "8.7",
                     Director = "Cary Joji Fukunaga",
                     Duration = "1 saat 19 dakika",
                     MovieTypeID = 5,
                     Subject = "Tüm zamanların en iyi İngiliz ajanı James Bond, artık aktif olarak hizmet vermemektedir. Jamaika’da sakin bir hayat sürmeye çalışan Bond, CIA’de çalışan eski arkadaşı Felix’e yardım etmek için sakin hayatını tekrar geride bırakmak zorunda kalacaktır…",
                     Players = "Ashley Greene, Ryan Phillippe, Scott Adkins",
                     VideoLink = "https://www.youtube.com/embed/pITv-pni8rM",
                 }
                     ,
                 new Movie()
                 {
                     ID = 20,
                     Name = "One Shot",
                     Slug = "one-shot",
                     Photo = "/images/one-shot.jpg",
                     Imdb = "7.1",
                     Director = "James Nunn",
                     Duration = "1 saat 19 dakika",
                     MovieTypeID = 5,
                     Subject = "Tüm zamanların en iyi İngiliz ajanı James Bond, artık aktif olarak hizmet vermemektedir. Jamaika’da sakin bir hayat sürmeye çalışan Bond, CIA’de çalışan eski arkadaşı Felix’e yardım etmek için sakin hayatını tekrar geride bırakmak zorunda kalacaktır…",
                     Players = "Ashley Greene, Ryan Phillippe, Scott Adkins",
                     VideoLink = "https://www.youtube.com/embed/pITv-pni8rM",
                 }
                  ,
                 new Movie()
                 {
                     ID = 21,
                     Name = "Zamanda Tutsak",
                     Slug = "zamanda-tutsak",
                     Photo = "/images/old-2021.jpg",
                     Imdb = "7.2",
                     Director = "M. Night Shyamalan",
                     Duration = "1 saat 19 dakika",
                     MovieTypeID = 5,
                     Subject = "Tropik bir tatile giden ve sonuna kadar keyfini çıkarmayı planlayan bir aile, tenha bir plajda dinlendikleri sıralarda beklemedikleri garip durumlarla karşılaşır. Plajın üzerindeyken anlam veremedikleri bir şekilde hızla yaşlanmaya başlarlar…",
                     Players = "Gael García Bernal, Rufus Sewell, Vicky Krieps",
                     VideoLink = "https://www.youtube.com/embed/pITv-pni8rM",
                 }
                    ,
                 new Movie()
                 {
                     ID = 22,
                     Name = "Av Günü",
                     Slug = "av-gunu",
                     Photo = "/images/prey.jpg",
                     Imdb = "7.3",
                     Director = "Thomas Sieben",
                     Duration = "1 saat 30 dakika",
                     MovieTypeID = 5,
                     Subject = "Beş yakın arkadaş vahşi doğa gezisine çıkar ve gizemli bir tetikçinin peşlerine düştüğünü gördüklerinde ölümcül kovalamaca başlar…",
                     Players = "David Kross, Hanno Koffler, Maria Ehrich",
                     VideoLink = "https://www.youtube.com/embed/pITv-pni8rM",
                 }
                    ,
                 new Movie()
                 {
                     ID = 23,
                     Name = "Güzel Poz",
                     Slug = "guzel-poz",
                     Photo = "/images/Guzel-Poz-2019.jpg",
                     Imdb = "7.4",
                     Director = "Dolly Wells",
                     Duration = "1 saat 25 dakika",
                     MovieTypeID = 6,
                     Subject = "Sinema okulundan yeni mezun olan Lilian sevgilisinden ayrılmıştır ve babası onu geçici bir süreliğine kalması için aile dostlarının ve Güzel Poz’un da yazarı olan Julia Price’ın evine gönderir. Ev sahibi ile genç kız arasında beklenmedik sürtüşmeler başlayacaktır…",
                     Players = "Ebon Moss-Bachrach, Gary Richardson, Grace Van Patten, Zadie Smith",
                     VideoLink = "https://www.youtube.com/embed/pITv-pni8rM",
                 }
                   ,
                 new Movie()
                 {
                     ID = 24,
                     Name = "Kimsin Sen?",
                     Slug = "kimsin-sen",
                     Photo = "/images/Good-on-Paper-2021.jpg",
                     Imdb = "8.4",
                     Director = "Kimmy Gatewood",
                     Duration = "1 saat 25 dakika",
                     MovieTypeID = 6,
                     Subject = "Yıllardır kariyeri üzerine yoğunlaşan Andrea Singer bir komedyendir ve artık aşk hayatında aradığı erkeği bulmanın vaktinin geldiğini düşünür. Her şey kusursuz ilerlerken bulduğu erkeğin doğru kişi olup olmadığı konusunda şüphelenmeye başlayacaktır…",
                     Players = "Iliza Shlesinger, Rebecca Rittenhouse, Ryan Hansen",
                     VideoLink = "https://www.youtube.com/embed/pITv-pni8rM",
                 }
                 ,
                 new Movie()
                 {
                     ID = 25,
                     Name = "Vahşi Rose",
                     Slug = "vahsi-rose",
                     Photo = "/images/Wild-Rose-2018-film.jpg",
                     Imdb = "9.4",
                     Director = "Tom Harper",
                     Duration = "1 saat 25 dakika",
                     MovieTypeID = 6,
                     Subject = "Rose-Lynn, sevilen ünlü bir müzisyen olmanın hayalini kuran genç bir kadındır. Her zaman uçarı biri olan Rose, işlediği bir suçtan ötürü hapis yatmış ve sonunda denetimli serbestlik şartıyla özgür kalmıştır. Bundan sonra ayağında bileklik ile hayatını devam ettirmeye çalışan genç kadın aynı zamanda bir annedir ve iki çocuğunun yanına dönerek sorumluluklar edinecektir. Çocuklarına iyi bakabilmek için iş arayışına giren Rose, hayallerinin peşinden giderek country şarkıcısı olmak ister. Fakat bu hayali yüzünden annesi Marion’un büyük tepkisini çeker ve Rose’un çocuklarına sahip çıkan sorumluluk sahibi bir yetişkin olmasını ister…",
                     Players = "Jane Patterson, Jessie Buckley, Lesley Hart, Matt Costello",
                     VideoLink = "https://www.youtube.com/embed/pITv-pni8rM",
                 }
                   ,
                 new Movie()
                 {
                     ID = 26,
                     Name = "Fortress",
                     Slug = "fortress",
                     Photo = "/images/fortress.jpg",
                     Imdb = "9.4",
                     Director = "James Cullen Bressack",
                     Duration = "1 saat 25 dakika",
                     MovieTypeID = 6,
                     Subject = "Robert, ormanda gizli bir tatil köyünde yaşayan emekli bir CIA ajanıdır. Uzun zamandır görüşmediği oğlu bir ziyaret için kampa gelirken, Robert’ın eski düşmanı Balzary da onu takip eder. Bölge, Balzary’nin saldırı timi tarafından kuşatılırken, baba ve oğul yüksek teknolojili bir sığınağa çekilir. Sığınağın çelik duvarları ve gelişmiş silahları, Balzary’nin intikam için kana susamış planlarına uyacak kadar güçlü müdür?",
                     Players = "Bruce Willis, Chad Michael Murray, Jesse Metcalfe, Shannen Doherty",
                     VideoLink = "https://www.youtube.com/embed/pITv-pni8rM",
                 }
                  ,
                 new Movie()
                 {
                     ID = 27,
                     Name = "Caveat",
                     Slug = "caveat",
                     Photo = "/images/Caveat-2020.jpg",
                     Imdb = "5.4",
                     Director = "Damian Mc Carthy",
                     Duration = "1 saat 45 dakika",
                     MovieTypeID = 7,
                     Subject = "Isaac hafıza kaybı yaşamaktadır ve Barrett’in toplumdan izola bir ada içerisinde terk edilmiş bir evde yaşayan ve psikolojik açıdan sorunları olan yeğeni Olga’ya para karşılığında bakmayı kabul etmiştir. Fakat eve vardığında durumların çok farklı olduğunu anlayacaktır…",
                     Players = "Ben Caplan, Conor Dwane, Jonathan French, Leila Sykes",
                     VideoLink = "https://www.youtube.com/embed/pITv-pni8rM",
                 }
                   ,
                 new Movie()
                 {
                     ID = 28,
                     Name = "Gaia",
                     Slug = "gaia",
                     Photo = "/images/Gaia-2021.jpg",
                     Imdb = "5.4",
                     Director = "Jaco Bouwer",
                     Duration = "1 saat 47 dakika",
                     MovieTypeID = 7,
                     Subject = "İlkel bir ormanın derinliklerinde gözetleme kulesinde görev yapan iki korucunun başına talihsiz bir olay gelir ve dış dünyadan soyutlanmış iki kişiyle karşılaşırlar. Karşılaştıkları çocuk ve onun babası, kendi dinleri ve doğayla iç içe gizemli ilişkileri dikkatlerini çeker. Bu noktadan sonra korucuların başına garip olaylar gelmeye başlar…",
                     Players = "Andi Matichak, Cranston Johnson, Emile Hirsch, Luke David Blumm",
                     VideoLink = "https://www.youtube.com/embed/pITv-pni8rM",
                 }
                   ,
                 new Movie()
                 {
                     ID = 29,
                     Name = "Son",
                     Slug = "son",
                     Photo = "/images/son-2021-film.jpg",
                     Imdb = "8.8",
                     Director = "Ivan Kavanagh",
                     Duration = "1 saat 47 dakika",
                     MovieTypeID = 7,
                     Subject = "İlkel bir ormanın derinliklerinde gözetleme kulesinde görev yapan iki korucunun başına talihsiz bir olay gelir ve dış dünyadan soyutlanmış iki kişiyle karşılaşırlar. Karşılaştıkları çocuk ve onun babası, kendi dinleri ve doğayla iç içe gizemli ilişkileri dikkatlerini çeker. Bu noktadan sonra korucuların başına garip olaylar gelmeye başlar…",
                     Players = "Andi Matichak, Cranston Johnson, Emile Hirsch, Luke David Blumm",
                     VideoLink = "https://www.youtube.com/embed/pITv-pni8rM",
                 }
                  ,
                 new Movie()
                 {
                     ID = 30,
                     Name = "Spell",
                     Slug = "spell",
                     Photo = "/images/spell-2020-izle.jpg",
                     Imdb = "7.8",
                     Director = "Mark Tonderai",
                     Duration = "1 saat 47 dakika",
                     MovieTypeID = 7,
                     Subject = "Appalachia’nın kırsal kesiminde ailesiyle uçağı düşen bir adam, kendini bir anda geleneksel bir büyücünün evinde uyanmış halde bulur. Ay tutulması yaşanmadan önce lanetli evden uzaklaşmaya çalışacak ve ailesini bulmanın yollarını arayacaktır.",
                     Players = "Loretta Devine, Omari Hardwick",
                     VideoLink = "https://www.youtube.com/embed/pITv-pni8rM",
                 }
                   ,
                 new Movie()
                 {
                     ID = 31,
                     Name = "Double World",
                     Slug = "double-world",
                     Photo = "/images/double-world-2019-izle.jpg",
                     Imdb = "8.9",
                     Director = "Teddy Chan",
                     Duration = "1 saat 19 dakika",
                     MovieTypeID = 8,
                     Subject = "10 uluslu fantastik bir evrende geçen filmde, komşu ülkenin giderek güçlendiğini fark eden bir savaş lordu en iyi savaşçılarını bulmak için bir yarışma düzenler. Bu haberi duyan cesur köylü Dong Yilong köyü her ne kadar onun başarısından şüphe duysa da yarışmaya katılmaya karar verecek, efsanevi bir maceraya atılacaktır.",
                     Players = "Luxia Jiang, Mark Cheng, Ming Hu, Peter Ho",
                     VideoLink = "https://www.youtube.com/embed/pITv-pni8rM",
                 }
                   ,
                 new Movie()
                 {
                     ID = 32,
                     Name = "John Carter",
                     Slug = "john-carter",
                     Photo = "/images/john-carter-filmi.jpg",
                     Imdb = "9.7",
                     Director = "Andrew Stanton",
                     Duration = "1 saat 19 dakika",
                     MovieTypeID = 8,
                     Subject = "Andrew Stanton senaryosunu hazırlayarak yönetmenliğini yaptığı 2012, 9 Mart Türkiye gösterim tarihli John Carter 2 saat 12 dakikaya yakın süresi ile izleyiciye Aksiyon, Macera ve Fantastik türünü yansıtıyor ve bu süre seyredenleri fazlasıyla doyuruyor. Başrolde ünlü oyuncu Taylor Kitsch başta olmak üzere Lynn Collins ve Willem Dafoe gibi isimlerin yer aldığı John Carter İki Dünya Arasında, 284 Milyon Dolarlık hasılata da sahiptir.",
                     Players = "Lynn Collins, Samantha Morton, Taylor Kitsch, Willem Dafoe",
                     VideoLink = "https://www.youtube.com/embed/pITv-pni8rM",
                 }
                    ,

                 new Movie()
                 {
                     ID = 33,
                     Name = "Dev Avcısı Jack",
                     Slug = "dev-avcisi-jack",
                     Photo = "/images/dev-avcisi-jack-2013-filmi.jpg",
                     Imdb = "8.7",
                     Director = "Bryan Singer",
                     Duration = "1 saat 54 dakika",
                     MovieTypeID = 8,
                     Subject = "Kral McShane’ın güzeller güzeli kızı Prenses Isabella devler tarafından kaçırılır ve kral en iyi şövalyelerine kızını kurtarma emri verir. Jack ise sıradan bir çiftlik işçisidir ve Isabella’yı kurtarma görevi için gönüllü olmak ister. İnsanlar ve Devler dünyası arasında köprü görevi görecek fasulye sırığı ile bir geçit oluştururlar ve insan kanına aç devlerin dünyasına giriş yaparlar. Prenses Isabella’yı kurtarmanın yanısıra insanlığın geleceği de Jack’in elinde olacaktır…",
                     Players = "Eleanor Tomlinson, Ewan McGregor, Nicholas Hoult, Stanley Tucci",
                     VideoLink = "https://www.youtube.com/embed/pITv-pni8rM",
                 }
                       ,
                 new Movie()
                 {
                     ID = 34,
                     Name = "Old Henry",
                     Slug = "old-henry",
                     Photo = "/images/old-henry.jpg",
                     Imdb = "8.1",
                     Director = "Potsy Ponciroli",
                     Duration = "1 saat 25 dakika",
                     MovieTypeID = 9,
                     Subject = "Eşini kaybetmiş çiftçi Yaşlı Henry, oğluyla birlikte yaşamaya devam etmektedir ve yaralı bir adamı çanta dolusu parasıyla birlikte evinde misafir eder. Kanunu temsil ettiklerini iddia eden bir grup parayı almak için geldiklerinde Henry’nin kime güveneceği konusunda bir karar vermesi gerekecektir…",
                     Players = "Gavin Lewis, Scott Haze, Tim Blake Nelson",
                     VideoLink = "https://www.youtube.com/embed/pITv-pni8rM",
                 }
                   ,
                 new Movie()
                 {
                     ID = 35,
                     Name = "The Outsider",
                     Slug = "the-outsider",
                     Photo = "/images/The-Outsider-2019.jpg",
                     Imdb = "8.3",
                     Director = "Timothy Woodward Jr.",
                     Duration = "1 saat 22 dakika",
                     MovieTypeID = 9,
                     Subject = "Daha iyi bir yaşam arayışı içinde olan bir demiryolu işçisi kendisini bir grup yozlaşmış kanun koruyucunun yanında bulur. Mareşal kentini kontrol etmeye çalışırken, trajedi onu adalet ve aile arasında karar vermeye zorlar. 2019 ABD yapımı The Outsider filmini Timothy Woodward Jr. yönetiyor.",
                     Players = "Jon Foo, Kaiwi Lyman, Sean Patrick Flanery, Trace Adkins",
                     VideoLink = "https://www.youtube.com/embed/pITv-pni8rM",
                 }
                  ,
                 new Movie()
                 {
                     ID = 36,
                     Name = "Compshop",
                     Slug = "Copshop",
                     Photo = "/images/copshop.jpg",
                     Imdb = "8.3",
                     Director = "S. Craig Zahler",
                     Duration = "2 saat 22 dakika",
                     MovieTypeID = 9,
                     Subject = "Eski usül olarak çekimleri ABD’de gerçekleştirilen Wester ve Korku unsurları içeren Bone Tomahawk filminde, bir grup esiri yamyam kabilelerden birinin elinden kurtarmaya çalışan, dört cesur yürekli adamın mücadelesi anlatılıyor.",
                     Players = "Kurt Russell, Lili Simmons, Patrick Wilson",
                     VideoLink = "https://www.youtube.com/embed/pITv-pni8rM",
                 }
                  ,
                 new Movie()
                 {
                     ID = 37,
                     Name = "Bone Tomahawk",
                     Slug = "bone-tomahawk",
                     Photo = "/images/bone-tomahawk-izle.jpg",
                     Imdb = "8.8",
                     Director = "Gore Verbinski",
                     Duration = "2 saat 22 dakika",
                     MovieTypeID = 9,
                     Subject = "Tüm dünya tarafından sevilen oyuncu Johnny Depp başta olmak üzere Armie Hammer ve William Fichtner gibi usta isimlerin başrol olarak oynadığı Maskeli Süvari filmi ülkemize biraz gecikmeli olarak 5 Temmuz 2013 tarihinde gelmiş ve özellikle Johnny Depp hayranları tarafından sinema salonları dolup taşmıştı. Gore Verbinski’nin yönetmen koltuğunda oturduğu Maskeli Süvari filmi İMDB cephesinden aldığı 6.5 değerindeki puan ile sevenleri tarafından yetersiz bulunsa da, oldukça iyi bir puan gibi duruyor. 149 dakikalık inanılmaz bir uzunluğa sahiptir. Vahşi batı, aksiyon ve macera unsurlarını yaşatan filmde Johnny Depp sayesinde çok komik anlarda yaşayacaksınız. Justin Haythe’in senaristliğini yaptığı filmin çekimleri Amerika Birleşik Devletlerinde yapılmış ve yaklaşık 250 Milyon Dolarlık bir bütçe ile çekilmiştir. 260 Milyon civarında bir gişe hasılatı yapan Maskeli Süvari, DVD ve Bluray satışlarından da 100 Milyon Doları aşkın bir gelir elde etmiştir. 1930 yıllarında ilk kez Amerika’da eski bir radyo programı tarafından kurgulanan bu karakter yıllar geçtikçe çizgi romanlara ve hatta beyazperdeye konuk olmayı başarmıştır.",
                     Players = "Armie Hammer, Helena Bonham Carter, Johnny Depp, William Fichtner",
                     VideoLink = "https://www.youtube.com/embed/pITv-pni8rM",
                 },
            #endregion

            #region İngilizce
        new Movie()
        {
            ID = 38,
            Name = "David ve Elfler",
            Slug = "david-ve-elfler",
            Photo = "/images/dawid-i-elfy.jpg",
            Imdb = "6.1",
            Director = "Michal Rogalski",
            Duration = "1 saat 45 dakika",
            MovieTypeID = 10,
            Subject = "An old tired elf from standing still and working escapes real life to live with nothing thanks to a new little boy...",
            Players = "Cezary Zak, Cyprian Grabowski, Jakub Zajac",
            VideoLink = "https://www.youtube.com/embed/pITv-pni8rM",
        }
                ,
                 new Movie()
                 {
                     ID = 39,
                     Name = "Kırık Kaset",
                     Slug = "kirik-kaset",
                     Photo = "/images/mixtape.jpg",
                     Imdb = "5.7",
                     Director = "Valerie Weiss",
                     Duration = "1 saat 33 dakika",
                     MovieTypeID = 10,
                     Subject = "12-year-old Beverly finds a mixtape recorded by her parents who died in 1999, and tries to learn more about her mother and father based on these songs…",
                     Players = "Jackson Rathbone, Julie Bowen, Nick Thune",
                     VideoLink = "https://www.youtube.com/embed/pITv-pni8rM",
                 }
                  ,
                 new Movie()
                 {
                     ID = 40,
                     Name = "Benim Güzel Noel Şatom",
                     Slug = "benim-guzel-noel-satom",
                     Photo = "/images/a-castle-for-christmas.jpg",
                     Imdb = "6.8",
                     Director = "Mary Lambert",
                     Duration = "1 saat 38 dakika",
                     MovieTypeID = 10,
                     Subject = "A bestselling author travels to Scotland to escape a scandal and loves a castle here. However, he has a conflict with the sullen duke who owns the castle.",
                     Players = "Brooke Shields, Cary Elwes, Suanne Braun",
                     VideoLink = "https://www.youtube.com/embed/pITv-pni8rM",
                 }
                   ,
                 new Movie()
                 {
                     ID = 41,
                     Name = "Honey Girls",
                     Slug = "honey-girls",
                     Photo = "/images/honey-girls.jpg",
                     Imdb = "8.5",
                     Director = "Trey Fanjoy",
                     Duration = "1 saat 30 dakika",
                     MovieTypeID = 10,
                     Subject = "Mega pop star Fancy G (Ashanti) holds a contest to find the next big solo artist. However, the young contestants realize they're better together and secretly form a group called the Honey Girls.",
                     Players = "Aliyah Mastin, Ashanti, Ava Grace",
                     VideoLink = "https://www.youtube.com/embed/pITv-pni8rM",
                 }
                  ,
                 new Movie()
                 {
                     ID = 42,
                     Name = "Kutup Macerası",
                     Slug = "kutup-macerasi",
                     Photo = "/images/Eight-Below-2006.jpg",
                     Imdb = "8.5",
                     Director = "Trey Fanjoy",
                     Duration = "1 saat 32 dakika",
                     MovieTypeID = 10,
                     Subject = "The Pole Adventure, starring Paul Walker as well as Jason Biggs and Bruce Greenwood, was presented to the cinema lovers as a family, adventure and drama production in 2006, proving that it was a very high quality production and was rated 7.3 on IMDB. The film, directed by Frank Marshall, takes movie lovers on a journey to the poles with a story written by David DiGilio for a period of 2 hours…",
                     Players = "Bruce Greenwood, Jason Biggs, Paul Walker",
                     VideoLink = "https://www.youtube.com/embed/pITv-pni8rM",
                 }

                     ,
                 new Movie()
                 {
                     ID = 43,
                     Name = "Arınma Gecesi",
                     Slug = "arinma-gecesi",
                     Photo = "/images/The-Forever-Purge-2021.jpg",
                     Imdb = "7.7",
                     Director = "Everardo Gout",
                     Duration = "2 saat 32 dakika",
                     MovieTypeID = 11,
                     Subject = "While Adela and Juan are living their lives as a very peaceful couple, they are stuck in a farmhouse in Texas in a way they don't understand. Purge time will begin for the couple who are on the run from a drug cartel…",
                     Players = "Ana de la Reguera, Josh Lucas, Tenoch Huerta",
                     VideoLink = "https://www.youtube.com/embed/pITv-pni8rM",
                 }
                    ,
                 new Movie()
                 {
                     ID = 44,
                     Name = "Black Widow",
                     Slug = "black-widow",
                     Photo = "/images/Black-Widow-2021.jpg",
                     Imdb = "7.8",
                     Director = "Everardo Gout",
                     Duration = "1 saat 33 dakika",
                     MovieTypeID = 11,
                     Subject = "He discovers a big conspiracy theory about Black Widow's past, who has to cooperate with her family, who came out of her past she wants to forget, against a great threat. Therefore, Romanoff, who has to face the darkest sides of his life, overcomes the relationships he broke before he became an Avenger. will have to come…”",
                     Players = "David Harbour, Florence Pugh, Rachel Weisz, Scarlett Johansson",
                     VideoLink = "https://www.youtube.com/embed/pITv-pni8rM",
                 },
                 new Movie()
                 {
                     ID = 45,
                     Name = "Son Düello",
                     Slug = "son-duello",
                     Photo = "/images/the-last-duel.jpg",
                     Imdb = "8.8",
                     Director = "Ridley Scott",
                     Duration = "1 saat 33 dakika",
                     MovieTypeID = 11,
                     Subject = "Norman (People of Frankish and Scandinavian descent living in Normandy) knight Jean de Carrouges and Norman lord Jacques le Gris used to be very close friends. Carrouges goes to war and nothing is the same when he returns. le Gris rapes Carrouges' wife But no one believes Margerite. Then the soldier goes to the king of France to appeal the decision. Le Gris is in an advantageous position for the judge. According to the new decision of the court, two men will duel and one of them will die as a result of this duel. The survivor is God. And if Le Gris survives, he will be acquitted.Also, if Carrouges loses, his wife will be burned at the stake as punishment.",
                     Players = "Adam Driver, Jodie Comer, Matt Damon",
                     VideoLink = "https://www.youtube.com/embed/pITv-pni8rM",
                 },
                 new Movie()
                 {
                     ID = 46,
                     Name = "Buz Yolu",
                     Slug = "buz-yolu",
                     Photo = "/images/The-Ice-Road-2021.jpg",
                     Imdb = "8.9",
                     Director = "Jonathan Hensleigh",
                     Duration = "1 saat 53 dakika",
                     MovieTypeID = 11,
                     Subject = "Goldenrod, the owner of a shipping company, agrees with a driver named Mike for a dangerous journey covered with snow. A diamond mine has collapsed in the northern region of Canada and people are stuck here. Mike will come to the rescue of people waiting for help…",
                     Players = "Holt McCallany, Liam Neeson, Matt McCoy",
                     VideoLink = "https://www.youtube.com/embed/pITv-pni8rM",
                 },
                 new Movie()
                 {
                     ID = 47,
                     Name = "Finch",
                     Slug = "finch",
                     Photo = "/images/finch.jpg",
                     Imdb = "9.2",
                     Director = "Miguel Sapochnik",
                     Duration = "1 saat 53 dakika",
                     MovieTypeID = 12,
                     Subject = "Finch, in the sci-fi genre, takes place in a post-apocalyptic era. After the destruction of the world, a robot built to protect his dying creator's dog begins to understand love, friendship and what it means to be human…",
                     Players = "Caleb Landry Jones, Lora Martinez-Cunningham, Tom Hanks",
                     VideoLink = "https://www.youtube.com/embed/pITv-pni8rM",
                 },
                 new Movie()
                 {
                     ID = 48,
                     Name = "Dune",
                     Slug = "dune",
                     Photo = "/images/dune.jpg",
                     Imdb = "9.8",
                     Director = "Miguel Sapochnik",
                     Duration = "1 saat 53 dakika",
                     MovieTypeID = 12,
                     Subject = "The drama, sci-fi and adventure genre Duna Desert Planet movie, which comes out as a remake, was directed by Denis Villeneuve. In the story that takes place in the far future, we follow the story of Paul Atreides, whose family has control of the desert planet Arrakis…",
                     Players = "Rebecca Ferguson, Timothée Chalamet, Zendaya",
                     VideoLink = "https://www.youtube.com/embed/pITv-pni8rM",
                 }
                 ,
                 new Movie()
                 {
                     ID = 49,
                     Name = "Implant",
                     Slug = "implant",
                     Photo = "/images/implanted.jpg",
                     Imdb = "7.8",
                     Director = "Fabien Dufils",
                     Duration = "1 saat 55 dakika",
                     MovieTypeID = 12,
                     Subject = "Sarah is so tired of dealing with headaches and decides to have a chip implanted for an experimental treatment. But once the chip comes under her control, she will have to fight for her survival…",
                     Players = "Michelle Girolami, Nader Boussandel, Scott Broughton",
                     VideoLink = "https://www.youtube.com/embed/pITv-pni8rM",
                 }
                  ,
                 new Movie()
                 {
                     ID = 50,
                     Name = "Koma",
                     Slug = "koma",
                     Photo = "/images/coma-2020-izle.jpg",
                     Imdb = "6.8",
                     Director = "Nikita Argunov",
                     Duration = "2 saat 55 dakika",
                     MovieTypeID = 12,
                     Subject = "As a result of a mysterious event, a young and talented architect re-opens his eyes in a world that resembles reality. This world is based on the memories of those who lived in it. These people are also people who are usually in a coma for a long time. All the laws of physics will be overcome, and the architect will meet the love of his life and fight for life. ",
                     Players = "Aleksey Serebryakov, Lyubov Aksyonova, Milos Bikovic, Rinal Mukhametov",
                     VideoLink = "https://www.youtube.com/embed/pITv-pni8rM",
                 }
                 ,
                 new Movie()
                 {
                     ID = 51,
                     Name = "Küçük Balık",
                     Slug = "kucuk-balik",
                     Photo = "/images/Little-Fish-2020-film.jpg",
                     Imdb = "6.2",
                     Director = "Chad Hartigan",
                     Duration = "2 saat 55 dakika",
                     MovieTypeID = 12,
                     Subject = "A worldwide pandemic causes people to lose their memory. People exposed to the virus forget everything for an unknown reason. The couple Emma and Jude are also newly married and soon become a part of this world. Jude They will do everything to keep their love alive after catching the disease...",
                     Players = "Jack O'Connell, Olivia Cooke, Raúl Castillo, Soko",
                     VideoLink = "https://www.youtube.com/embed/pITv-pni8rM",
                 }
                  ,
                 new Movie()
                 {
                     ID = 52,
                     Name = "Küçük Balık",
                     Slug = "kucuk-balik",
                     Photo = "/images/Little-Fish-2020-film.jpg",
                     Imdb = "6.2",
                     Director = "Chad Hartigan",
                     Duration = "2 saat 55 dakika",
                     MovieTypeID = 13,
                     Subject = "A worldwide pandemic causes people to lose their memory. People exposed to the virus forget everything for an unknown reason. The couple Emma and Jude are also newly married and soon become a part of this world. Jude They will do everything to keep their love alive after catching the disease...",
                     Players = "Jack O'Connell, Olivia Cooke, Raúl Castillo, Soko",
                     VideoLink = "https://www.youtube.com/embed/pITv-pni8rM",
                 }
                  ,
                 new Movie()
                 {
                     ID = 53,
                     Name = "Eternals",
                     Slug = "eternals",
                     Photo = "/images/eternals.jpg",
                     Imdb = "7.2",
                     Director = "Chloé Zhao",
                     Duration = "1 saat 45 dakika",
                     MovieTypeID = 13,
                     Subject = "The Deviants are thought to be obsolete and no longer around. But humanity's oldest and most arch-enemy, the Deviants, returns unexpectedly. Thus, the Eternals will have to save humanity one last time...",
                     Players = "Angelina Jolie, Gemma Chan, Richard Madden",
                     VideoLink = "https://www.youtube.com/embed/pITv-pni8rM",
                 }
                     ,
                 new Movie()
                 {
                     ID = 54,
                     Name = "Gizemli Delik",
                     Slug = "gizemli-delik",
                     Photo = "/images/the-whole-truth.jpg",
                     Imdb = "7.7",
                     Director = "Wisit Sasanatieng",
                     Duration = "1 saat 35 dakika",
                     MovieTypeID = 13,
                     Subject = "Terrifying events begin when two brothers find a strange hole in the wall of their grandparents' house, revealing sinister secrets about their families.",
                     Players = "Sadanont Durongkaweroj, Sompob Benjathikul, Steven Isarapong",
                     VideoLink = "https://www.youtube.com/embed/pITv-pni8rM",
                 }
                  ,
                 new Movie()
                 {
                     ID = 55,
                     Name = "Relic",
                     Slug = "relic",
                     Photo = "/images/the-whole-truth.jpg",
                     Imdb = "7.7",
                     Director = "Natalie Erika James",
                     Duration = "1 saat 19 dakika",
                     MovieTypeID = 13,
                     Subject = "Edna's daughter Kay and granddaughter Sam return home together to find Edna. Edna disappeared a short time ago and then returns as if nothing had happened. However, her behavior is violent and not the same as before. Before long, Kay and Sam will realize that there is something strange with Edna and that there are supernatural powers in the house.",
                     Players = "Bella Heathcote, Chris Bunton, Emily Mortimer, Robyn Nevin",
                     VideoLink = "https://www.youtube.com/embed/pITv-pni8rM",
                 }
                  ,
                 new Movie()
                 {
                     ID = 56,
                     Name = "Ölmek İçin Zaman Yok",
                     Slug = "olmek-icin-zaman-yok",
                     Photo = "/images/No-Time-to-Die-2021-film.jpg",
                     Imdb = "8.7",
                     Director = "Cary Joji Fukunaga",
                     Duration = "1 saat 19 dakika",
                     MovieTypeID = 14,
                     Subject = "The greatest British agent of all time, James Bond, is no longer actively serving. Bond, who is trying to lead a quiet life in Jamaica, will have to leave his quiet life behind to help his old friend Felix, who works in the CIA...",
                     Players = "Ashley Greene, Ryan Phillippe, Scott Adkins",
                     VideoLink = "https://www.youtube.com/embed/pITv-pni8rM",
                 }
                     ,
                 new Movie()
                 {
                     ID = 57,
                     Name = "One Shot",
                     Slug = "one-shot",
                     Photo = "/images/one-shot.jpg",
                     Imdb = "7.1",
                     Director = "James Nunn",
                     Duration = "1 saat 19 dakika",
                     MovieTypeID = 14,
                     Subject = "The greatest British agent of all time, James Bond, is no longer actively serving. Bond, who is trying to lead a quiet life in Jamaica, will have to leave his quiet life behind to help his old friend Felix, who works in the CIA...",
                     Players = "Ashley Greene, Ryan Phillippe, Scott Adkins",
                     VideoLink = "https://www.youtube.com/embed/pITv-pni8rM",
                 }
                  ,
                 new Movie()
                 {
                     ID = 58,
                     Name = "Zamanda Tutsak",
                     Slug = "zamanda-tutsak",
                     Photo = "/images/old-2021.jpg",
                     Imdb = "7.2",
                     Director = "M. Night Shyamalan",
                     Duration = "1 saat 19 dakika",
                     MovieTypeID = 14,
                     Subject = "A family going on a tropical vacation and planning to enjoy it to the fullest encounters strange situations that they did not expect while relaxing on a secluded beach. While on the beach, they begin to age rapidly in a way they cannot understand...",
                     Players = "Gael García Bernal, Rufus Sewell, Vicky Krieps",
                     VideoLink = "https://www.youtube.com/embed/pITv-pni8rM",
                 }
                    ,
                 new Movie()
                 {
                     ID = 59,
                     Name = "Av Günü",
                     Slug = "av-gunu",
                     Photo = "/images/prey.jpg",
                     Imdb = "7.3",
                     Director = "Thomas Sieben",
                     Duration = "1 saat 30 dakika",
                     MovieTypeID = 14,
                     Subject = "Five close friends go on a wilderness excursion and a deadly chase begins when they see a mysterious hitman following them...",
                     Players = "David Kross, Hanno Koffler, Maria Ehrich",
                     VideoLink = "https://www.youtube.com/embed/pITv-pni8rM",
                 }
                    ,
                 new Movie()
                 {
                     ID = 60,
                     Name = "Güzel Poz",
                     Slug = "guzel-poz",
                     Photo = "/images/Guzel-Poz-2019.jpg",
                     Imdb = "7.4",
                     Director = "Dolly Wells",
                     Duration = "1 saat 25 dakika",
                     MovieTypeID = 15,
                     Subject = "Lilian, who has just graduated from film school, broke up with her lover and her father sends her to the house of family friends and Julia Price, who is also the author of Beautiful Pose, for a temporary stay. Unexpected conflicts will begin between the landlord and the young girl…",
                     Players = "Ebon Moss-Bachrach, Gary Richardson, Grace Van Patten, Zadie Smith",
                     VideoLink = "https://www.youtube.com/embed/pITv-pni8rM",
                 }
                   ,
                 new Movie()
                 {
                     ID = 61,
                     Name = "Kimsin Sen?",
                     Slug = "kimsin-sen",
                     Photo = "/images/Good-on-Paper-2021.jpg",
                     Imdb = "8.4",
                     Director = "Kimmy Gatewood",
                     Duration = "1 saat 25 dakika",
                     MovieTypeID = 15,
                     Subject = "Andrea Singer, who has been focusing on her career for years, is a comedian and she thinks it's time to find the man she is looking for in her love life. While everything is going smoothly, she will start to doubt whether the man she finds is the right person…",
                     Players = "Iliza Shlesinger, Rebecca Rittenhouse, Ryan Hansen",
                     VideoLink = "https://www.youtube.com/embed/pITv-pni8rM",
                 }
                 ,
                 new Movie()
                 {
                     ID = 62,
                     Name = "Vahşi Rose",
                     Slug = "vahsi-rose",
                     Photo = "/images/Wild-Rose-2018-film.jpg",
                     Imdb = "9.4",
                     Director = "Tom Harper",
                     Duration = "1 saat 25 dakika",
                     MovieTypeID = 15,
                     Subject = "Rose-Lynn is a young woman who dreams of becoming a beloved famous musician. Always a frivolous person, Rose was imprisoned for a crime she committed and was eventually released on probation. After that, the young woman trying to maintain her life with a bracelet on her foot she is also a mother and will take on responsibilities by returning to her two children. Rose, who is looking for a job to take care of her children, wants to follow her dreams to become a country singer. she wants to be an adult…”,",
                     Players = "Jane Patterson, Jessie Buckley, Lesley Hart, Matt Costello",
                     VideoLink = "https://www.youtube.com/embed/pITv-pni8rM",
                 }
                   ,
                 new Movie()
                 {
                     ID = 63,
                     Name = "Fortress",
                     Slug = "fortress",
                     Photo = "/images/fortress.jpg",
                     Imdb = "9.4",
                     Director = "James Cullen Bressack",
                     Duration = "1 saat 25 dakika",
                     MovieTypeID = 15,
                     Subject = "Robert is a retired CIA agent living at a secret resort in the woods. His long-lost son comes to the camp for a visit, and Robert's old nemesis, Balzary, follows him. The area is surrounded by Balzary's assault team, father and son He retreats to a high-tech bunker. Are the steel walls and advanced weapons of the bunker strong enough to match Balzary's bloodthirsty plans for revenge?",
                     Players = "Bruce Willis, Chad Michael Murray, Jesse Metcalfe, Shannen Doherty",
                     VideoLink = "https://www.youtube.com/embed/pITv-pni8rM",
                 }
                  ,
                 new Movie()
                 {
                     ID = 64,
                     Name = "Caveat",
                     Slug = "caveat",
                     Photo = "/images/Caveat-2020.jpg",
                     Imdb = "5.4",
                     Director = "Damian Mc Carthy",
                     Duration = "1 saat 45 dakika",
                     MovieTypeID = 15,
                     Subject = "Isaac has amnesia and has agreed to take care of Barrett's niece, Olga, who is living in an abandoned house on an isolated island and has psychological problems, in exchange for money. But when she gets home, she realizes that things are very different…",
                     Players = "Ben Caplan, Conor Dwane, Jonathan French, Leila Sykes",
                     VideoLink = "https://www.youtube.com/embed/pITv-pni8rM",
                 }
                   ,
                 new Movie()
                 {
                     ID = 65,
                     Name = "Gaia",
                     Slug = "gaia",
                     Photo = "/images/Gaia-2021.jpg",
                     Imdb = "5.4",
                     Director = "Jaco Bouwer",
                     Duration = "1 saat 47 dakika",
                     MovieTypeID = 16,
                     Subject = "An unfortunate event happens to two guards working in a watchtower in the depths of a primitive forest, and they encounter two people isolated from the outside world. The child and his father, their religion and their mysterious relationship with nature draw their attention. After this point, strange events befall the guards. begins to come…”,",
                     Players = "Andi Matichak, Cranston Johnson, Emile Hirsch, Luke David Blumm",
                     VideoLink = "https://www.youtube.com/embed/pITv-pni8rM",
                 }
                   ,
                 new Movie()
                 {
                     ID = 66,
                     Name = "Son",
                     Slug = "son",
                     Photo = "/images/son-2021-film.jpg",
                     Imdb = "8.8",
                     Director = "Ivan Kavanagh",
                     Duration = "1 saat 47 dakika",
                     MovieTypeID = 16,
                     Subject = "An unfortunate event happens to two guards working in a watchtower in the depths of a primitive forest, and they encounter two people isolated from the outside world. The child and his father, their religion and their mysterious relationship with nature draw their attention. After this point, strange events befall the guards. begins to come…”,",
                     Players = "Andi Matichak, Cranston Johnson, Emile Hirsch, Luke David Blumm",
                     VideoLink = "https://www.youtube.com/embed/pITv-pni8rM",
                 }
                  ,
                 new Movie()
                 {
                     ID = 67,
                     Name = "Spell",
                     Slug = "spell",
                     Photo = "/images/spell-2020-izle.jpg",
                     Imdb = "7.8",
                     Director = "Mark Tonderai",
                     Duration = "1 saat 47 dakika",
                     MovieTypeID = 16,
                     Subject = "A man whose plane crashes with his family in rural Appalachia suddenly finds himself awakened in a traditional wizard's house. He will try to get away from the cursed house before the lunar eclipse and search for ways to find his family.",
                     Players = "Loretta Devine, Omari Hardwick",
                     VideoLink = "https://www.youtube.com/embed/pITv-pni8rM",
                 }
                   ,
                 new Movie()
                 {
                     ID = 68,
                     Name = "Double World",
                     Slug = "double-world",
                     Photo = "/images/double-world-2019-izle.jpg",
                     Imdb = "8.9",
                     Director = "Teddy Chan",
                     Duration = "1 saat 19 dakika",
                     MovieTypeID = 17,
                     Subject = "In the movie, which takes place in a 10-nation fantasy universe, a warlord realizes that the neighboring country is getting stronger and organizes a competition to find its best warriors. The brave villager Dong Yilong village, who hears this news, will decide to participate in the competition, although he doubts his success. will embark on a legendary adventure.",
                     Players = "Luxia Jiang, Mark Cheng, Ming Hu, Peter Ho",
                     VideoLink = "https://www.youtube.com/embed/pITv-pni8rM",
                 }
                   ,
                 new Movie()
                 {
                     ID = 69,
                     Name = "John Carter",
                     Slug = "john-carter",
                     Photo = "/images/john-carter-filmi.jpg",
                     Imdb = "9.7",
                     Director = "Andrew Stanton",
                     Duration = "1 saat 19 dakika",
                     MovieTypeID = 17,
                     Subject = "John Carter, whose script was prepared and directed by Andrew Stanton, reflects the genre of Action, Adventure and Fantasy to the audience with a time of approximately 2 hours and 12 minutes, dated March 9, 2012 in Turkey, and this period satisfies the audience. and John Carter Between Two Worlds, which features names like Willem Dafoe, also grossed $284 million.",
                     Players = "Lynn Collins, Samantha Morton, Taylor Kitsch, Willem Dafoe",
                     VideoLink = "https://www.youtube.com/embed/pITv-pni8rM",
                 }
                    ,

                 new Movie()
                 {
                     ID = 70,
                     Name = "Dev Avcısı Jack",
                     Slug = "dev-avcisi-jack",
                     Photo = "/images/dev-avcisi-jack-2013-filmi.jpg",
                     Imdb = "8.7",
                     Director = "Bryan Singer",
                     Duration = "1 saat 54 dakika",
                     MovieTypeID = 17,
                     Subject = "King McShane's beautiful daughter Princess Isabella is kidnapped by giants and the king orders his best knights to rescue his daughter. Jack, on the other hand, is an ordinary farm worker and wants to volunteer to save Isabella. He will act as a bridge between the Humans and the Giants world. They create a portal with a bean-stalk and enter the world of giants hungry for human blood. In addition to saving Princess Isabella, the future of humanity will be in Jack's hands...",
                     Players = "Eleanor Tomlinson, Ewan McGregor, Nicholas Hoult, Stanley Tucci",
                     VideoLink = "https://www.youtube.com/embed/pITv-pni8rM",
                 }
                       ,
                 new Movie()
                 {
                     ID = 71,
                     Name = "Old Henry",
                     Slug = "old-henry",
                     Photo = "/images/old-henry.jpg",
                     Imdb = "8.1",
                     Director = "Potsy Ponciroli",
                     Duration = "1 saat 25 dakika",
                     MovieTypeID = 18,
                     Subject = "Old Henry, a widowed farmer, continues to live with his son and hosts an injured man with a bag of money at his home. Henry will have to make a decision about whom to trust when a group of people claiming to represent the law arrive to collect money...",
                     Players = "Gavin Lewis, Scott Haze, Tim Blake Nelson",
                     VideoLink = "https://www.youtube.com/embed/pITv-pni8rM",
                 }
                   ,
                 new Movie()
                 {
                     ID = 72,
                     Name = "The Outsider",
                     Slug = "the-outsider",
                     Photo = "/images/The-Outsider-2019.jpg",
                     Imdb = "8.3",
                     Director = "Timothy Woodward Jr.",
                     Duration = "1 saat 22 dakika",
                     MovieTypeID = 18,
                     Subject = "A railroad worker in search of a better life finds himself surrounded by a group of corrupt law enforcement officers. As Marshal tries to control his city, tragedy forces him to decide between justice and family. Timothy Woodward Jr. is directing the 2019 US movie The Outsider. ",
                     Players = "Jon Foo, Kaiwi Lyman, Sean Patrick Flanery, Trace Adkins",
                     VideoLink = "https://www.youtube.com/embed/pITv-pni8rM",
                 }
                  ,
                 new Movie()
                 {
                     ID = 73,
                     Name = "Compshop",
                     Slug = "Compshop",
                     Photo = "/images/copshop.jpg",
                     Imdb = "8.3",
                     Director = "S. Craig Zahler",
                     Duration = "2 saat 22 dakika",
                     MovieTypeID = 18,
                     Subject = "The Bone Tomahawk movie, which contains Wester and Horror elements shot in the USA as an old-fashioned, is about the struggle of four brave-hearted men who try to save a group of captives from one of the cannibal tribes.",
                     Players = "Kurt Russell, Lili Simmons, Patrick Wilson",
                     VideoLink = "https://www.youtube.com/embed/pITv-pni8rM",
                 }
                  ,
                 new Movie()
                 {
                     ID = 74,
                     Name = "Bone Tomahawk",
                     Slug = "bone-tomahawk",
                     Photo = "/images/bone-tomahawk-izle.jpg",
                     Imdb = "8.8",
                     Director = "Gore Verbinski",
                     Duration = "2 saat 22 dakika",
                     MovieTypeID = 18,
                     Subject = "The Masked Horseman movie, in which the world-famous actor Johnny Depp and master names such as Armie Hammer and William Fichtner played the leading roles, arrived in our country with a little delay on July 5, 2013, and movie theaters were full of Johnny Depp fans. Gore Verbinski' The Masked Horseman movie, which is directed by the director, seems to be a very good score, although it is found to be insufficient by its fans with a score of 6.5 from the IMDB front. It has an incredible length of 149 minutes. You will live in very funny moments thanks to Johnny Depp in the movie, which keeps the wild west, action and adventure elements alive. Written by Justin Haythe, the film was shot in the United States with a budget of approximately $250 million.The Masquerade, which grossed around 260 million at the box office, also earned more than $100 million from DVD and Bluray sales. times america This character, who was fictionalized by an old radio program in .",
                     Players = "Armie Hammer, Helena Bonham Carter, Johnny Depp, William Fichtner",
                     VideoLink = "https://www.youtube.com/embed/pITv-pni8rM",
                 }
                 #endregion
                );



            base.OnModelCreating(modelBuilder);
        }
    }
}