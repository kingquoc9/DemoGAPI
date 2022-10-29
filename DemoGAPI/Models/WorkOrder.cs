using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DemoGAPI.Models
{
    public partial class WorkOrder
    {
        
        public int OrdersId { get; set; }
        public string OrdersName { get; set; } = null!;
        public string MachinesId { get; set; } = null!;
        public string Product { get; set; } = null!;
        public string ResourceGroupName { get; set; } = null!;
        public string ResourceName { get; set; } = null!;
        public DateTime SetupStart { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public decimal Quantity { get; set; }
        public decimal? ActualQuantity { get; set; }
        public string? Note { get; set; }
        public DateTime? ActusalSetupStart { get; set; }
        public string? Status { get; set; }
    }
}
