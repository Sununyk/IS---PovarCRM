using System;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using Microsoft.Extensions.Options;
using PovarCRM.Migrations;
using PovarCRM.Models.Views;

namespace PovarCRM.Models;

public class PovarDbContextFactory : IDesignTimeDbContextFactory<PovarDbContext>
{
    public PovarDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<PovarDbContext>();
        var connectionString = ConfigurationManager.ConnectionStrings["PovarDbContext"].ConnectionString;
        optionsBuilder.UseSqlServer(connectionString);

        var mode = PovarDbContext.DbMode.DataBaseOn; // default
        if (args.Length > 0 && Enum.TryParse<PovarDbContext.DbMode>(args[0], out var result)){
            mode = result;
        }
        return new PovarDbContext(optionsBuilder.Options, mode);

    }
}

public partial class PovarDbContext : DbContext
{
    public enum DbMode
    {
        DataBaseOn,  // реальная база
        DataBaseOff  // InMemory / временное хранение
    }
    public PovarDbContext()
    {
        connectionString = ConfigurationManager.ConnectionStrings["PovarDbContext"].ConnectionString;
    }

    public PovarDbContext(DbContextOptions<PovarDbContext> options, DbMode mode)
        : base(options)
    {
        if(mode == DbMode.DataBaseOn)
            connectionString = ConfigurationManager.ConnectionStrings["PovarDbContext"].ConnectionString;
        else if(mode == DbMode.DataBaseOff)
        {
            connectionString = "DataSource=:memory:";
            this._mode = mode;
        }
            
    }
    
    public virtual DbSet<Dish> Dishes { get; set; }

    public virtual DbSet<DishType> DishTypes { get; set; }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<OrderCheck> OrderChecks { get; set; }

    public virtual DbSet<Recipe> Recipes { get; set; }
    public virtual DbSet<Unit> Units { get; set; }

    public virtual DbSet<DishProduct> DishProducts { get; set; }
    public string connectionString;
    private readonly DbMode _mode = DbMode.DataBaseOn;


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured && this._mode == DbMode.DataBaseOn)
        {
            optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["PovarDbContext"].ConnectionString);
        }
        else if(this._mode == DbMode.DataBaseOff)
        {
            optionsBuilder.UseInMemoryDatabase(this.connectionString);
        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Dish>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Dish__3214EC073FCC58D9");

            entity.ToTable("Dish");

            entity.HasIndex(e => e.Naming, "UQ__Dish__EF1B1C3A7896333B").IsUnique();

            entity.Property(e => e.Cost).HasColumnType("money");
            entity.Property(e => e.Naming)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.DishType).WithMany(p => p.Dishes)
                .HasForeignKey(d => d.DishTypeId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Dish__DishTypeId__4E88ABD4");
        });

        modelBuilder.Entity<DishExpensiveView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("DishExpensiveView");

            entity.Property(e => e.Naming)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.SummaryCost).HasColumnName("SUMMARY_COST");
        });

        modelBuilder.Entity<DishProduct>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__DishProd__3214EC0793517D24");

            entity.ToTable("DishProduct");

            entity.HasIndex(e => e.Naming, "UQ__DishProd__EF1B1C3AB945F017").IsUnique();

            entity.Property(e => e.Cost).HasColumnType("money");
            entity.Property(e => e.Naming)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Unit).WithMany(p => p.DishProducts)
                .HasForeignKey(d => d.UnitId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__DishProdu__UnitI__5629CD9C");
        });

        modelBuilder.Entity<DishType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__DishType__3214EC070FA47347");

            entity.ToTable("DishType");

            entity.HasIndex(e => e.Naming, "UQ__DishType__EF1B1C3ABD2469FD").IsUnique();

            entity.Property(e => e.Naming)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Item>(entity =>
        {
            entity
                .HasKey(o => new { o.OrderCheckId, o.DishId }).HasName("PK_consist_OrderCheckId_DishId");

            entity.HasOne(d => d.Dish).WithMany()
                .HasForeignKey(d => d.DishId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Item__DishId__60A75C0F");

            entity.HasOne(d => d.OrderCheck).WithMany()
                .HasForeignKey(d => d.OrderCheckId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Item__OrderCheck__5FB337D6");
        });

        modelBuilder.Entity<OrderCheck>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OrderChe__3214EC07DDCE8732");

            entity.Property(e => e.ClientName).HasMaxLength(50).IsRequired();
            entity.ToTable("OrderCheck");

            entity.Property(e => e.OrderTime).HasColumnType("datetime");
            entity.Property(e => e.Total).HasColumnType("money");
        });

        modelBuilder.Entity<Recipe>(entity =>
        {
            entity
                .HasKey(o => new { o.DishProductId, o.DishId }).HasName("PK_consist_DishProductId_DishId");

            entity.HasIndex(e => new { e.DishId, e.DishProductId }, "UQ_Dish_Unit").IsUnique();

            entity.HasOne(d => d.Dish).WithMany()
                .HasForeignKey(d => d.DishId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Recipe__DishId__59063A47");

            entity.HasOne(d => d.DishProduct).WithMany()
                .HasForeignKey(d => d.DishProductId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Recipe__DishProd__59FA5E80");
        });

        modelBuilder.Entity<Unit>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Unit__3214EC07D9854487");

            entity.ToTable("Unit");

            entity.HasIndex(e => e.Naming, "UQ__Unit__EF1B1C3A358C331F").IsUnique();

            entity.Property(e => e.Naming)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
