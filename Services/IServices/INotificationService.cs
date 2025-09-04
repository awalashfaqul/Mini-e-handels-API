using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mini_e_handels_API.Models;

namespace Mini_e_handels_API.Services.IServices
{
    public interface INotificationService
    {
        void SendOrderConfirmation(ShoppingOrder order);
        void SendOrderCancellation(ShoppingOrder order);
    }
}