﻿using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DemoGAPI.Models
{
    public partial class DG1Context : DbContext
    {
        public DG1Context()
        {
        }

        public DG1Context(DbContextOptions<DG1Context> options)
            : base(options)
        {
        }

        public virtual DbSet<WorkOrder> WorkOrders { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=AN-LETHANH\\DEMOS;Database=DG1;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WorkOrder>(entity =>
            {
                entity.HasKey(e => e.OrdersId);

                entity.Property(e => e.ActualQuantity).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ActusalSetupStart).HasColumnType("datetime");

                entity.Property(e => e.EndTime).HasColumnType("datetime");

                entity.Property(e => e.MachinesId).HasMaxLength(100);

                entity.Property(e => e.Note).HasMaxLength(100);

                entity.Property(e => e.OrdersName).HasMaxLength(100);

                entity.Property(e => e.Product).HasMaxLength(100);

                entity.Property(e => e.Quantity).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ResourceGroupName).HasMaxLength(100);

                entity.Property(e => e.ResourceName).HasMaxLength(100);

                entity.Property(e => e.SetupStart).HasColumnType("datetime");

                entity.Property(e => e.StartTime).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
