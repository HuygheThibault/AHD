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
        private bool canScrollLeft;
        private bool canScrollRight;
        private CancellationTokenSource debounceCancellationTokenSource;

        protected override void OnParametersSet()
        {
            if (ItemTemplate == null)
            {
                throw new ArgumentNullException(nameof(ItemTemplate), "ItemTemplate must be provided.");
            }
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await DetectScroll();
            }
        }

        private void UpdateScrollStates(ScrollInfo scrollInfo)
        {
            canScrollLeft = scrollInfo.CanScrollLeft;
            canScrollRight = scrollInfo.CanScrollRight;
            StateHasChanged();
        }

        private async Task DetectScroll()
        {
            var scrollInfo = await JSRuntime.InvokeAsync<ScrollInfo>("blazorDetectScroll", carouselListRef);
            UpdateScrollStates(scrollInfo);
        }

        private async Task ScrollLeft()
        {
            await JSRuntime.InvokeVoidAsync("blazorScroll", carouselListRef, -ScrollAmount);
            DebounceDetectScroll();
        }

        private async Task ScrollRight()
        {
            await JSRuntime.InvokeVoidAsync("blazorScroll", carouselListRef, ScrollAmount);
            DebounceDetectScroll();
        }

        private void DebounceDetectScroll()
        {
            debounceCancellationTokenSource?.Cancel();
            debounceCancellationTokenSource = new CancellationTokenSource();

            _ = Task.Delay(200, debounceCancellationTokenSource.Token).ContinueWith(async t =>
            {
                if (!t.IsCanceled)
                {
                    await DetectScroll();
                }
            });
        }

        private void SelectItem(TItem item)
        {
            OnSelect.InvokeAsync(item);
        }

        private class ScrollInfo
        {
            public bool CanScrollLeft { get; set; }
            public bool CanScrollRight { get; set; }
        }
    }
}
