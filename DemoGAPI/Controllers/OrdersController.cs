//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using DemoGAPI.Models;
//using Microsoft.AspNetCore.Authorization;
//using System.Net.Http.Headers;
//using System.Linq.Expressions;
//using System.Linq;

//namespace DemoGAPI.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class OrdersController : ControllerBase
//    {
//        private readonly OpcenterAPS181DEMOforVietBayContext _contextx;
//        public OrdersController(OpcenterAPS181DEMOforVietBayContext contextx)
//        {
//            _contextx = contextx;
//        }
//        [HttpGet]

//        public async Task<ActionResult<IEnumerable<Order>>> GetAllOrders()
//        {
//            return await _contextx.Orders.ToListAsync();
//        }
//        //[HttpGet]
//        //public async Task<IEnumerable<Order>> GetAOrders()
//        //{
//        //    var od = await _contextx.Orders.Select(x => new Order()
//        //    {
//        //        OrdersId = x.OrdersId,
//        //        DatasetId = x.DatasetId,
//        //        OrderNo = x.OrderNo,
//        //        PartNo = x.PartNo,
//        //        Product = x.Product,
//        //        ResourceGroup = x.ResourceGroup,
//        //        Resource = x.Resource,
//        //        SetupStart = x.SetupStart,
//        //        StartTime = x.StartTime,
//        //        EndTime = x.EndTime,
//        //        Quantity = x.Quantity,
//        //        TableAttribute1 = x.TableAttribute1,
//        //        ActualSetupStart = x.ActualSetupStart, 
//        //        ActualStartTime = x.ActualStartTime,
//        //        ActualEndTime = x.ActualEndTime,
//        //        Notes = x.Notes,
//        //        OrderStatus = x.OrderStatus
//        //    }).ToListAsync() ;
//        //    return od; 
//        //}
//        //Update WorkOrders
//        //[HttpPut]
//        ////  [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
//        //public async Task<IActionResult> UpdateStart( Order orderData)
//        //{
//        //    if (orderData == null || orderData.OrdersId == 0 )
//        //        return BadRequest();

//        //    var order = await _contextx.Orders.FindAsync(orderData.OrdersId);
//        //    if (order == null)
//        //        return NotFound();
//        //    order.ActualStartTime = orderData.ActualStartTime;
//        //    order.OrderStatus = orderData.OrderStatus;


//        //    await _contextx.SaveChangesAsync();
//        //    return Ok();
//        //}
//        [HttpPut("{id}/{ids}")]
//        public async Task<IActionResult> PutOrder(int id,int ids, Order order)
//        {
//            if (id != order.DatasetId && ids != order.OrdersId)
//            {
//                return BadRequest();
//            }

//            _contextx.Entry(order).State = EntityState.Modified;

//            try
//            {
//                await _contextx.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!OrderExists(id))
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    throw;
//                }
//            }

//            return NoContent();
//        }
//        private bool OrderExists(int id)
//        {
//            return _contextx.Orders.Any(e => e.DatasetId == id);
//        }

//    }
//}
