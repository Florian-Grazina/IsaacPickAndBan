namespace IsaacPickAndBan.Models
{
    public class Card
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Extension { get; set; }
        public string Image { get; set; }
        public string Ethernal { get; set; }


        public Card(int id, string name, string extension, string ethernal)
        {
            Id = id;
            Name = name;
            Extension = extension;
            Image = $"{extension}_{name}.png";
            Ethernal = $"{extension}_{ethernal}.png";
        }
    }
}
