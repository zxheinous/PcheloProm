using System;
using System.Collections.Generic;

namespace PcheloProm.Models;

public partial class Report
{
    public int ReportId { get; set; }

    public string ReportType { get; set; } = null!;

    public int? GeneratedBy { get; set; }

    public DateTime GeneratedAt { get; set; }

    public string? Parameters { get; set; }

    public string? FilePath { get; set; }

    public virtual User? GeneratedByNavigation { get; set; }
}
