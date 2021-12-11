using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieProject.Data.EntityframeworkCore.Models
{
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
