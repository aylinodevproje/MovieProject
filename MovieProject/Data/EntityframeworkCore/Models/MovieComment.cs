using System;

namespace MovieProject.Data.EntityframeworkCore.Models
{
    //Yorumları simgeleyen sınıftır.
    public class MovieComment
    {
        public int ID { get; set; }
        public string CommentText { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual int MovieID { get; set; }
        public virtual Movie Movie { get; set; }
        public virtual int UserID { get; set; }
        public virtual User User { get; set; }
    }
}