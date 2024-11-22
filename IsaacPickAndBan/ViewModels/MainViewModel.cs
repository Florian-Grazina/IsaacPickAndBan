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

        [RelayCommand]
        private async Task ToggleFilter(FilterViewModel filter)
        {
            filter.IsActif = !filter.IsActif;

            if(filter.IsActif)
                await AddItemsOneByOneAsync(Data.ListOfCards.Where(card => card.Extension == filter.Extension));
            else
                await RemoveItemsOneByOneAsync(ListOfCards.Where(card => card.Extension == filter.Extension));

        }
        #endregion

        #region private methods
        private List<FilterViewModel> GetFilters()
        {
            List<FilterViewModel> filters = [];
            foreach (Extension extension in Enum.GetValues(typeof(Extension)))
            {
                filters.Add(new FilterViewModel(extension, true));
            }
            return filters;
        }

        private void PopulateListOfCards(List<Card> source)
        {
            ListOfCards = new(source);
        }

        private async Task AddItemsOneByOneAsync(IEnumerable<Card> newItems, int delayMilliseconds = 100)
        {
            foreach (var item in newItems)
            {
                ListOfCards.Add(item);
                await Task.Delay(delayMilliseconds);
            }
        }

        private async Task RemoveItemsOneByOneAsync(IEnumerable<Card> itemsToRemove, int delayMilliseconds = 100)
        {
            foreach (var item in itemsToRemove)
            {
                ListOfCards.Remove(item);
                await Task.Delay(delayMilliseconds);
            }
        }
        #endregion
    }
}
