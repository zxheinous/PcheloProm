using System;
using System.Collections.Generic;

namespace PcheloProm.Models;

public partial class OrderItem
{
    public int ItemId { get; set; }

    public int OrderId { get; set; }

    public int ProductId { get; set; }

    public decimal Quantity { get; set; }

    public decimal PricePerUnit { get; set; }

    public decimal DiscountPercent { get; set; }

    public decimal TotalPrice { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
