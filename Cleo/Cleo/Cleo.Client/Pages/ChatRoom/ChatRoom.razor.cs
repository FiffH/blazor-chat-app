using Microsoft.AspNetCore.SignalR.Client;
using Cleo.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace Cleo.Client.Pages.ChatRoom
{
    public partial class ChatRoom
    {
        public static string? storedUserName { get; set; }
        private HubConnection? hubConnection;
        private Message newMessage = new();
        List<Message> messages = new();

        protected async override Task OnInitializedAsync()
        {
            hubConnection = new HubConnectionBuilder()
            .WithUrl(NavManager.ToAbsoluteUri("/chatroom-hub"))
            .Build();

            hubConnection.On<Message>("ReceiveMessage", (message) => {

                messages.Add(message);

                InvokeAsync(() => StateHasChanged());
            });

            await hubConnection.StartAsync();
        }

        private bool isConnected =>
        hubConnection!.State == HubConnectionState.Connected;

        void Send()
        {
            newMessage.User.Username ??= storedUserName;
            hubConnection.SendAsync("SendMessage", newMessage);
        }

        void SendMessageClicked()
        {
            newMessage.DateTime = DateTime.Now;
            if (!string.IsNullOrEmpty(newMessage.User.Username))
            {
                storedUserName = newMessage.User.Username;
            }

            Send();
            newMessage.Text = string.Empty;

        }
        
    }
}
