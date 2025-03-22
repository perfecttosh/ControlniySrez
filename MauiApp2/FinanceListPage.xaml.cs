using MauiApp2.ViewModels;
namespace MauiApp2;

public partial class FinanceListPage : ContentPage
{

    public FinanceListPage()
    {
        InitializeComponent();
        BindingContext = new FinanceListViewModel() { Navigation = this.Navigation };
    }

}
