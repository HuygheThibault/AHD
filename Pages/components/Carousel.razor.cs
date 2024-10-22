using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace AHD.Pages.components
{
    public partial class Carousel<TItem> : ComponentBase
    {
        [Inject] private IJSRuntime JSRuntime { get; set; }

        [Parameter] public RenderFragment<TItem> ItemTemplate { get; set; }
        [Parameter] public List<TItem> Items { get; set; } = new List<TItem>();
        [Parameter] public EventCallback<TItem> OnSelect { get; set; } // Triggers when clicking on an item in the carrousel
        [Parameter] public int ScrollAmount { get; set; } = 200;

        private ElementReference carouselListRef;
        private int activeIndex = 0;

        protected override void OnParametersSet()
        {
            if (ItemTemplate == null)
            {
                throw new ArgumentNullException(nameof(ItemTemplate), "ItemTemplate must be provided.");
            }
        }

        private async Task ScrollLeft()
        {
            activeIndex = (activeIndex == 0) ? Items.Count - 1 : activeIndex - 1;
            await ScrollToActiveIndexAsync();
        }

        private async Task ScrollRight()
        {
            activeIndex = (activeIndex == Items.Count - 1) ? 0 : activeIndex + 1;
            await ScrollToActiveIndexAsync();
        }

        private async Task ScrollToIndex(int index)
        {
            activeIndex = index;
            await ScrollToActiveIndexAsync();
        }

        private async Task ScrollToActiveIndexAsync()
        {
            var scrollPosition = activeIndex * ScrollAmount;
            await SelectItemAsync(activeIndex);
            await JSRuntime.InvokeVoidAsync("blazorScrollTo", carouselListRef, scrollPosition);
        }

        private async Task SelectItemAsync(int index)
        {
            activeIndex = index;
            await OnSelect.InvokeAsync(Items[index]);
        }

        private async Task SelectItem(TItem item)
        {
            var index = Items.IndexOf(item);
            if (index >= 0)
            {
                await SelectItemAsync(index);
            }
        }
    }
}
