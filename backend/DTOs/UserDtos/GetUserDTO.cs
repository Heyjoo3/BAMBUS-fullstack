using Bambus.Enums;

namespace Bambus.DTOs.UserDtos
{
    public class GetUserDTO
    {
       public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }   
        public string FirstName { get; set; }
        public string LastName { get; set; }   
        public Role Role { get; set; }
        public int NumberLoans { get; set; }
        public int NumberExtensions { get; set; }
        public int NumberMissedReturns { get; set; }
    }
}
