using System;
using System.Collections.Generic;

namespace PcheloProm.Models;

public partial class User
{
    public int UserId { get; set; }

    public string Username { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Phone { get; set; }

    public int RoleId { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? LastLogin { get; set; }

    public virtual ICollection<Apiary> Apiaries { get; set; } = new List<Apiary>();

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual ICollection<Harvest> Harvests { get; set; } = new List<Harvest>();

    public virtual ICollection<Report> Reports { get; set; } = new List<Report>();

    public virtual Role Role { get; set; } = null!;

    public virtual ICollection<SeasonalWork> SeasonalWorks { get; set; } = new List<SeasonalWork>();

    public virtual ICollection<Store> Stores { get; set; } = new List<Store>();

    public virtual ICollection<SupplyMaterial> SupplyMaterials { get; set; } = new List<SupplyMaterial>();

    public virtual ICollection<Warehouse> Warehouses { get; set; } = new List<Warehouse>();
}
