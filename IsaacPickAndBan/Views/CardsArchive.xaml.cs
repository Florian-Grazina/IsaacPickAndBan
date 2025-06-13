using IsaacPickAndBan.ViewModels;

namespace IsaacPickAndBan.Views;

public partial class CardsArchive : ContentView
{
    #region properties
    private readonly CardsArchiveViewModel _viewModel;
    #endregion

    #region constructor
    public CardsArchive(CardsArchiveViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = _viewModel;
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