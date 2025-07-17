using IsaacPickAndBan.ViewModels;

namespace IsaacPickAndBan.Views;

public partial class CardsArchiveManager : ContentView
{
    #region properties
    private readonly CardsArchiveViewModel _viewModel;
    #endregion

    #region constructor
    public CardsArchiveManager(CardsArchiveViewModel viewModel)
    {
        _viewModel = viewModel;
        _viewModel.Clear();
        BindingContext = _viewModel;
        InitializeComponent();
    }
    #endregion

    #region methods
    private async void FlipCard(object sender, EventArgs e)
    {
        await cardFrame.ScaleTo(1.02, 0, Easing.Linear);
        _viewModel.FlipCard();
        await cardFrame.ScaleTo(1.0, 200, Easing.BounceOut);
    }
    #endregion
}