using System;
using System.Collections.Generic;

namespace PcheloProm.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public string Category { get; set; } = null!;

    public string UnitOfMeasure { get; set; } = null!;

    public string? Description { get; set; }

    public int? ShelfLife { get; set; }

    public string? StorageConditions { get; set; }

    public decimal PricePerUnit { get; set; }

    public decimal WholesalePrice { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<Harvest> Harvests { get; set; } = new List<Harvest>();

    public virtual ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
