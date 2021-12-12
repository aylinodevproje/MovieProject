namespace MovieProject.Models
{
    //Kayıt olurken view tarafı ve back-end tarafı arasında parametre sınıfıdr.
    public class RegisterViewModel
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}