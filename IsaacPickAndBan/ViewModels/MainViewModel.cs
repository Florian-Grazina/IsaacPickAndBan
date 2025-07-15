using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IsaacPickAndBan.Views;
using IsaacPickAndBan.Views.PickAndBan;

namespace IsaacPickAndBan.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        #region fields
        private readonly CardsArchiveViewModel _cardsArchiveViewModel;
        private readonly PickAndBanManagerViewModel _pickAndBanManagerViewModel;
        #endregion

        #region constructor
        public MainViewModel(CardsArchiveViewModel cardsArchiveViewModel, PickAndBanManagerViewModel pickAndBanManagerViewModel)
        {
            _cardsArchiveViewModel = cardsArchiveViewModel;
            _pickAndBanManagerViewModel = pickAndBanManagerViewModel;
            OpenCardsArchive();
        }
        #endregion

        #region observable properties
        [ObservableProperty]
        private ContentView? activeContentView;
        #endregion

        #region properties
        #endregion

        #region commands
        [RelayCommand]
        public void OpenCardsArchive()
        {
            _cardsArchiveViewModel.FilteredListOfCards?.Clear();
            ActiveContentView = new CardsArchive(_cardsArchiveViewModel);
        }

        [RelayCommand]
        public void OpenPickAndBan()
        {
            ActiveContentView = new PickAndBanManager(_pickAndBanManagerViewModel);
        }
        #endregion

        #region private methods
        #endregion
    }
}
