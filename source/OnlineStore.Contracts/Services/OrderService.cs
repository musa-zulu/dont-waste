﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineStore.Contracts.Interfaces.Services;
using OnlineStore.DB;
using OnlineStore.DB.Domain;
using Microsoft.EntityFrameworkCore;

namespace OnlineStore.Contracts.Services
{
    public class OrderService : IOrderService
    {
        private readonly IApplicationDbContext _dataContext;
        public OrderService(IApplicationDbContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Order>> GetAllOrdersAsync(PaginationFilter paginationFilter = null)
        {
            var queryable = _dataContext.Orders.AsQueryable();

            if (paginationFilter == null)
            {
                return await queryable.ToListAsync();
            }

            var skip = (paginationFilter.PageNumber - 1) * paginationFilter.PageSize;
            return await queryable.Skip(skip).Take(paginationFilter.PageSize).OrderByDescending(o => o.OrderNumber).ToListAsync();
        }

        public async Task<bool> CreateOrderAsync(Order order, List<FoodItem> items)
        {
            if (_dataContext.Orders.Any())
            {
                var orderNumber = _dataContext.Orders.Max(x => x.OrderNumber);
                order.OrderNumber = orderNumber + 1;
            }
            CreateOrderItem(items, order.OrderId);
            await _dataContext.Orders.AddAsync(order);
            var saved = await _dataContext.SaveChangesAsync() > 0;
            return saved;
        }

        private void CreateOrderItem(List<FoodItem> items, Guid orderId)
        {
            foreach (var foodItem in items)
            {
                var orderItem = new OrderItem()
                {
                    OrderItemId = new Guid(),
                    FoodItemId = foodItem.FoodItemId,
                    OrderId = orderId,
                    DateLastModified = DateTime.Now,
                    DateCreated = DateTime.Now
                };
                _dataContext.OrderItems.Add(orderItem);
            }
        }

        public async Task<bool> UpdateOrderAsync(Order orderToUpdate)
        {
            _dataContext.Orders.Update(orderToUpdate);
            return await _dataContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteOrderAsync(Guid orderId)
        {
            var order = await GetOrderByIdAsync(orderId);

            if (order == null)
                return false;

            _dataContext.Orders.Remove(order);
            return await _dataContext.SaveChangesAsync() > 0;
        }

        public async Task<Order> GetOrderByIdAsync(Guid orderId)
        {
            return await _dataContext.Orders
                .SingleOrDefaultAsync(x => x.OrderId == orderId);
        }
    }
}
