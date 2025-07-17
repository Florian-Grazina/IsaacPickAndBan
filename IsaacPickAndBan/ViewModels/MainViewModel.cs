using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IsaacPickAndBan.Views;
using IsaacPickAndBan.Views.PickAndBan;

namespace IsaacPickAndBan.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        #region fields
        private readonly CardsArchiveManager _cardsArchiveManager;
        private readonly PickAndBanManager _pickAndBanManager;
        #endregion

        #region constructor
        public MainViewModel(CardsArchiveViewModel cardsArchiveViewModel, PickAndBanManagerViewModel pickAndBanManagerViewModel)
        {
            _cardsArchiveManager = new(cardsArchiveViewModel);
            _pickAndBanManager = new (pickAndBanManagerViewModel);
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
            ActiveContentView = _cardsArchiveManager;
        }

        [RelayCommand]
        public void OpenPickAndBan()
        {
            ActiveContentView = _pickAndBanManager;
        }
        #endregion

        #region public methods
        #endregion
    }
}
