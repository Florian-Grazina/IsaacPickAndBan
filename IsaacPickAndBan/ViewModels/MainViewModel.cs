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
        private bool isFocused = false;

        [ObservableProperty]
        private bool isFlipped = false;

        [ObservableProperty]
        private bool isNotFlipped = true;

        [ObservableProperty]
        private Card focusedCard;

        [ObservableProperty]
        private double cardWidth;
        #endregion

        #region properties
        #endregion

        #region commands
        [RelayCommand]
        public void FocusingOnCard(Card focusedCard)
        {
            IsFocused = true;
            FocusedCard = focusedCard;
        }

        [RelayCommand]
        public void FlipCard()
        {
            IsFlipped = !IsFlipped;
            IsNotFlipped = !IsNotFlipped;
        }

        [RelayCommand]
        public void ClearFocus()
        {
            IsFocused = false;
            IsFlipped = false;
            IsNotFlipped = true;
            FocusedCard = null;
        }
        #endregion
    }
}
