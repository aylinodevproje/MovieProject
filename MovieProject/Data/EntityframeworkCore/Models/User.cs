using System.Collections.Generic;

namespace MovieProject.Data.EntityframeworkCore.Models
{
    //Kullanıcıları,üyeleri, ve Admini simgeleyen sınıftır.
    public class User
    {
        public User()
        {
            MovieComments = new HashSet<MovieComment>();
        }

        public int ID { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public virtual ICollection<MovieComment> MovieComments { get; set; }
    }
}