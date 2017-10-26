using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MediatR;
using WebAppMediatr.Messages;
using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;

namespace WebAppMediatr.Services
{
    public class RemoteQuueueService : IAsyncNotificationHandler<ProfileSavedNotification>
    {
        public Task Handle(ProfileSavedNotification notification)
        {

            return Task.Run(() =>
            {
                System.Threading.Thread.Sleep(5000);
                IHubContext hub = GlobalHost.ConnectionManager.GetHubContext<SRHub>();
                hub.Clients.All.broadcastMessage("RemoteQuueueService", "inviato al sistema di coda 1! " + notification.profilo.name + " id:" + notification.profilo.Id);
            });
        }
       
    }
}