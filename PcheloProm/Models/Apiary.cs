using System;
using System.Collections.Generic;

namespace PcheloProm.Models;

public partial class Apiary
{
    public int ApiaryId { get; set; }

    public string ApiaryName { get; set; } = null!;

    public string? Location { get; set; }

    public int TotalCapacity { get; set; }

    public int CurrentBeehives { get; set; }

    public int? ResponsibleId { get; set; }

    public string? Phone { get; set; }

    public string? Notes { get; set; }

    public virtual ICollection<Beehive> Beehives { get; set; } = new List<Beehive>();

    public virtual User? Responsible { get; set; }
}
