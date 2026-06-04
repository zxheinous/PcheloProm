using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PcheloProm.Infrastructure;
using PcheloProm.Models;

namespace PcheloProm.ViewModels;

public class WarehousesViewModel : ViewModelBase
{
    private readonly PcheloPromContext _context = new();
    private ObservableCollection<Inventory> _inventories = new();

    public ObservableCollection<Inventory> Inventories
    {
        get => _inventories;
        set => SetField(ref _inventories, value);
    }

    public WarehousesViewModel()
    {
        LoadData();
    }

    private void LoadData()
    {
        var data = _context.Inventories
            .Include(i => i.Product)
            .Include(i => i.Warehouse)
            .ToList();

        Inventories = new ObservableCollection<Inventory>(data);
    }
}