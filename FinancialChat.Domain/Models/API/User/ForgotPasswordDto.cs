using System.ComponentModel.DataAnnotations;

namespace FinancialChat.Domain.API.User
{
    public class ForgotPasswordDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}