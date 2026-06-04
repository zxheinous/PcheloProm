using System;
using System.Collections.Generic;

namespace PcheloProm.Models;

public partial class Harvest
{
    public int HarvestId { get; set; }

    public int FamilyId { get; set; }

    public int ProductId { get; set; }

    public DateOnly HarvestDate { get; set; }

    public decimal Quantity { get; set; }

    public string? QualityGrade { get; set; }

    public int? HarvesterId { get; set; }

    public string? Notes { get; set; }

    public virtual BeeFamily Family { get; set; } = null!;

    public virtual User? Harvester { get; set; }

    public virtual Product Product { get; set; } = null!;
}
