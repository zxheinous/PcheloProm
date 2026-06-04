using System;
using System.Collections.Generic;

namespace PcheloProm.Models;

public partial class Supplier
{
    public int SupplierId { get; set; }

    public string SupplierName { get; set; } = null!;

    public string? ContactPerson { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? Address { get; set; }

    public string? Inn { get; set; }

    public string? Notes { get; set; }

    public virtual ICollection<SupplyMaterial> SupplyMaterials { get; set; } = new List<SupplyMaterial>();
}
