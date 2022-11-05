using System;
using System.Collections.Generic;

namespace DemoGAPI.Models
{
    public partial class Order
    {
        public int BelongsToOrderNo { get; set; }
        public int OrdersId { get; set; }
        public int? OrderStatus { get; set; }
        public string OrderNo { get; set; } = null!;
        public DateTime? EarliestStartDate { get; set; }
        public DateTime? DueDate { get; set; }
        public double Priority { get; set; }
        public double? DeliveryBuffer { get; set; }
        public DateTime? OrderStart { get; set; }
        public DateTime? OrderEnd { get; set; }
        public double? WaitingTime { get; set; }
        public string Notes { get; set; } = null!;
        public double? CriticalRatio { get; set; }
        public int OpNo { get; set; }
        public string OperationName { get; set; } = null!;
        public int? ResourceGroup { get; set; }
        public int? RequiredResource { get; set; }
        public int? Resource { get; set; }
        public double? SetupTime { get; set; }
        public int ProcessTimeType { get; set; }
        public double? OpTimePerItem { get; set; }
        public double? BatchTime { get; set; }
        public double QuantityPerHour { get; set; }
        public double MidBatchQuantity { get; set; }
        public DateTime? MidBatchTime { get; set; }
        public double? EffectiveOpTime { get; set; }
        public double? TransferQuantity { get; set; }
        public double MaterialCostPerItem { get; set; }
        public double UserDefinedOperationCost { get; set; }
        public double OperationCost { get; set; }
        public double OrderCost { get; set; }
        public string Document { get; set; } = null!;
        public DateTime? SetupStart { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public bool Hold { get; set; }
        public int SetSequencerOperationThumb { get; set; }
        public bool MarkedForDeletion { get; set; }
        public int DatasetId { get; set; }
        public int SeqOrders { get; set; }
        public DateTime? DemandDate { get; set; }
        public int OpId { get; set; }
        public int OpSeqMarker { get; set; }
        public bool MaterialControlComplete { get; set; }
        public string PartNo { get; set; } = null!;
        public string Product { get; set; } = null!;
        public DateTime? SupplyDate { get; set; }
        public int? OperationProgress { get; set; }
        public bool LockOperation { get; set; }
        public bool UseActualTimes { get; set; }
        public bool IndependentLots { get; set; }
        public bool MaterialShortage { get; set; }
        public int OrderType { get; set; }
        public bool MaterialOverSupply { get; set; }
        public string OriginalOrderNo { get; set; } = null!;
        public double? TotalSetupTime { get; set; }
        public double? TotalProcessTime { get; set; }
        public double Quantity { get; set; }
        public double Weighting { get; set; }
        public double Profit { get; set; }
        public int? OrderStatusRank { get; set; }
        public int? TableAttribute1 { get; set; }
        public int? TableAttribute1Rank { get; set; }
        public int? TableAttribute2 { get; set; }
        public int? TableAttribute2Rank { get; set; }
        public int? TableAttribute3 { get; set; }
        public int? TableAttribute3Rank { get; set; }
        public string StringAttribute1 { get; set; } = null!;
        public string StringAttribute2 { get; set; } = null!;
        public string StringAttribute3 { get; set; } = null!;
        public double NumericalAttribute1 { get; set; }
        public double NumericalAttribute2 { get; set; }
        public double NumericalAttribute3 { get; set; }
        public DateTime? DateAttribute1 { get; set; }
        public double? DurationAttribute1 { get; set; }
        public double? DurationAttribute2 { get; set; }
        public double? SlackTimeAfterLastOperation { get; set; }
        public bool? StartOffsetEndSync { get; set; }
        public int? TableAttribute4 { get; set; }
        public int? TableAttribute4Rank { get; set; }
        public int? TableAttribute5 { get; set; }
        public int? TableAttribute5Rank { get; set; }
        public string StringAttribute4 { get; set; } = null!;
        public string StringAttribute5 { get; set; } = null!;
        public double NumericalAttribute4 { get; set; }
        public double NumericalAttribute5 { get; set; }
        public DateTime? DateAttribute2 { get; set; }
        public double? DurationAttribute3 { get; set; }
        public double ProductivityMultiplier { get; set; }
        public double? SlackTimeBeforeNextOperation { get; set; }
        public double? MaxTimeBeforeNextOp { get; set; }
        public int IntervalType { get; set; }
        public double MaximumOperationSpanIncrease { get; set; }
        public double? LookAheadWindow { get; set; }
        public bool OrderEnquiry { get; set; }
        public double? MakeSpan { get; set; }
        public bool? RatePerHourToggle { get; set; }
        public bool? TimePerItemToggle { get; set; }
        public bool? TimePerBatchToggle { get; set; }
        public bool? BatchTimeFieldToggle { get; set; }
        public bool? ResourceTimePerItemToggle { get; set; }
        public bool? ResourceRatePerHourToggle { get; set; }
        public bool? ResourceBatchTimeToggle { get; set; }
        public double? MaterialCost { get; set; }
        public bool? SequencingEnabled { get; set; }
        public int? DemandStatus { get; set; }
        public DateTime? ActualEarliestStartDate { get; set; }
        public DateTime? ActualDueDate { get; set; }
        public string OrderExternalId { get; set; } = null!;
        public string OperationExternalId { get; set; } = null!;
        public int? ActualResource { get; set; }
        public DateTime? ActualSetupStart { get; set; }
        public DateTime? ActualStartTime { get; set; }
        public DateTime? ActualEndTime { get; set; }
        public bool? UsingActualTimes { get; set; }
        public int TransferType { get; set; }
        public double? StartOffsetQuantity { get; set; }
        public bool? TransferQuantityEnabled { get; set; }
        public double? RealOpTimePerItem { get; set; }
        public bool ToggleAttribute1 { get; set; }
        public bool ToggleAttribute2 { get; set; }
        public int? ConstraintGroup1 { get; set; }
        public int? SelectedConstraint1 { get; set; }
        public int? ConstraintGroup2 { get; set; }
        public int? SelectedConstraint2 { get; set; }

        public virtual Resource? ActualResourceNavigation { get; set; }
        public virtual OrderStatus? OrderStatusNavigation { get; set; }
        public virtual Resource? RequiredResourceNavigation { get; set; }
        public virtual ResourceGroup? ResourceGroupNavigation { get; set; }
        public virtual Resource? ResourceNavigation { get; set; }
    }
}
