using Microsoft.AspNetCore.SignalR;
using System.Runtime.CompilerServices;

namespace Cleo.ChatroomHubs
{
    public class CleoHub : Hub
    {
        public async Task SendMessage(string message, string userName, DateTime date) => await
            Clients.All.SendAsync("ReceiveMessage", userName, message, date);
    }
}
