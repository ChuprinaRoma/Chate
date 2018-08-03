using Chate.Business_Layer;
using Chate.Business_Layer.Model;
using Chate.DAO;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Chate.HandlerSignalR
{
    //Сигналер
    public class ChateHub : Hub
    {
        //Принятие подключения клиента
        public async Task Connect(string login)
        {
            if (!ManagerUser.users.Exists(u => u.Login == login))
            {
                //Добавление клиента в олайн список
                ManagerUser.users.Add(new User(login));
                //Отправление всем клиентам, что клиент именем "login" подключился
                await this.Clients.All.SendAsync("Connect", login);
            }
        }
        

        public async Task DisConnect(string login)
        {
            if (ManagerUser.users.Exists(u => u.Login == login))
            {
                //Удалени клиента из олайн список
                ManagerUser.users.Remove(ManagerUser.users.Find(u => u.Login == login));
                //Отправление всем клиентам, что клиент с именем "login" отключился
                await this.Clients.All.SendAsync("DisConnect", login);
            }
        }

        public async Task Send(string login, string mesage)
        {
            //Отправление всем клиентам сообщение
            await this.Clients.All.SendAsync("Send", login, mesage);
            //Добавление сообщенив базу
            SqlEntityFramworke.AddChate(login, mesage);
        }
    }
}
