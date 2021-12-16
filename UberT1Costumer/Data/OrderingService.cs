﻿using System.Collections.Generic;
using System.Threading.Tasks;
using UberT1Costumer.Models;
using UberT1Costumer.Services;

namespace UberT1Costumer.Data
{
    public class OrderingService:IOrderingService
    {
        private Order cacheOrder;
        private bool haveOrder;
        public async Task<Order> RequestVehicle(Order order)
        {
            haveOrder = true;
            return await ClientController.getInstance().RequestVehicle(order);
        }

        public async Task<string> CancelRequest(Order order)
        {
            return await ClientController.getInstance().CancelRequest(order);
        }

        public async Task<Order> CheckProcess(Order order)
        {
            cacheOrder = await ClientController.getInstance().CheckProcess(order);
            return cacheOrder;
        }

        public Order GetOrder()
        {
            return cacheOrder;
        }

        public async Task<IList<HistoryOrder>> GetHistory(Costumer costumer)
        {
            return await ClientController.getInstance().GetHistory(costumer);
        }

        public bool GetHaveOrder()
        {
            return haveOrder;
        }

        public void DontHaveOrder()
        {
            haveOrder = false;
        }
    }
}