using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IsaacPickAndBan.Models;
using Microsoft.Maui.Storage;
using System.Text.Json;
using System.Text.Json.Nodes;

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
            string cardsJson = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "cards.json");
            ListOfCards = JsonSerializer.Deserialize<List<Card>>(cardsJson);
        }
    }
}
