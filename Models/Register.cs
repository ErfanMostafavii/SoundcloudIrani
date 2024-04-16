namespace soundcloud_.Models
{
    public class Register
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string family { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Password_2 { get; set; }
        public IFormFile UserPhoto { get; set; }

        public int Roleid { get; set; }
    }
}
