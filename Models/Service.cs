namespace AHD.Models
{
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string DetailsImageUrl { get; set; }
        public string Description { get; set; }
        public List<Link> Links { get; set; }

        public Service(int id, string name, string imageUrl, string detailsImageUrl, string description, List<Link> links)
        {
            Id = id;
            Name = name;
            ImageUrl = imageUrl;
            DetailsImageUrl = detailsImageUrl;
            Description = description;
            Links = links;
        }
    }
}

