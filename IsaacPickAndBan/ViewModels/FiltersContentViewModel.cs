using CommunityToolkit.Mvvm.ComponentModel;
using IsaacPickAndBan.Models;
using System.Collections.ObjectModel;

namespace IsaacPickAndBan.ViewModels
{
    public partial class FiltersContentViewModel : ObservableObject
    {
        #region constants
        public const int MIN_PLAYERS = 1;
        public const int MAX_PLAYERS = 10;

        public const int MIN_REROLLS = 0;
        public const int MAX_REROLLS = 10;

        public const int MIN_CARDS_TO_DRAW = 1;
        public const int MAX_CARDS_TO_DRAW = 10;

        public const int MIN_HIDDEN_CARDS = 0;
        public const int MIN_BANS = 0;
        #endregion

        #region constructor
        public FiltersContentViewModel()
        {
            Extensions = [.. Enum.GetValues<Extension>().Select(extension => new FilterViewModel(extension, true))];
        }
        #endregion

        #region observable properties
        [ObservableProperty]
        private ObservableCollection<FilterViewModel> extensions;

        [ObservableProperty]
        private int numberOfPlayers = 2;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(MaxHiddenCards))]
        [NotifyPropertyChangedFor(nameof(MaxBans))]
        private int numberOfCardsToDraw = 3;
        
        [ObservableProperty]
        private int numberOfRerolls = 1;

        [ObservableProperty]
        private int numberOfHiddenCards = 1;

        [ObservableProperty]
        private int numberOfBans = 1;
        #endregion

        #region properties
        public int MaxHiddenCards => NumberOfCardsToDraw - 1;
        public int MaxBans => NumberOfCardsToDraw - 1;

        public IEnumerable<Extension> SelectedExtensions
            => Extensions.Where(filter => filter.IsActif).Select(filter => filter.Extension);
        #endregion

        #region private methods
        partial void OnNumberOfCardsToDrawChanged(int value)
        {
            if (NumberOfHiddenCards > MaxHiddenCards)
                NumberOfHiddenCards = MaxHiddenCards;

            if (NumberOfBans > MaxBans)
                NumberOfBans = MaxBans;
        }
        #endregion
    }
}
