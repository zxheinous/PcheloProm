using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Microsoft.EntityFrameworkCore;
using PcheloProm.Infrastructure;
using PcheloProm.Models;

namespace PcheloProm.ViewModels;

public class ApiariesViewModel : ViewModelBase
{
    private readonly PcheloPromContext _context = new();
    private Apiary? _selectedApiary;
    private string _newApiaryName = string.Empty;
    private string? _newLocation;
    private int _newCapacity = 50;

    public ObservableCollection<Apiary> Apiaries { get; set; } = new();

    public Apiary? SelectedApiary
    {
        get => _selectedApiary;
        set => SetField(ref _selectedApiary, value);
    }

    public string NewApiaryName
    {
        get => _newApiaryName;
        set => SetField(ref _newApiaryName, value);
    }

    public string? NewLocation
    {
        get => _newLocation;
        set => SetField(ref _newLocation, value);
    }

    public int NewCapacity
    {
        get => _newCapacity;
        set => SetField(ref _newCapacity, value);
    }

    public ICommand AddCommand { get; }
    public ICommand DeleteCommand { get; }

    public ApiariesViewModel()
    {
        AddCommand = new RelayCommand(_ => AddApiary(), _ => !string.IsNullOrWhiteSpace(NewApiaryName));
        DeleteCommand = new RelayCommand(_ => DeleteApiary(), _ => SelectedApiary != null);
        LoadData();
    }

    private void LoadData()
    {
        Apiaries.Clear();
        // Загружаем пасеки вместе с ответственными пользователями
        var data = _context.Apiaries.Include(a => a.Responsible).ToList();
        foreach (var apiary in data)
        {
            Apiaries.Add(apiary);
        }
    }

    private void AddApiary()
    {
        var apiary = new Apiary
        {
            ApiaryName = NewApiaryName,
            Location = NewLocation,
            TotalCapacity = NewCapacity,
            CurrentBeehives = 0
        };

        _context.Apiaries.Add(apiary);
        _context.SaveChanges();
        Apiaries.Add(apiary);

        NewApiaryName = string.Empty;
        NewLocation = string.Empty;
        NewCapacity = 50;
    }

    private void DeleteApiary()
    {
        if (SelectedApiary == null) return;

        var result = MessageBox.Show($"Вы уверены, что хотите удалить пасеку '{SelectedApiary.ApiaryName}'?",
            "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Warning);

        if (result == MessageBoxResult.Yes)
        {
            _context.Apiaries.Remove(SelectedApiary);
            _context.SaveChanges();
            Apiaries.Remove(SelectedApiary);
        }
    }
}