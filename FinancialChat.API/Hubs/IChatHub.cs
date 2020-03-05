using FinancialChat.API.HubModels;
using System.Threading.Tasks;

namespace FinancialChat.API.Hubs
{
    public interface IChatHub
    {
        Task Send(MessageModel message);

        Task OnConnectedAsync();
    }

}
