window.blazorScrollTo = (carouselElement, scrollPosition) => {
    carouselElement.scrollTo({
        left: scrollPosition,
        behavior: 'smooth'
    });
};

