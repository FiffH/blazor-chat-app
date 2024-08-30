using Cleo.Repos;
using Cleo.Shared.Models;
using Microsoft.AspNetCore.SignalR;
using System.Runtime.CompilerServices;

namespace Cleo.ChatroomHubs
{
    public class CleoHub(ChatroomRepository _chatroomRepository) : Hub
    {
        public async Task SendMessage(Message message)
        {
            await _chatroomRepository.SaveMessagesAsync(message);
            await Clients.All.SendAsync("ReceiveMessage", message);
        }
    }
}
