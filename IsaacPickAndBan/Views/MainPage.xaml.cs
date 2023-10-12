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
        public void TurnFocusCard()
        {
            focusedCardImageButton.Source = "b2_the_d6.png";
        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            _viewModel.ListOfCards = Data.ListOfCards.Where(card => card.Name.Contains(e.NewTextValue)).ToList();
        }
    }
}
