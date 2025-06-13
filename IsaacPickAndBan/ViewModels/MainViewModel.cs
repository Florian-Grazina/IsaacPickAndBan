using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IsaacPickAndBan.Views;

namespace IsaacPickAndBan.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        #region fields
        private readonly CardsArchiveViewModel _cardsArchiveViewModel;
        #endregion

        #region constructor
        public MainViewModel(CardsArchiveViewModel cardsArchiveViewModel)
        {
            _cardsArchiveViewModel = cardsArchiveViewModel;
            OpenCardsArchive();
        }
        #endregion

        #region observable properties
        [ObservableProperty]
        private ContentView? activeContentView;
        #endregion

        #region properties
        #endregion

        #region public methods
        [RelayCommand]
        public void OpenCardsArchive()
        {
            ActiveContentView = new CardsArchive(_cardsArchiveViewModel);
        }
        #endregion

        #region commands
        #endregion

        #region private methods
        #endregion
    }
}
