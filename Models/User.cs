using car_service.Models.Entities;

namespace soundcloud_.Models
{
    public class User
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string family { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserPhoto { get; set; }

        public int? Roleid { get; set; }
        public Role? Role { get; set; }
    }
}
