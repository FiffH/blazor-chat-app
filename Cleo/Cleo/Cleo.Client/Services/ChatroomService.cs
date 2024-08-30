using Cleo.Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;

namespace Cleo.Client.Services
{
    public class ChatroomService
    {
        public Action? InvokeChatDisplay { get; set; }
        public List<Message> Messages { get; set; } = new();
        public bool IsConnected { get; set; }
        private readonly HubConnection _hubConnection;

        public ChatroomService(NavigationManager navigationManager)
        {
            _hubConnection = new HubConnectionBuilder()
            .WithUrl(navigationManager.ToAbsoluteUri("/chatroom-hub"))
            .Build();
        }

        public void ReceiveMessage()
        {
            _hubConnection.On<Message>("ReceiveMessage", (message) => 
            {
                Messages.Add(message);
                InvokeChatDisplay?.Invoke();
            });
        }

        public async Task StartConnectionAnync()
        {
            await _hubConnection.StartAsync();
            IsConnected = _hubConnection!.State == HubConnectionState.Connected;
        }

        public Task SendMessage(Message message) =>
            _hubConnection!.SendAsync("SendMessage", message);
        

    }
}
