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
        public const int DEFAULT_PLAYERS = 2;

        public const int MIN_REROLLS = 0;
        public const int MAX_REROLLS = 10;
        public const int DEFAULT_REROLLS = 1;

        public const int MIN_CARDS_TO_DRAW = 1;
        public const int MAX_CARDS_TO_DRAW = 10;
        public const int DEFAULT_CARDS_TO_DRAW = 3;

        public const int MIN_HIDDEN_CARDS = 0;
        public const int DEFAULT_HIDDEN_CARDS = 1;

        public const int MIN_BANS = 0;
        public const int DEFAULT_BANS = 1;
        #endregion

        #region constructor
        public FiltersContentViewModel()
        {
            Extensions = [.. Enum.GetValues<Extension>().Select(extension => new ExtensionFilterViewModel(extension, true))];
            NumberOfPlayers = DEFAULT_PLAYERS;
            NumberOfCardsToDraw = DEFAULT_CARDS_TO_DRAW;
            NumberOfRerolls = DEFAULT_REROLLS;
            NumberOfHiddenCards = DEFAULT_HIDDEN_CARDS;
            NumberOfBans = DEFAULT_BANS;
        }
        #endregion

        #region observable properties
        [ObservableProperty]
        private ObservableCollection<ExtensionFilterViewModel> extensions;

        private int numberOfPlayers;
        public int NumberOfPlayers
        {
            get => numberOfPlayers;
            set
            {
                numberOfPlayers = Math.Clamp(value, MIN_PLAYERS, MAX_PLAYERS);
                OnPropertyChanged(nameof(NumberOfPlayers));
            }
        }

        private int numberOfCardsToDraw;
        public int NumberOfCardsToDraw
        {
            get => numberOfCardsToDraw;
            set
            {
                numberOfCardsToDraw = Math.Clamp(value, MIN_CARDS_TO_DRAW, MAX_CARDS_TO_DRAW);
                OnPropertyChanged(nameof(NumberOfCardsToDraw));
                HandleSetNumberOfCardsToDraw(NumberOfCardsToDraw);
            }
        }

        private int numberOfRerolls;
        public int NumberOfRerolls
        {
            get => numberOfRerolls;
            set
            {
                numberOfRerolls = Math.Clamp(value, MIN_REROLLS, MAX_REROLLS);
                OnPropertyChanged(nameof(NumberOfRerolls));
            }
        }

        private int numberOfHiddenCards;
        public int NumberOfHiddenCards
        {
            get => numberOfHiddenCards;
            set
            {
                numberOfHiddenCards = Math.Clamp(value, MIN_HIDDEN_CARDS, MaxHiddenCards);
                OnPropertyChanged(nameof(NumberOfHiddenCards));
            }
        }

        private int numberOfBans;
        public int NumberOfBans
        {
            get => numberOfBans;
            set
            {
                numberOfBans = Math.Clamp(value, MIN_BANS, MaxBans);
                OnPropertyChanged(nameof(NumberOfBans));
            }
        }
        #endregion

        #region properties
        public int MaxHiddenCards => NumberOfCardsToDraw - 1;
        public int MaxBans => NumberOfCardsToDraw - 1;

        public IEnumerable<Extension> SelectedExtensions
            => Extensions.Where(filter => filter.IsActif).Select(filter => filter.Extension);
        #endregion

        #region private methods
        private void HandleSetNumberOfCardsToDraw(int value)
        {
            if (NumberOfHiddenCards > MaxHiddenCards)
                NumberOfHiddenCards = MaxHiddenCards;

            if (NumberOfBans > MaxBans)
                NumberOfBans = MaxBans;
        }
        #endregion
    }
}
