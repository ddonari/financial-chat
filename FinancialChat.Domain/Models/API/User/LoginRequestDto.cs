using System.ComponentModel.DataAnnotations;

namespace FinancialChat.Domain.API.User
{
    public class LoginRequestDto
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}