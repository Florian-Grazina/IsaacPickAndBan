namespace IsaacPickAndBan.Models
{
    public class Card
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Extension Extension { get; set; }
        public string Image { get; set; }
        public string Ethernal { get; set; }


        public Card(int id, string name, Extension extension, string ethernal)
        {
            Id = id;
            Name = name;
            Extension = extension;
            Image = $"{extension}_{name}.png";
            Ethernal = $"{ethernal}_{name}.png";
        }
    }
}
