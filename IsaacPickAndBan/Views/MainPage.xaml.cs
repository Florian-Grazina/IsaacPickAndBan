using IsaacPickAndBan.Database;
using IsaacPickAndBan.ViewModels;

namespace IsaacPickAndBan
{
    public partial class MainPage : ContentPage
    {
        // properties
        private readonly MainViewModel _viewModel;


        // constructor
        public MainPage(MainViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            BindingContext = _viewModel;
        }

        // methods
        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            _viewModel.ListOfCards = Data.ListOfCards.Where(card => card.Name.Contains(e.NewTextValue)).ToList();
        }

        private async void FlipCard(object sender, EventArgs e)
        {
            await cardFrame.ScaleTo(1.02, 0, Easing.Linear);
            _viewModel.FlipCard();
            await cardFrame.ScaleTo(1.0, 200, Easing.BounceOut);
        }
    }
}
