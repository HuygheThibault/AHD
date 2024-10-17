window.blazorScroll = function (element, scrollAmount) {
    element.scrollBy({
        left: scrollAmount,
        behavior: 'smooth' // Ensures smooth scrolling
    });
};
