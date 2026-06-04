using System;
using System.Collections.Generic;

namespace PcheloProm.Models;

public partial class SeasonalWork
{
    public int WorkId { get; set; }

    public int FamilyId { get; set; }

    public string WorkType { get; set; } = null!;

    public DateTime WorkDate { get; set; }

    public int? WorkerId { get; set; }

    public string? Description { get; set; }

    public string? MaterialsUsed { get; set; }

    public string? Result { get; set; }

    public string? NextAction { get; set; }

    public virtual BeeFamily Family { get; set; } = null!;

    public virtual User? Worker { get; set; }
}
