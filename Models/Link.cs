namespace AHD.Models
{
    public class Link
    {
        public string Text { get; set; }
        public string Url { get; set; }

        public Link(string text, string url)
        {
            Text = text;
            Url = url;
        }
    }
}