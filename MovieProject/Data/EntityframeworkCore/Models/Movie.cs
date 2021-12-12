using System.Collections.Generic;

namespace MovieProject.Data.EntityframeworkCore.Models
{
    //Filmleri simgeleyen sınıftır.

    public class Movie
    {
        public Movie()
        {
            MovieComments = new HashSet<MovieComment>();
        }

        public int ID { get; set; }
        public string Slug { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }
        public string Subject { get; set; }
        public string Director { get; set; }
        public string Duration { get; set; }
        public string Players { get; set; }
        public string VideoLink { get; set; }
        public string Imdb { get; set; }
        public virtual int MovieTypeID { get; set; }
        public virtual MovieType MovieType { get; set; }
        public virtual ICollection<MovieComment> MovieComments { get; set; }
    }
}