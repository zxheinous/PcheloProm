using System;
using System.Collections.Generic;

namespace PcheloProm.Models;

public partial class BeeFamily
{
    public int FamilyId { get; set; }

    public int? BeehiveId { get; set; }

    public string FamilyNumber { get; set; } = null!;

    public string Breed { get; set; } = null!;

    public int? QueenAge { get; set; }

    public string? QueenOrigin { get; set; }

    public string? Strength { get; set; }

    public string? HealthStatus { get; set; }

    public int? ProductivityRating { get; set; }

    public string? Notes { get; set; }

    public virtual Beehive? Beehive { get; set; }

    public virtual ICollection<Harvest> Harvests { get; set; } = new List<Harvest>();

    public virtual ICollection<SeasonalWork> SeasonalWorks { get; set; } = new List<SeasonalWork>();
}
