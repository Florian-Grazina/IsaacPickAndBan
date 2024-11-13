using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IsaacPickAndBan.Database;
using IsaacPickAndBan.Models;

namespace IsaacPickAndBan.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        #region constructor
        public MainViewModel()
        {
            ListOfCards = Data.ListOfCards;
            CardWidth = DeviceDisplay.MainDisplayInfo.Width / DeviceDisplay.MainDisplayInfo.Density / 3;
        }
        #endregion

        #region observable properties
        [ObservableProperty]
        private List<Card> listOfCards;

        [ObservableProperty]
        private bool filterMenuIsOpen = false;

        [ObservableProperty]
        private bool isFocused = false;

        [ObservableProperty]
        private bool isFlipped = false;

        [ObservableProperty]
        private Card focusedCard;

        [ObservableProperty]
        private double cardWidth;
        #endregion

        #region properties
        #endregion

        #region public methods
        public void FlipCard()
        {
            IsFlipped = !IsFlipped;
        }
        #endregion

        #region commands
        [RelayCommand]
        private void FocusingOnCard(Card focusedCard)
        {
            IsFocused = true;
            FocusedCard = focusedCard;
        }

        [RelayCommand]
        private void ClearFocus()
        {
            IsFocused = false;
            IsFlipped = false;
            FocusedCard = null;
        }

        [RelayCommand]
        private void OpenFilterMenu()
        {
            FilterMenuIsOpen = true;
        }

        [RelayCommand]
        private void CloseFilterMenu()
        {
            FilterMenuIsOpen = false;
        }
        #endregion
    }
}
