using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Linknight.UI.Models;
using Microsoft.AspNetCore.SignalR;

namespace Linknight.UI.Hubs
{
    public class ChatHub : Hub
    {
        static List<UserInfo> UsersList = new List<UserInfo>();
        static List<MessageInfo> MessageList = new List<MessageInfo>();


        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
