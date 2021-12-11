using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieProject.Data.EntityframeworkCore.Models
{
    public class MovieType
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual int LanguageID { get; set; }
        public virtual Language Language { get; set; }
    }
}
