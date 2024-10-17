window.blazorDetectScroll = (element) => {
    if (!element) return { canScrollLeft: false, canScrollRight: false };

    const canScrollLeft = element.scrollLeft > 0;
    const canScrollRight = element.scrollLeft + element.clientWidth < element.scrollWidth;

    return { canScrollLeft, canScrollRight };
};
