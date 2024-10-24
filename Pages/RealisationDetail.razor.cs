using AHD.Models;
using Microsoft.AspNetCore.Components;

namespace AHD.Pages
{
    public partial class RealisationDetail
    {
        [Parameter]
        public string RealisationId { get; set; }

        public Realisation Realisation { get; set; }

        public string SelectedImg { get; set; }

        public string BaseImgUrl { get; set; } = "https://loremflickr.com/200/200?random=";

        protected override void OnInitialized()
        {
            var imageUrls = new List<string>();
            for (int i = 1; i <= 50; i++)
            {
                imageUrls.Add($"{BaseImgUrl}{i}");
            }
            Realisation = new Realisation(1, "Test", "Test description", imageUrls[0], imageUrls);
        }

        private void SelectImg(string img)
        {
            SelectedImg = img;
        }


        private bool IsSelected(string img) => img == SelectedImg;
    }
}
