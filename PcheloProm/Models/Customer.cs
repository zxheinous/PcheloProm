using System;
using System.Collections.Generic;

namespace PcheloProm.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string CustomerType { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? Address { get; set; }

    public decimal DiscountPercent { get; set; }

    public DateOnly RegistrationDate { get; set; }

    public string? Notes { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
