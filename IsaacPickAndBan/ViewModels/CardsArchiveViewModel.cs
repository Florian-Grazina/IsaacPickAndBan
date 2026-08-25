
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IsaacPickAndBan.Database;
using IsaacPickAndBan.Models;
using System.Collections.ObjectModel;

namespace IsaacPickAndBan.ViewModels
{
    public partial class CardsArchiveViewModel : ObservableObject
    {
        #region fields
        private readonly IReadOnlyList<Card> _listOfCards;
        private const int SEARCH_PAUSE_WAIT = 200;

        private CancellationTokenSource? _searchCts;
        #endregion

        #region constructor
        public CardsArchiveViewModel(Data data)
        {
            _listOfCards = data.ListOfCards;
            FilteredListOfCards = new ObservableCollection<Card>(_listOfCards);
        }
        #endregion

        #region observable properties
        [ObservableProperty]
        private ObservableCollection<Card> filteredListOfCards;

        [ObservableProperty]
        private bool isFocused = false;

        [ObservableProperty]
        private bool isFlipped = false;

        [ObservableProperty]
        private Card focusedCard;

        [ObservableProperty]
        private string searchEntry = string.Empty;

        partial void OnSearchEntryChanged(string value)
        {
            FilterItems();
        }
        #endregion

        #region public methods
        public void FlipCard()
        {
            IsFlipped = !IsFlipped;
        }

        public void Clear()
        {
            SearchEntry = string.Empty;
            ClearFocus();
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
        private async void FilterItems()
        {
            CancellationTokenSource cts = new();
            CancellationTokenSource? previous = Interlocked.Exchange(ref _searchCts, cts);
            previous?.Cancel();
            previous?.Dispose();

            try
            {
                await Task.Delay(SEARCH_PAUSE_WAIT, cts.Token);

                string term = SearchEntry;
                List<Card> matches = await Task.Run(() => Match(term), cts.Token);

                cts.Token.ThrowIfCancellationRequested();

                FilteredListOfCards = new ObservableCollection<Card>(matches);
            }
            catch (OperationCanceledException)
            {
                // the user typed somethig before the delay
            }
        }

        private List<Card> Match(string term)
        {
            if (string.IsNullOrWhiteSpace(term))
                return [.. _listOfCards];

            return [.. _listOfCards.Where(card => card.Name.Contains(term, StringComparison.OrdinalIgnoreCase))];
        }
        #endregion
    }
}
