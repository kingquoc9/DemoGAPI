using System;
using System.Collections.Generic;

namespace DemoGAPI.Models
{
    public partial class Resource
    {
        public Resource()
        {
            OrderActualResourceNavigations = new HashSet<Order>();
            OrderRequiredResourceNavigations = new HashSet<Order>();
            OrderResourceNavigations = new HashSet<Order>();
        }

        public int ResourcesId { get; set; }
        public string Name { get; set; } = null!;
        public double CostPerHour { get; set; }
        public bool UseCostFactorShiftMultiplier { get; set; }
        public int FiniteOrInfinite { get; set; }
        public int ResourceWindow { get; set; }
        public int GraduationItems { get; set; }
        public int GraduationTime { get; set; }
        public int VerticalBucketSize { get; set; }
        public bool GanttSeparator { get; set; }
        public string? Attribute1 { get; set; }
        public double? Attribute2 { get; set; }
        public double? Attribute3 { get; set; }
        public double DisplaySequenceNumber { get; set; }
        public double PreactorDisplayOrder { get; set; }
        public int ResourceDisplayOptions { get; set; }
        public int PlotColor { get; set; }
        public int PlotFillPattern { get; set; }
        public int PlotColorAboveMaxHours { get; set; }
        public int SetupTimeLineColor { get; set; }
        public bool ExcludeFromPerformanceMetrics { get; set; }
        public bool? DisplayUsagePlot { get; set; }
        public int SeqResources { get; set; }
        public int InfiniteModeBehavior { get; set; }
        public int ResourceDisplayStyle { get; set; }
        public int? ChangeoverGroup { get; set; }
        public bool ConcurrentSetupTimes { get; set; }
        public string MatchField { get; set; } = null!;
        public int? MatchProperty { get; set; }
        public int? MatchPropertyRemote { get; set; }
        public bool? FiniteToggle { get; set; }
        public string ExternalId { get; set; } = null!;
        public double Efficiency { get; set; }
        public bool ApplyEfficiencyToSetups { get; set; }
        public double? EfficiencyMultiplier { get; set; }
        public double? SetupEfficiencyMultiplier { get; set; }

        public virtual ICollection<Order> OrderActualResourceNavigations { get; set; }
        public virtual ICollection<Order> OrderRequiredResourceNavigations { get; set; }
        public virtual ICollection<Order> OrderResourceNavigations { get; set; }
    }
}
