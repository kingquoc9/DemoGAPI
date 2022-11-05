using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DemoGAPI.Models
{
    public partial class WorkOrder
    {
        
        public int OrdersId { get; set; }
        public int DatasetId { get; set; }
        public string OrderNo { get; set; } = null!;
        public string PartNo { get; set; } = null!;
        public string Product { get; set; } = null!;
        public string ResourceGroup { get; set; } = null!;
        public string Resource { get; set; } = null!;
        public DateTime SetupStart { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public decimal Quantity { get; set; }
        public decimal? ActualQuantity { get; set; }
        public DateTime? ActualSetupStart { get; set; }
        public DateTime? ActualStartTime { get; set; }
        public DateTime? ActualEndTime { get; set; }
        public string? Notes { get; set; }       
        public string? OrderStatus { get; set; }
    }
}
