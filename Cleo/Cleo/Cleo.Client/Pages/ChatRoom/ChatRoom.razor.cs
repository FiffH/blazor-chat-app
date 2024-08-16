using Microsoft.AspNetCore.SignalR.Client;
using Cleo.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace Cleo.Client.Pages.ChatRoom
{
    public partial class ChatRoom
    {
        private HubConnection? hubConnection;
        List<Message> messages = new();

        private string username;
        public string message;
        private DateTime dateTime = DateTime.Now;

        protected async override Task OnInitializedAsync()
        {
            hubConnection = new HubConnectionBuilder()
            .WithUrl(NavManager.ToAbsoluteUri("/chatroom-hub"))
            .Build();

            hubConnection.On<string, string, DateTime>("ReceiveMessage", (message, username, dateTime) => {

                messages.Add(new Message()
                {
                    User = new User()
                    {
                        Username = username
                    },
                    Text = message,
                    DateTime = DateTime.Now
                });

                InvokeAsync(() => StateHasChanged());
            });

            await hubConnection.StartAsync();
        }

        private bool isConnected =>
        hubConnection!.State == HubConnectionState.Connected;

        Task Send() =>
        hubConnection.SendAsync("SendMessage", username, message, dateTime);
    }
}
