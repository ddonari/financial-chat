using FinancialChat.Domain.Models.DB;
using FinancialChat.Logic.Models;

namespace FinancialChat.Logic.Interfaces
{
    public interface ITokenService
    {
        JsonWebToken GenerateJwtToken(string email, ApplicationUser user);
    }
}