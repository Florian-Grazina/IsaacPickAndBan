using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IsaacPickAndBan.Models;

namespace IsaacPickAndBan.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        // properties
        public List<Card> ListOfCards { get; set; }

        [ObservableProperty]
        public bool isFocused = false;

        [ObservableProperty]
        public Card focusedCard;


        // constructor
        public MainViewModel()
        {
            InitMainPage();
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

        public void InitMainPage()
        {
            ListOfCards = new List<Card>()
            {
                new Card(1, "isaac", Extension.b2, "the_d6"),
                new Card(2, "maggy", Extension.b2, "yum_heart"),
                new Card(3, "cain", Extension.b2, "sleight_of_hand"),
                new Card(4, "judas", Extension.b2, "book_of_belial"),
                new Card(5, "isaac", Extension.b2, "the_d6"),
                new Card(6, "maggy", Extension.b2, "yum_heart"),
                new Card(7, "cain", Extension.b2, "sleight_of_hand"),
                new Card(8, "judas", Extension.b2, "book_of_belial"),
                new Card(9, "isaac", Extension.b2, "the_d6"),
                new Card(10, "maggy", Extension.b2, "yum_heart"),
                new Card(11, "cain", Extension.b2, "sleight_of_hand"),
                new Card(12, "judas", Extension.b2, "book_of_belial"),
                new Card(13, "isaac", Extension.b2, "the_d6"),
                new Card(14, "maggy", Extension.b2, "yum_heart"),
                new Card(15, "cain", Extension.b2, "sleight_of_hand"),
                new Card(16, "judas", Extension.b2, "book_of_belial"),
                new Card(17, "isaac", Extension.b2, "the_d6"),
                new Card(18, "maggy", Extension.b2, "yum_heart"),
                new Card(19, "cain", Extension.b2, "sleight_of_hand"),
                new Card(20, "judas", Extension.b2, "book_of_belial"),
                new Card(21, "isaac", Extension.b2, "the_d6"),
                new Card(22, "maggy", Extension.b2, "yum_heart"),
                new Card(23, "cain", Extension.b2, "sleight_of_hand"),
                new Card(24, "judas", Extension.b2, "book_of_belial"),
                new Card(25, "isaac", Extension.b2, "the_d6"),
                new Card(26, "maggy", Extension.b2, "yum_heart"),
                new Card(27, "cain", Extension.b2, "sleight_of_hand"),
                new Card(28, "judas", Extension.b2, "book_of_belial"),
                new Card(29, "isaac", Extension.b2, "the_d6"),
                new Card(30, "maggy", Extension.b2, "yum_heart"),
                new Card(31, "cain", Extension.b2, "sleight_of_hand"),
                new Card(32, "judas", Extension.b2, "book_of_belial"),
                new Card(33, "isaac", Extension.b2, "the_d6"),
                new Card(34, "maggy", Extension.b2, "yum_heart"),
                new Card(35, "cain", Extension.b2, "sleight_of_hand"),
                new Card(36, "judas", Extension.b2, "book_of_belial")
            };
        }
    }
}
