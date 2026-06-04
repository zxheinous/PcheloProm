using System.Windows.Input;
using PcheloProm.Infrastructure;

namespace PcheloProm.ViewModels;

public class MainViewModel : ViewModelBase
{
    private ViewModelBase _currentView;

    public ViewModelBase CurrentView
    {
        get => _currentView;
        set => SetField(ref _currentView, value);
    }

    public ICommand OpenApiariesCommand { get; }
    public ICommand OpenBeeFamiliesCommand { get; }
    public ICommand OpenWarehousesCommand { get; }
    public ICommand OpenOrdersCommand { get; }

    public MainViewModel()
    {
        _currentView = new ApiariesViewModel();

        OpenApiariesCommand = new RelayCommand(_ => CurrentView = new ApiariesViewModel());
        OpenBeeFamiliesCommand = new RelayCommand(_ => CurrentView = new BeeFamiliesViewModel());
        OpenWarehousesCommand = new RelayCommand(_ => CurrentView = new WarehousesViewModel());
        OpenOrdersCommand = new RelayCommand(_ => CurrentView = new OrdersViewModel());
    }
}