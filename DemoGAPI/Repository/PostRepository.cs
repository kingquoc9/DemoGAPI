using DemoGAPI.Models;
using DemoGAPI.Repository;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoGAPI.Repository
{
    public class PostRepository : IPostRepository
    {
        private readonly OpcenterAPS181DEMOforVietBayContext _contextx;
        public PostRepository(OpcenterAPS181DEMOforVietBayContext contextx)
        {
            _contextx = contextx;
        }
        public async Task<List<WorkOrder>> GetPosts()
        {
            if (_contextx != null)
            {
                return await (from a in _contextx.Orders
                              from b in _contextx.OrderStatuses
                              from c in _contextx.ResourceGroups
                              from d in _contextx.Resources
                              where a.OrderStatus == b.OrderStatusId && a.Resource == d.ResourcesId && a.ResourceGroup == c.ResourceGroupsId && a.OrderStatus != 1 && a.OrderStatus != 2 && a.OrderStatus != 3
                              select new WorkOrder
                              {
                                  OrdersId = a.OrdersId,
                                  DatasetId = a.DatasetId,
                                  OrderNo = a.OrderNo,
                                  PartNo = a.PartNo,
                                  Product = a.Product,
                                  ResourceGroup = c.Name,
                                  Resource = d.Name,
                                  SetupStart = (DateTime)a.SetupStart,
                                  StartTime = (DateTime)a.StartTime,
                                  EndTime = (DateTime)a.EndTime,
                                  Quantity = (decimal)a.Quantity,
                                  ActualQuantity = a.TableAttribute1,
                                  ActualSetupStart = (DateTime)a.ActualSetupStart,
                                  ActualStartTime = (DateTime)a.ActualStartTime,
                                  ActualEndTime = (DateTime)a.ActualEndTime,
                                  Notes = a.Notes,
                                  OrderStatus = b.OrderStatusName
                              }).ToListAsync();
            }

            return null;
        }
        public async Task<List<onlyidno>> GetPostsid()
        {
            if (_contextx != null)
            {
                return await (from a in _contextx.Orders
                              from b in _contextx.OrderStatuses
                              from c in _contextx.ResourceGroups
                              from d in _contextx.Resources
                              where a.OrderStatus == b.OrderStatusId && a.Resource == d.ResourcesId && a.ResourceGroup == c.ResourceGroupsId && a.OrderStatus != 1 && a.OrderStatus != 2 && a.OrderStatus != 3
                              group a by a.OrderNo into g

                              select new onlyidno
                              {
                                  OrderNo = g.Key
                              }).ToListAsync();
            }

            return null;
        }
        public async Task<Order> UpdateOrderPatchAsync(int did,int oid, JsonPatchDocument orderData)
        {
            var uorder= await _contextx.Orders.FindAsync(did,oid) ;
            if (uorder == null)
            {
                return uorder;
            }
            orderData.ApplyTo(uorder);
            await _contextx.SaveChangesAsync();

            return uorder;
        }

    }    
}