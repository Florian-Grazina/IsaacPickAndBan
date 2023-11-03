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
        public bool isFlipped = false;
        
        [ObservableProperty]
        public bool isNotFlipped = true;

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
    }
}
