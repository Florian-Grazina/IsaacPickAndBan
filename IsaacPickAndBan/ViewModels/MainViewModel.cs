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
            CardWidth = DeviceDisplay.MainDisplayInfo.Width / DeviceDisplay.MainDisplayInfo.Density / 3;
            Filters = GetFilters();
        }
        #endregion

        #region observable properties
        [ObservableProperty]
        public List<Card> listOfCards;

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

        [ObservableProperty]
        private double cardWidth;

        private string searchEntry = string.Empty;

        public string SearchEntry
        {
            get => searchEntry;
            set
            {
                searchEntry = value;
                ApplyFilters();
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
        private void ToggleFilter(FilterViewModel filter)
        {
            filter.IsActif = !filter.IsActif;
            ApplyFilters();
        }
        #endregion

        #region private methods
        private List<FilterViewModel> GetFilters()
        {
            List<FilterViewModel> filters = [];
            foreach(Extension extension in Enum.GetValues(typeof(Extension)))
            {
                filters.Add(new FilterViewModel(extension, true));
            }
            return filters;
        }

        private void PopulateListOfCards(List<Card> source)
        {
            ListOfCards = source;
        }

        private void ApplyFilters()
       {
            List<Extension> activeExtensions = Filters.Where(f => f.IsActif).Select(f => f.Extension).ToList();
            List<Card> filteredCards = Data.ListOfCards.Where(c => activeExtensions.Contains(c.Extension)).ToList();

            if(!string.IsNullOrEmpty(searchEntry))
                ListOfCards = new(filteredCards.Where(c => searchEntry.Contains(c.Name)));

            //PopulateListOfCards(filteredCards);
        }
        #endregion
    }
}
