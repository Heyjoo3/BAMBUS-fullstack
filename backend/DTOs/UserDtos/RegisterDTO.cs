﻿using Bambus.Enums;

namespace Bambus.DTOs.UserDtos
{
    public class RegisterDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public Role Role { get; set; } = Role.User;
    }
}
