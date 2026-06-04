using System;
using System.Collections.Generic;

namespace PcheloProm.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public string OrderNumber { get; set; } = null!;

    public int CustomerId { get; set; }

    public DateTime OrderDate { get; set; }

    public int? StoreId { get; set; }

    public string OrderStatus { get; set; } = null!;

    public string? PaymentMethod { get; set; }

    public string? PaymentStatus { get; set; }

    public string? DeliveryType { get; set; }

    public string? DeliveryAddress { get; set; }

    public decimal TotalAmount { get; set; }

    public decimal DiscountAmount { get; set; }

    public string? Notes { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual Store? Store { get; set; }
}
