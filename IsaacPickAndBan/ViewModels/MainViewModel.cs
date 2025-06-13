using Android.Widget;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IsaacPickAndBan.Database;
using IsaacPickAndBan.Models;
using System.Collections.ObjectModel;

namespace IsaacPickAndBan.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        #region constructor
        public MainViewModel()
        {
            listOfCards = [];
            PopulateListOfCards(Data.ListOfCards);
            Filters = GetFilters();
        }
        #endregion

        #region observable properties
        [ObservableProperty]
        public ObservableCollection<Card> listOfCards;

        [ObservableProperty]
        private bool filterMenuIsOpen = false;

        [ObservableProperty]
        private List<FilterViewModel> filters;

        [ObservableProperty]
        private bool isFocused = false;

        [ObservableProperty]
        private bool isFlipped = false;

        [ObservableProperty]
        private Card focusedCard;

        private string searchEntry = string.Empty;

        public string SearchEntry
        {
            get => searchEntry;
            set
            {
                searchEntry = value;
            }
        }
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
        #endregion

        #region private methods
        private void PopulateListOfCards(List<Card> source)
        {
            ListOfCards = new(source);
        }
        #endregion
    }
}
