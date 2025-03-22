using MauiApp2.ViewModels;
namespace MauiApp2;

public partial class FinancePage : ContentPage
{

    public FinanceViewModel ViewModel { get; private set; }
    public FinancePage(FinanceViewModel vm)
    {
        InitializeComponent();
        ViewModel = vm;
        this.BindingContext = ViewModel;
    }
}