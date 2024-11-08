namespace IsaacPickAndBan.Models
{
    public class Card
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Extension Extension { get; set; }
        public string Ethernal { get; set; }
        public string MainImage { get; set; }
        public string EthernalImage { get; set; }


        public void GenerateImage()
        {
            MainImage = $"Cards/{Extension}_{Name}.png";
            EthernalImage = $"Cards/{Extension}_{Ethernal}.png";
        }
    }
}
