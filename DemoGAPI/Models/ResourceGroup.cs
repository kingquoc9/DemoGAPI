using System;
using System.Collections.Generic;

namespace DemoGAPI.Models
{
    public partial class ResourceGroup
    {
        public ResourceGroup()
        {
            Orders = new HashSet<Order>();
        }

        public int ResourceGroupsId { get; set; }
        public string Name { get; set; } = null!;
        public int PlotColor { get; set; }
        public int PlotFillPattern { get; set; }
        public int PlotColorAboveMaxHours { get; set; }
        public int SetupTimeLineColor { get; set; }
        public bool? DisplayUsagePlot { get; set; }
        public int SeqResourceGroups { get; set; }
        public string ExternalId { get; set; } = null!;

        public virtual ICollection<Order> Orders { get; set; }
    }
}
