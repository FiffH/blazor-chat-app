using Cleo.Shared.Models;
using Microsoft.AspNetCore.SignalR;
using System.Runtime.CompilerServices;

namespace Cleo.ChatroomHubs
{
    public class CleoHub : Hub
    {
        public async Task SendMessage(Message message)
        {
            await Clients.All.SendAsync("ReceiveMessage", message);
        }
    }
}
