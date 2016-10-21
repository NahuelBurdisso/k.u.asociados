$(document).ready(function () {
    $('#fullpage').fullpage({
        menu: '#menu',
        scrollingSpeed: 1000,
        controlArrows: false,
        responsiveSlides: true,
        loopBottom: true,
        fadingEffect: true,
        navigation: true,
        slidesNavigation: true,
        navigationTooltips: ['Presentación', 'Funciones','Nuestra Misión','Nuestra Visión'],
    });

    // init Isotope
    var $grid = $('.grid-isotope').isotope({
        // options
    });
    // filter items on button click
    $('.filter-button-group').on('click', 'button', function () {
        var filterValue = $(this).attr('data-filter');
        $grid.isotope({ filter: filterValue });
    });

    // owl carousel
    $('.owl-carousel').owlCarousel({
        items: 1,
    });
});