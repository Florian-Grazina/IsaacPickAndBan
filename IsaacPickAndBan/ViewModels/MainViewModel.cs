using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IsaacPickAndBan.Database;
using IsaacPickAndBan.Models;

namespace IsaacPickAndBan.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        // properties
        [ObservableProperty]
        public List<Card> listOfCards;

        [ObservableProperty]
        public bool isFocused = false;

        [ObservableProperty]
        public Card focusedCard;


        // constructor
        public MainViewModel()
        {
            ListOfCards = Data.ListOfCards;
        }


        // methods
        [RelayCommand]
        public void FocusingOnCard(Card focusedCard)
        {
            IsFocused = true;
            FocusedCard = focusedCard;
        }

        public string TurnFocusCard()
        {
            return FocusedCard.Ethernal;
        }

        [RelayCommand]
        public void ClearFocus()
        {
            IsFocused = false;
            FocusedCard = null;
        }
    }
}
