using CommunityToolkit.Mvvm.Input;
using IsaacPickAndBan.ViewModels;

namespace IsaacPickAndBan
{
    public partial class MainPage : ContentPage
    {
        // properties
        public double ScreenWidth { get; } = DeviceDisplay.MainDisplayInfo.Width;
        public double ScreenHeight { get; } = DeviceDisplay.MainDisplayInfo.Width;

        private readonly MainViewModel _viewModel;


        // constructor
        public MainPage(MainViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            BindingContext = _viewModel;
        }


        // methods
        public void TurnFocusCard()
        {
            focusedCardImageButton.Source = "b2_the_d6.png";
        }
    }
}
