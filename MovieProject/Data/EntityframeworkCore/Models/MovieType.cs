namespace MovieProject.Data.EntityframeworkCore.Models
{
    //Film türlerini simgeleyen sınıftır.
    public class MovieType
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public virtual int LanguageID { get; set; }
        public virtual Language Language { get; set; }
    }
}