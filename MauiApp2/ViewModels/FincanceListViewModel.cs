using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using MauiApp2.ViewModels;
using MauiApp2.Models;
using MauiApp2;

public class FinanceListViewModel : INotifyPropertyChanged
{
    public ObservableCollection<FinanceViewModel> Finances { get; set; }

    public event PropertyChangedEventHandler PropertyChanged;

    public ICommand CreateFinanceCommand { protected set; get; }
    public ICommand DeleteFinanceCommand { protected set; get; }
    public ICommand SaveFinanceCommand { protected set; get; }
    public ICommand BackCommand { protected set; get; }
    FinanceViewModel selectedFinance;

    public INavigation Navigation { get; set; }

    public FinanceListViewModel()
    {
        Finances = new ObservableCollection<FinanceViewModel>();
        CreateFinanceCommand = new Command(CreateFinance);
        DeleteFinanceCommand = new Command(DeleteFinance);
        SaveFinanceCommand = new Command(SaveFinance);
        BackCommand = new Command(Back);
    }

    public FinanceViewModel SelectedFinance
    {
        get { return selectedFinance; }
        set
        {
            if (selectedFinance != value)
            {
                FinanceViewModel tempFinance = value;
                selectedFinance = null;
                OnPropertyChanged("SelectedFinance");
                Navigation.PushAsync(new FinancePage(tempFinance));
            }
        }
    }

    protected void OnPropertyChanged(string propName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
    }

    private void CreateFinance()
    {
        Navigation.PushAsync(new FinancePage(new FinanceViewModel() { ListViewModel = this }));
    }

    private void Back()
    {
        Navigation.PopAsync();
    }

    private void SaveFinance(object financeObject)
    {
        FinanceViewModel finance = financeObject as FinanceViewModel;
        if (finance != null && finance.IsValid && !Finances.Contains(finance))
        {
            Finances.Add(finance);
        }
        Back();
    }

    private void DeleteFinance(object financeObject)
    {
        FinanceViewModel finance = financeObject as FinanceViewModel;
        if (finance != null)
        {
            Finances.Remove(finance);
        }
        Back();
    }
}