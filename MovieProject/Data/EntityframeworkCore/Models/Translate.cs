namespace MovieProject.Data.EntityframeworkCore.Models
{
    //Farklı dillere göre cümle , kelime translate işlemini gerçekleştiren sınıftır.
    public class Translate
    {
        public int ID { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }

        public virtual int LanguageID { get; set; }
        public virtual Language Language { get; set; }
    }
}