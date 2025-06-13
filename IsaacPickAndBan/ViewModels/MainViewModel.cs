using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IsaacPickAndBan.Database;
using IsaacPickAndBan.Models;
using System.Collections.ObjectModel;

namespace IsaacPickAndBan.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        #region fields
        private readonly IEnumerable<Card> _listOfCards;
        private const int DELAY_SHOW_CARD = 30;
        #endregion

        #region constructor
        public MainViewModel(Data data)
        {
            FilteredListOfCards = [];
            _listOfCards = data.ListOfCards;
            FilterItems();
        }
        #endregion

        #region observable properties
        [ObservableProperty]
        public ObservableCollection<Card> filteredListOfCards;

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
                FilterItems();
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

        public async void FilterItems()
        {
            var newItems = await Task.Run(() =>
            {
                return _listOfCards
                    .Where(item => string.IsNullOrEmpty(SearchEntry) || item.Name.Contains(SearchEntry, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            });

            FilteredListOfCards.Clear();

            foreach (Card item in newItems)
            {
                await MainThread.InvokeOnMainThreadAsync(() => FilteredListOfCards.Add(item));
                await Task.Delay(DELAY_SHOW_CARD);
            }
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
            FocusedCard = default;
        }
        #endregion

        #region private methods
        
        #endregion
    }
}
