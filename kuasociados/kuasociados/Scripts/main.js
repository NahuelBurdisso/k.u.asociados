$(document).ready(function () {
    // get ajax
    //$.ajax({
    //    method: GET,
    //    type: "JSON",
    //    url: "Shared/GetNotifications",
    //});

    // full page menu
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
    var carouselCount = 0;
    $(".owl-carousel").each(function () {
        $(this).attr("id", "owl-carousel" + carouselCount);
        $('#owl-carousel' + carouselCount).owlCarousel({
            items: 4,
            // Responsive 
            responsive: true,
            //Pagination
            pagination: false
        });
        carouselCount++;
    });

    // init map

});