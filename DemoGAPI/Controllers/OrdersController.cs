//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using DemoGAPI.Models;
//using Microsoft.AspNetCore.Authorization;
//using System.Net.Http.Headers;
//using System.Linq.Expressions;
//using System.Linq;


//namespace DemoGAPI.controllers
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
//        [Route("GetAllO")]
//        public async Task<ActionResult<IEnumerable<Order>>> Getallorders()
//        {
//            return await _contextx.Orders.ToListAsync();
//        }
        ////[httpget]
        ////public async task<ienumerable<order>> getaorders()
        ////{
        ////    var od = await _contextx.orders.select(x => new order()
        ////    {
        ////        ordersid = x.ordersid,
        ////        datasetid = x.datasetid,
        ////        orderno = x.orderno,
        ////        partno = x.partno,
        ////        product = x.product,
        ////        resourcegroup = x.resourcegroup,
        ////        resource = x.resource,
        ////        setupstart = x.setupstart,
        ////        starttime = x.starttime,
        ////        endtime = x.endtime,
        ////        quantity = x.quantity,
        ////        tableattribute1 = x.tableattribute1,
        ////        actualsetupstart = x.actualsetupstart, 
        ////        actualstarttime = x.actualstarttime,
        ////        actualendtime = x.actualendtime,
        ////        notes = x.notes,
        ////        orderstatus = x.orderstatus
        ////    }).tolistasync() ;
        ////    return od; 
        ////}
        ////update workorders
        ////[httpput]
        //////  [authorize(authenticationschemes = microsoft.aspnetcore.authentication.jwtbearer.jwtbearerdefaults.authenticationscheme)]
        ////public async task<iactionresult> updatestart( order orderdata)
        ////{
        ////    if (orderdata == null || orderdata.ordersid == 0 )
        ////        return badrequest();

        ////    var order = await _contextx.orders.findasync(orderdata.ordersid);
        ////    if (order == null)
        ////        return notfound();
        ////    order.actualstarttime = orderdata.actualstarttime;
        ////    order.orderstatus = orderdata.orderstatus;


        ////    await _contextx.savechangesasync();
        ////    return ok();
        ////}
        //[httpput("{id}/{ids}")]
        //public async task<iactionresult> putorder(int id, int ids, order order)
        //{
        //    if (id != order.datasetid && ids != order.ordersid)
        //    {
        //        return badrequest();
        //    }

        //    _contextx.entry(order).state = entitystate.modified;

        //    try
        //    {
        //        await _contextx.savechangesasync();
        //    }
        //    catch (dbupdateconcurrencyexception)
        //    {
        //        if (!orderexists(id))
        //        {
        //            return notfound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return nocontent();
        //}
        //private bool orderexists(int id)
        //{
        //    return _contextx.orders.any(e => e.datasetid == id);
        //}

//    }
//}
