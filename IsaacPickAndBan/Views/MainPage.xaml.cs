using IsaacPickAndBan.ViewModels;

namespace IsaacPickAndBan
{
    public partial class MainPage : ContentPage
    {
        #region properties
        private readonly MainViewModel _viewModel;
        #endregion

        #region constructor
        public MainPage(MainViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            BindingContext = _viewModel;
        }
        #endregion
    }
}
