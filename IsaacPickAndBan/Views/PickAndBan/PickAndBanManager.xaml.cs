using IsaacPickAndBan.ViewModels;

namespace IsaacPickAndBan.Views.PickAndBan;

public partial class PickAndBanManager : ContentView
{
    PickAndBanManagerViewModel _viewModel;

	public PickAndBanManager(PickAndBanManagerViewModel viewModel)
	{
		_viewModel = viewModel;
        BindingContext = _viewModel;
        InitializeComponent();
    }

    private void ContentView_Loaded(object sender, EventArgs e)
    {
        _viewModel.LoadFilterContentView();
    }
}