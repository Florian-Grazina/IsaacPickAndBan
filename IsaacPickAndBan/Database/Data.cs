using IsaacPickAndBan.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace IsaacPickAndBan.Database
{
    public class Data
    {
        public List<Card> ListOfCards { get; private set; } = [];

        public async Task InitializeAsync()
        {
            using Stream stream = await FileSystem.OpenAppPackageFileAsync("cards.json");
            using StreamReader reader = new(stream);
            string jsonText = await reader.ReadToEndAsync();

            JsonSerializerOptions options = new()
            {
                Converters = { new JsonStringEnumConverter() }
            };

            var deserializedCards = JsonSerializer.Deserialize<List<Card>>(jsonText, options) ?? new List<Card>();

            foreach (var card in deserializedCards)
            {
                card.GenerateImage();
                ListOfCards.Add(card);
            }
        }
    }
}
