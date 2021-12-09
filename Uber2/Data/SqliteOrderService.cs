﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Uber2.Models;
using Uber2.Persistence;

namespace Uber2.Data
{
    public class SqliteOrderService:IOrderService
    {
        UberDBContext uberContext;

        public SqliteOrderService()
        {
            uberContext = new UberDBContext();
        }
        public async Task<IList<Order>> GetOrdersAsync()
        {
            return await uberContext.Orders.ToListAsync();
        }

        public async Task<Order> AddOrder(Order order)
        {

                EntityEntry<Order> orderAdd = await uberContext.Orders.AddAsync(order);
                await uberContext.SaveChangesAsync(); 
                return orderAdd.Entity;
        }

        public async Task<Order> SearchOrder(int id)
        {
            var list = uberContext.Orders;
            foreach (var order in list)
            {
                if (order.id == id)
                {
                    return order;   
                }
            }
            return null;
        }
        

        public async Task<Location> GetCustomerLocation(int orderId)
        {
            var list = uberContext.Orders;
            foreach (var order in list)
            {
                if (order.id == orderId)
                {
                    return order.customerLocation;   
                }
            }
            return null;
        }

        public async Task<Location> GetDestination(int orderId)
        {
            var list = uberContext.Orders;
            foreach (var order in list)
            {
                if (order.id == orderId)
                {
                    return order.destination;
                }
            }
            return null;
        }


        public async Task<Order> EditOrderStatus(Order order)
        {
            try
            {
                Order orderUpdate = await uberContext.Orders.FirstOrDefaultAsync(o => o.id == order.id);
                orderUpdate.status = order.status;
                uberContext.Update(orderUpdate);
                await uberContext.SaveChangesAsync();
                return orderUpdate; 
            }
            catch (Exception e) 
            { 
                throw new Exception($"Did not find order with id{order.id}"); 
            }
        }

        public async Task<IList<Order>> GetCompletedOrders(Customer customer)
        {
            try
            {
                var all = uberContext.Orders;
                IList<Order> list = new List<Order>();
                foreach (var order in all)
                {
                    if (order.status == "Completed" && order.customer == customer)
                    {
                        list.Add(order);
                    }
                }
                return list;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
    }