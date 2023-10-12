namespace IsaacPickAndBan.Models
{
    public class Card
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Extension { get; set; }
        public string Ethernal { get; set; }
        public string MainImage { get; set; }
        public string EthernalImage { get; set; }


        public void GenerateImage()
        {
            MainImage = $"{Extension}_{Name}.png";
            EthernalImage = $"{Extension}_{Ethernal}.png";
        }
    }
}
