using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PcheloProm.Infrastructure;
using PcheloProm.Models;

namespace PcheloProm.ViewModels;

public class OrdersViewModel : ViewModelBase
{
    private readonly PcheloPromContext _context = new();
    private ObservableCollection<Order> _orders = new();

    public ObservableCollection<Order> Orders
    {
        get => _orders;
        set => SetField(ref _orders, value);
    }

    public OrdersViewModel()
    {
        LoadData();
    }

    private void LoadData()
    {
        // Загружаем заказы вместе с данными клиентов
        var data = _context.Orders
            .Include(o => o.Customer)
            .ToList();

        Orders = new ObservableCollection<Order>(data);
    }
}