using DemoGAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoGAPI.Repository
{
    public interface IPostRepository
    {
        Task<List<onlyidno>> GetPostsid();
        Task<List<WorkOrder>> GetPosts();
        Task<Order> UpdateOrderPatchAsync(int did, int oid, JsonPatchDocument orderData);
    }
}