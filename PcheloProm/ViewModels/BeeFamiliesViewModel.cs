using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using PcheloProm.Infrastructure;
using PcheloProm.Models;

namespace PcheloProm.ViewModels;

public class BeeFamiliesViewModel : ViewModelBase
{
    private readonly PcheloPromContext _context = new();
    private ObservableCollection<BeeFamily> _beeFamilies = new();

    public ObservableCollection<BeeFamily> BeeFamilies
    {
        get => _beeFamilies;
        set => SetField(ref _beeFamilies, value);
    }

    public BeeFamiliesViewModel()
    {
        LoadData();
    }

    private void LoadData()
    {
        var data = _context.BeeFamilies.ToList();
        BeeFamilies = new ObservableCollection<BeeFamily>(data);
    }
}