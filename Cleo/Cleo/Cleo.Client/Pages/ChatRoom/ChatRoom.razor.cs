using Microsoft.AspNetCore.SignalR.Client;
using Cleo.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace Cleo.Client.Pages.ChatRoom
{
    public partial class ChatRoom
    {
        public static string? storedUserName { get; set; }
        private Message newMessage = new();
        
        protected async override Task OnInitializedAsync()
        {
            chatroomService.InvokeChatDisplay += StateHasChanged;
            await chatroomService.StartConnectionAnync();
            chatroomService.ReceiveMessage();
        }

        async void SendMessageOnClick()
        {
            await chatroomService.SendMessage(newMessage);
        }
        public void Dispose() => chatroomService.InvokeChatDisplay -= StateHasChanged;
        
    }
}
