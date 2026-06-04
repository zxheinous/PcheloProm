using System;
using System.Collections.Generic;

namespace PcheloProm.Models;

public partial class Store
{
    public int StoreId { get; set; }

    public string StoreName { get; set; } = null!;

    public string? Address { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? OpeningHours { get; set; }

    public int? ManagerId { get; set; }

    public virtual User? Manager { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
