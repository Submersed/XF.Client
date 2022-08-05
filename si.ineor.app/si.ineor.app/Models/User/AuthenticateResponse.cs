
using si.ineor.app.Entities;
using System;
namespace si.ineor.app.Models.Users
{
    public class AuthenticateResponse
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }

        public Role Role { get; set; }
        public string Token { get; set; }

        public AuthenticateResponse()
        {
        }
    }
}
