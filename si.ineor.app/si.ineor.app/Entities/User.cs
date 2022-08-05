using System;

namespace si.ineor.app.Entities
{
    public class User
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Username { get; set; }

        public DateTime CreatedDate { get; set; }

        public Role Role { get; set; }

        public string PasswordHash { get; set; }
    }
}
