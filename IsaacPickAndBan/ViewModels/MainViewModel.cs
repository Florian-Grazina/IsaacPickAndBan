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

        private void ApplyFilters()
        {
        }
        #endregion
    }
}
