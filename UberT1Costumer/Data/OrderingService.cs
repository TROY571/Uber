﻿using System.Threading.Tasks;
using UberT1Costumer.Models;
using UberT1Costumer.Services;

namespace UberT1Costumer.Data
{
    public class OrderingService:IOrderingService
    {
        public async Task<Order> RequestVehicle(Order order)
        {
            return await ClientController.getInstance().RequestVehicle(order);
        }

        public async Task<string> CancelRequest(Order order)
        {
            return await ClientController.getInstance().CancelRequest(order);
        }

        public async Task<string> CheckProcess(Order order)
        {
            return await ClientController.getInstance().CheckProcess(order);
        }
    }
}