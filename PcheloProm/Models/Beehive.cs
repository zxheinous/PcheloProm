using System;
using System.Collections.Generic;

namespace PcheloProm.Models;

public partial class Beehive
{
    public int BeehiveId { get; set; }

    public int ApiaryId { get; set; }

    public string HiveNumber { get; set; } = null!;

    public string HiveType { get; set; } = null!;

    public DateOnly? InstallationDate { get; set; }

    public string? Condition { get; set; }

    public bool IsOccupied { get; set; }

    public virtual Apiary Apiary { get; set; } = null!;

    public virtual ICollection<BeeFamily> BeeFamilies { get; set; } = new List<BeeFamily>();
}
