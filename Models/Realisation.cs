namespace AHD.Models
{
    public class Realisation
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string MainImageUrl { get; set; }

        public List<string> ImageUrls { get; set; }

        public Realisation(int id, string name, string description, string mainImageUrl, List<string> imageUrls)
        {
            Id = id;
            Name = name;
            Description = description;
            MainImageUrl = mainImageUrl;
            ImageUrls = imageUrls;
        }
    }
}
