using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoGAPI.Models;
using DemoGAPI.Repository;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace DemoGAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class POController : ControllerBase
    {

        IPostRepository pr;
        public POController(IPostRepository _pr)
        {
            pr = _pr;
        }


        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetPosts()
        {
            try
            {
                var orders = await pr.GetPosts();
                if (orders == null)
                {
                    return NotFound();
                }

                return Ok(orders);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPatch]
        [Route("{did}/{oid}")]
        
        public async Task<IActionResult> PatchOrder([FromRoute] int oid, [FromRoute] int did, [FromBody] JsonPatchDocument orderData)
        {
            var updatedOrder = await pr.UpdateOrderPatchAsync(did, oid, orderData);
            if (updatedOrder == null)
            {
                return NotFound();
            }
            return Ok(updatedOrder);
        }

    }
}