using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chate.HandlerSignalR
{
    public class ChateHub : Hub
    {
        public async Task Avtorization(string message)
        {
            await this.Clients.All.SendAsync("Avtorization", message);
        }
    }
}
