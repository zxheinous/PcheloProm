using System;
using System.Collections.Generic;

namespace PcheloProm.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public int UserId { get; set; }

    public string Position { get; set; } = null!;

    public DateOnly HireDate { get; set; }

    public decimal Salary { get; set; }

    public string? Department { get; set; }

    public bool IsActive { get; set; }

    public virtual User User { get; set; } = null!;
}
