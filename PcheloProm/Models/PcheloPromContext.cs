using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PcheloProm.Models;

public partial class PcheloPromContext : DbContext
{
    public PcheloPromContext()
    {
    }

    public PcheloPromContext(DbContextOptions<PcheloPromContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Apiary> Apiaries { get; set; }

    public virtual DbSet<BeeFamily> BeeFamilies { get; set; }

    public virtual DbSet<Beehive> Beehives { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Harvest> Harvests { get; set; }

    public virtual DbSet<Inventory> Inventories { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Report> Reports { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<SeasonalWork> SeasonalWorks { get; set; }

    public virtual DbSet<Store> Stores { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<SupplyMaterial> SupplyMaterials { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Warehouse> Warehouses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=QWE\\QWE;Database=PcheloProm;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Apiary>(entity =>
        {
            entity.HasKey(e => e.ApiaryId).HasName("PK__Apiaries__AE9520B0101CBA98");

            entity.Property(e => e.ApiaryId).HasColumnName("apiary_id");
            entity.Property(e => e.ApiaryName)
                .HasMaxLength(100)
                .HasColumnName("apiary_name");
            entity.Property(e => e.CurrentBeehives).HasColumnName("current_beehives");
            entity.Property(e => e.Location)
                .HasMaxLength(255)
                .HasColumnName("location");
            entity.Property(e => e.Notes).HasColumnName("notes");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasColumnName("phone");
            entity.Property(e => e.ResponsibleId).HasColumnName("responsible_id");
            entity.Property(e => e.TotalCapacity).HasColumnName("total_capacity");

            entity.HasOne(d => d.Responsible).WithMany(p => p.Apiaries)
                .HasForeignKey(d => d.ResponsibleId)
                .HasConstraintName("FK_Apiaries_Users");
        });

        modelBuilder.Entity<BeeFamily>(entity =>
        {
            entity.HasKey(e => e.FamilyId).HasName("PK__BeeFamil__28829CD6C156DB79");

            entity.Property(e => e.FamilyId).HasColumnName("family_id");
            entity.Property(e => e.BeehiveId).HasColumnName("beehive_id");
            entity.Property(e => e.Breed)
                .HasMaxLength(100)
                .HasColumnName("breed");
            entity.Property(e => e.FamilyNumber)
                .HasMaxLength(20)
                .HasColumnName("family_number");
            entity.Property(e => e.HealthStatus)
                .HasMaxLength(50)
                .HasColumnName("health_status");
            entity.Property(e => e.Notes).HasColumnName("notes");
            entity.Property(e => e.ProductivityRating).HasColumnName("productivity_rating");
            entity.Property(e => e.QueenAge).HasColumnName("queen_age");
            entity.Property(e => e.QueenOrigin)
                .HasMaxLength(100)
                .HasColumnName("queen_origin");
            entity.Property(e => e.Strength)
                .HasMaxLength(20)
                .HasColumnName("strength");

            entity.HasOne(d => d.Beehive).WithMany(p => p.BeeFamilies)
                .HasForeignKey(d => d.BeehiveId)
                .HasConstraintName("FK_BeeFamilies_Beehives");
        });

        modelBuilder.Entity<Beehive>(entity =>
        {
            entity.HasKey(e => e.BeehiveId).HasName("PK__Beehives__418E8D02597BFCF6");

            entity.Property(e => e.BeehiveId).HasColumnName("beehive_id");
            entity.Property(e => e.ApiaryId).HasColumnName("apiary_id");
            entity.Property(e => e.Condition)
                .HasMaxLength(50)
                .HasColumnName("condition");
            entity.Property(e => e.HiveNumber)
                .HasMaxLength(20)
                .HasColumnName("hive_number");
            entity.Property(e => e.HiveType)
                .HasMaxLength(50)
                .HasColumnName("hive_type");
            entity.Property(e => e.InstallationDate).HasColumnName("installation_date");
            entity.Property(e => e.IsOccupied).HasColumnName("is_occupied");

            entity.HasOne(d => d.Apiary).WithMany(p => p.Beehives)
                .HasForeignKey(d => d.ApiaryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Beehives_Apiaries");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__CD65CB8582FFDE42");

            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .HasColumnName("address");
            entity.Property(e => e.CustomerType)
                .HasMaxLength(20)
                .HasColumnName("customer_type");
            entity.Property(e => e.DiscountPercent)
                .HasDefaultValueSql("((0.00))")
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("discount_percent");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.FullName)
                .HasMaxLength(100)
                .HasColumnName("full_name");
            entity.Property(e => e.Notes).HasColumnName("notes");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasColumnName("phone");
            entity.Property(e => e.RegistrationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("registration_date");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__Employee__C52E0BA8C1B8138D");

            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.Department)
                .HasMaxLength(100)
                .HasColumnName("department");
            entity.Property(e => e.HireDate).HasColumnName("hire_date");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.Position)
                .HasMaxLength(100)
                .HasColumnName("position");
            entity.Property(e => e.Salary)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("salary");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Employees)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Employees_Users");
        });

        modelBuilder.Entity<Harvest>(entity =>
        {
            entity.HasKey(e => e.HarvestId).HasName("PK__Harvest__DE8766CD4B8A70CD");

            entity.ToTable("Harvest");

            entity.Property(e => e.HarvestId).HasColumnName("harvest_id");
            entity.Property(e => e.FamilyId).HasColumnName("family_id");
            entity.Property(e => e.HarvestDate).HasColumnName("harvest_date");
            entity.Property(e => e.HarvesterId).HasColumnName("harvester_id");
            entity.Property(e => e.Notes).HasColumnName("notes");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.QualityGrade)
                .HasMaxLength(50)
                .HasColumnName("quality_grade");
            entity.Property(e => e.Quantity)
                .HasColumnType("decimal(10, 3)")
                .HasColumnName("quantity");

            entity.HasOne(d => d.Family).WithMany(p => p.Harvests)
                .HasForeignKey(d => d.FamilyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Harvest_BeeFamilies");

            entity.HasOne(d => d.Harvester).WithMany(p => p.Harvests)
                .HasForeignKey(d => d.HarvesterId)
                .HasConstraintName("FK_Harvest_Users");

            entity.HasOne(d => d.Product).WithMany(p => p.Harvests)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Harvest_Products");
        });

        modelBuilder.Entity<Inventory>(entity =>
        {
            entity.HasKey(e => e.InventoryId).HasName("PK__Inventor__B59ACC49AD9078A9");

            entity.ToTable("Inventory");

            entity.Property(e => e.InventoryId).HasColumnName("inventory_id");
            entity.Property(e => e.BatchNumber)
                .HasMaxLength(50)
                .HasColumnName("batch_number");
            entity.Property(e => e.ExpirationDate).HasColumnName("expiration_date");
            entity.Property(e => e.LastUpdated)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("last_updated");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.ProductionDate).HasColumnName("production_date");
            entity.Property(e => e.Quantity)
                .HasDefaultValueSql("((0.000))")
                .HasColumnType("decimal(10, 3)")
                .HasColumnName("quantity");
            entity.Property(e => e.WarehouseId).HasColumnName("warehouse_id");

            entity.HasOne(d => d.Product).WithMany(p => p.Inventories)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Inventory_Products");

            entity.HasOne(d => d.Warehouse).WithMany(p => p.Inventories)
                .HasForeignKey(d => d.WarehouseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Inventory_Warehouses");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Orders__46596229ED130216");

            entity.HasIndex(e => e.OrderNumber, "UQ__Orders__730E34DFDD060244").IsUnique();

            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.DeliveryAddress)
                .HasMaxLength(255)
                .HasColumnName("delivery_address");
            entity.Property(e => e.DeliveryType)
                .HasMaxLength(50)
                .HasColumnName("delivery_type");
            entity.Property(e => e.DiscountAmount)
                .HasDefaultValueSql("((0.00))")
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("discount_amount");
            entity.Property(e => e.Notes).HasColumnName("notes");
            entity.Property(e => e.OrderDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("order_date");
            entity.Property(e => e.OrderNumber)
                .HasMaxLength(50)
                .HasColumnName("order_number");
            entity.Property(e => e.OrderStatus)
                .HasMaxLength(50)
                .HasColumnName("order_status");
            entity.Property(e => e.PaymentMethod)
                .HasMaxLength(50)
                .HasColumnName("payment_method");
            entity.Property(e => e.PaymentStatus)
                .HasMaxLength(50)
                .HasColumnName("payment_status");
            entity.Property(e => e.StoreId).HasColumnName("store_id");
            entity.Property(e => e.TotalAmount)
                .HasDefaultValueSql("((0.00))")
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("total_amount");

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Orders_Customers");

            entity.HasOne(d => d.Store).WithMany(p => p.Orders)
                .HasForeignKey(d => d.StoreId)
                .HasConstraintName("FK_Orders_Stores");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasKey(e => e.ItemId).HasName("PK__OrderIte__52020FDDCA94B70E");

            entity.Property(e => e.ItemId).HasColumnName("item_id");
            entity.Property(e => e.DiscountPercent)
                .HasDefaultValueSql("((0.00))")
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("discount_percent");
            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.PricePerUnit)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price_per_unit");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.Quantity)
                .HasColumnType("decimal(10, 3)")
                .HasColumnName("quantity");
            entity.Property(e => e.TotalPrice)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("total_price");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderItems_Orders");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderItems_Products");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Products__47027DF5E277E6CC");

            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.Category)
                .HasMaxLength(50)
                .HasColumnName("category");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.PricePerUnit)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price_per_unit");
            entity.Property(e => e.ProductName)
                .HasMaxLength(100)
                .HasColumnName("product_name");
            entity.Property(e => e.ShelfLife).HasColumnName("shelf_life");
            entity.Property(e => e.StorageConditions)
                .HasMaxLength(255)
                .HasColumnName("storage_conditions");
            entity.Property(e => e.UnitOfMeasure)
                .HasMaxLength(20)
                .HasColumnName("unit_of_measure");
            entity.Property(e => e.WholesalePrice)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("wholesale_price");
        });

        modelBuilder.Entity<Report>(entity =>
        {
            entity.HasKey(e => e.ReportId).HasName("PK__Reports__779B7C58B4579724");

            entity.Property(e => e.ReportId).HasColumnName("report_id");
            entity.Property(e => e.FilePath)
                .HasMaxLength(255)
                .HasColumnName("file_path");
            entity.Property(e => e.GeneratedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("generated_at");
            entity.Property(e => e.GeneratedBy).HasColumnName("generated_by");
            entity.Property(e => e.Parameters).HasColumnName("parameters");
            entity.Property(e => e.ReportType)
                .HasMaxLength(50)
                .HasColumnName("report_type");

            entity.HasOne(d => d.GeneratedByNavigation).WithMany(p => p.Reports)
                .HasForeignKey(d => d.GeneratedBy)
                .HasConstraintName("FK_Reports_Users");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Roles__760965CC20E2B8FB");

            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.RoleName)
                .HasMaxLength(50)
                .HasColumnName("role_name");
        });

        modelBuilder.Entity<SeasonalWork>(entity =>
        {
            entity.HasKey(e => e.WorkId).HasName("PK__Seasonal__110F4747C2EA7FDC");

            entity.Property(e => e.WorkId).HasColumnName("work_id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.FamilyId).HasColumnName("family_id");
            entity.Property(e => e.MaterialsUsed).HasColumnName("materials_used");
            entity.Property(e => e.NextAction).HasColumnName("next_action");
            entity.Property(e => e.Result).HasColumnName("result");
            entity.Property(e => e.WorkDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("work_date");
            entity.Property(e => e.WorkType)
                .HasMaxLength(100)
                .HasColumnName("work_type");
            entity.Property(e => e.WorkerId).HasColumnName("worker_id");

            entity.HasOne(d => d.Family).WithMany(p => p.SeasonalWorks)
                .HasForeignKey(d => d.FamilyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SeasonalWorks_BeeFamilies");

            entity.HasOne(d => d.Worker).WithMany(p => p.SeasonalWorks)
                .HasForeignKey(d => d.WorkerId)
                .HasConstraintName("FK_SeasonalWorks_Users");
        });

        modelBuilder.Entity<Store>(entity =>
        {
            entity.HasKey(e => e.StoreId).HasName("PK__Stores__A2F2A30CD9DD8795");

            entity.Property(e => e.StoreId).HasColumnName("store_id");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .HasColumnName("address");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.ManagerId).HasColumnName("manager_id");
            entity.Property(e => e.OpeningHours)
                .HasMaxLength(100)
                .HasColumnName("opening_hours");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasColumnName("phone");
            entity.Property(e => e.StoreName)
                .HasMaxLength(100)
                .HasColumnName("store_name");

            entity.HasOne(d => d.Manager).WithMany(p => p.Stores)
                .HasForeignKey(d => d.ManagerId)
                .HasConstraintName("FK_Stores_Users");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.SupplierId).HasName("PK__Supplier__6EE594E855620FF9");

            entity.Property(e => e.SupplierId).HasColumnName("supplier_id");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .HasColumnName("address");
            entity.Property(e => e.ContactPerson)
                .HasMaxLength(100)
                .HasColumnName("contact_person");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Inn)
                .HasMaxLength(12)
                .HasColumnName("inn");
            entity.Property(e => e.Notes).HasColumnName("notes");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasColumnName("phone");
            entity.Property(e => e.SupplierName)
                .HasMaxLength(100)
                .HasColumnName("supplier_name");
        });

        modelBuilder.Entity<SupplyMaterial>(entity =>
        {
            entity.HasKey(e => e.SupplyId).HasName("PK__SupplyMa__4870CD83DA293645");

            entity.Property(e => e.SupplyId).HasColumnName("supply_id");
            entity.Property(e => e.MaterialName)
                .HasMaxLength(100)
                .HasColumnName("material_name");
            entity.Property(e => e.Quantity)
                .HasColumnType("decimal(10, 3)")
                .HasColumnName("quantity");
            entity.Property(e => e.ReceivedBy).HasColumnName("received_by");
            entity.Property(e => e.SupplierId).HasColumnName("supplier_id");
            entity.Property(e => e.SupplyDate).HasColumnName("supply_date");
            entity.Property(e => e.TotalCost)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("total_cost");
            entity.Property(e => e.UnitPrice)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("unit_price");

            entity.HasOne(d => d.ReceivedByNavigation).WithMany(p => p.SupplyMaterials)
                .HasForeignKey(d => d.ReceivedBy)
                .HasConstraintName("FK_SupplyMaterials_Users");

            entity.HasOne(d => d.Supplier).WithMany(p => p.SupplyMaterials)
                .HasForeignKey(d => d.SupplierId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SupplyMaterials_Suppliers");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__B9BE370F969AC8DB");

            entity.HasIndex(e => e.Email, "UQ__Users__AB6E61648BBCF767").IsUnique();

            entity.HasIndex(e => e.Username, "UQ__Users__F3DBC5729E00377E").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.FullName)
                .HasMaxLength(100)
                .HasColumnName("full_name");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.LastLogin)
                .HasColumnType("datetime")
                .HasColumnName("last_login");
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(255)
                .HasColumnName("password_hash");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasColumnName("phone");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Users_Roles");
        });

        modelBuilder.Entity<Warehouse>(entity =>
        {
            entity.HasKey(e => e.WarehouseId).HasName("PK__Warehous__734FE6BF64620608");

            entity.Property(e => e.WarehouseId).HasColumnName("warehouse_id");
            entity.Property(e => e.Capacity).HasColumnName("capacity");
            entity.Property(e => e.Location)
                .HasMaxLength(255)
                .HasColumnName("location");
            entity.Property(e => e.ResponsibleId).HasColumnName("responsible_id");
            entity.Property(e => e.WarehouseName)
                .HasMaxLength(100)
                .HasColumnName("warehouse_name");
            entity.Property(e => e.WarehouseType)
                .HasMaxLength(50)
                .HasColumnName("warehouse_type");

            entity.HasOne(d => d.Responsible).WithMany(p => p.Warehouses)
                .HasForeignKey(d => d.ResponsibleId)
                .HasConstraintName("FK_Warehouses_Users");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
