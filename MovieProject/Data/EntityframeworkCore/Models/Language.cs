using System.Collections.Generic;

namespace MovieProject.Data.EntityframeworkCore.Models
{
    //Dillerimizi simgeleyen sınıftır.
    public class Language
    {
        public Language()
        {
            MovieTypes = new HashSet<MovieType>();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Culture { get; set; }

        public virtual ICollection<MovieType> MovieTypes { get; set; }
    }
}