using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bingo.Hubs
{
    public class BingoHub:Hub
    {
        public static int contador = 0;
        public static List<string> users = new List<string>();

        public override Task OnConnectedAsync()
        {
            contador++;
            Clients.All.SendAsync("MostrarConectados", contador);
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            contador--;
            Clients.All.SendAsync("MostraConectados", contador);
            return base.OnDisconnectedAsync(exception);
        }

        public async Task SendNumber(int number)
        {
            await Clients.Others.SendAsync("ReceiveNumber", number);
        }

        public async Task AddList(string name)
        {
            users.Add(name);
            await Clients.All.SendAsync("ListUsers", users);
        }
    }
}
