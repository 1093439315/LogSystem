using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiSelfHostTest
{
    public class MyHub : Hub
    {
        public void Send(string name, string message)
        {
            Console.WriteLine($"接收到客户端消息:{name} -- {message}");
            Clients.All.addMessage(name, message);
        }

        public override Task OnConnected()
        {
            Console.WriteLine("客户端连接");
            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            Console.WriteLine("客户端掉线！");
            return base.OnDisconnected(stopCalled);
        }

        public override Task OnReconnected()
        {
            Console.WriteLine("客户端重新连接！");
            return base.OnReconnected();
        }
    }
}
