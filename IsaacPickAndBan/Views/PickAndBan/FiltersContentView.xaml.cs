using IsaacPickAndBan.ViewModels;

namespace IsaacPickAndBan.Views.PickAndBan;

public partial class FiltersContentView : ContentView
{
    #region properties
    private readonly FiltersContentViewModel _viewModel;
    #endregion

    #region constructor
    public FiltersContentView(FiltersContentViewModel viewModel)
    {
        _viewModel = viewModel;
        BindingContext = _viewModel;
        InitializeComponent();
    }
    #endregion
}
