using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DemoGAPI.Models;
using Microsoft.AspNetCore.Authorization;
using System.Net.Http.Headers;

namespace DemoGAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ordersController : ControllerBase
    {
        private readonly DG1Context _context;

        public ordersController(DG1Context context)
        {
            _context = context;
        }
        //Get all WorkOrders
        [HttpGet]
       
        public async Task<IEnumerable<WorkOrder>> GetAllWorkOrders()
        {
            return await _context.WorkOrders.ToListAsync();
        }
        //Get WorkOrder by id
        [HttpGet("{id}")]
        [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Detail(int id)
        {
            if (id < 1)
                return BadRequest();
            var order = await _context.WorkOrders.FirstOrDefaultAsync(m => m.OrdersId == id);
            if (order == null)
                return NotFound();
            return Ok(order);

        }
        //test featch data by POST
     

        //Create new WorkOrders
        [HttpPost]
        [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Create(WorkOrder order)
        {
            _context.Add(order);
            await _context.SaveChangesAsync();
            return Ok();
        }
        //Update WorkOrders
        [HttpPut]
        [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Update(WorkOrder orderData)
        {
            if (orderData == null || orderData.OrdersId == 0)
                return BadRequest();

            var order = await _context.WorkOrders.FindAsync(orderData.OrdersId);
            if (order == null)
                return NotFound();
            order.OrdersName = orderData.OrdersName;
            order.MachinesId = orderData.MachinesId;
            order.Product = orderData.Product;
            order.ResourceGroupName = orderData.ResourceGroupName;
            order.ResourceName = orderData.ResourceName;
            order.SetupStart = orderData.SetupStart;
            order.StartTime = orderData.StartTime;
            order.EndTime = orderData.EndTime;
            order.Quantity = orderData.Quantity;
            order.ActualQuantity = orderData.ActualQuantity;
            order.Note = orderData.Note;
            order.ActusalSetupStart = orderData.ActusalSetupStart;
          

            await _context.SaveChangesAsync();
            return Ok();
        }
        //Delete WorkOrders
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Delete(int id)
        {
            if (id < 1)
                return BadRequest();
            var order = await _context.WorkOrders.FindAsync(id);
            if (order == null)
                return NotFound();
            _context.WorkOrders.Remove(order);
            await _context.SaveChangesAsync();
            return Ok();

        }
    }
}