using IsaacPickAndBan.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace IsaacPickAndBan.Database
{
    public static class Data
    {
        public static List<Card> ListOfCards { get; set; }

        public static async Task InitDatabase()
        {
            using Stream stream = await FileSystem.OpenAppPackageFileAsync("cards.json");
            using StreamReader reader = new(stream);
            string jsonText = reader.ReadToEnd();


            JsonSerializerOptions options = new()
            {
                Converters = { new JsonStringEnumConverter() }
            };

            ListOfCards = JsonSerializer.Deserialize<List<Card>>(jsonText, options);

            foreach (var card in ListOfCards)
            {
                card.GenerateImage();
            }
        }
    }
}
