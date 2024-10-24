using AHD.Models;
using Microsoft.AspNetCore.Components;

namespace AHD.Pages.components
{
    public partial class RealisationCard
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public Realisation Realisation { get; set; } = default!;

        private void NavigateToDetail()
        {
            NavigationManager.NavigateTo($"/realisations/{Realisation.Id}");
        }
    }
}
