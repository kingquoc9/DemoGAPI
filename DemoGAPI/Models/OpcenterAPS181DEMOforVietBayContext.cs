using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DemoGAPI.Models
{
    public partial class OpcenterAPS181DEMOforVietBayContext : DbContext
    {
        public OpcenterAPS181DEMOforVietBayContext()
        {
        }

        public OpcenterAPS181DEMOforVietBayContext(DbContextOptions<OpcenterAPS181DEMOforVietBayContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderStatus> OrderStatuses { get; set; } = null!;
        public virtual DbSet<Resource> Resources { get; set; } = null!;
        public virtual DbSet<ResourceGroup> ResourceGroups { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Data Source=FME-03;Database=Opcenter APS 18.1 DEMO for VietBay;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("Latin1_General_CI_AS");

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => new { e.DatasetId, e.OrdersId })
                    .HasName("Orders PK");

                entity.ToTable("Orders", "UserData");

                entity.Property(e => e.OrdersId).HasDefaultValueSql("((1))");

                entity.Property(e => e.ActualDueDate)
                    .HasColumnType("datetime")
                    .HasComputedColumnSql("(nullif(CONVERT([datetime],((((case when CONVERT([float],isnull([DueDate],(-1)),(0))=(-1) then (1) else (0) end*case when CONVERT([float],isnull([SupplyDate],(-1)),(0))=(-1) then (1) else (0) end)*(-1)+(case when CONVERT([float],isnull([DueDate],(-1)),(0))>(0) then (1) else (0) end*case when CONVERT([float],isnull([SupplyDate],(-1)),(0))>CONVERT([float],isnull([DueDate],(-1)),(0)) then (1) else (0) end)*CONVERT([float],isnull([DueDate],(-1)),(0)))+(case when CONVERT([float],isnull([SupplyDate],(-1)),(0))>(0) then (1) else (0) end*case when CONVERT([float],isnull([DueDate],(-1)),(0))>=CONVERT([float],isnull([SupplyDate],(-1)),(0)) then (1) else (0) end)*CONVERT([float],isnull([SupplyDate],(-1)),(0)))+(case when CONVERT([float],isnull([DueDate],(-1)),(0))=(-1) then (1) else (0) end*case when CONVERT([float],isnull([SupplyDate],(-1)),(0))>(0) then (1) else (0) end)*CONVERT([float],isnull([SupplyDate],(-1)),(0)))+(case when CONVERT([float],isnull([SupplyDate],(-1)),(0))=(-1) then (1) else (0) end*case when CONVERT([float],isnull([DueDate],(-1)),(0))>(0) then (1) else (0) end)*CONVERT([float],isnull([DueDate],(-1)),(0)),(0)),(-1)))", false);

                entity.Property(e => e.ActualEarliestStartDate)
                    .HasColumnType("datetime")
                    .HasComputedColumnSql("(nullif(CONVERT([datetime],case when CONVERT([float],isnull([DemandDate],(-1)),(0))>CONVERT([float],isnull([EarliestStartDate],(-1)),(0)) then (1) else (0) end*CONVERT([float],isnull([DemandDate],(-1)),(0))+case when CONVERT([float],isnull([DemandDate],(-1)),(0))<=CONVERT([float],isnull([EarliestStartDate],(-1)),(0)) then (1) else (0) end*CONVERT([float],isnull([EarliestStartDate],(-1)),(0)),(0)),(-1)))", false);

                entity.Property(e => e.ActualEndTime).HasColumnType("datetime");

                entity.Property(e => e.ActualSetupStart).HasColumnType("datetime");

                entity.Property(e => e.ActualStartTime).HasColumnType("datetime");

                entity.Property(e => e.BatchTime).HasDefaultValueSql("((0.006944444444445))");

                entity.Property(e => e.BatchTimeFieldToggle).HasComputedColumnSql("(CONVERT([bit],case when CONVERT([float],[ProcessTimeType],(0))=(1) then (1) else (0) end,(0)))", false);

                entity.Property(e => e.BelongsToOrderNo).HasDefaultValueSql("((-1))");

                entity.Property(e => e.DateAttribute1).HasColumnType("datetime");

                entity.Property(e => e.DateAttribute2).HasColumnType("datetime");

                entity.Property(e => e.DeliveryBuffer).HasDefaultValueSql("((0))");

                entity.Property(e => e.DemandDate).HasColumnType("datetime");

                entity.Property(e => e.DemandStatus).HasComputedColumnSql("(CONVERT([int],(((((case when case when CONVERT([float],[MaterialControlComplete],(0))=(0) then (1) else (0) end>(0) AND case when CONVERT([float],[MaterialShortage],(0))=(0) then (1) else (0) end>(0) then (1) else (0) end*(2)+case when case when case when CONVERT([float],[MaterialControlComplete],(0))=(1) then (1) else (0) end>(0) AND case when CONVERT([float],[MaterialShortage],(0))=(0) then (1) else (0) end>(0) then (1) else (0) end>(0) AND case when CONVERT([float],[MaterialOverSupply],(0))=(0) then (1) else (0) end>(0) then (1) else (0) end*(3))+case when case when case when CONVERT([float],[MaterialControlComplete],(0))=(1) then (1) else (0) end>(0) AND case when CONVERT([float],[MaterialShortage],(0))=(1) then (1) else (0) end>(0) then (1) else (0) end>(0) AND case when CONVERT([float],[MaterialOverSupply],(0))=(0) then (1) else (0) end>(0) then (1) else (0) end*(4))+case when case when case when CONVERT([float],[MaterialControlComplete],(0))=(0) then (1) else (0) end>(0) AND case when CONVERT([float],[MaterialShortage],(0))=(1) then (1) else (0) end>(0) then (1) else (0) end>(0) AND case when CONVERT([float],[MaterialOverSupply],(0))=(0) then (1) else (0) end>(0) then (1) else (0) end*(5))+case when case when case when CONVERT([float],[MaterialControlComplete],(0))=(1) then (1) else (0) end>(0) AND case when CONVERT([float],[MaterialShortage],(0))=(0) then (1) else (0) end>(0) then (1) else (0) end>(0) AND case when CONVERT([float],[MaterialOverSupply],(0))=(1) then (1) else (0) end>(0) then (1) else (0) end*(6))+case when case when case when CONVERT([float],[MaterialControlComplete],(0))=(0) then (1) else (0) end>(0) AND case when CONVERT([float],[MaterialShortage],(0))=(1) then (1) else (0) end>(0) then (1) else (0) end>(0) AND case when CONVERT([float],[MaterialOverSupply],(0))=(1) then (1) else (0) end>(0) then (1) else (0) end*(7))+case when case when case when CONVERT([float],[MaterialControlComplete],(0))=(1) then (1) else (0) end>(0) AND case when CONVERT([float],[MaterialShortage],(0))=(1) then (1) else (0) end>(0) then (1) else (0) end>(0) AND case when CONVERT([float],[MaterialOverSupply],(0))=(1) then (1) else (0) end>(0) then (1) else (0) end*(8),(0)))", false);

                entity.Property(e => e.Document)
                    .HasMaxLength(99)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DueDate).HasColumnType("datetime");

                entity.Property(e => e.EarliestStartDate).HasColumnType("datetime");

                entity.Property(e => e.EffectiveOpTime).HasDefaultValueSql("((0))");

                entity.Property(e => e.EndTime).HasColumnType("datetime");

                entity.Property(e => e.LookAheadWindow).HasDefaultValueSql("((7))");

                entity.Property(e => e.MakeSpan).HasComputedColumnSql("(nullif(CONVERT([float],CONVERT([float],isnull([OrderEnd],(-1)),(0))-CONVERT([float],isnull([OrderStart],(-1)),(0)),(0)),(-1)))", false);

                entity.Property(e => e.MaterialCost).HasComputedColumnSql("(CONVERT([float],CONVERT([float],[Quantity],(0))*CONVERT([float],[MaterialCostPerItem],(0)),(0)))", false);

                entity.Property(e => e.MaximumOperationSpanIncrease).HasDefaultValueSql("((-1))");

                entity.Property(e => e.MidBatchTime).HasColumnType("datetime");

                entity.Property(e => e.Notes)
                    .HasMaxLength(1000)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.OpId).HasDefaultValueSql("((10))");

                entity.Property(e => e.OpNo).HasDefaultValueSql("((10))");

                entity.Property(e => e.OpTimePerItem).HasDefaultValueSql("((0.006944444444445))");

                entity.Property(e => e.OperationExternalId)
                    .HasMaxLength(99)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.OperationName)
                    .HasMaxLength(99)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.OperationProgress).HasDefaultValueSql("((2))");

                entity.Property(e => e.OrderEnd).HasColumnType("datetime");

                entity.Property(e => e.OrderExternalId)
                    .HasMaxLength(99)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.OrderNo)
                    .HasMaxLength(99)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.OrderStart).HasColumnType("datetime");

                entity.Property(e => e.OriginalOrderNo)
                    .HasMaxLength(99)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PartNo)
                    .HasMaxLength(99)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Priority).HasDefaultValueSql("((10))");

                entity.Property(e => e.Product)
                    .HasMaxLength(99)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ProductivityMultiplier).HasDefaultValueSql("((1))");

                entity.Property(e => e.Quantity).HasDefaultValueSql("((1))");

                entity.Property(e => e.QuantityPerHour).HasDefaultValueSql("((1))");

                entity.Property(e => e.RatePerHourToggle).HasComputedColumnSql("(CONVERT([bit],case when CONVERT([float],[ProcessTimeType],(0))=(2) then (1) else (0) end,(0)))", false);

                entity.Property(e => e.RealOpTimePerItem).HasComputedColumnSql("(nullif(CONVERT([float],case when CONVERT([float],[ProductivityMultiplier],(0))=(0) then (0) else ((CONVERT([float],isnull([OpTimePerItem],(-1)),(0))*case when CONVERT([float],[ProcessTimeType],(0))=(0) then (1) else (0) end+CONVERT([float],isnull([BatchTime],(-1)),(0))*case when CONVERT([float],[ProcessTimeType],(0))=(1) then (1) else (0) end)+case when (24)=(0) then (0) else case when CONVERT([float],[QuantityPerHour],(0))=(0) then (0) else (1)/CONVERT([float],[QuantityPerHour],(0)) end/(24) end*case when CONVERT([float],[ProcessTimeType],(0))=(2) then (1) else (0) end)/CONVERT([float],[ProductivityMultiplier],(0)) end+ -(1)*case when CONVERT([float],[ProcessTimeType],(0))>=(3) then (1) else (0) end,(0)),(-1)))", false);

                entity.Property(e => e.ResourceBatchTimeToggle).HasComputedColumnSql("(CONVERT([bit],case when CONVERT([float],[ProcessTimeType],(0))=(5) then (1) else (0) end,(0)))", false);

                entity.Property(e => e.ResourceRatePerHourToggle).HasComputedColumnSql("(CONVERT([bit],case when CONVERT([float],[ProcessTimeType],(0))=(4) then (1) else (0) end,(0)))", false);

                entity.Property(e => e.ResourceTimePerItemToggle).HasComputedColumnSql("(CONVERT([bit],case when CONVERT([float],[ProcessTimeType],(0))=(3) then (1) else (0) end,(0)))", false);

                entity.Property(e => e.SeqOrders).HasColumnName("__seq__Orders");

                entity.Property(e => e.SequencingEnabled).HasComputedColumnSql("(CONVERT([bit],case when CONVERT([float],[Hold],(0))=(0) then (1) else (0) end,(0)))", false);

                entity.Property(e => e.SetSequencerOperationThumb).HasDefaultValueSql("((1))");

                entity.Property(e => e.SetupStart).HasColumnType("datetime");

                entity.Property(e => e.SetupTime).HasDefaultValueSql("((0))");

                entity.Property(e => e.SlackTimeAfterLastOperation).HasDefaultValueSql("((0))");

                entity.Property(e => e.StartOffsetEndSync)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.StartOffsetQuantity).HasComputedColumnSql("(CONVERT([float],case when CONVERT([float],[TransferType],(0))=(0) then (1) else (0) end*CONVERT([float],isnull([TransferQuantity],(-1)),(0))+case when CONVERT([float],[TransferType],(0))<>(0) then (1) else (0) end*(-1),(0)))", false);

                entity.Property(e => e.StartTime).HasColumnType("datetime");

                entity.Property(e => e.StringAttribute1)
                    .HasMaxLength(99)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StringAttribute2)
                    .HasMaxLength(99)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StringAttribute3)
                    .HasMaxLength(99)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StringAttribute4)
                    .HasMaxLength(99)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StringAttribute5)
                    .HasMaxLength(99)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SupplyDate).HasColumnType("datetime");

                entity.Property(e => e.TimePerBatchToggle).HasComputedColumnSql("(CONVERT([bit],case when case when CONVERT([float],[ProcessTimeType],(0))=(1) then (1) else (0) end>(0) OR case when CONVERT([float],[ProcessTimeType],(0))=(5) then (1) else (0) end>(0) then (1) else (0) end,(0)))", false);

                entity.Property(e => e.TimePerItemToggle).HasComputedColumnSql("(CONVERT([bit],case when CONVERT([float],[ProcessTimeType],(0))=(0) then (1) else (0) end,(0)))", false);

                entity.Property(e => e.TransferQuantity).HasDefaultValueSql("((1))");

                entity.Property(e => e.TransferQuantityEnabled).HasComputedColumnSql("(CONVERT([bit],case when CONVERT([float],[TransferType],(0))=(0) then (1) else (0) end,(0)))", false);

                entity.Property(e => e.TransferType).HasDefaultValueSql("((1))");

                entity.Property(e => e.UsingActualTimes).HasComputedColumnSql("(CONVERT([bit],case when case when case when case when CONVERT([float],isnull([ActualSetupStart],(-1)),(0))>(0) then (1) else (0) end>(0) AND case when CONVERT([float],isnull([ActualStartTime],(-1)),(0))>(0) then (1) else (0) end>(0) then (1) else (0) end>(0) AND case when CONVERT([float],isnull([ActualEndTime],(-1)),(0))>(0) then (1) else (0) end>(0) then (1) else (0) end>(0) OR case when CONVERT([float],[UseActualTimes],(0))>(0) then (1) else (0) end>(0) then (1) else (0) end,(0)))", false);

                entity.HasOne(d => d.ActualResourceNavigation)
                    .WithMany(p => p.OrderActualResourceNavigations)
                    .HasForeignKey(d => d.ActualResource)
                    .HasConstraintName("FK_Orders_ActualResource");

                entity.HasOne(d => d.OrderStatusNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.OrderStatus)
                    .HasConstraintName("FK_Orders_OrderStatus");

                entity.HasOne(d => d.RequiredResourceNavigation)
                    .WithMany(p => p.OrderRequiredResourceNavigations)
                    .HasForeignKey(d => d.RequiredResource)
                    .HasConstraintName("FK_Orders_RequiredResource");

                entity.HasOne(d => d.ResourceNavigation)
                    .WithMany(p => p.OrderResourceNavigations)
                    .HasForeignKey(d => d.Resource)
                    .HasConstraintName("FK_Orders_Resource");

                entity.HasOne(d => d.ResourceGroupNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ResourceGroup)
                    .HasConstraintName("FK_Orders_ResourceGroup");
            });

            modelBuilder.Entity<OrderStatus>(entity =>
            {
                entity.ToTable("OrderStatus", "UserData");

                entity.Property(e => e.OrderStatusId).HasDefaultValueSql("((1))");

                entity.Property(e => e.Color).HasDefaultValueSql("((16))");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ExternalId)
                    .HasMaxLength(99)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.OrderStatusName)
                    .HasMaxLength(99)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Rank).HasDefaultValueSql("((1))");

                entity.Property(e => e.SeqOrderStatus).HasColumnName("__seq__OrderStatus");

                entity.Property(e => e.SpareStringField1)
                    .HasMaxLength(99)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SpareStringField2)
                    .HasMaxLength(99)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<Resource>(entity =>
            {
                entity.HasKey(e => e.ResourcesId)
                    .HasName("Resources PK");

                entity.ToTable("Resources", "UserData");

                entity.Property(e => e.ResourcesId).HasDefaultValueSql("((1))");

                entity.Property(e => e.Attribute1)
                    .HasMaxLength(99)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DisplaySequenceNumber).HasDefaultValueSql("((1))");

                entity.Property(e => e.DisplayUsagePlot)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Efficiency).HasDefaultValueSql("((100))");

                entity.Property(e => e.EfficiencyMultiplier).HasComputedColumnSql("(CONVERT([float],case when (100)=(0) then (0) else CONVERT([float],[Efficiency],(0))/(100) end,(0)))", false);

                entity.Property(e => e.ExternalId)
                    .HasMaxLength(99)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FiniteOrInfinite).HasDefaultValueSql("((1))");

                entity.Property(e => e.FiniteToggle).HasComputedColumnSql("(CONVERT([bit],case when CONVERT([float],[FiniteOrInfinite],(0))=(1) then (1) else (0) end,(0)))", false);

                entity.Property(e => e.GraduationItems).HasDefaultValueSql("((2))");

                entity.Property(e => e.GraduationTime).HasDefaultValueSql("((1))");

                entity.Property(e => e.InfiniteModeBehavior).HasDefaultValueSql("((-2))");

                entity.Property(e => e.MatchField)
                    .HasMaxLength(200)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.MatchPropertyRemote).HasColumnName("MatchProperty__remote");

                entity.Property(e => e.Name)
                    .HasMaxLength(99)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PlotColor).HasDefaultValueSql("((8))");

                entity.Property(e => e.PlotColorAboveMaxHours).HasDefaultValueSql("((8))");

                entity.Property(e => e.PlotFillPattern).HasDefaultValueSql("((1))");

                entity.Property(e => e.PreactorDisplayOrder).HasDefaultValueSql("((1))");

                entity.Property(e => e.ResourceWindow).HasDefaultValueSql("((1))");

                entity.Property(e => e.SeqResources).HasColumnName("__seq__Resources");

                entity.Property(e => e.SetupEfficiencyMultiplier).HasComputedColumnSql("(CONVERT([float],case when CONVERT([float],[ApplyEfficiencyToSetups],(0))=(1) then (1) else (0) end*case when case when (100)=(0) then (0) else CONVERT([float],[Efficiency],(0))/(100) end=(0) then (0) else (1)/case when (100)=(0) then (0) else CONVERT([float],[Efficiency],(0))/(100) end end+case when CONVERT([float],[ApplyEfficiencyToSetups],(0))=(0) then (1) else (0) end*(1),(0)))", false);

                entity.Property(e => e.SetupTimeLineColor).HasDefaultValueSql("((5))");

                entity.Property(e => e.VerticalBucketSize).HasDefaultValueSql("((24))");
            });

            modelBuilder.Entity<ResourceGroup>(entity =>
            {
                entity.HasKey(e => e.ResourceGroupsId)
                    .HasName("ResourceGroups PK");

                entity.ToTable("ResourceGroups", "UserData");

                entity.Property(e => e.ResourceGroupsId).HasDefaultValueSql("((1))");

                entity.Property(e => e.DisplayUsagePlot)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ExternalId)
                    .HasMaxLength(99)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Name)
                    .HasMaxLength(99)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PlotColor).HasDefaultValueSql("((8))");

                entity.Property(e => e.PlotColorAboveMaxHours).HasDefaultValueSql("((8))");

                entity.Property(e => e.PlotFillPattern).HasDefaultValueSql("((1))");

                entity.Property(e => e.SeqResourceGroups).HasColumnName("__seq__ResourceGroups");

                entity.Property(e => e.SetupTimeLineColor).HasDefaultValueSql("((5))");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
