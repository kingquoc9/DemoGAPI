using System;
using System.Collections.Generic;

namespace DemoGAPI.Models
{
    public partial class OrderStatus
    {
        public OrderStatus()
        {
            Orders = new HashSet<Order>();
        }

        public int OrderStatusId { get; set; }
        public string OrderStatusName { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int SeqOrderStatus { get; set; }
        public double Color { get; set; }
        public int Rank { get; set; }
        public string SpareStringField1 { get; set; } = null!;
        public string SpareStringField2 { get; set; } = null!;
        public double SpareNumberField { get; set; }
        public string ExternalId { get; set; } = null!;

        public virtual ICollection<Order> Orders { get; set; }
    }
}
