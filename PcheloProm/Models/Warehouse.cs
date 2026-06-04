using System;
using System.Collections.Generic;

namespace PcheloProm.Models;

public partial class Warehouse
{
    public int WarehouseId { get; set; }

    public string WarehouseName { get; set; } = null!;

    public string? Location { get; set; }

    public string WarehouseType { get; set; } = null!;

    public int? Capacity { get; set; }

    public int? ResponsibleId { get; set; }

    public virtual ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();

    public virtual User? Responsible { get; set; }
}
