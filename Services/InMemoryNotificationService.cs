using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mini_e_handels_API.Models;
using Mini_e_handels_API.Services.IServices;

namespace Mini_e_handels_API.Services
{
    public class InMemoryNotificationService : INotificationService
    {
        public void SendOrderConfirmation(ShoppingOrder order)
        {
            Console.WriteLine($"[Email] Order #{order.Id} confirmed for CustomerId={order.CustomerId}. Status={order.Status}");
        }

        public void SendOrderCancellation(ShoppingOrder order)
        {
            Console.WriteLine($"[Email] Order #{order.Id} cancelled for CustomerId={order.CustomerId}.");
        }
    }
}